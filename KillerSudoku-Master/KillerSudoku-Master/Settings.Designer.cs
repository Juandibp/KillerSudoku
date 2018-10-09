namespace KillerSudoku_Master
{
	partial class Settings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.threadAmountL = new System.Windows.Forms.Label();
			this.Prob1L = new System.Windows.Forms.Label();
			this.prob2L = new System.Windows.Forms.Label();
			this.prob4L = new System.Windows.Forms.Label();
			this.sumL = new System.Windows.Forms.Label();
			this.multiplicationL = new System.Windows.Forms.Label();
			this.labelPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.applyBtn = new System.Windows.Forms.Button();
			this.textPanel = new System.Windows.Forms.Panel();
			this.threadAmountText = new System.Windows.Forms.TextBox();
			this.prob1Text = new System.Windows.Forms.TextBox();
			this.prob2Text = new System.Windows.Forms.TextBox();
			this.prob4Text = new System.Windows.Forms.TextBox();
			this.probSumText = new System.Windows.Forms.TextBox();
			this.probMultText = new System.Windows.Forms.TextBox();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.labelPanel.SuspendLayout();
			this.textPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// threadAmountL
			// 
			this.threadAmountL.AutoSize = true;
			this.threadAmountL.Location = new System.Drawing.Point(18, 23);
			this.threadAmountL.Name = "threadAmountL";
			this.threadAmountL.Size = new System.Drawing.Size(121, 23);
			this.threadAmountL.TabIndex = 0;
			this.threadAmountL.Text = "Thread Amount";
			// 
			// Prob1L
			// 
			this.Prob1L.AutoSize = true;
			this.Prob1L.Location = new System.Drawing.Point(18, 83);
			this.Prob1L.Name = "Prob1L";
			this.Prob1L.Size = new System.Drawing.Size(110, 23);
			this.Prob1L.TabIndex = 1;
			this.Prob1L.Text = "1 Cell Group %";
			// 
			// prob2L
			// 
			this.prob2L.AutoSize = true;
			this.prob2L.Location = new System.Drawing.Point(18, 149);
			this.prob2L.Name = "prob2L";
			this.prob2L.Size = new System.Drawing.Size(113, 23);
			this.prob2L.TabIndex = 2;
			this.prob2L.Text = "2 Cell Group %";
			// 
			// prob4L
			// 
			this.prob4L.AutoSize = true;
			this.prob4L.Location = new System.Drawing.Point(18, 206);
			this.prob4L.Name = "prob4L";
			this.prob4L.Size = new System.Drawing.Size(114, 23);
			this.prob4L.TabIndex = 3;
			this.prob4L.Text = "4 Cell Group %";
			// 
			// sumL
			// 
			this.sumL.AutoSize = true;
			this.sumL.Location = new System.Drawing.Point(18, 264);
			this.sumL.Name = "sumL";
			this.sumL.Size = new System.Drawing.Size(58, 23);
			this.sumL.TabIndex = 4;
			this.sumL.Text = "Sum %";
			// 
			// multiplicationL
			// 
			this.multiplicationL.AutoSize = true;
			this.multiplicationL.Location = new System.Drawing.Point(18, 321);
			this.multiplicationL.Name = "multiplicationL";
			this.multiplicationL.Size = new System.Drawing.Size(125, 23);
			this.multiplicationL.TabIndex = 5;
			this.multiplicationL.Text = "Multiplication %";
			// 
			// labelPanel
			// 
			this.labelPanel.Controls.Add(this.prob2L);
			this.labelPanel.Controls.Add(this.threadAmountL);
			this.labelPanel.Controls.Add(this.Prob1L);
			this.labelPanel.Controls.Add(this.prob4L);
			this.labelPanel.Controls.Add(this.multiplicationL);
			this.labelPanel.Controls.Add(this.sumL);
			this.labelPanel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPanel.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.labelPanel.Location = new System.Drawing.Point(12, 98);
			this.labelPanel.Name = "labelPanel";
			this.labelPanel.Size = new System.Drawing.Size(152, 359);
			this.labelPanel.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label1.Location = new System.Drawing.Point(183, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(238, 77);
			this.label1.TabIndex = 10;
			this.label1.Text = "Settings";
			// 
			// applyBtn
			// 
			this.applyBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.applyBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.applyBtn.ForeColor = System.Drawing.SystemColors.Control;
			this.applyBtn.Location = new System.Drawing.Point(185, 487);
			this.applyBtn.Name = "applyBtn";
			this.applyBtn.Size = new System.Drawing.Size(219, 45);
			this.applyBtn.TabIndex = 11;
			this.applyBtn.Text = "Apply";
			this.applyBtn.UseVisualStyleBackColor = true;
			this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
			// 
			// textPanel
			// 
			this.textPanel.Controls.Add(this.probMultText);
			this.textPanel.Controls.Add(this.probSumText);
			this.textPanel.Controls.Add(this.prob4Text);
			this.textPanel.Controls.Add(this.prob2Text);
			this.textPanel.Controls.Add(this.prob1Text);
			this.textPanel.Controls.Add(this.threadAmountText);
			this.textPanel.Location = new System.Drawing.Point(185, 98);
			this.textPanel.Name = "textPanel";
			this.textPanel.Size = new System.Drawing.Size(219, 359);
			this.textPanel.TabIndex = 12;
			// 
			// threadAmountText
			// 
			this.threadAmountText.Location = new System.Drawing.Point(28, 25);
			this.threadAmountText.Name = "threadAmountText";
			this.threadAmountText.Size = new System.Drawing.Size(161, 20);
			this.threadAmountText.TabIndex = 0;
			// 
			// prob1Text
			// 
			this.prob1Text.Location = new System.Drawing.Point(28, 85);
			this.prob1Text.Name = "prob1Text";
			this.prob1Text.Size = new System.Drawing.Size(161, 20);
			this.prob1Text.TabIndex = 1;
			// 
			// prob2Text
			// 
			this.prob2Text.Location = new System.Drawing.Point(28, 151);
			this.prob2Text.Name = "prob2Text";
			this.prob2Text.Size = new System.Drawing.Size(161, 20);
			this.prob2Text.TabIndex = 2;
			// 
			// prob4Text
			// 
			this.prob4Text.Location = new System.Drawing.Point(28, 208);
			this.prob4Text.Name = "prob4Text";
			this.prob4Text.Size = new System.Drawing.Size(161, 20);
			this.prob4Text.TabIndex = 3;
			// 
			// probSumText
			// 
			this.probSumText.Location = new System.Drawing.Point(28, 266);
			this.probSumText.Name = "probSumText";
			this.probSumText.Size = new System.Drawing.Size(161, 20);
			this.probSumText.TabIndex = 4;
			// 
			// probMultText
			// 
			this.probMultText.Location = new System.Drawing.Point(28, 321);
			this.probMultText.Name = "probMultText";
			this.probMultText.Size = new System.Drawing.Size(161, 20);
			this.probMultText.TabIndex = 5;
			// 
			// cancelBtn
			// 
			this.cancelBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelBtn.Location = new System.Drawing.Point(13, 487);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(151, 45);
			this.cancelBtn.TabIndex = 13;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
			this.ClientSize = new System.Drawing.Size(443, 561);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.textPanel);
			this.Controls.Add(this.applyBtn);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelPanel);
			this.Name = "Settings";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.Settings_Load);
			this.labelPanel.ResumeLayout(false);
			this.labelPanel.PerformLayout();
			this.textPanel.ResumeLayout(false);
			this.textPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label threadAmountL;
		private System.Windows.Forms.Label Prob1L;
		private System.Windows.Forms.Label prob2L;
		private System.Windows.Forms.Label prob4L;
		private System.Windows.Forms.Label sumL;
		private System.Windows.Forms.Label multiplicationL;
		private System.Windows.Forms.Panel labelPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button applyBtn;
		private System.Windows.Forms.Panel textPanel;
		private System.Windows.Forms.TextBox probMultText;
		private System.Windows.Forms.TextBox probSumText;
		private System.Windows.Forms.TextBox prob4Text;
		private System.Windows.Forms.TextBox prob2Text;
		private System.Windows.Forms.TextBox prob1Text;
		private System.Windows.Forms.TextBox threadAmountText;
		private System.Windows.Forms.Button cancelBtn;
	}
}