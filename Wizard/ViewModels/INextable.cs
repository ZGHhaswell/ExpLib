using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wizard.ViewModels
{
    public interface INextable
    {
        event Action EndEvent;

        ICommand NextCommand { get; set; }
    }
}
