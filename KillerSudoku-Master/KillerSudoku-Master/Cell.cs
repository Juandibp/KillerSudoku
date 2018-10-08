using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerSudoku_Master
{
	public class Cell : IComparable<Cell>
	{
		public int number;
		public int posX;
		public int posY;
		public bool caged;
		public int operationId;

		public Cell(Cell other)
		{
			this.number = other.number;
			this.posX = other.posX;
			this.posY = other.posY;
			this.caged = other.caged;
			this.operationId = other.operationId;
		}
		public Cell(int x, int y)
		{
			this.posX = x;
			this.posY = y;
			this.caged = false;
		}

		public int CompareTo(Cell another)
		{
			if (this.posX == another.posX)
			{
				return this.posY.CompareTo(another.posY);
			}
			else
			{
				return this.posX.CompareTo(another.posX);
			}
		}		

	}
}

