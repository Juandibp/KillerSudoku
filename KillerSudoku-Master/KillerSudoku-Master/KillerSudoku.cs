﻿using System;
using System.Windows.Forms;

namespace KillerSudoku_Master
{
	
	public static class KillerSudoku
	{
		public static string FengDesktopDirectory = "D:\\josep\\Documents\\GitRepos\\KillerSudoku\\";
        public static string JuandibpDirectory = "C:\\Users\\juand\\Documents\\GitHub\\KillerSudoku\\KillerSudoku\\";
        public static string currentUser=JuandibpDirectory;
		[STAThread]
		public static void Main(String[] args)
		{

			KillerSudokuFrame test = new KillerSudokuFrame();
			Application.Run(test);
		}
	}
}
