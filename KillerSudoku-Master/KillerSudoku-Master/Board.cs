using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KillerSudoku_Master
{
	public class Board
	{
		public Cell[][] cells;
		public int size;
		public List<int> possibleNum;
		public List<Operation> operations;
		public List<List<int>> possibleNumRows;
		public List<List<int>> possibleNumColumns;

		int prob1,prob2,prob4,probSum,probMult;

		public static string[] indexcolors = new string[] {
		"#E83000", "#FFAB00", "#E91E63", "#04F757", "#304FFE", "#A3C8C9", "#636375",
		"#C8D0F6", "#FF8A9A", "#A77500", "#3B9700", "#AEEA00", "#CB7E98", "#D0AC94",
		"#FF5722", "#AA00FF", "#6367A9", "#3F51B5", "#FF6F00", "#795548", "#03A9F4",
		"#4A148C", "#BF5650", "#311B92", "#009688", "#7900D7", "#5B4E51", "#607D8B",
		"#452C2C", "#A05837", "#201625", "#33691E", "#320033", "#F57F17", "#8CD0FF",
		"#6200EA", "#772600", "#C895C5", "#BEC459", "#34362D", "#006064", "#FF1A59",
		"#1E6E00", "#001C1E", "#575329", "#99ADC0", "#D157A0", "#806C66", "#B05B6F",
		"#D50000", "#880E4F", "#FFD600", "#A4E804", "#324E72", "#1B5E20", "#404E55",
		"#00BCD4", "#2962FF", "#DA007C", "#3E2723", "#9B9700", "#9C27B0", "#D1F7CE",
		"#C8A1A1", "#FFF69F", "#B71C1C", "#6B002C", "#7A87A1", "#66E1D3", "#64DD17",
		"#788D66", "#549E79", "#5B4534", "#004B28", "#B4A8BD", "#6A3A4C", "#FF9800",
		"#FF913F", "#885578", "#A3A489", "#BC23FF", "#000000", "#0091EA", "#3A2465",
		"#00A6AA", "#DD2C00", "#FAD09F", "#01579B", "#66796D", "#263238", "#00B8D4",
		"#4CAF50", "#1E0200", "#938A81", "#E65100", "#FF6D00", "#922329", "#C51162",
		"#00C853", "#0089A3", "#72418F", "#00FECF", "#BF360C", "#8ADBB4", "#456648",
		"#012C58", "#8BC34A", "#004D40", "#FDE8DC", "#886F4C", "#0086ED", "#0D47A1",
		"#83AB58", "#FF6832", "#7ED379", "#222800", "#FFEB3B", "#00BFA5", "#827717",
		"#2196F3", "#F44336", "#FFC107", "#CFCDAC", "#311B92", "#D790FF", "#673AB7",
		"#212121", "#CDDC39"
		};

		public Board(Board other)
		{
			this.size = other.size;
			this.possibleNum = new List<int>(other.possibleNum);
			this.operations = new List<Operation>();
			this.possibleNumRows = ArrayListMatrix.copyArrayList(other.possibleNumRows);
			this.possibleNumColumns = ArrayListMatrix.copyArrayList(other.possibleNumColumns);
			this.cells = new Cell[size][];
			this.prob1 = other.prob1;
			this.prob2 = other.prob2;
			this.prob4 = other.prob4;
			this.probSum = other.probSum;
			this.probMult = other.probMult;

			for (int i = 0; i < size; i++)
			{
				cells[i] = new Cell[size];
			}
			for(int y =0; y < size; y++)
			{
				for (int x = 0; x < size; x++)
				{
					cells[y][x] = new Cell(other.cells[y][x]);
				}
			}
			Operation op;
			for(int i=0;i<other.operations.Count;i++)
			{
				op = other.operations.ElementAt(i);
				this.operations.Add(new Operation(op, cells));
			}
		}

		public Board(int boardSize, int pProb1, int pProb2,int pProb4, int pProbSum,int pProbMult)
		{
			int rand;
			this.possibleNumRows = new List<List<int>>(boardSize);
			possibleNumColumns = new List<List<int>>(boardSize);
			this.prob1 = pProb1;
			this.prob2 = pProb2;
			this.prob4 = pProb4;
			this.probSum = pProbSum;
			this.probMult = pProbMult;
			size = boardSize;
			possibleNum = new List<int>(boardSize);
			cells = new Cell[boardSize][];
			operations = new List<Operation>();
			rand = 0;

			//Initializing the jagged array
			for(int i = 0; i < boardSize; i++)
			{
				cells[i] = new Cell[boardSize];
			}

			for (int y = 0; y < boardSize; y++)
			{
				possibleNum.Add(rand);
				for (int x = 0; x < boardSize; x++)
				{
					cells[y][x] = new Cell(x, y);
					cells[y][x].number = -1;
				}

				rand++;
			}
			for (int y = 0; y < boardSize; y++)
			{
				possibleNumRows.Add(new List<int>(possibleNum));
				possibleNumColumns.Add(new List<int>(possibleNum));
			}
			LatinBoardGenerator(possibleNum, 0, size);

			OperationGenerator();
		}

		public void sortOperations()
		{
			operations.Sort();
		}

		public void initPossibleNumbers()
		{
			int index;
			int boardSize = size;
			List<int> localPossibleNum = new List<int>(size);
			index = 0;
			for (int y = 0; y < boardSize; y++)
			{
				localPossibleNum.Add(index);
				index++;
			}
			for (int y = 0; y < boardSize; y++)
			{
				possibleNumRows.Add(localPossibleNum);
				possibleNumColumns.Add(localPossibleNum);
			}
		}

		public void setCellsToZero()
		{
			foreach (Operation op in operations)
			{
				op.setCellsToZero();
			}
		}

		public bool isSafe(Cell cell, int num)
		{
			int posX = cell.posX;
			int posY = cell.posY;
			for (int k = 0; k < size; k++)
			{
				if (posX != k)
				{
					if (cells[posY][k].number == num)
					{
						return false;
					}
				}
				if (posY != k)
				{
					if (cells[k][posX].number == num)
					{
						return false;
					}
				}
			}
			return true;
		}

		private bool LatinBoardGenerator(List<int> possibleNumbers, int cellNumb, int boardSize)
		{
			Random r = new Random();
			int rand;
			int contador = 0;
			if (cellNumb == boardSize * boardSize)
			{
				return true; //Se asignaron todos lo vértices exitosamente
			}
			else
			{
				Cell currentCell = cells[cellNumb / boardSize][cellNumb % boardSize];
				while (possibleNumbers.Count > 0)
				{
					rand = r.Next(possibleNumbers.Count);
					contador++;
					if (contador > boardSize * 2)
					{
						return false;
					}
					if (isSafe(currentCell, possibleNumbers.ElementAt(rand)))
					{ // Determina si a una celda en particular se le puede asignar un numero
						currentCell.number = possibleNumbers.ElementAt(rand);
						if (LatinBoardGenerator(possibleNumbers, cellNumb + 1, boardSize))
						{
							return true;
						}
					}
				}
				currentCell.number = size;
				return false;
			}
			
		}

		private void OperationGenerator()
		{

			Cell initialCell;
			int operationId = 0;
			int xpos;
			int ypos;
			int cagedAmount = 0;
			int cageSize;

			while (cagedAmount < size * size)
			{

				cageSize = getCageSize();
				initialCell = getNextUncagedCell();
				xpos = initialCell.posX;
				ypos = initialCell.posY;
				Operation op= new Operation(-1);
				List<Cell> shape;
				switch (cageSize)
				{
					case (1):
						op = new Operation(operationId);
						op.addCell(initialCell);
						cagedAmount++;
						break;
					case (2):
						op = new Operation(operationId);
						op.addCell(initialCell);
						cagedAmount++;
						initialCell = getRandomAdjacentCell(xpos, ypos);
						if (initialCell != null)
						{
							op.addCell(initialCell);
							cagedAmount++;

						}

						break;

					case (4):
						op = new Operation(operationId);
						op.addCell(initialCell);
						cagedAmount++;
						shape = getRandomTetrisShape(xpos, ypos);
						if (shape != null)
						{
							cagedAmount += 3;
							for (int i=0;i<shape.Count;i++)
							{
								Cell part = shape.ElementAt(i);
								op.addCell(part);
							}

						}
						else
						{
							initialCell = getRandomAdjacentCell(xpos, ypos);
							if (initialCell != null)
							{
								op.addCell(initialCell);
								cagedAmount++;
							}
						}

						break;

				}
				op.generateOperation(probSum, probMult);
				operations.Add(op);
				operationId++;
			}
		}

		private Cell getNextUncagedCell()
		{
			for (int y = 0; y < size; y++)
			{
				for (int x = 0; x < size; x++)
				{
					if (!cells[y][x].caged)
					{
						return cells[y][x];
					}
				}
			}
			return null;
		}


		private List<Cell> getRandomTetrisShape(int x, int y) {
        List<List<Cell>> candidates = new List<List<Cell>>();
        List<Cell> shape;
        if (y < size - 1) {  //Potential Square Shape
            if (y < size - 2) { //Potential L or T shape.
                if (!cells[y + 1][x].caged && !cells[y + 2][x].caged) {
                    if (x < size - 1) {
                        if (!cells[y + 1][x + 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y + 1][x]);
                            shape.Add(cells[y + 2][x]);
                            shape.Add(cells[y + 1][x + 1]);
                            candidates.Add(shape);
                        }
                        if (!cells[y + 2][x + 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y + 1][x]);
                            shape.Add(cells[y + 2][x]);
                            shape.Add(cells[y + 2][x + 1]);
                            candidates.Add(shape);
                        }
                    }
                    if (x > 0) {

                        if (!cells[y + 1][x - 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y + 1][x]);
                            shape.Add(cells[y + 2][x]);
                            shape.Add(cells[y + 1][x - 1]);
                            candidates.Add(shape);
                        }

                        if (!cells[y + 2][x - 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y + 1][x]);
                            shape.Add(cells[y + 2][x]);
                            shape.Add(cells[y + 2][x - 1]);
                            candidates.Add(shape);
                        }
                    }
                }
            }
            if (!cells[y + 1][x].caged) {
                if (x < size - 1) {
                    if (!cells[y + 1][x + 1].caged && !cells[y][x + 1].caged) {
                        shape = new List<Cell>();
                        shape.Add(cells[y + 1][x]);
                        shape.Add(cells[y + 1][x + 1]);
                        shape.Add(cells[y][x + 1]);
                        candidates.Add(shape);
                    }
                }
                if (x > 0) {
                    if (!cells[y + 1][x - 1].caged && !cells[y][x - 1].caged) {
                        shape = new List<Cell>();
                        shape.Add(cells[y + 1][x]);
                        shape.Add(cells[y + 1][x - 1]);
                        shape.Add(cells[y][x - 1]);
                        candidates.Add(shape);
                    }
                }
            }
        }

        if (x < size - 1) { //Potential Square Shape
            if (x < size - 2) { //Potential L or T shape.
                if (!cells[y][x + 1].caged && !cells[y][x + 2].caged) {
                    if (y < size - 1) {
                        if (!cells[y + 1][x + 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y][x + 1]);
                            shape.Add(cells[y][x + 2]);
                            shape.Add(cells[y + 1][x + 1]);
                            candidates.Add(shape);
                        }
                        if (!cells[y + 1][x + 2].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y][x + 1]);
                            shape.Add(cells[y][x + 2]);
                            shape.Add(cells[y + 1][x + 2]);
                            candidates.Add(shape);
                        }
                    }
                    if (y > 0) {

                        if (!cells[y - 1][x + 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y][x + 1]);
                            shape.Add(cells[y][x + 2]);
                            shape.Add(cells[y - 1][x + 1]);
                            candidates.Add(shape);
                        }

                        if (!cells[y - 1][x + 2].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y][x + 1]);
                            shape.Add(cells[y][x + 2]);
                            shape.Add(cells[y - 1][x + 2]);
                            candidates.Add(shape);
                        }
                    }
                }
            }
            if (!cells[y][x + 1].caged) {
                if (y < size - 1) {
                    if (!cells[y + 1][x + 1].caged && !cells[y + 1][x].caged) {
                        shape = new List<Cell>();
                        shape.Add(cells[y + 1][x]);
                        shape.Add(cells[y + 1][x + 1]);
                        shape.Add(cells[y][x + 1]);
                        candidates.Add(shape);
                    }
                }
                if (y > 0) {
                    if (!cells[y - 1][x + 1].caged && !cells[y - 1][x].caged) {
                        shape = new List<Cell>();
                        shape.Add(cells[y - 1][x]);
                        shape.Add(cells[y - 1][x + 1]);
                        shape.Add(cells[y][x + 1]);
                        candidates.Add(shape);
                    }
                }
            }
        }
        if (x > 0) {  //Potential Square Shape
            if (x > 1) { //Potential L or T shape.
                if (!cells[y][x - 1].caged && !cells[y][x - 2].caged) {
                    if (y < size - 1) {
                        if (!cells[y + 1][x - 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y][x - 1]);
                            shape.Add(cells[y][x - 2]);
                            shape.Add(cells[y + 1][x - 1]);
                            candidates.Add(shape);
                        }
                        if (!cells[y + 1][x - 2].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y][x - 1]);
                            shape.Add(cells[y][x - 2]);
                            shape.Add(cells[y + 1][x - 2]);
                            candidates.Add(shape);
                        }
                    }
                    if (y > 0) {

                        if (!cells[y - 1][x - 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y][x - 1]);
                            shape.Add(cells[y][x - 2]);
                            shape.Add(cells[y - 1][x - 1]);
                            candidates.Add(shape);
                        }

                        if (!cells[y - 1][x - 2].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y][x - 1]);
                            shape.Add(cells[y][x - 2]);
                            shape.Add(cells[y - 1][x - 2]);
                            candidates.Add(shape);
                        }
                    }
                }
            }
            if (!cells[y][x - 1].caged) {
                if (y < size - 1) {
                    if (!cells[y + 1][x - 1].caged && !cells[y + 1][x].caged) {
                        shape = new List<Cell>();
                        shape.Add(cells[y + 1][x]);
                        shape.Add(cells[y + 1][x - 1]);
                        shape.Add(cells[y][x - 1]);
                        candidates.Add(shape);
                    }
                }
                if (y > 0) {
                    if (!cells[y - 1][x - 1].caged && !cells[y - 1][x].caged) {
                        shape = new List<Cell>();
                        shape.Add(cells[y - 1][x]);
                        shape.Add(cells[y - 1][x - 1]);
                        shape.Add(cells[y][x - 1]);
                        candidates.Add(shape);
                    }
                }

            }
        }

        if (y > 0) {  //Potential Square Shape
            if (y > 1) { //Potential L or T shape.
                if (!cells[y - 1][x].caged && !cells[y - 2][x].caged) {
                    if (x < size - 1) {
                        if (!cells[y - 1][x + 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y - 1][x]);
                            shape.Add(cells[y - 2][x]);
                            shape.Add(cells[y - 1][x + 1]);
                            candidates.Add(shape);
                        }
                        if (!cells[y - 2][x + 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y - 1][x]);
                            shape.Add(cells[y - 2][x]);
                            shape.Add(cells[y - 2][x + 1]);
                            candidates.Add(shape);
                        }
                    }
                    if (x > 0) {

                        if (!cells[y - 1][x - 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y - 1][x]);
                            shape.Add(cells[y - 2][x]);
                            shape.Add(cells[y - 1][x - 1]);
                            candidates.Add(shape);
                        }

                        if (!cells[y - 2][x - 1].caged) {
                            shape = new List<Cell>();
                            shape.Add(cells[y - 1][x]);
                            shape.Add(cells[y - 2][x]);
                            shape.Add(cells[y - 2][x - 1]);
                            candidates.Add(shape);
                        }
                    }
                }
            }
            if (!cells[y - 1][x].caged) {
                if (x < size - 1) {
                    if (!cells[y - 1][x + 1].caged && !cells[y][x + 1].caged) {
                        shape = new List<Cell>();
                        shape.Add(cells[y - 1][x]);
                        shape.Add(cells[y - 1][x + 1]);
                        shape.Add(cells[y][x + 1]);
                        candidates.Add(shape);
                    }
                }
                if (x > 0) {
                    if (!cells[y - 1][x - 1].caged && !cells[y][x - 1].caged) {
                        shape = new List<Cell>();
                        shape.Add(cells[y - 1][x]);
                        shape.Add(cells[y - 1][x - 1]);
                        shape.Add(cells[y][x - 1]);
                        candidates.Add(shape);
                    }
                }
            }
        }

        if (candidates.Count > 0) {
            return candidates.ElementAt(new Random().Next(candidates.Count));
        }
        return null;
    }

		private Cell getRandomAdjacentCell(int x, int y)
		{
			Random r = new Random();
			List<Cell> candidates = new List<Cell>();
			if (y < size - 1)
			{
				if (!cells[y + 1][x].caged)
				{
					candidates.Add(cells[y + 1][x]);
				}
			}

			if (x < size - 1)
			{
				if (!cells[y][x + 1].caged)
				{
					candidates.Add(cells[y][x + 1]);
				}
			}
			if (x > 0)
			{
				if (!cells[y][x - 1].caged)
				{
					candidates.Add(cells[y][x - 1]);
				}
			}

			if (y > 0)
			{
				if (!cells[y - 1][x].caged)
				{
					candidates.Add(cells[y - 1][x]);
				}
			}
			if (candidates.Count > 0)
			{
				return candidates.ElementAt(r.Next(candidates.Count));
			}
			return null;
		}

		private int getCageSize()
		{
			Random r = new Random();

			if (r.Next(100) < prob4)
			{
				return 4;
			}
			if (r.Next(100) < prob2)
			{
				return 2;
			}
			else
			{
				return 1;
			}
		}

		public void saveBoard(String filename)
		{
			try
			{
				JsonSerializer ser = new JsonSerializer();
				using (StreamWriter sw = new StreamWriter(filename+".board"))
				using (JsonWriter writer = new JsonTextWriter(sw))
				{
					ser.Serialize(writer, this);
				}
			}
			catch (IOException)
			{
				{
					MessageBox.Show("File not found");
				}
			}

		}

	}
}
