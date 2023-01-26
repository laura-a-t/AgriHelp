using System;
using System.Collections.Generic;
using AgriHelp.ViewModel;

namespace AgriHelp.Database
{
    using System.Data.SQLite;
    using System.IO;
    using NLog;

    public class Manager
    {
        private const string TableName = "Inputs";
        private const string DbPath = "database.db";
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();
        private SQLiteConnection _conn;
        
        public void Init()
        {
            if (!File.Exists(DbPath))
            {
                _conn = new SQLiteConnection($"Data Source={DbPath};Version=3;New=True;");
                _conn.Open();
                CreateTable(_conn);
            }
            else
            {
                _conn = new SQLiteConnection($"Data Source={DbPath};Version=3;");
                _conn.Open();
            }
        }

        public void Dispose()
        {
            _conn.Close();
        }

        public List<InputRowViewModel> LoadInputs()
        {
            var inputs = new List<InputRowViewModel>();
            var selectSql = $"SELECT crop_type, qty_seed, soil_type, qty_nitrate, qty_phosphorus, qty_potassium, qty_microelements FROM {TableName}";
            var cmd = _conn.CreateCommand();
            cmd.CommandText = selectSql;
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                inputs.Add(new InputRowViewModel(
                    reader.GetString(0),
                    reader.GetDouble(1),
                    reader.GetString(2),
                    reader.GetDouble(3),
                    reader.GetDouble(4),
                    reader.GetDouble(5),
                    reader.GetDouble(6)));
            }

            return inputs;
        }

        public void InsertInputs(string cropType, double qtySeed, string soilType, double qtyNitrate, double qtyPhosphorus, double qtyPotassium, double qtyMicroelements)
        {
            var insertSql = $"INSERT INTO {TableName} (crop_type, qty_seed, soil_type, qty_nitrate, qty_phosphorus, qty_potassium, qty_microelements) " +
                            $"VALUES ('{cropType}', {qtySeed}, '{soilType}', {qtyNitrate}, {qtyPhosphorus}, {qtyPotassium}, {qtyMicroelements});";
            var cmd = _conn.CreateCommand();
            cmd.CommandText = insertSql;
            cmd.ExecuteNonQuery();
        }
        
        private void CreateTable(SQLiteConnection conn)
        {
            var createSql = $"CREATE TABLE {TableName} (crop_type VARCHAR(20), qty_seed NUMERIC DEFAULT 0, soil_type VARCHAR(20), qty_nitrate NUMERIC DEFAULT 0, qty_phosphorus NUMERIC DEFAULT 0, qty_potassium NUMERIC DEFAULT 0, qty_microelements NUMERIC DEFAULT 0)";
            var cmd = conn.CreateCommand();
            cmd.CommandText = createSql;
            cmd.ExecuteNonQuery();
        }
    }
}