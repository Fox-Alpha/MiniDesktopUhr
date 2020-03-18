using Caliburn.Micro;

namespace MiniDesktopUhrWPF.Models
{
    public interface ISettingsModel
        //: INotifyPropertyChangedEx
    {
        void GetAlarmList();
        void GetAlarmSettings();
        void GetClockSettings();
    }
}