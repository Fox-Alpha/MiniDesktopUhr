namespace MiniDesktopUhr
{
	partial class Form1
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent ()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.immerImFordergrundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.datumAnzeigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.schriftAnpassenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(5);
			this.label1.Size = new System.Drawing.Size(170, 43);
			this.label1.TabIndex = 0;
			this.label1.Text = "HH:MM:SS";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.immerImFordergrundToolStripMenuItem,
            this.datumAnzeigenToolStripMenuItem,
            this.schriftAnpassenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.beendenToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(196, 98);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// immerImFordergrundToolStripMenuItem
			// 
			this.immerImFordergrundToolStripMenuItem.CheckOnClick = true;
			this.immerImFordergrundToolStripMenuItem.Name = "immerImFordergrundToolStripMenuItem";
			this.immerImFordergrundToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.immerImFordergrundToolStripMenuItem.Text = "Immer im Fordergrund";
			this.immerImFordergrundToolStripMenuItem.Click += new System.EventHandler(this.immerImFordergrundToolStripMenuItem_Click);
			// 
			// datumAnzeigenToolStripMenuItem
			// 
			this.datumAnzeigenToolStripMenuItem.Checked = true;
			this.datumAnzeigenToolStripMenuItem.CheckOnClick = true;
			this.datumAnzeigenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.datumAnzeigenToolStripMenuItem.Name = "datumAnzeigenToolStripMenuItem";
			this.datumAnzeigenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.datumAnzeigenToolStripMenuItem.Text = "Datum anzeigen";
			this.datumAnzeigenToolStripMenuItem.Click += new System.EventHandler(this.datumAnzeigenToolStripMenuItem_Click);
			// 
			// schriftAnpassenToolStripMenuItem
			// 
			this.schriftAnpassenToolStripMenuItem.Name = "schriftAnpassenToolStripMenuItem";
			this.schriftAnpassenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.schriftAnpassenToolStripMenuItem.Text = "Schrift anpassen";
			this.schriftAnpassenToolStripMenuItem.Click += new System.EventHandler(this.schriftAnpassenToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
			// 
			// beendenToolStripMenuItem
			// 
			this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
			this.beendenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.beendenToolStripMenuItem.Text = "Beenden";
			this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(386, 99);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Form1";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem immerImFordergrundToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.ToolStripMenuItem datumAnzeigenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem schriftAnpassenToolStripMenuItem;
	}
}

