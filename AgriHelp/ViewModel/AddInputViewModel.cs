using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using AgriHelp.Database;
using DevExpress.Mvvm;

namespace AgriHelp.ViewModel
{
    public class AddInputViewModel : ViewModelBase
    {
        private readonly Manager _dbManager;
        private readonly Subject<bool> _dataUpdated = new Subject<bool>();

        public IObservable<bool> DataUpdated => _dataUpdated;
        public List<string> AvailableCrops { get; }

        private string _selectedCrop;

        public string SelectedCrop
        {
            get => _selectedCrop;
            set
            {
                SetValue(ref _selectedCrop, value);
                RaisePropertyChanged(nameof(SeedQtyLabel));
            }
        }

        private double _seedQty;

        public double SeedQty
        {
            get => _seedQty;
            set => SetValue(ref _seedQty, value);
        }
        
        public List<string> SoilTypes { get; }

        private string _selectedSoilType;

        public string SelectedSoilType
        {
            get => _selectedSoilType;
            set => SetValue(ref _selectedSoilType, value);
        }
        
        public string SeedQtyLabel => "Cantitate samanta " + (string.IsNullOrEmpty(SelectedCrop) ? string.Empty : $"de {SelectedCrop} ") + "kg/ha";

        private double _qtyN;

        public double QtyN
        {
            get => _qtyN;
            set => SetValue(ref _qtyN, value);
        }

        private double _qtyP;

        public double QtyP
        {
            get => _qtyP;
            set => SetValue(ref _qtyP, value);
        }

        private double _qtyK;

        public double QtyK
        {
            get => _qtyK;
            set => SetValue(ref _qtyK, value);
        }

        private double _qtyMicroelements;

        public double QtyMicroelements
        {
            get => _qtyMicroelements;
            set => SetValue(ref _qtyMicroelements, value);
        }
        
        public AddInputViewModel(Manager dbManager)
        {
            AvailableCrops = new List<string> { "Porumb", "Grau", "Orz" };
            SoilTypes = new List<string> { "Acid", "Neutru", "Alcalin" };
            _dbManager = dbManager;
        }

        public void Save()
        {
            _dbManager.InsertInputs(SelectedCrop, SeedQty, SelectedSoilType, QtyN, QtyP, QtyK, QtyMicroelements);
            _dataUpdated.OnNext(true);
        }
    }
}