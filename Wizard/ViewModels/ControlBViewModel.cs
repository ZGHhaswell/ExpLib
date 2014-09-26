using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace Wizard.ViewModels
{
    public class ControlBViewModel : NotificationObject, INextable
    {
        public event Action EndEvent;


        public System.Windows.Input.ICommand NextCommand { get; set; }

        private void NextCommandExecute()
        {
            EndEvent();
        }

        public ControlBViewModel()
        {
            NextCommand = new DelegateCommand(NextCommandExecute);
        }
    }
}
