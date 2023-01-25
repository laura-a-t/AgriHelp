using System.Windows;
using AgriHelp.View;
using AgriHelp.ViewModel;

namespace AgriHelp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindowViewModel ViewModel { get; }
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();
        }

        private void AddInput(object sender, RoutedEventArgs e)
        {
            var inputWindow = new AddInputWindow();
            inputWindow.Show();
        }
    }
}