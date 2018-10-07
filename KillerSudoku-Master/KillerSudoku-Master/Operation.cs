using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerSudoku_Master
{
	class Operation : IComparable<Operation>
	{
		public OperationType operationType;
		public int operationId;
		public int cellAmount;
		public int operationResult;
		public List<Cell> cells;

		public enum OperationType { MULT, SUM }

		public Operation(int id)
		{
			this.operationId = id;
			this.cellAmount = 0;
			cells = new List<Cell>();
		}

		public Operation(Operation other, Cell[][] cellArray)
		{
			this.operationId = other.operationId;
			this.operationType = other.operationType;
			this.cellAmount = other.cellAmount;
			this.operationResult = other.operationResult;
			cells = new List<Cell>();
			for (int i = 0; i < this.cellAmount; i++)
			{
				cells.Add(cellArray[other.cells.ElementAt(i).posY][other.cells.ElementAt(i).posX]);
			}
		}

		public void addCell(Cell cell)
		{
			cell.caged = true;
			cell.operationId = this.operationId;
			this.cells.Add(cell);
			this.cellAmount++;
		}


		public void generateResult()
		{
			int auxResult = 0;
			switch (operationType)
			{
				case OperationType.SUM:
					for (int i = 0; i < cells.Count; i++)
					{
						auxResult = auxResult + cells.ElementAt(i).number;
					}
					break;
				case OperationType.MULT:
					auxResult = 1;
					for (int i = 0; i < cells.Count; i++)
					{
						auxResult = auxResult * cells.ElementAt(i).number;
					}
					break;
			}
			operationResult = auxResult;
		}

		public void setCellsToZero()
		{
			foreach(Cell selectedCell in cells)
			{
				selectedCell.number = -1;
			}
		}

		public void generateOperation(int probSum, int probMult)
		{

			Random r = new Random();
			cells.Sort();
			if (r.Next(10) < 5)
			{
				operationType = OperationType.SUM;
			}
			else {
				switch (cellAmount)
				{
					case 1:

						if (r.Next(100) < probMult)
						{
							if (OperationValidator.notZero(cells))
							{
								operationType = OperationType.MULT;
							}
						}
						else if (r.Next(100) < probSum)
						{
							operationType = OperationType.SUM;
						}

						break;

					case 2:

						if (r.Next() < probMult)
						{
							if (OperationValidator.notZero(cells))
							{
								if (OperationValidator.notZero(cells))
								{
									operationType = OperationType.MULT;
								}
							}
						}
						else if (r.Next() < probSum)
						{
							operationType = OperationType.SUM;
						}

						break;
				}
				generateResult();
			}

		}

		public int Compare(int x, int y)
		{
			if (x == y)
			{
				return 0;
			} else if (x < y) {
				return -1;
			}
			else
			{
				return 1;
			}
		}

		private String getOperationCharacter()
		{
			switch (operationType)
			{
				case OperationType.SUM:
					return "+";
				case OperationType.MULT:
					return "*";
				default:
					return "";
			}

		}

		override
		public String ToString()
		{
			String result;
			if (operationResult % 1 == 0)
			{
				int auxNumb = (int)operationResult;
				result = auxNumb + "";
			}
			else
			{
				result = String.Format("%.2f", operationResult);
			}

			result += getOperationCharacter();
			return result;
		}

		public String toStringRestOfCells(Cell cell)
		{
			String result = "";
			int numb = cell.number;
			if (numb > 0)
			{
				result = result + '\n' + "     " + cells.ElementAt(0).number;
			}
			else
			{
				result = result + '\n' + "     " + cells.ElementAt(0).number;
			}
			return result;
		}

		public string toStringFirstCell()
		{
			string result;
			result = operationResult + "";
			int numb = cells.ElementAt(0).number;
			result += getOperationCharacter();

			if (numb > -1)
			{
				result = result + '\n' + "      " + numb;
			}
			return result;
		}

		public int CompareTo(Operation other)
		{
			if (this.cellAmount == other.cellAmount)
			{
				return 0;
			}else if (this.cellAmount < other.cellAmount)
			{
				return -1;
			}
			else
			{
				return 1; //   this > other
			}
		}

	}
}
