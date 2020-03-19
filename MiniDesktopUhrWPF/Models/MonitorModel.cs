using MiniDesktopUhrWPF.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using System.Collections.ObjectModel;

namespace MiniDesktopUhrWPF.Models
{
    public class MonitorModel : IMonitorModel
    {
        //private Screen[] _screens;
        //public Screen[] Screens { get => _screens; set => _screens = value; }
        private BindableCollection<Helper.Screen> _screens;

        public BindableCollection<Helper.Screen> Screens
        {
            get { return _screens; }
            set { _screens = value; }
        }

        public MonitorModel()
        {
            //Screens = Screen.AllScreens.ToArray();
            Screens = new BindableCollection<Helper.Screen>();
            Screens.AddRange(Helper.Screen.AllScreens);
        }

        public int GetPrimaryScreenIndex()
        {
            int activeDisplay = -1;

            foreach (var scr in Helper.Screen.AllScreens)
            {
                if (scr.Primary)
                {
                    activeDisplay = Helper.Screen.AllScreens.ToList().IndexOf(scr);
                    break;
                }
            }

            return activeDisplay;
        }

        public Helper.Screen GetPrimaryScreen()
        {
            return Screens[GetPrimaryScreenIndex()];
        }
    }
}
