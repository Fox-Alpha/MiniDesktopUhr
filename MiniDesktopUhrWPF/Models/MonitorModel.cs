using MiniDesktopUhrWPF.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiniDesktopUhrWPF.Models
{
    public class MonitorModel
    {
        private Screen[] _screens;
        public Screen[] Screens { get => _screens; set => _screens = value; }

        public MonitorModel()
        {
            Screens = Screen.AllScreens.ToArray();
        }        

        public int GetPrimaryScreenIndex()
        {
            int activeDisplay = -1;

            foreach (var scr in Screen.AllScreens)
            {
                if (scr.Primary)
                {
                    activeDisplay = Screen.AllScreens.ToList().IndexOf(scr);
                    break;
                }
            }

            return activeDisplay;
        }

        public Screen GetPrimaryScreen()
        {
            return Screens[GetPrimaryScreenIndex()];
        }
    }
}
