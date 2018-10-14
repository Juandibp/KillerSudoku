using System;
using System.Windows.Forms;

namespace KillerSudoku_Master
{
	
	public class KillerSudoku
	{
		public static string FengDesktopDirectory = "D:\\josep\\Documents\\GitRepos\\KillerSudoku\\";
		public static string currentUser=FengDesktopDirectory;

		public static void Main(String[] args)
		{

			KillerSudokuFrame test = new KillerSudokuFrame();
			Application.Run(test);
		}
	}
}
