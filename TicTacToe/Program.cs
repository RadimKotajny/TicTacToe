using System;
using System.Media;
using System.Reflection.Emit;
using System.Threading;

namespace ConsoleApplication1
{
	public class Global
	{
		public static int X = 5;
		public static int Y = 2;
		public static char OX;
		public static char[] CellsChar = new char[9];
		public static int SelectedCell = 4;
		public static bool GameOver = false;
		
		public static void BuildCon(char[] cell)
		{
			Console.Clear();
			int lastNum = 0;
			int i2;
			Console.WriteLine("-----------");
			for (int i = 0; i < 3; i++)
			{
				Console.Write("|");
				for (i2 = lastNum; i2 < lastNum + 3; i2++)
				{
					Console.Write(" " + cell[i2] + " ");
				}
				lastNum = i2;
				Console.Write("|\n");
			}
			Console.WriteLine("-----------");
			Console.SetCursorPosition(Global.X, Global.Y);
		}
	}
	public class Player
	{
		private static void PlayerDecision()
		{
			bool cycleContinue = false;
			while(cycleContinue == false)
			{
				switch (Console.ReadKey().Key)												
				{
					case ConsoleKey.UpArrow:
						if (Global.Y > 1)
						{
							Global.Y = Global.Y - 1;
							Console.SetCursorPosition(Global.X,Global.Y);
							Global.SelectedCell = Global.SelectedCell - 3;
							Global.BuildCon(Global.CellsChar);
						}
						else
						{
							Console.SetCursorPosition(Global.X, Global.Y); 
						}
						break;
					case ConsoleKey.LeftArrow:
						if (Global.X > 2)
						{
							Global.X = Global.X - 3;
							Console.SetCursorPosition(Global.X,Global.Y);	
							Global.SelectedCell = Global.SelectedCell - 1;
							Global.BuildCon(Global.CellsChar);
						}
						else
						{
							Console.SetCursorPosition(Global.X, Global.Y); 
						}
						break;
					case ConsoleKey.DownArrow:
						if (Global.Y < 3)
						{
							Global.Y = Global.Y + 1;
							Console.SetCursorPosition(Global.X, Global.Y);
							Global.SelectedCell = Global.SelectedCell + 3;
							Global.BuildCon(Global.CellsChar);
						}
						else
						{
							Console.SetCursorPosition(Global.X, Global.Y); 
						}
						break;
					case ConsoleKey.RightArrow:
						if (Global.X < 8)
						{
							Global.X = Global.X + 3;
							Console.SetCursorPosition(Global.X, Global.Y); 
							Global.SelectedCell = Global.SelectedCell + 1;
							Global.BuildCon(Global.CellsChar);
						}
						else
						{
							Console.SetCursorPosition(Global.X, Global.Y); 
						}
						break;
					case ConsoleKey.Enter:
						Global.CellsChar[Global.SelectedCell] = Global.OX;
						Global.SelectedCell = 4;
						Global.X = 5;
						Global.Y = 2;
						cycleContinue = true;
						break;
				}
			}
		}
		public static void First()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Global.BuildCon(Global.CellsChar);
			Console.SetCursorPosition(Global.X, Global.Y);
			Global.OX = 'X';
			PlayerDecision();
		}
		public static void Second()
		{
			Global.BuildCon(Global.CellsChar);
			Console.SetCursorPosition(Global.X, Global.Y);
			Console.ForegroundColor = ConsoleColor.Cyan;
			Global.OX = 'O';
			PlayerDecision();
		}
	}
	internal class Program
	{
		public static void CheckCharacter(char var1)
		{
			if (var1 == 'X')
			{
				Console.Clear();
				Console.WriteLine("X has won!");
				Global.GameOver = true;
			}
			else if (var1 == 'O')
			{
				Console.Clear();
				Console.WriteLine("O has won!");
				Global.GameOver = true;
			}
		}
		public static void Main(string[] args)
		{
			Console.SetWindowSize(50, 10);
			Console.Title = "OX Game | made by Radim Kotajny";

			void Reset()
			{
				Console.SetCursorPosition(5, 2);
				Console.Clear();
			}
			
			// DO ONCE:	
			for (int counter = 0; counter < 9; counter++)
			{
				Global.CellsChar[counter] = '-';
			}
			
			int keyPressedCounter = 0;
			while (Global.GameOver == false)
			{
				if (keyPressedCounter % 2 == 0)
				{
					Player.First();
					Reset();
				}
				else
				{
					Player.Second();
					Reset();
				}
				keyPressedCounter++;
				if (Global.CellsChar[0] == Global.CellsChar[1] && Global.CellsChar[1] == Global.CellsChar[2])
				{
					CheckCharacter(Global.CellsChar[0]);
				}
				else if (Global.CellsChar[3] == Global.CellsChar[4] && Global.CellsChar[4] == Global.CellsChar[5])
				{
					CheckCharacter(Global.CellsChar[3]);
				}
				else if (Global.CellsChar[6] == Global.CellsChar[7] && Global.CellsChar[7] == Global.CellsChar[8])
				{
					CheckCharacter(Global.CellsChar[6]);
				}
				else if (Global.CellsChar[0] == Global.CellsChar[4] && Global.CellsChar[4] == Global.CellsChar[8])
				{
					CheckCharacter(Global.CellsChar[0]);
				}
				else if (Global.CellsChar[1] == Global.CellsChar[4] && Global.CellsChar[4] == Global.CellsChar[7])
				{
					CheckCharacter(Global.CellsChar[1]);
				}
				else if (Global.CellsChar[2] == Global.CellsChar[5] && Global.CellsChar[5] == Global.CellsChar[8])
				{
					CheckCharacter(Global.CellsChar[2]);
				}
				else if (Global.CellsChar[0] == Global.CellsChar[4] && Global.CellsChar[4] == Global.CellsChar[8])
				{
					CheckCharacter(Global.CellsChar[0]);
				}
				else if (Global.CellsChar[2] == Global.CellsChar[4] && Global.CellsChar[4] == Global.CellsChar[6])
				{
					CheckCharacter(Global.CellsChar[2]);
				}
				else
				{
					int checker = 0;
					for (int i = 0; i < 9; i++)
					{
						if (Global.CellsChar[i] != '-')
						{
							checker++;
						}
					}
					if (checker == 9)
					{
						Console.Clear();
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.WriteLine("It's a draw!");
						Console.ReadKey();
					}
				}
			}
			Console.ReadKey();
		}
	}
}