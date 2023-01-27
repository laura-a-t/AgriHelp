using System;
using System.Linq;
using System.Windows;
using AgriHelp.Database;
using AgriHelp.View;
using AgriHelp.ViewModel;

namespace AgriHelp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Manager _dbManager;
        public MainWindowViewModel ViewModel { get; }
        public MainWindow()
        {
            _dbManager = new Manager();
            _dbManager.Init();
            ViewModel = new MainWindowViewModel(_dbManager.LoadInputs());
            InitializeComponent();

            Closing += (sender, args) => _dbManager.Dispose();
        }

        private void AddInput(object sender, RoutedEventArgs e)
        {
            var existingInputWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(w => w is AddInputWindow);
            if (existingInputWindow != null)
            {
                existingInputWindow.Focus();
                return;
            }

            var inputWindow = new AddInputWindow(_dbManager);
            inputWindow.ViewModel.DataUpdated.Subscribe(RefreshInputs);
            Closing += (o, args) =>
            {
                inputWindow.Close();
            };
            inputWindow.Show();
        }

        private void RefreshInputs(bool _)
        {
            var inputs = _dbManager.LoadInputs();
            ViewModel.RefreshInputs(inputs);
        }
    }
}