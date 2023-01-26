using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;

namespace AgriHelp.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<InputRowViewModel> Inputs { get; }

        public MainWindowViewModel(List<InputRowViewModel> inputs)
        {
            Inputs = new ObservableCollection<InputRowViewModel>(inputs);
        }
    }
}