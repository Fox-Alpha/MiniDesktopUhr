using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Caliburn.Micro;
using System.ComponentModel;

namespace MiniDesktopUhrWPF.Models
{
    public enum WeekDays
    {
        [EnumMember(Value = "montag")]
        Monday,
        [EnumMember(Value = "dienstag")]
        Thuesday,
        [EnumMember(Value = "mittwoch")]
        Wednesday,
        [EnumMember(Value = "donnerstag")]
        Thursday,
        [EnumMember(Value = "freitag")]
        Friday,
        [EnumMember(Value = "samstag")]
        Saturday,
        [EnumMember(Value = "sontag")]
        Sunday
    }

    public enum DisplayEdge
    {
        [EnumMember(Value = "TopLeft")]
        TopLeft,
        [EnumMember(Value = "TopRight")]
        TopRight,
        [EnumMember(Value = "BottomLeft")]
        BottomLeft,
        [EnumMember(Value = "BottomRight")]
        BottomRight
    }

    public class SettingsModel : PropertyChangedBase, ISettingsModel 
    {
        private AppSettings _appSettings;

        //public event PropertyChangedEventHandler PropertyChanged;

        public AppSettings AppSettings
        {
            get { return _appSettings; }
            set { _appSettings = value; }
        }

        //public bool IsNotifying { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SettingsModel()
        {

        }

        public void GetClockSettings()
        {

        }

        public void GetAlarmSettings()
        {

        }

        public void GetAlarmList()
        {

        }

        //public void NotifyOfPropertyChange(string propertyName)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Refresh()
        //{
        //    throw new NotImplementedException();
        //}
    }

    /* Klasse zum einlesen der JSON Konfiguration */
    [JsonObject(MemberSerialization.OptIn)]
    public class AppSettings
    {
        [JsonProperty(PropertyName = "ForeGround", Required = Required.Always)]
        public bool SetForground { get; set; }

        [JsonProperty(PropertyName = "ShowDate", Required = Required.Always)]
        public bool ShowDateText { get; set; }

        [JsonProperty(PropertyName = "Display", Required = Required.Always)]
        public int ActiveDisplay { get; set; }

        [JsonProperty(PropertyName = "DisplayEdge", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DisplayEdge ActiveEdge { get; set; }

        //[JsonProperty(PropertyName = "Alarm", Required = Required.Always)]
        //public List<AlarmSettings> Alarm = new List<AlarmSettings>();

        //[JsonProperty(PropertyName = "ClockText", Required = Required.Always)]
        //public TextSettings ClockText = new TextSettings();
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class AlarmSettings
    {
        [JsonProperty(PropertyName = "TimeHour", Required = Required.Always)]
        public int TimeHour { get; set; }

        [JsonProperty(PropertyName = "TimeMinute", Required = Required.Always)]
        public int TimeMinute { get; set; }

        [JsonProperty(PropertyName = "Repeat", Required = Required.Always)]
        public bool Repeat { get; set; }

        [JsonProperty(PropertyName = "Active", Required = Required.Always)]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "Soundfile", Required = Required.AllowNull)]
        public string SoundFile { get; set; }

        //[JsonProperty(PropertyName = "Color", Required = Required.Always)]
        //public System.Drawing.Color alarmcolor = new System.Drawing.Color();

        [JsonProperty(PropertyName = "DayOfWeek", Required = Required.Always)]
        public Dictionary<String, bool> DayOfWeek = new Dictionary<String, bool>()
        {
            { "Monday", false },
            { "Tuesday", false },
            { "Wednesday", false },
            { "Thursday", false },
            { "Friday", false },
            { "Saturday", false },
            { "Sunday", false } };
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class TextSettings
    {
        

        [JsonProperty(PropertyName = "Font", Required = Required.AllowNull)]
        public Font font = new Font("Arial", 12, GraphicsUnit.Pixel);

        [JsonProperty(PropertyName = "Color", Required = Required.Always)]
        public System.Drawing.Color color = System.Drawing.Color.Black; //new Color ();
    }
}
