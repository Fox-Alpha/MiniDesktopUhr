using MiniDesktopUhrWPF.Helper;

namespace MiniDesktopUhrWPF.Models
{
    public interface IMonitorModel
    {
        Helper.Screen[] Screens { get; set; }

        Helper.Screen GetPrimaryScreen();
        int GetPrimaryScreenIndex();
    }
}