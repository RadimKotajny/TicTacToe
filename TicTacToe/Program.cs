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
	}
	public class Player
	{
		private static void PlayerDecision()	//TODO: fix statements
		{
			bool cycleContinue = false;
			while(cycleContinue == false)
			{
				switch (Console.ReadKey().Key)												
				{
					case ConsoleKey.UpArrow:
						Global.Y = Global.Y - 1;
						Console.SetCursorPosition(Global.X,Global.Y); 
						break;
					case ConsoleKey.LeftArrow:
						//if (Global.X > 1)
						//{
						Global.X = Global.X - 3;
						Console.SetCursorPosition(Global.X,Global.Y);	
						//}
						break;
					case ConsoleKey.DownArrow:
						Global.Y = Global.Y + 1;
						Console.SetCursorPosition(Global.X, Global.Y);
						break;
					case ConsoleKey.RightArrow:
						//if(Global.X < )
						Global.X = Global.X + 2;
						Global.X++; 
						Console.SetCursorPosition(Global.X, Global.Y); 
						break;
					case ConsoleKey.Enter:
						Console.Write(Global.OX);
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
			Global.OX = 'X';
			PlayerDecision();
		}
		public static void Second()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Global.OX = 'O';
			PlayerDecision();
		}
	}
	internal class Program
	{
		public static void BuildCon(char[] cell)
		{
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
		}
		public static void CheckCharacter(char var1)
		{
			if (var1 == 'X')
			{
				Console.Clear();
				Console.WriteLine("X has won!");
			}
			else if (var1 == 'O')
			{
				Console.Clear();
				Console.WriteLine("O has won!");
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
			//char[] cellsChar = new char[8];								//is global variable
			for (int counter = 0; counter < 9; counter++)					//initialize '-' to arrays
			{
				Global.CellsChar[counter] = '-';
			}
			
			int keyPressedCounter = 0;
			while (true)
			{
				BuildCon(Global.CellsChar);
				Console.SetCursorPosition(Global.X, Global.Y);
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
			}
		}
	}
}