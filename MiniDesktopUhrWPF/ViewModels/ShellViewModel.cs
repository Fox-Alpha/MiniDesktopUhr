using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiniDesktopUhrWPF.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private ClockViewModel _clockVM;

        public ShellViewModel(ClockViewModel clockVM)
        {
            _clockVM = clockVM;
            ActivateItem(_clockVM);
        }

    }
}
