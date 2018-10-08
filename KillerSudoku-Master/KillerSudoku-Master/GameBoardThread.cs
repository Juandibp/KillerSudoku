using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KillerSudoku_Master
{
	public class GameBoardThread
	{
		KillerSudokuGrid parent;
		Semaphore sem;
		string threadName;
		Board gameBoard;

		public GameBoardThread(Semaphore sem, String threadName, Board gameBoard, KillerSudokuGrid father)
		{
			this.sem = sem;
			this.threadName = threadName;
			this.gameBoard = new Board(gameBoard);
			this.parent = father;
			Thread th = new Thread(Start);
		}

		public void Start()
		{
			Console.WriteLine("Se inicio la ejecucion en el hilo"+this.threadName);
			if (backtrackingRandom(0, ArrayListMatrix.copyArrayList(gameBoard.possibleNumRows), ArrayListMatrix.copyArrayList(gameBoard.possibleNumColumns)))
			{
				try{
					sem.WaitOne();
					Shared.finished = true;
					Console.WriteLine("Terminoi primero el hilo "+this.threadName);
					this.parent.desplegarConSolucion(this.gameBoard);
					sem.Release();
				}catch (ThreadInterruptedException ex)
				{
					Console.WriteLine(ex.StackTrace);
				}
			}
		}

		private List<int> getAllNumbers(Operation op, int maxRepeated)
		{
			int y;
			int x;
			HashSet<int> setX;
			HashSet<int> setY;
			List<int> possibleNum = new List<int>();
			for (int i = 0; i < op.cells.Count; i++)
			{
				Cell cell = op.cells.ElementAt(i);
				x = cell.posX;
				y = cell.posY;
				setX = new HashSet<int>(gameBoard.possibleNumColumns.ElementAt(x));
				setY = new HashSet<int>(gameBoard.possibleNumRows.ElementAt(y));
				setX.Intersect(setY);//RetainAll(), check in case it isnt the same result
				int[] partialPossible = setX.ToArray();
				for (int j = 0; j < setX.Count; j++)
				{
					if (frequency(possibleNum, partialPossible[j]) < maxRepeated)
					{
						possibleNum.Add(partialPossible[j]);
					}
				}
			}
			return possibleNum;
		}

		private int frequency(List<int> possibleNum, int partialPossibleNum)
		{
			int hits = 0;
			for (int i = 0; i < possibleNum.Count; i++)
			{
				if (possibleNum.ElementAt(i) == partialPossibleNum)
				{
					hits += 1;
				}
				else
				{
					continue;
				}
			}
			return hits;
		}

		private bool removeInvalidAux(List<int> permutations, List<Cell> cells, List<List<int>> possibleRows, List<List<int>> possibleColumns)
		{
			int posx, posy;

			for (int x = 0; x < permutations.Count(); x++)
			{
				posx = cells.ElementAt(x).posX;
				posy = cells.ElementAt(x).posY;

				if (!possibleRows.ElementAt(posy).Contains(permutations.ElementAt(x)) || !possibleColumns.ElementAt(posx).Contains(permutations.ElementAt(x)))
				{
					return false;
				}
			}
			for (int i = 0; i < permutations.Count(); i++)
			{
				for (int j = 0; j < permutations.Count(); j++)
				{
					if (j != i)
					{
						if (cells.ElementAt(i).posX == cells.ElementAt(j).posX || cells.ElementAt(i).posY == cells.ElementAt(j).posY)
						{
							if (permutations.ElementAt(i).Equals(permutations.ElementAt(j)))
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}

		private List<List<int>> removeInvalidOperations(List<List<int>> permutations, Operation op, List<List<int>> possibleRows, List<List<int>> possibleColumns)
		{
			List<List<int>> solution = new List<List<int>>();
			for (int i = 0; i < permutations.Count; i++)
			{
				List<int> part = permutations.ElementAt(i);
				if (removeInvalidAux(part, op.cells, possibleRows, possibleColumns))
				{
					solution.Add(part);
				}
			}
			return solution;
		}

		private List<List<int>> deleteReps(List<List<int>> input)
		{
			List<List<int>> newSolution = new List<List<int>>();
			for (int i = 0; i < input.Count; i++)
			{
				List<int> part = input.ElementAt(i);
				if (!newSolution.Contains(part))
				{
					newSolution.Add(part);
				}
			}
			return newSolution;
		}

		private List<List<int>> getAllPermutations(List<List<int>> solution)
		{
			List<List<int>> newSolution = new List<List<int>>(solution);
			for (int i = 0; i < solution.Count; i++)
			{
				newSolution.AddRange(permutation(new List<int>(solution.ElementAt(i))));
			}
			newSolution = deleteReps(newSolution);
			return newSolution;
		}

		public List<List<int>> permutation(List<int> nums)
		{
			List<List<int>> accum = new List<List<int>>();
			accum = permutationAux(accum, new List<int>(), nums);
			return accum;
		}

		private List<List<int>> permutationAux(List<List<int>> accum, List<int> prefix, List<int> nums)
		{
			int n = nums.Count();
			if (n == 0)
			{
				accum.Add(prefix);
			}
			else
			{
				for (int i = 0; i < n; ++i)
				{
					List<int> newPrefix = new List<int>();
					newPrefix.AddRange(prefix);
					newPrefix.Add(nums.ElementAt(i));
					List<int> numsLeft = new List<int>();
					numsLeft.AddRange(nums);
					numsLeft.Remove(i);
					permutationAux(accum, newPrefix, numsLeft);
				}
			}
			return accum;
		}

		private List<List<int>> possibleSubtractionSubset(int subsetSize, int result, List<int> inputNumbers)
		{
			List<List<int>> solutions = new List<List<int>>();
			HashSet<int> initialNumb = new HashSet<int>(inputNumbers);
			List<int> possibilityCopy;
			List<List<int>> solutionPermutation;
			int resultingSum;
			List<List<int>> partialSolution;
			for (int i = 0; i < initialNumb.Count; i++)
			{
				int initial = initialNumb.ElementAt(i);
				resultingSum = initial + ((int)-result);
				if (resultingSum >= 0)
				{
					possibilityCopy = new List<int>(inputNumbers);
					possibilityCopy.Remove(initial);
					partialSolution = possibleSumSubset(subsetSize - 1, resultingSum, new List<int>(possibilityCopy), new List<int>(), new List<List<int>>());
					for (int j = 0; j < partialSolution.Count; j++)
					{
						List<int> partialArray = partialSolution.ElementAt(j);
						solutionPermutation = permutation(new List<int>(partialArray));
						for (int k = 0; i < solutionPermutation.Count; k++)
						{
							List<int> permutaton = solutionPermutation.ElementAt(k);
							permutaton.Insert(0, initial);
							if (!solutions.Contains(permutaton))
							{
								solutions.Add(permutaton);
							}
						}

					}
				}
			}
			return solutions;
		}

		private List<List<int>> possibleSumSubset(int subsetSize, int result, List<int> inputNumbers, List<int> partial, List<List<int>> solutions)
		{
			int s = 0;
			List<int> remaining;
			List<int> partial_rec;
			for (int k = 0; k < partial.Count; k++)
			{
				int x = partial.ElementAt(k);
				s += x;
			}
			if (s == result && partial.Count == subsetSize)
			{
				if (!solutions.Contains(partial))
				{
					solutions.Add(partial);
				}
			}

			if (s > result || partial.Count > subsetSize)
			{
				return null;
			}
			for (int i = 0; i < inputNumbers.Count; i++)
			{
				remaining = new List<int>();
				int n = inputNumbers.ElementAt(i);
				for (int j = 1 + i; j < inputNumbers.Count; j++)
				{
					remaining.Add(inputNumbers.ElementAt(j));
				}
				partial_rec = new List<int>(partial);
				partial_rec.Add(n);
				possibleSumSubset(subsetSize, result, remaining, partial_rec, solutions);
			}
			return solutions;
		}

		private List<List<int>> possibleMultiplicationSubset(int subsetSize, int result, List<int> inputNumbers, List<int> partial, List<List<int>> solutions)
		{
			int s = 0;
			List<int> remaining;
			List<int> partial_rec;
			if (s > result || partial.Count > subsetSize)
			{
				return null;
			}
			if (partial.Count > 0)
			{
				s = partial.ElementAt(0);
			}
			for (int x = 1; x < partial.Count; x++)
			{
				s = s * partial.ElementAt(x);
			}
			if (s == result && partial.Count == subsetSize)
			{
				if (!solutions.Contains(partial))
				{
					solutions.Add(partial);
				}
			}

			for (int i = 0; i < inputNumbers.Count; i++)
			{
				remaining = new List<int>();
				int n = inputNumbers.ElementAt(i);
				for (int j = 1 + i; j < inputNumbers.Count; j++)
				{
					remaining.Add(inputNumbers.ElementAt(j));
				}
				partial_rec = new List<int>(partial);
				partial_rec.Add(n);
				possibleMultiplicationSubset(subsetSize, result, remaining, partial_rec, solutions);
			}
			return solutions;
		}

		private static bool isFloat(int dividend, int divisor)
		{
			return !(dividend % divisor == 0);
		}

		private List<List<int>> possibleDivisionSubset(int subsetSize, int result, List<int> inputNumbers, List<int> partial, List<List<int>> solutions)
		{
			int s = 0;
			List<int> remaining;
			List<int> partial_rec;
			if (partial.Count > 0 && !partial.Contains((int)0))
			{
				s = partial.ElementAt(0);
				for (int x = 1; x < partial.Count; x++)
				{
					if (isFloat(s, partial.ElementAt(x)))
					{
						s = -1;
						break;
					}
					s = s / partial.ElementAt(x);
				}
			}
			if (s == -1 || partial.Count > subsetSize)
			{
				return null;
			}

			if (s == result && partial.Count == subsetSize)
			{
				if (!solutions.Contains(partial))
				{
					solutions.Add(partial);
				}
			}
			if (subsetSize == 2)
			{
				for (int i = inputNumbers.Count - 1; i > -1; i--)
				{
					remaining = new List<int>();
					int n = inputNumbers.ElementAt(i);
					for (int j = i - 1; j > -1; j--)
					{
						remaining.Add(inputNumbers.ElementAt(j));
					}
					partial_rec = new List<int>(partial);
					partial_rec.Add(n);
					possibleDivisionSubset(subsetSize, result, remaining, partial_rec, solutions);
				}
			}
			else
			{
				for (int i = inputNumbers.Count - 1; i > -1; i--)
				{
					remaining = new List<int>(inputNumbers);
					int n = inputNumbers.ElementAt(i);
					remaining.Remove((int)n);
					partial_rec = new List<int>(partial);
					partial_rec.Add(n);
					possibleDivisionSubset(subsetSize, result, remaining, partial_rec, solutions);
				}
			}
			return solutions;
		}

		private List<List<int>> possibleModulusSubset(int result, List<int> inputNumbers)
		{
			List<List<int>> possibleSolution = new List<List<int>>();
			HashSet<int> initialNumb = new HashSet<int>(inputNumbers);
			List<int> partialSolution;
			List<int> possibilityCopy;
			while (inputNumbers.Contains((int)0))
			{
				inputNumbers.Remove((int)0);
			}
			for (int i = 0; i < initialNumb.Count; i++)
			{
				int initial = initialNumb.ElementAt(i);
				possibilityCopy = new List<int>(inputNumbers);
				possibilityCopy.Remove(initial);

				for (int j = 0; j < possibilityCopy.ElementAt(j); j++)
				{
					int possibility = possibilityCopy.ElementAt(j);
					partialSolution = new List<int>();
					if ((initial % possibility) == (result))
					{
						partialSolution.Add(initial);
						partialSolution.Add(possibility);
						if (!possibleSolution.Contains(partialSolution))
						{
							possibleSolution.Add(partialSolution);
						}
					}
				}
			}
			return possibleSolution;
		}

		private List<List<int>> findPower(int result)
		{
			List<List<int>> solution = new List<List<int>>();
			List<int> solutionAux = new List<int>();

			solutionAux.Add((int)Math.Pow(result, (1 / 3)));
			solution.Add(solutionAux);
			return solution;
		}

		private bool backtrackingRandom(int indice, List<List<int>> NumPossibleRows, List<List<int>> NumPossibleColumns)
		{
			if (!Shared.finished)
			{

				Random r = new Random();
				int x;
				int removable;

				if (indice >= gameBoard.operations.Count)
				{
					return true;
				}

				List<List<int>> possibleSolutions = possibleSolution(gameBoard.operations.ElementAt(indice), NumPossibleRows, NumPossibleColumns);
				List<List<int>> remainingNumPossibleColumns;
				List<List<int>> remainingNumPossibleRows;
				Operation currentOp = gameBoard.operations.ElementAt(indice);
				while (possibleSolutions.Count > 0 && !Shared.finished)
				{

					x = r.Next(possibleSolutions.Count);
					remainingNumPossibleColumns = ArrayListMatrix.copyArrayList(NumPossibleColumns);
					remainingNumPossibleRows = ArrayListMatrix.copyArrayList(NumPossibleRows);
					//se asigna una por una cada una de las solucines posibles, quitando del tablero de posibilidades en las filas y columnas respectivas de cada una de las celdas asignadas
					for (int y = 0; y < gameBoard.operations.ElementAt(indice).cells.Count; y++)
					{
						removable = possibleSolutions.ElementAt(x).ElementAt(y);
						currentOp.cells.ElementAt(y).number = removable;
						remainingNumPossibleColumns = removeNumberUsedC(removable, remainingNumPossibleColumns, currentOp.cells.ElementAt(y).posX, currentOp.cells.ElementAt(y).posY);
						remainingNumPossibleRows = removeNumberUsedR(removable, remainingNumPossibleRows, currentOp.cells.ElementAt(y).posX, currentOp.cells.ElementAt(y).posY);

					}
					if (threadName.Equals("thread0") && !Shared.finished)
					{
						parent.displayOpResult(indice, possibleSolutions.ElementAt(x), gameBoard);
					}
					if (backtrackingRandom(indice + 1, remainingNumPossibleRows, remainingNumPossibleColumns))
					{
						return true;
					}
					possibleSolutions.RemoveAt(x);
					if (threadName.Equals("thread0") && !Shared.finished)
					{
						parent.removeOpResult(indice, gameBoard);
					}
				}

			}
			return false;
		}

		private List<List<int>> removeNumberUsedR(int number, List<List<int>> NumPossibleRows, int posX, int posY)
		{
			NumPossibleRows.ElementAt(posY).Remove((int)number);
			return NumPossibleRows;
		}

		private List<List<int>> removeNumberUsedC(int number, List<List<int>> NumPossibleColumns, int posX, int posY)
		{
			NumPossibleColumns.ElementAt(posX).Remove((int)number);
			return NumPossibleColumns;
		}

		private List<List<int>> possibleSolution(Operation op, List<List<int>> possibleRows, List<List<int>> possibleColumns)
		{

			List<List<int>> solutions = new List<List<int>>();
			List<int> possibleNum = new List<int>();
			switch (op.cellAmount)
			{
				case (1):
					possibleNum = getAllNumbers(op, 1);
					break;
				case (2):
					possibleNum = getAllNumbers(op, 1);
					break;
				case (4):
					possibleNum = getAllNumbers(op, 2);
					break;
			}

			switch (op.operationType)
			{
				case MULT:
					solutions = possibleMultiplicationSubset(op.cellAmount, op.operationResult, possibleNum, new List<int>(), new List<List<int>>());
					break;
				case SUM:
					solutions = possibleSumSubset(op.cellAmount, op.operationResult, possibleNum, new List<int>(), new List<List<int>>());
					break;


			}
			if (op.operationType == Operation.OperationType.SUM || op.operationType == Operation.OperationType.MULT)
			{
				solutions = getAllPermutations(new List<List<int>>(solutions)); //hay que encontrar las permutaciones de las posibilidades dadas
			}

			solutions = removeInvalidOperations(new List<List<int>>(solutions), op, possibleRows, possibleColumns); //hay que quitar aquellas permutaciones que no sean validas  
			return solutions;
		}

	}
}
