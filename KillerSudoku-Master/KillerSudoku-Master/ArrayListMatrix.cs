using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerSudoku_Master
{
	class ArrayListMatrix
	{
		public static List<List<int>> copyList(List<List<int>> input)
		{
			List<List<int>> returnArray = new List<List<int>>();
			List<int> aux;
			for (int i = 0; i < input.Count; i++)
			{
				aux = new List<int>();
				for (int j = 0; j < input.ElementAt(i).Count; j++)
				{
					aux.ElementAt(input.ElementAt(i).ElementAt(j));
				}
				returnArray.Add(aux);
			}
			return returnArray;
		}
	}
}
