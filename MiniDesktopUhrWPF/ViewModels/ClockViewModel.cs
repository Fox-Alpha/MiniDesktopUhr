using Caliburn.Micro;
using MiniDesktopUhrWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MiniDesktopUhrWPF.ViewModels
{
    public class ClockViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private bool _ShowDate = false;
        public bool ShowDate
        {
            get { return _ShowDate; }
            set
            {
                _ShowDate = value;
                NotifyOfPropertyChange(() => ShowDate);
            }
        }

        const string strWithDate = "{0:dddd dd MMM, HH:mm:ss}";
        const string strWithOutDate = "{0:HH:mm:ss}";

        private string _strUhrzeit = "";
        public string StrUhrzeit
        {
            get { return _strUhrzeit; }
            set
            {
                _strUhrzeit = value;
                NotifyOfPropertyChange(() => StrUhrzeit);
            }
        }

        private System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public ClockViewModel(SimpleContainer container)
        {
            _container = container;

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            StrUhrzeit = string.Format(ShowDate ? strWithDate : strWithOutDate, DateTime.Now);
            dispatcherTimer.Start();
        }

        public ClockViewModel()
        {
        }

        void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            StrUhrzeit = string.Format(ShowDate ? strWithDate : strWithOutDate, DateTime.Now);
        }

        public void AppExit()
        {
            Application.Current.Shutdown();
        }

        public void ShowStringDate()
        {
            ShowDate = !ShowDate;
        }

        public async void  OpenOptions()
        {
            SettingsViewModel setting = _container.GetInstance<SettingsViewModel>();
            IWindowManager windowManager = _container.GetInstance<IWindowManager>();

            // Assumes that there is a NewDialogView...
            bool? result = await windowManager.ShowDialogAsync(setting);
            // result is true if user pressed ok button...
        }

        public void DisplayMonitorInfo()
        {
            IMonitorModel monitorModel = _container.GetInstance<IMonitorModel>();
            string primary = "(*P)";

            foreach (var scr in monitorModel.Screens)
            {
                System.Diagnostics.Debug.WriteLine($"{(scr.Primary ? primary : "")} {scr.DeviceName}: ({scr.Bounds.Height} * {scr.Bounds.Width})");
            }

        }
    }
}
