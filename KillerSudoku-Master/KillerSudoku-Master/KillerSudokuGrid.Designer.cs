using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using System.Threading;
using System;

namespace KillerSudoku_Master
{
	public partial class KillerSudokuGrid
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		private System.ComponentModel.IContainer components = null;

		// Attributes
		private int dimension;
		private int threadAmount;
		private Benchmark bench = new Benchmark();
		public Board initialGameBoard;
		private List<GameBoardThread> threads;

		public KillerSudokuGrid(int threadAmount, Board Savedgame)
		{
			this.threadAmount = threadAmount;
			this.initialGameBoard = Savedgame;
			this.dimension = Savedgame.size;
			setup();
		}

		public KillerSudokuGrid(int dimension, int pProb1, int pProb2, int pProb4, int pProbSum, int pProbMult, int threadAmount)
		{
			this.threadAmount = threadAmount;
			this.dimension = dimension;
			this.initialGameBoard = new Board(dimension, pProb1, pProb2, pProb4, pProbSum, pProbMult);
			setup();
		}

		public void setup()
		{
			this.grid = new TextBox[dimension][];
			for (int y = 0; y < dimension; ++y)
			{
				for (int x = 0; x < dimension; ++x)
				{
					TextBox field = new TextBox();
					grid[y][x] = field;
				}
			}

			this.gridPanel = new Panel();
			this.buttonPanel = new Panel();

			for (int y = 0; y < dimension; ++y)
			{
				for (int x = 0; x < dimension; ++x)
				{
					TextBox field = new TextBox();
				}
			}

			this.minisquarePanels = new Panel[dimension][];

			for (int y = 0; y < dimension; ++y)
			{
				for (int x = 0; x < dimension; ++x)
				{
					Panel panel = new Panel();
					minisquarePanels[y][x] = panel;
					gridPanel.Controls.Add(panel);
				}
			}

			for (int y = 0; y < dimension; ++y)
			{
				for (int x = 0; x < dimension; ++x)
				{
					minisquarePanels[y][x].Controls.Add(grid[y][x]);
				}
			}

		}

		public void displayOpResult(int indiceOp, List<int> possibleSolution, Board gameBoard)
		{
			grid[gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(0).posY][gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(0).posX].Text = (gameBoard.operations.ElementAt(indiceOp).toStringFirstCell());
			if (gameBoard.operations.ElementAt(indiceOp).cells.Count > 1)
			{
				for (int x = 1; x < gameBoard.operations.ElementAt(indiceOp).cellAmount; x++)
				{
					if (possibleSolution.ElementAt(x) > 9)
					{
						grid[gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(x).posY][gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(x).posX].Text = ("" + possibleSolution.ElementAt(x));
					}
					else
					{
						grid[gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(x).posY][gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(x).posX].Text = (" " + possibleSolution.ElementAt(x));
					}
				}
			}
		}

		public void removeOpResult(int indiceOp, Board gameBoard)
		{
			gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(0).number = -1;
			grid[gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(0).posY][gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(0).posX].Text = (gameBoard.operations.ElementAt(indiceOp).toStringFirstCell());
			if (gameBoard.operations.ElementAt(indiceOp).cells.Count > 1)
			{
				for (int x = 1; x < gameBoard.operations.ElementAt(indiceOp).cellAmount; x++)
				{
					gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(x).number = -1;
					grid[gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(x).posY][gameBoard.operations.ElementAt(indiceOp).cells.ElementAt(x).posX].Text = ("");

				}
			}
		}

		public void desplegarProceso(Board gameBoard)
		{
			int numb;
			int k;
			int j;
			for (int y = 0; y < dimension; y++)
			{
				for (int x = 0; x < dimension; x++)
				{
					numb = gameBoard.cells[y][x].number;
					if (numb > 9)
					{
						grid[y][x].Text = ("" + numb);
					}
					else if (numb > -1)
					{
						grid[y][x].Text = (" " + numb);
					}
				}
			}
			for (int i = 0; i < gameBoard.operations.Count; i++)
			{
				Operation op = gameBoard.operations.ElementAt(i);
				k = op.cells.ElementAt(0).posX;
				j = op.cells.ElementAt(0).posY;
				grid[j][k].Font = (new Font("Verdana", 10));
				grid[j][k].Text = (op.toStringFirstCell());
			}
		}

		public void desplegarConSolucion(Board gameBoard)
		{

			bench.end();

			desplegarProceso(gameBoard);
			MessageBox.Show("The KenKen was succesfully completed " + bench.getTime() + "Success!");

		}

		public void desplegarSinSolucion()
		{
			int k;
			int j;
			ColorConverter converter = new ColorConverter();
			for (int y = 0; y < dimension; y++)
			{
				for (int x = 0; x < dimension; x++)
				{

					Color bgColor = (Color)converter.ConvertFromString(Board.indexcolors[initialGameBoard.cells[y][x].operationId % 128]);
					grid[y][x].Text = "";
					grid[y][x].BackColor = (bgColor);
					if (bgColor.R * 0.299 + bgColor.G * 0.587 + bgColor.B * 0.114 > 186)
					{
						grid[y][x].ForeColor = (Color.Black);
					}
					else
					{
						grid[y][x].ForeColor = (Color.White);
					}
				}
			}
			for (int i = 0; i < initialGameBoard.operations.Count; i++)
			{
				Operation op = initialGameBoard.operations.ElementAt(i);
				k = op.cells.ElementAt(0).posX;
				j = op.cells.ElementAt(0).posY;
				grid[j][k].Font = (new System.Drawing.Font("Verdana", 12.0f));

				grid[j][k].Text = (op.ToString());
				Color bgColor = (Color)converter.ConvertFromString(Board.indexcolors[op.operationId % 128]);
				grid[j][k].BackColor = (bgColor);
				if (bgColor.R * 0.299 + bgColor.G * 0.587 + bgColor.B * 0.114 > 186)
				{
					grid[j][k].ForeColor = (Color.Black);
				}
				else
				{
					grid[j][k].ForeColor = (Color.White);
				}
			}
		}

		private void runApplication()
		{
			initialGameBoard.sortOperations();
			initialGameBoard.setCellsToZero();
			Shared.finished = false;
			threads = new List<GameBoardThread>(threadAmount);
			System.Threading.Semaphore sem = new Semaphore(1,1);
			bench.start();
			for (int i = 0; i < threadAmount; i++)
			{
				threads.Add(new GameBoardThread(sem, "thread" + i, new Board(initialGameBoard), this));
				threads.ElementAt(i).Start();
				try
				{
					Thread.Sleep(100);
				}
				catch (ThreadInterruptedException ex)
				{
					Console.WriteLine(ex.StackTrace);
				}
			}
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
			this.gridPanel = new System.Windows.Forms.Panel();
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.clearButton = new System.Windows.Forms.Button();
			this.solveButton = new System.Windows.Forms.Button();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridPanel
			// 
			this.gridPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.gridPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.gridPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.gridPanel.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gridPanel.Location = new System.Drawing.Point(23, 29);
			this.gridPanel.Name = "gridPanel";
			this.gridPanel.Size = new System.Drawing.Size(451, 375);
			this.gridPanel.TabIndex = 0;
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.clearButton);
			this.buttonPanel.Controls.Add(this.solveButton);
			this.buttonPanel.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPanel.Location = new System.Drawing.Point(541, 281);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(200, 123);
			this.buttonPanel.TabIndex = 1;
			// 
			// clearButton
			// 
			this.clearButton.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
			this.clearButton.FlatAppearance.BorderSize = 10;
			this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.clearButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearButton.ForeColor = System.Drawing.Color.White;
			this.clearButton.Location = new System.Drawing.Point(58, 67);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(75, 29);
			this.clearButton.TabIndex = 1;
			this.clearButton.Text = "Clear";
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// solveButton
			// 
			this.solveButton.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
			this.solveButton.FlatAppearance.BorderSize = 10;
			this.solveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.solveButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.solveButton.ForeColor = System.Drawing.Color.White;
			this.solveButton.Location = new System.Drawing.Point(58, 14);
			this.solveButton.Name = "solveButton";
			this.solveButton.Size = new System.Drawing.Size(75, 30);
			this.solveButton.TabIndex = 0;
			this.solveButton.Text = "Solve";
			this.solveButton.UseVisualStyleBackColor = true;
			// 
			// KillerSudokuGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.buttonPanel);
			this.Controls.Add(this.gridPanel);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "KillerSudokuGrid";
			this.Text = "KillerSudokuGrid";
			this.buttonPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private TextBox[][] grid;
		private Panel gridPanel;
		private Panel buttonPanel;
		private Button clearButton;
		private Button solveButton;
		private Panel[][] minisquarePanels;
	}
}