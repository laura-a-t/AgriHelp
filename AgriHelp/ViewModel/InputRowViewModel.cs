using CommunityToolkit.Mvvm.ComponentModel;

namespace AgriHelp.ViewModel
{
    public class InputRowViewModel : ObservableObject
    {
        public string CropType { get; }
        
        public double SeedQty { get; }
        
        public string SoilType { get; }
        
        public double QtyN { get; }
        
        public double QtyP { get; }
        
        public double QtyK { get; }
        
        public double QtyMicroelements { get; }

        public InputRowViewModel(string cropType, double seedQty, string soilType, double qtyNitrate, double qtyPhosphorus, double qtyPotassium, double qtyMicroelements)
        {
            CropType = cropType;
            SeedQty = seedQty;
            SoilType = soilType;
            QtyN = qtyNitrate;
            QtyP = qtyPhosphorus;
            QtyK = qtyPotassium;
            QtyMicroelements = qtyMicroelements;
        }
    }
}