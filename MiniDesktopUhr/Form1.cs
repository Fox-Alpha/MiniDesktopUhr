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

namespace MiniDesktopUhr
{
	public partial class Form1 : Form
	{
		bool bShowDate = false;
		const string strWithDate = "{0:dddd dd MMM, HH:mm:ss}";
		const string strWithOutDate = "{0:HH:mm:ss}";
		int activeDisplay = 0;

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
				RecalcPosition (activeDisplay);

				mi.Text = (scr.Primary ? "(P)" : "") + //Ist dies der Primär Bildschirm `?
								(scr.Bounds.Contains (this.Location) ? "*" : "") + // Wird die Form auf diesem Bildschrirm angezeigt ?
								scr.DeviceName + " " + scr.Bounds.Width.ToString () + " " + scr.Bounds.Height.ToString ();

			}
		}

		private void Form1_FormClosing (object sender, FormClosingEventArgs e)
		{
			timer.Enabled = false;
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

			RecalcPosition (activeDisplay);
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

				RecalcPosition (activeDisplay);
			}
		}

		private void RecalcPosition (int scrIdx)
		{
			//this.Location = new Point (Screen.AllScreens[scrIdx].WorkingArea.Width - this.Width - 5, Screen.AllScreens [scrIdx].WorkingArea.Height - this.Height - 5);
			//this.Focus ();

			Point disPosBottLeft = new Point ();
			Point FrmLoc = new Point ();

			Rectangle disRect = new Rectangle ();

			disRect = Screen.AllScreens [scrIdx].WorkingArea;
			disPosBottLeft.X = disRect.Width + disRect.X;
			disPosBottLeft.Y = disRect.Height + disRect.Y;

			FrmLoc.X = disPosBottLeft.X - this.Width - 5;
			FrmLoc.Y = disPosBottLeft.Y - this.Height - 5;

			this.Location = FrmLoc;
		}
	}
}
