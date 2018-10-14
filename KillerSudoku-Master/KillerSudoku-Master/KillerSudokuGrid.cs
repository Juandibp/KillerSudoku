using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KillerSudoku_Master
{
	public class KillerSudokuGrid:FlowLayoutPanel
	{
		private Panel parent;
		//Attributes
		private int dimension;
		private int threadAmount;
		private Benchmark bench = new Benchmark();
		public Board initialGameBoard;
		private List<GameBoardThread> threads;
		public FlowLayoutPanel[][] minisquarePanels;
		public TextBox[][] grid;

		public KillerSudokuGrid(int threadAmount,Board Savedgame,KillerSudokuFrame Parent)
		{
			this.Width = Parent.getPanel().Width;
			this.Height = Parent.getPanel().Height;
			this.parent = Parent.getPanel();
			this.FlowDirection = FlowDirection.LeftToRight;
			this.BorderStyle = BorderStyle.Fixed3D;

			this.threadAmount = threadAmount;
			this.initialGameBoard = Savedgame;
			this.dimension = Savedgame.size;

			this.grid = new TextBox[dimension][];
			this.minisquarePanels = new FlowLayoutPanel[dimension][];

			//Initialize jagged array
			for (int i = 0; i < dimension; i++)
			{
				grid[i] = new TextBox[dimension];
				minisquarePanels[i] = new FlowLayoutPanel[dimension];
			}
			setup();
		}

		public KillerSudokuGrid(int dimension, int pProb1, int pProb2, int pProb4, int pProbSum, int pProbMult, int threadAmount, KillerSudokuFrame Parent)
		{
			this.Width = Parent.getPanel().Width;
			this.Height = Parent.getPanel().Height;
			this.parent = Parent.getPanel();
			//Debug.WriteLine(parent.Width.ToString()+"X"+parent.Height.ToString());
			this.FlowDirection = FlowDirection.LeftToRight;
			this.BorderStyle = BorderStyle.Fixed3D;
			this.dimension = dimension;
			this.threadAmount = threadAmount;

			this.grid = new TextBox[dimension][];
			this.minisquarePanels = new FlowLayoutPanel[dimension][];
			
			//Initialize jagged array
			for(int i = 0; i < dimension; i++)
			{
				grid[i] = new TextBox[dimension];
				minisquarePanels[i] = new FlowLayoutPanel[dimension];
			}

			this.initialGameBoard = new Board(dimension, pProb1, pProb2, pProb4, pProbSum, pProbMult);
			setup();
		}

		public void setup()
		{
			for (int y = 0; y < dimension; ++y)
			{
				for (int x = 0; x < dimension; ++x)
				{
					TextBox field = new TextBox();
					field.BorderStyle = BorderStyle.Fixed3D;
					grid[y][x] = field;
				}
			}

			for (int y = 0; y < dimension; ++y)
			{
				for (int x = 0; x < dimension; ++x)
				{
					FlowLayoutPanel panel = new FlowLayoutPanel();
					panel.FlowDirection = FlowDirection.LeftToRight;
					panel.Margin = new Padding(0);
					panel.Width = (int)parent.Width / dimension - 1;
					panel.Height = (int)parent.Height / dimension - 1;
					//Debug.WriteLine(panel.Width.ToString() + "X" + panel.Height.ToString());
					panel.BorderStyle = BorderStyle.Fixed3D;
					minisquarePanels[y][x] = panel;
					this.Controls.Add(panel);
				}
			}

			for (int y = 0; y < dimension; ++y)
			{
				for (int x = 0; x < dimension; ++x)
				{
					grid[y][x].Width = (int)minisquarePanels[y][x].Width / dimension - 1;
					grid[y][x].Height = (int)minisquarePanels[y][x].Height / dimension - 1;
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
			MessageBox.Show("The KillerSudoku was succesfully completed " + bench.getTime() + "Success!");

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
			System.Threading.Semaphore sem = new Semaphore(1, 1);
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


	}
}
