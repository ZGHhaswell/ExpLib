using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Microsoft.Practices.Prism.ViewModel;

namespace Wizard.ViewModels
{
    public class MainViewModel : NotificationObject
    {
        private ControlAViewModel _controlAViewModel;
        public ControlAViewModel ControlAViewModel
        {
            get
            {
                return _controlAViewModel;
            }
            set
            {
                _controlAViewModel = value;
                RaisePropertyChanged("ControlAViewModel");
            }
        }

        private Visibility _aVisibility;
        public Visibility AVisibility
        {
            get
            {
                return _aVisibility;
            }
            set
            {
                _aVisibility = value;
                RaisePropertyChanged("AVisibility");
            }
        }


        private ControlBViewModel _controlBViewModel;
        public ControlBViewModel ControlBViewModel
        {
            get
            {
                return _controlBViewModel;
            }
            set
            {
                _controlBViewModel = value;
                RaisePropertyChanged("ControlBViewModel");
            }
        }

        private Visibility _bVisibility;
        public Visibility BVisibility
        {
            get
            {
                return _bVisibility;
            }
            set
            {
                _bVisibility = value;
                RaisePropertyChanged("BVisibility");
            }
        }

        private ControlCViewModel _controlCViewModel;
        public ControlCViewModel ControlCViewModel
        {
            get
            {
                return _controlCViewModel;
            }
            set
            {
                _controlCViewModel = value;
                RaisePropertyChanged("ControlCViewModel");
            }
        }

        private Visibility _cVisibility;
        public Visibility CVisibility
        {
            get
            {
                return _cVisibility;
            }
            set
            {
                _cVisibility = value;
                RaisePropertyChanged("CVisibility");
            }
        }

        

        public MainViewModel()
        {
            ControlAViewModel = new ControlAViewModel();
            ControlBViewModel = new ControlBViewModel();
            ControlCViewModel = new ControlCViewModel();

            AVisibility = Visibility.Visible;
            BVisibility = Visibility.Hidden;
            CVisibility = Visibility.Hidden;

            ControlAViewModel.EndEvent += () =>
            {
                AVisibility = Visibility.Hidden;
                BVisibility = Visibility.Visible;
                CVisibility = Visibility.Hidden;
            };

            ControlBViewModel.EndEvent += () =>
            {
                AVisibility = Visibility.Hidden;
                BVisibility = Visibility.Hidden;
                CVisibility = Visibility.Visible;
            };
        }
    }
}
