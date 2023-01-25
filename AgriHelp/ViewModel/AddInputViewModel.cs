using System.Collections.Generic;
using DevExpress.Mvvm;

namespace AgriHelp.ViewModel
{
    public class AddInputViewModel : ViewModelBase
    {
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
        
        public AddInputViewModel()
        {
            AvailableCrops = new List<string> { "Porumb", "Grau", "Orz" };
            SoilTypes = new List<string> { "Acid", "Neutru", "Alcalin" };
        }
    }
}