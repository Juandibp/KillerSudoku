using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KillerSudoku_Master
{
	public partial class KillerSudokuFrame : Form
	{

		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(5, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x6ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(6, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x7ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(7, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x8ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(8, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x9ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(9, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(10, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x11ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(11, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x12ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(12, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x13ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(13, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x14ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(14, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x15ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(15, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x16ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(16, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x17ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(17, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x18ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(18, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void x19ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getPanel().Controls.Clear();
			frame.Controls.Add(grid = new KillerSudokuGrid(19, prob1, prob2, prob4, probSum, probMult, threadAmount));
			CenterToParent();
		}

		private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Juan Diego Bejarano y Jose Pablo Feng");
		}
	}
}
