using System.Linq;
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
            var existingInputWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(w => w is AddInputWindow);
            if (existingInputWindow != null)
            {
                existingInputWindow.Focus();
                return;
            }

            var inputWindow = new AddInputWindow();
            Closing += (o, args) =>
            {
                inputWindow.Close();
            };
            inputWindow.Show();
        }
    }
}