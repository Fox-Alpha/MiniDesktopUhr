using Caliburn.Micro;
using MiniDesktopUhrWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDesktopUhrWPF.ViewModels
{
    public class SettingsViewModel : Screen
    {
        private readonly ISettingsModel _settingsModel;
        private readonly SimpleContainer _container;

        public SettingsViewModel(SimpleContainer container)
        {
            this._container = container;

            _settingsModel = container.GetInstance<ISettingsModel>();
        }
    }
}
