using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KillerSudoku_Master
{
	public enum OperationType { POWER,MULT, SUM }
	public class Operation : IComparable<Operation>
	{
		public OperationType operationType;
		public int operationId;
		public int cellAmount;
		public int operationResult;
		public List<Cell> cells;

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
			Debug.WriteLine("operationType= " + this.operationType.ToString());
			switch (this.operationType)
			{
				case OperationType.POWER:
					//Debug.WriteLine(operationType.ToString() + ":" + OperationType.POWER);
					auxResult = (int)Math.Pow(cells.ElementAt(0).number, 3);
                    break;
				case OperationType.SUM:
					//Debug.WriteLine(operationType.ToString() + ":" + OperationType.SUM);
					for (int i = 0; i < cells.Count; i++)
					{

						auxResult = auxResult + cells.ElementAt(i).number;
					}
					break;
				case OperationType.MULT:
					//Debug.WriteLine(operationType.ToString()+":"+OperationType.MULT);
					auxResult = 1;
                    for (int i = 0; i < cells.Count; i++)
                    {
                    
                        auxResult = auxResult * cells.ElementAt(i).number;
					}
					break;
			}
            Debug.WriteLine("Elba Lazo " + auxResult);
            this.operationResult = auxResult;
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
			if (r.Next(1000000000) < 1)
			{
				operationType = OperationType.POWER;
			}
			else{
                Debug.WriteLine("Elsi Garro Mata " + cellAmount);
                switch (cellAmount)
				{
					case 1:
						operationType = OperationType.POWER;
						break;

					case 2:

						/*if (r.Next(100) < probMult)
						{
							//if (OperationValidator.notZero(cells))
							//{
								operationType = OperationType.MULT;
							//}
						}
						else if (r.Next(100) < probSum)*/
						{
							operationType = OperationType.SUM;
						}
						break;

					case 3:

						if (r.Next(100) < probMult)
						{
							//if (OperationValidator.notZero(cells)==false)
							//{
								operationType = OperationType.MULT;	
							//}
						}
						else if (r.Next(100) < probSum)
						{
							operationType = OperationType.SUM;
						}
						break;
                    case 4:

                        /*if (r.Next(100) < probMult)
                        {
                            //if (OperationValidator.notZero(cells) == false)
                           // {
                                operationType = OperationType.MULT;
                           // }
                        }
                        else if (r.Next(100) < probSum)*/
                        {
                            operationType = OperationType.SUM;
                        }
                        break;
                    default:
                        operationType = OperationType.SUM;
                        break;
                }
				generateResult();
			}

		}

		private String getOperationCharacter()
		{
			switch (operationType)
			{
				case OperationType.POWER:
					return "^";
				case OperationType.SUM:
					return "+";
				case OperationType.MULT:
					return "*";	
			}
			return "";
		}

		
		public override String ToString()
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
				result = result + +'\t' + "     " + cells.ElementAt(0).number;
			}
			else
			{
				result = result + '\t' + "     " + cells.ElementAt(0).number;
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
				result = result + '\t' + "      " + numb;
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
