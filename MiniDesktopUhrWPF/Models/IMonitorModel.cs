using MiniDesktopUhrWPF.Helper;

namespace MiniDesktopUhrWPF.Models
{
    public interface IMonitorModel
    {
        Screen[] Screens { get; set; }

        Screen GetPrimaryScreen();
        int GetPrimaryScreenIndex();
    }
}