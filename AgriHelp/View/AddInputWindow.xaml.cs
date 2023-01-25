using AgriHelp.ViewModel;

namespace AgriHelp.View
{
    public partial class AddInputWindow
    {
        public AddInputViewModel ViewModel { get; }
        public AddInputWindow()
        {
            ViewModel = new AddInputViewModel();
            InitializeComponent();
        }
    }
}