using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KillerSudoku_Master
{
	public partial class Settings : Form
	{
		public KillerSudokuFrame parent;
		public Settings(KillerSudokuFrame parent)
		{
			this.parent = parent;
			InitializeComponent();
			this.Show();
		}

		private void applyBtn_Click(object sender, EventArgs e)
		{
			string threadAmount,prob1, prob2, prob4, probSum, probMult;
			threadAmount = this.threadAmountText.Text;
			prob1 = this.prob2Text.Text;
			prob2 = this.prob2Text.Text;
			prob4 = this.prob4Text.Text;
			probSum = this.probSumText.Text;
			probMult = this.probMultText.Text;

			if(prob1 =="" || threadAmount == "" || prob2 == "" || prob4 == "" || probSum == "" || probMult == "")
			{
				MessageBox.Show("Fill all spaces please.");
			}
			else
			{
				try
				{
					int threadAmountN, prob1N, prob2N, prob4N, probSumN, probMultN;
					threadAmountN = int.Parse(threadAmount);
					prob1N = int.Parse(prob2);
					prob2N = int.Parse(prob2);
					prob4N = int.Parse(prob4);
					probSumN = int.Parse(probSum);
					probMultN = int.Parse(probMult);

					List<int> settings = new List<int>();

					settings.Add(prob1N);
					settings.Add(prob2N);
					settings.Add(prob4N);
					settings.Add(probSumN);
					settings.Add(probMultN);
					settings.Add(threadAmountN);

					parent.saveSettings(settings);
					this.Dispose();
					parent.actionLabel.Visible = false;
				}
				catch(FormatException)
				{
					MessageBox.Show("Only numbers are accepted.");
				}
			}
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
		
			Dispose();
			parent.actionLabel.Visible = false;
		}

		private void Settings_FormClosing(object sender, FormClosingEventArgs e)
		{
			Dispose();
			parent.actionLabel.Visible = false;
		}
	}
}
