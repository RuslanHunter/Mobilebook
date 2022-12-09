using Mobilebook.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilebook.Mvvm.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand CallsViewCommand { get; set; }

        public RelayCommand KabinetViewCommand { get; set; }

        public RelayCommand StatsViewCommand { get; set; }

       
        public CallsViewModel CallsVm { get; set; }

        public KabinetViewModel KabVm { get; set; }

        public StatsViewModel StatsVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CallsVm = new CallsViewModel();
            KabVm = new KabinetViewModel();
            StatsVm = new StatsViewModel();
            CurrentView = CallsVm;

            CallsViewCommand = new RelayCommand(o =>
            {
                CurrentView = CallsVm;
            });

            KabinetViewCommand = new RelayCommand(o =>
            {
                CurrentView = KabVm;
            });

            StatsViewCommand = new RelayCommand(o =>
            {
                CurrentView = StatsVm;
            });

        }
    }
}
