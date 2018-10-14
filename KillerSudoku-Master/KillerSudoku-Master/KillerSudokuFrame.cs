using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace KillerSudoku_Master
{
	public partial class KillerSudokuFrame : Form
	{
		public Label getActionLabel()
		{
			return this.actionLabel;
		}
		private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(5, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x6ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(6, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x7ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(7, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x8ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(8, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x9ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(9, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(10, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x11ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(11, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x12ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(12, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x13ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(13, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x14ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(14, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x15ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(15, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x16ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(16, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x17ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(17, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x18ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(18, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void x19ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(19, prob1, prob2, prob4, probSum, probMult, threadAmount,this));
			CenterToParent();
		}

		private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Killer Sudoku - Juan Diego Bejarano y Jose Pablo Feng");
		}

		private void settingsBtn_Click(object sender, EventArgs e)
		{
			new Settings(this);
			this.actionLabel.Text = "Setting things up...";
			this.actionLabel.Visible = true;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Research how to use the file explorer");
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Research file explorer to add a name to save");
			//grid.initialGameBoard.saveBoard();
		}
	}
}
