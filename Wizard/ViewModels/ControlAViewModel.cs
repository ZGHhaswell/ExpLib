using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace Wizard.ViewModels
{
    public class ControlAViewModel : NotificationObject, INextable
    {
        public event Action EndEvent;


        public System.Windows.Input.ICommand NextCommand { get; set; }

        private void NextCommandExecute()
        {
            EndEvent();
        }

        public ControlAViewModel()
        {
            NextCommand = new DelegateCommand(NextCommandExecute);
        }

    }
}
