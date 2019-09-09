using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiniDesktopUhrWPF.ViewModels
{
    public class ClockViewModel : Screen
    {
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

        public ClockViewModel()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            StrUhrzeit = string.Format(ShowDate ? strWithDate : strWithOutDate, DateTime.Now);
            dispatcherTimer.Start();
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
    }
}
