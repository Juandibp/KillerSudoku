using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KillerSudoku_Master
{
	partial class KillerSudokuFrame
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		
		private System.ComponentModel.IContainer components = null;

		private KillerSudokuGrid grid;
		
		public int prob1;
		public int prob2;
		public int prob4;

		public int probSum;
		public int probMult;
		public int threadAmount;


		public KillerSudokuFrame()
		{
			loadSettings();
			InitializeComponent();
			grid = new KillerSudokuGrid(5, prob1, prob2, prob4, probSum, probMult, threadAmount,this);
			frame.Controls.Add(grid);
			CenterToParent();
			frame.Visible = true;
		}

		public Panel getPanel()
		{
			return this.frame;
		}

		public void loadSettings()
		{
			try {
				//deserialize JSON directly from a file
				using (StreamReader file = File.OpenText(@KillerSudoku.currentUser+"Settings.json"))
				{
					JsonSerializer serializer = new JsonSerializer();
					List<int> settings = (List<int>)serializer.Deserialize(file, typeof(List<int>));

					this.prob1 = settings.ElementAt(0);
					this.prob2 = settings.ElementAt(1);
					this.prob4 = settings.ElementAt(2);
					this.probSum = settings.ElementAt(3);
					this.probMult = settings.ElementAt(4);
					this.threadAmount = settings.ElementAt(5);
				}
			}
			catch (IOException)
			{
				loadDefaultSettings();
			}
		}

		public void saveSettings(List<int> settings)
		{
			try { 
				JsonSerializer ser = new JsonSerializer();
				using (StreamWriter sw = new StreamWriter(@KillerSudoku.currentUser + "Settings.json"))
				using (JsonWriter writer = new JsonTextWriter(sw))
				{
					ser.Serialize(writer, settings);
				}
				frame.Controls.Clear();
				frame.Controls.Add(grid = new KillerSudokuGrid(grid.initialGameBoard.size,prob1,prob2,prob4,probSum,probMult,threadAmount,this));
			}
			catch (IOException)
			{
				MessageBox.Show("Specified path to save settings does not exist.");
			}
		}

		public void loadDefaultSettings()
		{
			this.prob1 = 20;
			this.prob2 = 40;
			this.prob4 = 40;
			this.probSum = 5;
			this.probMult = 35;
			this.threadAmount = 1;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menuBar = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x13ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x14ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x17ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x18ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x19ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.frame = new System.Windows.Forms.Panel();
			this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.solveBtn = new System.Windows.Forms.Button();
			this.clearBtn = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.actionLabel = new System.Windows.Forms.Label();
			this.menuBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuBar
			// 
			this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuBar.Location = new System.Drawing.Point(0, 0);
			this.menuBar.Name = "menuBar";
			this.menuBar.Size = new System.Drawing.Size(772, 24);
			this.menuBar.TabIndex = 0;
			this.menuBar.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.settingsBtn,
            this.aboutToolStripMenuItem1});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x5ToolStripMenuItem,
            this.x6ToolStripMenuItem,
            this.x7ToolStripMenuItem,
            this.x8ToolStripMenuItem,
            this.x9ToolStripMenuItem,
            this.x10ToolStripMenuItem,
            this.x11ToolStripMenuItem,
            this.x12ToolStripMenuItem,
            this.x13ToolStripMenuItem,
            this.x14ToolStripMenuItem,
            this.x15ToolStripMenuItem,
            this.x16ToolStripMenuItem,
            this.x17ToolStripMenuItem,
            this.x18ToolStripMenuItem,
            this.x19ToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.settingsToolStripMenuItem.Text = "Size";
			// 
			// x5ToolStripMenuItem
			// 
			this.x5ToolStripMenuItem.Name = "x5ToolStripMenuItem";
			this.x5ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x5ToolStripMenuItem.Text = "5x5";
			this.x5ToolStripMenuItem.Click += new System.EventHandler(this.x5ToolStripMenuItem_Click);
			// 
			// x6ToolStripMenuItem
			// 
			this.x6ToolStripMenuItem.Name = "x6ToolStripMenuItem";
			this.x6ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x6ToolStripMenuItem.Text = "6x6";
			this.x6ToolStripMenuItem.Click += new System.EventHandler(this.x6ToolStripMenuItem_Click);
			// 
			// x7ToolStripMenuItem
			// 
			this.x7ToolStripMenuItem.Name = "x7ToolStripMenuItem";
			this.x7ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x7ToolStripMenuItem.Text = "7x7";
			this.x7ToolStripMenuItem.Click += new System.EventHandler(this.x7ToolStripMenuItem_Click);
			// 
			// x8ToolStripMenuItem
			// 
			this.x8ToolStripMenuItem.Name = "x8ToolStripMenuItem";
			this.x8ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x8ToolStripMenuItem.Text = "8x8";
			this.x8ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
			// 
			// x9ToolStripMenuItem
			// 
			this.x9ToolStripMenuItem.Name = "x9ToolStripMenuItem";
			this.x9ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x9ToolStripMenuItem.Text = "9x9";
			this.x9ToolStripMenuItem.Click += new System.EventHandler(this.x9ToolStripMenuItem_Click);
			// 
			// x10ToolStripMenuItem
			// 
			this.x10ToolStripMenuItem.Name = "x10ToolStripMenuItem";
			this.x10ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x10ToolStripMenuItem.Text = "10x10";
			this.x10ToolStripMenuItem.Click += new System.EventHandler(this.x10ToolStripMenuItem_Click);
			// 
			// x11ToolStripMenuItem
			// 
			this.x11ToolStripMenuItem.Name = "x11ToolStripMenuItem";
			this.x11ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x11ToolStripMenuItem.Text = "11x11";
			this.x11ToolStripMenuItem.Click += new System.EventHandler(this.x11ToolStripMenuItem_Click);
			// 
			// x12ToolStripMenuItem
			// 
			this.x12ToolStripMenuItem.Name = "x12ToolStripMenuItem";
			this.x12ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x12ToolStripMenuItem.Text = "12x12";
			this.x12ToolStripMenuItem.Click += new System.EventHandler(this.x12ToolStripMenuItem_Click);
			// 
			// x13ToolStripMenuItem
			// 
			this.x13ToolStripMenuItem.Name = "x13ToolStripMenuItem";
			this.x13ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x13ToolStripMenuItem.Text = "13x13";
			this.x13ToolStripMenuItem.Click += new System.EventHandler(this.x13ToolStripMenuItem_Click);
			// 
			// x14ToolStripMenuItem
			// 
			this.x14ToolStripMenuItem.Name = "x14ToolStripMenuItem";
			this.x14ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x14ToolStripMenuItem.Text = "14x14";
			this.x14ToolStripMenuItem.Click += new System.EventHandler(this.x14ToolStripMenuItem_Click);
			// 
			// x15ToolStripMenuItem
			// 
			this.x15ToolStripMenuItem.Name = "x15ToolStripMenuItem";
			this.x15ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x15ToolStripMenuItem.Text = "15x15";
			this.x15ToolStripMenuItem.Click += new System.EventHandler(this.x15ToolStripMenuItem_Click);
			// 
			// x16ToolStripMenuItem
			// 
			this.x16ToolStripMenuItem.Name = "x16ToolStripMenuItem";
			this.x16ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x16ToolStripMenuItem.Text = "16x16";
			this.x16ToolStripMenuItem.Click += new System.EventHandler(this.x16ToolStripMenuItem_Click);
			// 
			// x17ToolStripMenuItem
			// 
			this.x17ToolStripMenuItem.Name = "x17ToolStripMenuItem";
			this.x17ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x17ToolStripMenuItem.Text = "17x17";
			this.x17ToolStripMenuItem.Click += new System.EventHandler(this.x17ToolStripMenuItem_Click);
			// 
			// x18ToolStripMenuItem
			// 
			this.x18ToolStripMenuItem.Name = "x18ToolStripMenuItem";
			this.x18ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x18ToolStripMenuItem.Text = "18x18";
			this.x18ToolStripMenuItem.Click += new System.EventHandler(this.x18ToolStripMenuItem_Click);
			// 
			// x19ToolStripMenuItem
			// 
			this.x19ToolStripMenuItem.Name = "x19ToolStripMenuItem";
			this.x19ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.x19ToolStripMenuItem.Text = "19x19";
			this.x19ToolStripMenuItem.Click += new System.EventHandler(this.x19ToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// settingsBtn
			// 
			this.settingsBtn.Name = "settingsBtn";
			this.settingsBtn.Size = new System.Drawing.Size(180, 22);
			this.settingsBtn.Text = "Settings";
			this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
			// 
			// aboutToolStripMenuItem1
			// 
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
			this.aboutToolStripMenuItem1.Text = "About";
			this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
			// 
			// frame
			// 
			this.frame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.frame.Location = new System.Drawing.Point(13, 40);
			this.frame.Name = "frame";
			this.frame.Size = new System.Drawing.Size(500, 500);
			this.frame.TabIndex = 1;
			// 
			// solveBtn
			// 
			this.solveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.solveBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
			this.solveBtn.FlatAppearance.BorderSize = 2;
			this.solveBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
			this.solveBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.solveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(178)))), ((int)(((byte)(204)))));
			this.solveBtn.Location = new System.Drawing.Point(27, 38);
			this.solveBtn.Name = "solveBtn";
			this.solveBtn.Size = new System.Drawing.Size(148, 54);
			this.solveBtn.TabIndex = 2;
			this.solveBtn.Text = "Solve";
			this.solveBtn.UseVisualStyleBackColor = true;
			this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
			// 
			// clearBtn
			// 
			this.clearBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.clearBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
			this.clearBtn.FlatAppearance.BorderSize = 2;
			this.clearBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
			this.clearBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(178)))), ((int)(((byte)(204)))));
			this.clearBtn.Location = new System.Drawing.Point(27, 114);
			this.clearBtn.Name = "clearBtn";
			this.clearBtn.Size = new System.Drawing.Size(148, 54);
			this.clearBtn.TabIndex = 3;
			this.clearBtn.Text = "Clear";
			this.clearBtn.UseVisualStyleBackColor = true;
			this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.clearBtn);
			this.panel1.Controls.Add(this.solveBtn);
			this.panel1.Location = new System.Drawing.Point(560, 341);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 199);
			this.panel1.TabIndex = 4;
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.titleLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(178)))), ((int)(((byte)(204)))));
			this.titleLabel.Location = new System.Drawing.Point(560, 40);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(200, 135);
			this.titleLabel.TabIndex = 5;
			this.titleLabel.Text = "Killer Sudoku...\r\n       On Steroids\r\n\r\n";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// actionLabel
			// 
			this.actionLabel.AutoSize = true;
			this.actionLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.actionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(178)))), ((int)(((byte)(204)))));
			this.actionLabel.Location = new System.Drawing.Point(561, 175);
			this.actionLabel.Name = "actionLabel";
			this.actionLabel.Size = new System.Drawing.Size(82, 39);
			this.actionLabel.TabIndex = 6;
			this.actionLabel.Text = "Action";
			this.actionLabel.Visible = false;
			// 
			// KillerSudokuFrame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(772, 555);
			this.Controls.Add(this.actionLabel);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.frame);
			this.Controls.Add(this.menuBar);
			this.MainMenuStrip = this.menuBar;
			this.Name = "KillerSudokuFrame";
			this.Text = "KillerSudokuFrame";
			this.menuBar.ResumeLayout(false);
			this.menuBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuBar;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.Panel frame;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x5ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x6ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x7ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x8ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x9ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x10ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x11ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x12ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x13ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x14ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x15ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x16ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x17ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x18ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x19ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsBtn;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
		private BindingSource bindingSource1;
		private Button solveBtn;
		private Button clearBtn;
		private Panel panel1;
		private Label titleLabel;
		public Label actionLabel;
	}
}