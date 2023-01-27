using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;

namespace AgriHelp.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<InputRowViewModel> Inputs { get; } = new ObservableCollection<InputRowViewModel>();

        public MainWindowViewModel(List<InputRowViewModel> inputs)
        {
            RefreshInputs(inputs);
        }

        public void RefreshInputs(List<InputRowViewModel> inputs)
        {
            Inputs.Clear();
            foreach (var input in inputs)
            {
                Inputs.Add(input);
            }
        }
    }
}