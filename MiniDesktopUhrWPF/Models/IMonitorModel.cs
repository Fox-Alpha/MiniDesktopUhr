using MiniDesktopUhrWPF.Helper;
using Caliburn.Micro;

namespace MiniDesktopUhrWPF.Models
{
    public interface IMonitorModel
    {
        //Helper.Screen[] Screens { get; set; }

        BindableCollection<Helper.Screen> Screens { get; set; }

        Helper.Screen GetPrimaryScreen();
        int GetPrimaryScreenIndex();
    }
}