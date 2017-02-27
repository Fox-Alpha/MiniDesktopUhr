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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 98);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // immerImFordergrundToolStripMenuItem
            // 
            this.immerImFordergrundToolStripMenuItem.CheckOnClick = true;
            this.immerImFordergrundToolStripMenuItem.Name = "immerImFordergrundToolStripMenuItem";
            this.immerImFordergrundToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.immerImFordergrundToolStripMenuItem.Text = "Immer im Fordergrund";
            this.immerImFordergrundToolStripMenuItem.Click += new System.EventHandler(this.immerImFordergrundToolStripMenuItem_Click);
            // 
            // datumAnzeigenToolStripMenuItem
            // 
            this.datumAnzeigenToolStripMenuItem.Checked = true;
            this.datumAnzeigenToolStripMenuItem.CheckOnClick = true;
            this.datumAnzeigenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.datumAnzeigenToolStripMenuItem.Name = "datumAnzeigenToolStripMenuItem";
            this.datumAnzeigenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.datumAnzeigenToolStripMenuItem.Text = "Datum anzeigen";
            this.datumAnzeigenToolStripMenuItem.Click += new System.EventHandler(this.datumAnzeigenToolStripMenuItem_Click);
            // 
            // schriftAnpassenToolStripMenuItem
            // 
            this.schriftAnpassenToolStripMenuItem.Name = "schriftAnpassenToolStripMenuItem";
            this.schriftAnpassenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.schriftAnpassenToolStripMenuItem.Text = "Schrift anpassen";
            this.schriftAnpassenToolStripMenuItem.Click += new System.EventHandler(this.schriftAnpassenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.MaximumSize = new System.Drawing.Size(12, 12);
            this.button1.MinimumSize = new System.Drawing.Size(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(12, 12);
            this.button1.TabIndex = 1;
            this.button1.Tag = "0";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.FormToDiplayEdge);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(375, 0);
            this.button2.MaximumSize = new System.Drawing.Size(12, 12);
            this.button2.MinimumSize = new System.Drawing.Size(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(12, 12);
            this.button2.TabIndex = 2;
            this.button2.Tag = "1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.FormToDiplayEdge);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 88);
            this.button3.MaximumSize = new System.Drawing.Size(12, 12);
            this.button3.MinimumSize = new System.Drawing.Size(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(12, 12);
            this.button3.TabIndex = 3;
            this.button3.Tag = "2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.FormToDiplayEdge);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(375, 88);
            this.button4.MaximumSize = new System.Drawing.Size(12, 12);
            this.button4.MinimumSize = new System.Drawing.Size(12, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(12, 12);
            this.button4.TabIndex = 4;
            this.button4.Tag = "3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.FormToDiplayEdge);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(386, 99);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

