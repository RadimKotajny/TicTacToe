using System;
using System.Media;
using System.Threading;

namespace ConsoleApplication1
{
	public class Globals
	{
		public static int X = 0;
		public static int Y = 0;
	}
	public class Player
	{
		private static char OX;
		private static int decision = 0;
		public static void First()
		{
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.ForegroundColor = ConsoleColor.Yellow;
			OX = 'X';
			while (decision == 1)
			{
				switch (Console.ReadKey().Key)
				{
					case ConsoleKey.W:
						Console.SetCursorPosition(X,Y); 
						break;
				}
			}
		}

		public static void Second()
		{
			Console.BackgroundColor = ConsoleColor.Yellow;
			Console.ForegroundColor = ConsoleColor.Blue;
			OX = 'O';
			while (decision == 2)
			{
				
			}
		}
	}
	internal class Program
	{
		public static void buildCon(char[] cell)
		{
			Console.WriteLine("-------");
			for (int i = 0; i < 3; i++)
			{
				Console.Write("|");
				for (int i2 = 0; i2 < 3; i2++)
				{
					Console.WriteLine(" " + cell[i2]);
				}
				Console.Write(" |\n");
			}
			Console.WriteLine("-------");
		}
		public static void checkCharacter(char var1)
		{
			if (var1 == 'X')
			{
				Console.WriteLine("X has won!");
			}
			else
			{
				Console.WriteLine("O has won!");
			}
		}
		public static void Main(string[] args)
		{
			// DO ONCE: 
			char[] cellsChar = new char[8];
			for (int counter = 0; counter < 8; counter++)
			{
				cellsChar[counter] = '-';
			}
			
			
			int keyPressedCounter = 0;
			while (!KeyPressed)						//TODO: fix function keyPressed
			{
				buildCon(cellsChar);				//TODO: select character depending on player type
				Thread.Sleep(250);
				if (keyPressedCounter % 2 == 0)
				{
					Player.First();
				}
				else
				{
					Player.Second();
				}
				keyPressedCounter++;
			}


			/*
			const int maxLength = 9;
			Console.WriteLine("Enter cells: ");
			string cells = Console.ReadLine();
			if (cells.Length > maxLength)
			{
				cells = cells.Substring(0, maxLength);
			}
			char[] cellsChar = new char[8];
			cellsChar = cells.ToCharArray();
			Console.Clear();
			Console.WriteLine("-----------");
			
			int lastNum = 0;
			int cycle;
			for (int i2 = 0; i2 < 3; i2++)
			{
				Console.Write("|");
				for (cycle = lastNum; cycle < lastNum + 3; cycle++)
				{
					Console.Write(" " + cellsChar[cycle] + " ");
				}
				lastNum = cycle;
				Console.Write("|\n");
			}
			Console.WriteLine("-----------");
			
			*/
			
			if (cellsChar[0] == cellsChar[1] && cellsChar[1] == cellsChar[2])
			{
				checkCharacter(cellsChar[0]);
			}
			else if (cellsChar[3] == cellsChar[4] && cellsChar[4] == cellsChar[5])
			{
				checkCharacter(cellsChar[3]);
			}
			else if (cellsChar[6] == cellsChar[7] && cellsChar[7] == cellsChar[8])
			{
				checkCharacter(cellsChar[6]);
			}
			else if (cellsChar[0] == cellsChar[4] && cellsChar[4] == cellsChar[8])
			{
				checkCharacter(cellsChar[0]);
			}
			else if (cellsChar[1] == cellsChar[4] && cellsChar[4] == cellsChar[7])
			{
				checkCharacter(cellsChar[1]);
			}
			else if (cellsChar[2] == cellsChar[5] && cellsChar[5] == cellsChar[8])
			{
				checkCharacter(cellsChar[2]);
			}
			else if (cellsChar[0] == cellsChar[4] && cellsChar[4] == cellsChar[8])
			{
				checkCharacter(cellsChar[0]);
			}
			else if (cellsChar[2] == cellsChar[4] && cellsChar[4] == cellsChar[6])
			{
				checkCharacter(cellsChar[2]);
			}
			/*else if (cellsChar[1] != '1' && cellsChar[2] != '2' && 
					cellsChar[3] != '3' && cellsChar[4] != '4' && cellsChar[5] != '5' && cellsChar[6]
					!= '6' && cellsChar[7] != '7' && cellsChar[8] != '8' && cellsChar[9] != '9')
			{
				Console.WriteLine("\nERROR");
			}*/
			else
			{
				Console.Write("\nRemiza.\nNikdo nevyhral :/");
			}
			
			Console.ReadLine(); 
		}
	}
}