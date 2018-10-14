using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KillerSudoku_Master
{
	public static class OperationValidator
	{
		public static bool notZero(List<Cell> cells)
		{
			cells.Sort();
			for(int i = 0; i < cells.Count; i++)
			{
				if (cells.ElementAt(i).number == 0)
				{
					return true;
				}
				else
				{
					continue;
				}
			}
			return false;
		}
	}
}
