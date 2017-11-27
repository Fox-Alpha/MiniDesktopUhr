using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace MiniDesktopUhr
{
    enum DisplayEdge
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

	public partial class Form1 : Form
	{
		bool bShowDate = false;
		const string strWithDate = "{0:dddd dd MMM, HH:mm:ss}";
		const string strWithOutDate = "{0:HH:mm:ss}";
		int activeDisplay = 0;
        DisplayEdge Edge = DisplayEdge.TopLeft;
        AppSettings setting;

        JsonSerializerSettings jsonSerializerSettings;
        JsonSerializer serializer;

        public Form1 ()
		{
			InitializeComponent ();
			foreach (var scr in Screen.AllScreens)
			{
				if (scr.Primary)
				{
					activeDisplay = Screen.AllScreens.ToList ().IndexOf (scr);
					break;
				}
			}

            //	Setzen der Serializer Settings
            jsonSerializerSettings = new JsonSerializerSettings ();
            jsonSerializerSettings.Formatting = Formatting.Indented;
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            jsonSerializerSettings.NullValueHandling = NullValueHandling.Include;
            jsonSerializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
            jsonSerializerSettings.TypeNameHandling = TypeNameHandling.Auto;

            serializer = JsonSerializer.CreateDefault (jsonSerializerSettings);

            setting = new AppSettings ();
            ReadJSonKonfiguration ("settings.json");
		}

        private void ReadJSonKonfiguration (string JSonFile)
        {
            if (!File.Exists (JSonFile))
            {
                Debug.WriteLine ("Fehlende Angabe oder Angegebene Konfiguration ungültig.");
                //WriteToLogFile ("Fehlende Angabe oder Angegebene Konfiguration ungültig.", "");
                string json = JsonConvert.SerializeObject (setting, jsonSerializerSettings);
                Debug.WriteLine (json);
                return;
            }

            //StreamWriter sw = new StreamWriter (@"data\exampleOut.json");
            //JsonWriter writer = new JsonTextWriter (sw);

            using (StreamReader sr = new StreamReader (JSonFile))
            {
                using (JsonReader reader = new JsonTextReader (sr))
                {
                    setting = serializer.Deserialize<AppSettings> (reader);
#if (DEBUG)
                    string output = JsonConvert.SerializeObject (setting, jsonSerializerSettings);
                    Debug.WriteLine (output);
#endif
                }
            }
        }

        public bool WriteJsonKonfiguration (string JSonFile)
        {
            try
            {
                //  Datei wird angelegt, wenn diese nicht existiert
                using (StreamWriter file = File.CreateText (JSonFile))
                {
                    serializer.Serialize (file, setting);

                    string json = JsonConvert.SerializeObject (setting, jsonSerializerSettings);
                    Debug.WriteLine (json);

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine (e.Message, "Error: writeJSON()");
                return false;
            }
            return true;
        }


        private void contextMenuStrip1_Opening (object sender, CancelEventArgs e)
		{
		}

		private void timer_Tick (object sender, EventArgs e)
		{
			//	Setzen der Uhrzeit
			label1.Text = string.Format (bShowDate ? strWithDate : strWithOutDate, DateTime.Now);
			
		}

		private void Form1_Shown (object sender, EventArgs e)
		{
			label1.Text = string.Format (bShowDate ? strWithDate : strWithOutDate, DateTime.Now);
			this.Size = label1.PreferredSize;

			RecalcPosition (activeDisplay);

			AddDisplaysToContextMenu ();

			datumAnzeigenToolStripMenuItem.Checked = bShowDate;

			Screen [] screens = Screen.AllScreens;

			foreach (Screen scr in screens)
			{
				Debug.WriteLine (screens.ToList ().IndexOf (scr));
				Debug.WriteLine (scr.DeviceName);
				Debug.WriteLine (scr.Bounds.Width.ToString() + " " + scr.Bounds.Height.ToString ());
				Debug.WriteLine (scr.WorkingArea);
			}
			
			timer.Enabled = true;
			this.Size = label1.PreferredSize;
		}

		private void AddDisplaysToContextMenu ()
		{
			contextMenuStrip1.Items.Add (new ToolStripSeparator ());
			Screen [] screens = Screen.AllScreens;

			foreach (var scr in screens)
			{
				int index = contextMenuStrip1.Items.Add (
					new ToolStripMenuItem
					{
						Name = "Display_" + screens.ToList ().IndexOf (scr),
						Text = (scr.Primary ? "(P)" : "") + //Ist dies der Primär Bildschirm `?
								(scr.Bounds.Contains (this.Location) ? "*" : "") + // Wird die Form auf diesem Bildschrirm angezeigt ?
								scr.DeviceName + " " + scr.Bounds.Width.ToString () + " " + scr.Bounds.Height.ToString (),  // Breite und Höhe der Auflösung
						Tag = screens.ToList ().IndexOf (scr),
						CheckOnClick = true
					});
				contextMenuStrip1.Items [index].Click += windowNewMenu_Click;
				(contextMenuStrip1.Items [index] as ToolStripMenuItem).Checked = scr.Bounds.Contains (this.Location);
				if ((contextMenuStrip1.Items [index] as ToolStripMenuItem).Checked)
				{
					//activeDisplay = index;
					activeDisplay = (int)(contextMenuStrip1.Items [index] as ToolStripMenuItem).Tag;
				}
			}

		}

		private void windowNewMenu_Click (object sender, EventArgs e)
		{
			//	Setzen der Position auf den ausgewählten Bildschirm
			ToolStripMenuItem mi;
			Screen scr = Screen.AllScreens [0];

			if ((mi = sender as ToolStripMenuItem) != null)
			{
				foreach (ToolStripItem tsmi in contextMenuStrip1.Items)
				{
					if (System.Text.RegularExpressions.Regex.IsMatch (tsmi.Name, "Display_[0-9]"))
					{
						scr = Screen.AllScreens [(int) tsmi.Tag];
						(tsmi as ToolStripMenuItem).Checked = false;
						tsmi.Text = (scr.Primary ? "(P)" : "") + //Ist dies der Primär Bildschirm `?
							scr.DeviceName + " " + scr.Bounds.Width.ToString () + " " + scr.Bounds.Height.ToString ();
					}
				}

				mi.Checked = true;
				activeDisplay = (int) mi.Tag;
				scr = Screen.AllScreens [activeDisplay];
				RecalcPosition (activeDisplay, Edge);

				mi.Text = (scr.Primary ? "(P)" : "") + //Ist dies der Primär Bildschirm `?
								(scr.Bounds.Contains (this.Location) ? "*" : "") + // Wird die Form auf diesem Bildschrirm angezeigt ?
								scr.DeviceName + " " + scr.Bounds.Width.ToString () + " " + scr.Bounds.Height.ToString ();

			}
		}

		private void Form1_FormClosing (object sender, FormClosingEventArgs e)
		{
			timer.Enabled = false;
            setting.ActiveDisplay = activeDisplay;
            setting.ActiveEdge = (int) Edge;
            setting.SetForground = this.TopMost;
            setting.ClockText.color = label1.ForeColor;
            setting.ClockText.font = label1.Font;


            //Test Alarm
            setting.Alarm.Add (new AlarmSettings () { TimeHour = 16, TimeMinute = 25, Active = true, alarmcolor = Color.AliceBlue, Repeat = false });

            WriteJsonKonfiguration ("settings.json");
        }

		private void immerImFordergrundToolStripMenuItem_Click (object sender, EventArgs e)
		{
			this.TopMost = immerImFordergrundToolStripMenuItem.Checked;
		}

		private void beendenToolStripMenuItem_Click (object sender, EventArgs e)
		{
			Application.Exit ();
		}

		private void datumAnzeigenToolStripMenuItem_Click (object sender, EventArgs e)
		{
			bShowDate = datumAnzeigenToolStripMenuItem.Checked;
			label1.Text = string.Format (bShowDate ? strWithDate : strWithOutDate, DateTime.Now);
			this.Size = label1.PreferredSize;

			RecalcPosition (activeDisplay, Edge);
            //RecalcPosButtuns ();
        }

		private void schriftAnpassenToolStripMenuItem_Click (object sender, EventArgs e)
		{
			//	Dialog zur Font Auswahl
			// Show the dialog.
			FontDialog fd = new FontDialog ();
			ColorDialog cd = new ColorDialog ();

			cd.Color = label1.ForeColor;
			DialogResult result = fd.ShowDialog ();
			// See if OK was pressed.
			if (result == DialogResult.OK)
			{
				// Get Font.
				Font font = fd.Font;
				// Set TextBox properties.
				//this.label1.Text = string.Format ("Font: {0}", font.Name);
				this.label1.Font = font;

				result = cd.ShowDialog ();
				// See if OK was pressed.
				if (result == DialogResult.OK)
				{
					this.label1.ForeColor = cd.Color;
				}
				label1.Text = string.Format (bShowDate ? strWithDate : strWithOutDate, DateTime.Now);
				this.Size = label1.PreferredSize;

				RecalcPosition (activeDisplay, Edge);
                //RecalcPosButtuns ();

            }
		}

		private void RecalcPosition (int scrIdx, DisplayEdge pos=DisplayEdge.TopLeft)
		{
			//this.Location = new Point (Screen.AllScreens[scrIdx].WorkingArea.Width - this.Width - 5, Screen.AllScreens [scrIdx].WorkingArea.Height - this.Height - 5);
			//this.Focus ();

			Point disPosTopLeft = new Point ();
			Point FrmLoc = new Point ();

			Rectangle disRect = new Rectangle ();

            disRect = Screen.AllScreens [scrIdx].WorkingArea;
            disPosTopLeft.X = disRect.X;
            disPosTopLeft.Y = disRect.Y;

            switch (pos)
            {
                case DisplayEdge.TopLeft:
                    FrmLoc.X = disRect.X + 5;
                    FrmLoc.Y = 0 + 5;
                    break;

                case DisplayEdge.TopRight:
                    FrmLoc.X = disRect.X + disRect.Width - this.Width - 5;
                    FrmLoc.Y = 0 + 5;
                    break;

                case DisplayEdge.BottomLeft:
                    FrmLoc.X = disRect.X + 5;
                    FrmLoc.Y = disRect.Y + disRect.Height - this.Height - 5;
                    break;

                case DisplayEdge.BottomRight:
                    FrmLoc.X = disRect.X + disRect.Width - this.Width - 5;
                    FrmLoc.Y = disRect.Y + disRect.Height - this.Height - 5;
                    break;
            }

            Edge = pos;

			this.Location = FrmLoc;
		}

        private void Form1_KeyPress (object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown (object sender, KeyEventArgs e)
        {
            //Anzeigen der Positionsbuttons
            if(e.KeyCode == Keys.ShiftKey)
            {
                RecalcPosButtuns ();
            }
        }

        private void RecalcPosButtuns ()
        {
            Point formSize = new Point (this.Size);

            Debug.WriteLine ("FormSize: " + formSize.ToString ());
            Rectangle myForm = new Rectangle (0, 0, this.Size.Width, this.Size.Height);
            Point newLoc = new Point ();

            button1.Visible = true;

            newLoc.X = myForm.Width - button2.Width;
            newLoc.Y = 0;
            button2.Location = newLoc;
            button2.Visible = true;

            newLoc.X = 0;
            newLoc.Y = myForm.Height - button3.Height;
            button3.Location = newLoc;
            button3.Visible = true;

            newLoc.X = myForm.Width - button4.Width;
            newLoc.Y = myForm.Height - button4.Height;
            button4.Location = newLoc;
            button4.Visible = true;
        }

        private void FormToDiplayEdge (object sender, EventArgs e)
        {
            Button butt = sender as Button;

            if(butt != null)
            {
                switch (Convert.ToInt32(butt.Tag))
                {
                    case 0:
                        RecalcPosition (activeDisplay, DisplayEdge.TopLeft);
                        break;
                    case 1:
                        RecalcPosition (activeDisplay, DisplayEdge.TopRight);
                        break;
                    case 2:
                        RecalcPosition (activeDisplay, DisplayEdge.BottomLeft);
                        break;
                    case 3:
                        RecalcPosition (activeDisplay, DisplayEdge.BottomRight);
                        break;
                }
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        private void Form1_KeyUp (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }
    }

    /* Klasse zum einlesen der JSON Konfiguration */
    [JsonObject (MemberSerialization.OptIn)]
    public class AppSettings
    {
        [JsonProperty (PropertyName = "ForeGround", Required = Required.Always)]
        public bool SetForground { get; set; }

        [JsonProperty (PropertyName = "Display", Required = Required.Always)]
        public int ActiveDisplay { get; set; }

        [JsonProperty (PropertyName = "Edge", Required = Required.Always)]
        public int ActiveEdge { get; set; }

        [JsonProperty (PropertyName = "Alarm", Required = Required.Always)]
        public List<AlarmSettings> Alarm = new List<AlarmSettings> ();

        [JsonProperty (PropertyName = "ClockText", Required = Required.Always)]
        public TextSettings ClockText = new TextSettings();
    }

    [JsonObject (MemberSerialization.OptIn)]
    public class AlarmSettings
    {
        [JsonProperty (PropertyName = "TimeHour", Required = Required.Always)]
        public int TimeHour { get; set; }

        [JsonProperty (PropertyName = "TimeMinute", Required = Required.Always)]
        public int TimeMinute { get; set; }

        [JsonProperty (PropertyName = "Repeat", Required = Required.Always)]
        public bool Repeat { get; set; }

        [JsonProperty (PropertyName = "Active", Required = Required.Always)]
        public bool Active { get; set; }

        [JsonProperty (PropertyName = "Soundfile", Required = Required.AllowNull)]
        public string SoundFile { get; set; }

        [JsonProperty (PropertyName = "Color", Required = Required.Always)]
        public Color alarmcolor = new Color ();

        [JsonProperty (PropertyName = "DayOfWeek", Required = Required.Always)]
        public Dictionary<String, bool> DayOfWeek = new Dictionary<String, bool>() { { "Monday", true }, { "Tuesday", true }, { "Wednesday", true }, { "Thursday", true }, { "Friday", true }, { "Saturday", true }, { "Sunday", true } };
    }

    [JsonObject (MemberSerialization.OptIn)]
    public class TextSettings
    {
        [JsonProperty (PropertyName = "ShowDate", Required = Required.Always)]
        public bool ShowDateText { get; set; }

        [JsonProperty (PropertyName = "Font", Required = Required.AllowNull)]
        public Font font = new Font ("Arial", 12, GraphicsUnit.Pixel);

        [JsonProperty (PropertyName = "Color", Required = Required.Always)]
        public Color color = Color.Black; //new Color ();
    }
}
