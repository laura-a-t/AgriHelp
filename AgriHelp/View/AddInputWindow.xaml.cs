using System.Windows;
using AgriHelp.Database;
using AgriHelp.ViewModel;

namespace AgriHelp.View
{
    public partial class AddInputWindow
    {
        public AddInputViewModel ViewModel { get; }
        public AddInputWindow(Manager dbManager)
        {
            ViewModel = new AddInputViewModel(dbManager);
            InitializeComponent();
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
            Close();
        }
    }
}