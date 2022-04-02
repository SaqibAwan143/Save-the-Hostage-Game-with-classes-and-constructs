using EZInput;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Save_the_Hostage__Game___with_classes_and_constructs.classes;

namespace game
{
	class Program
	{
		

		static char[,] maze = new char[25, 107];

		//              global variables



		static int score = 0;
		static int ghostX = 23; // X Coordinate of Ghost
		static int ghost1X = 9; // X Coordinate of Ghost
		static int ghostY = 36; // Y Coordinate of Ghost
		static int ghost1Y = 20; // Y Coordinate of Ghost
		static int ghost2X = 15;
		static int ghost2Y = 40;
		static int verX = 2;
		static int verY = 54;
		static int horX = 19;
		static int horY = 12;
		static int pX = 16;
		static int pY = 3;
		static int hostX = 23;
		static int hostY = 63;
		static int firehorX = 12;
		static int firevertX = 21;
		static int firehorY = 3;
		static int firevertY = 32;

		static char previousItem2 = ' ';
		static char previousItem = ' ';
		static char previousItem1 = ' ';
		static char previousitem1_2 = ' ';
		static char previousItem3 = ' ';
		static char random_prev = ' ';
		static char hostprevious = ' ';
		static int moveCount = 0;
		static int moveCounth = 0;
		static int it = 0;
		static int mit = 33;
		static bool energizer = false;
		static int checkpost = 0;
		static int firecount1 = 0;
		static int firecount2 = 0;
		static bool restart1 = false;
		static bool restart2 = false;
		static int life = 3;
		static int health = 3;

		//                      Start of main function
		static void Main()
		{
			loadfromfile();
			int player_X = 2;
			int player_Y = 2;
			player_data info = new player_data(player_X,player_Y);
			while (true)
			{
				Console.Clear();
				header();
				int op;
				Console.Write(" ");
				Console.Write("\n");
				Console.Write("          1: Play Game ");
				Console.Write("\n");
				Console.Write(" ");
				Console.Write("\n");
				Console.Write("          2: Instructions ");
				Console.Write("\n");
				Console.Write(" ");
				Console.Write("\n");
				Console.Write("          3: Exit");
				Console.Write("\n");
				op = int.Parse(Console.ReadLine());

				if (op == 1)
				{
					bool gamerunning = true;
					Console.Clear();
					printmaze();
					Console.SetCursorPosition(info.player_Y, info.player_X);
					Console.Write("S");
					while (gamerunning && life > 0)
					{
						Thread.Sleep(75);
						Console.SetCursorPosition(81, 10);
						Console.Write("Checkpostes left = ");
						Console.Write(4 - checkpost);
						Console.SetCursorPosition(83, 14);
						Console.Write("Lives left = ");
						Console.Write(life);

						if (checkpost == 2)
						{
							maze[6, 27] = ' ';
							maze[6, 28] = ' ';
							Console.SetCursorPosition(27, 6);
							Console.Write(' ');
							Console.SetCursorPosition(28, 6);
							Console.Write(' ');
						}
						else if (checkpost == 3)
						{
							maze[20, 61] = ' ';
							maze[20, 62] = ' ';
							maze[20, 63] = ' ';
							Console.SetCursorPosition(61, 20);
							Console.Write(' ');
							Console.SetCursorPosition(62, 20);
							Console.Write(' ');
							Console.SetCursorPosition(63, 20);
							Console.Write(' ');
							maze[22, 73] = ' ';
							maze[23, 74] = ' ';
							Console.SetCursorPosition(73, 22);
							Console.Write(' ');
							Console.SetCursorPosition(74, 22);
							Console.Write(' ');
						}
						else if (checkpost == 4)
						{
							maze[16, 4] = ' ';
							maze[16, 5] = ' ';
							maze[16, 6] = ' ';
							Console.SetCursorPosition(4, 16);
							Console.Write(' ');
							Console.SetCursorPosition(5, 16);
							Console.Write(' ');
							Console.SetCursorPosition(6, 16);
							Console.Write(' ');
						}
						if ((energizer == true && it <= mit))
						{
							while (it <= mit)
							{
								hostmovement(ref info.player_X, ref info.player_Y);
								Thread.Sleep(75);
								// if (ghostmovement() && ghostmovement1() && vertical_ghost() && horizontal_ghost())

								if (energizer)
								{
									Console.SetCursorPosition(81, 5);
									Console.Write("Iterations Left : ");
									Console.Write(mit - it);
									Console.Write(" ");
								}
								it++;

								if (Keyboard.IsKeyPressed(Key.LeftArrow))
								{
									energyleft(ref info.player_X, ref info.player_Y);
								}
								if (Keyboard.IsKeyPressed(Key.RightArrow))
								{
									energyright(ref info.player_X, ref info.player_Y);
								}
								if (Keyboard.IsKeyPressed(Key.UpArrow))
								{
									energyup(ref info.player_X, ref info.player_Y);
								}
								if (Keyboard.IsKeyPressed(Key.DownArrow))
								{
									energydown(ref info.player_X, ref info.player_Y);
								}
								if (Keyboard.IsKeyPressed(Key.Escape))
								{
									gamerunning = false;
								}
							}
							energizer = false;
							it = 0;
						}
						else
						{
							energizer = false;
							it = 0;
						}
						if (ghostmovement(ref info.player_X, ref info.player_Y) && ghostmovement1(ref info.player_X, ref info.player_Y) && vertical_ghost(ref info.player_X, ref info.player_Y) && horizontal_ghost(ref info.player_X, ref info.player_Y) && hostmovement(ref info.player_X, ref info.player_Y)) //&& ghostmovement2()
						{

							gamerunning = true;
						}
						else
						{
							if (energizer)
							{
								gamerunning = true;
							}
							else
							{
								gamerunning = false;
							}
						}
						if (energizer == true && !(it <= mit))
						{
							gamerunning = true;
						}
						if (ghostmovement(ref info.player_X, ref info.player_Y) && ghostmovement1(ref info.player_X, ref info.player_Y) && vertical_ghost(ref info.player_X, ref info.player_Y) && horizontal_ghost(ref info.player_X, ref info.player_Y)) //&& firehor()
						{
							gamerunning = true;
						}
						else
						{
							gamerunning = false;
						}
						/*else
						{
							if (!(energizer==true))
							{
								energizer=false;
								it=0;
							}
							else
							{
								gamerunning = false;
							}
						}*/
						//        random_running = moverandom_ghost();
						if (Keyboard.IsKeyPressed(Key.LeftArrow))
						{
							moveleft(ref info.player_X, ref info.player_Y);
						}
						if (Keyboard.IsKeyPressed(Key.RightArrow))
						{
							moveright(ref info.player_X, ref info.player_Y);
						}
						if (Keyboard.IsKeyPressed(Key.UpArrow))
						{
							moveup(ref info.player_X, ref info.player_Y);
						}
						if (Keyboard.IsKeyPressed(Key.DownArrow))
						{
							movedown(ref info.player_X, ref info.player_Y);
						}
						if (Keyboard.IsKeyPressed(Key.Escape))
						{
							gamerunning = false;
						}
					}
					gameover(ref info.player_X, ref info.player_Y);
				}

				if (op == 2)
				{
					Console.Write("                     Instructions");
					Console.Write("\n");
					Console.Write(" ");
					Console.Write("\n");
					Console.Write("     1. Your Player is S ");
					Console.Write("\n");
					Console.Write(" ");
					Console.Write("\n");
					Console.Write("     2. You have to save the Hostage which is E");
					Console.Write("\n");
					Console.Write(" ");
					Console.Write("\n");
					Console.Write("     3. You have to avoid from different ghosts and fires(+)");
					Console.Write("\n");
					Console.Write(" ");
					Console.Write("\n");
					Console.Write("     4. Take the checkpoints(*) to open the different gates");
					Console.Write("\n");
					Console.Write(" ");
					Console.Write("\n");
					Console.Write("     5. Also take the energizer to avoid from ghosts for a limited time");
					Console.Write("\n");
					Console.Write(" ");
					Console.Write("\n");
					Console.Write("     6. Press right key for right move and left key for left move");
					Console.Write("\n");
					Console.Write(" ");
					Console.Write("\n");
					Console.Write("     7. Press ESCAPE for exit the Game");
					Console.Write("\n");
					Console.ReadKey(true);
				}
				if (op == 3)
				{
					Console.Clear();
					Console.Write("Thanks for playing...");
					Console.Write("\n");
					Console.WriteLine("Press Any Key to continue..."); Console.ReadKey();
					break;
				}
			}
		}
		//                          Functions Prototypes
		static void loadfromfile()
		{
			string p = "mymaze1.txt";
			StreamReader sr = new StreamReader(p);
			string line;
			for (int row = 0; row < 25; row++)
			{
				line = sr.ReadLine();
				for (int col = 0; col < 107 - 1; col++)
				{
					maze[row, col] = line[col];
				}
			}
			sr.Close();
		}
		static void printmaze()
		{
			for (int row = 0; row < 25; row = row + 1)
			{
				for (int col = 0; col < 107; col = col + 1)
				{
					if (maze[row, col] == '@' || maze[row, col] == '&' || maze[row, col] == '#')
					{
						Console.ForegroundColor = ConsoleColor.DarkMagenta;
						Console.BackgroundColor = ConsoleColor.DarkMagenta;
					}
					if (maze[row, col] == '|')
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.BackgroundColor = ConsoleColor.Green;

					}
					if (maze[row, col] == '*')
					{
						Console.ForegroundColor = ConsoleColor.White;
					}
					if (maze[row, col] == '_')
					{
						Console.ForegroundColor = ConsoleColor.DarkRed;
						Console.BackgroundColor = ConsoleColor.DarkRed;
					}

					if (maze[row, col] == '<' || maze[row, col] == '>')
					{
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.BackgroundColor = ConsoleColor.DarkYellow;
					}
					if (maze[row, col] == ')' || maze[row, col] == '(')
					{
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.BackgroundColor = ConsoleColor.Blue;
					}
					if (maze[row, col] == '~')
					{
						Console.ForegroundColor = ConsoleColor.White;
					}
					Console.Write(maze[row, col]);
					Console.ResetColor();
				}
				Console.Write("\n");
			}
		}

		static void movedown(ref int pacmanX, ref int pacmanY)
		{

			if (maze[pacmanX + 1, pacmanY] == '*')
			{
				checkpost++;
			}
			if (maze[pacmanX + 1, pacmanY] == 'o')
			{
				energizer = true;
			}
			if (maze[pacmanX + 1, pacmanY] == 'F' || maze[pacmanX + 1, pacmanY] == 'H' || maze[pacmanX + 1, pacmanY] == 'V' || maze[pacmanX + 1, pacmanY] == 'R' || maze[pacmanX + 1, pacmanY] == 'J' || maze[pacmanX + 1, pacmanY] == '+')
			{

				gameover(ref pacmanX, ref pacmanY);
			}
			else if (maze[pacmanX + 1, pacmanY] != '#' && maze[pacmanX + 1, pacmanY] != '~' && maze[pacmanX + 1, pacmanY] != '@' && maze[pacmanX + 1, pacmanY] != '&' && maze[pacmanX + 1, pacmanY] != '|' && maze[pacmanX + 1, pacmanY] != '_' && maze[pacmanX + 1, pacmanY] != '<' && maze[pacmanX + 1, pacmanY] != '>' && maze[pacmanX + 1, pacmanY] != '(' && maze[pacmanX + 1, pacmanY] != ')' || maze[pacmanX + 1, pacmanY] == ' ' || maze[pacmanX + 1, pacmanY] == 'o' || maze[pacmanX + 1, pacmanY] == '*')
			{
				maze[pacmanX, pacmanY] = ' ';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write(" ");
				pacmanX = pacmanX + 1;
				/*if (maze[pacmanX][pacmanY] == '.')
				{
					calculateScore();
				}*/
				maze[pacmanX, pacmanY] = 'S';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write("S");
			}
		}
		static void moveup(ref int pacmanX, ref int pacmanY)
		{
			if (maze[pacmanX - 1, pacmanY] == '*')
			{
				checkpost++;
			}
			if (maze[pacmanX - 1, pacmanY] == 'o')
			{
				energizer = true;
			}
			if (maze[pacmanX - 1, pacmanY] == 'F' || maze[pacmanX - 1, pacmanY] == 'H' || maze[pacmanX - 1, pacmanY] == 'V' || maze[pacmanX - 1, pacmanY] == 'R' || maze[pacmanX - 1, pacmanY] == 'J' || maze[pacmanX - 1, pacmanY] == '+')
			{

				gameover(ref pacmanX, ref pacmanY);
			}
			else if (maze[pacmanX - 1, pacmanY] != '#' && maze[pacmanX - 1, pacmanY] != '~' && maze[pacmanX - 1, pacmanY] != '@' && maze[pacmanX - 1, pacmanY] != '&' && maze[pacmanX - 1, pacmanY] != '|' && maze[pacmanX - 1, pacmanY] != '_' && maze[pacmanX - 1, pacmanY] != '<' && maze[pacmanX - 1, pacmanY] != '>' && maze[pacmanX - 1, pacmanY] != '(' && maze[pacmanX - 1, pacmanY] != ')' || maze[pacmanX - 1, pacmanY] == ' ' || maze[pacmanX - 1, pacmanY] == 'o' || maze[pacmanX - 1, pacmanY] == '*')
			{
				maze[pacmanX, pacmanY] = ' ';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write(" ");
				pacmanX = pacmanX - 1;
				/*if (maze[pacmanX][pacmanY] == '.')
				{

					calculateScore();
				}*/
				maze[pacmanX, pacmanY] = 'S';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write("S");
			}
		}
		static void moveleft(ref int pacmanX, ref int pacmanY)
		{
			if (maze[pacmanX, pacmanY - 1] == '*')
			{
				checkpost++;
			}
			if (maze[pacmanX, pacmanY - 1] == 'o')
			{
				energizer = true;
			}
			if (maze[pacmanX, pacmanY - 1] == 'F' || maze[pacmanX, pacmanY - 1] == 'H' || maze[pacmanX, pacmanY - 1] == 'V' || maze[pacmanX, pacmanY - 1] == 'R' || maze[pacmanX, pacmanY - 1] == 'J' || maze[pacmanX, pacmanY - 1] == '+')
			{
				gameover(ref pacmanX, ref pacmanY);
			}
			else if (maze[pacmanX, pacmanY - 1] != '#' && maze[pacmanX, pacmanY - 1] != '~' && maze[pacmanX, pacmanY - 1] != '@' && maze[pacmanX, pacmanY - 1] != '&' && maze[pacmanX, pacmanY - 1] != '|' && maze[pacmanX, pacmanY - 1] != '_' && maze[pacmanX, pacmanY - 1] != '<' && maze[pacmanX, pacmanY - 1] != '>' && maze[pacmanX, pacmanY - 1] != '(' && maze[pacmanX, pacmanY - 1] != ')' || maze[pacmanX, pacmanY - 1] == ' ' || maze[pacmanX, pacmanY - 1] == 'o' || maze[pacmanX, pacmanY - 1] == '*')
			{
				maze[pacmanX, pacmanY] = ' ';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write(" ");
				pacmanY = pacmanY - 1;
				maze[pacmanX, pacmanY] = 'S';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write("S");
			}
		}
		static void moveright(ref int pacmanX, ref int pacmanY)
		{
			if (maze[pacmanX, pacmanY + 1] == '*')
			{
				checkpost++;
			}
			if (maze[pacmanX, pacmanY + 1] == 'o')
			{
				energizer = true;
			}
			if (maze[pacmanX, pacmanY + 1] == 'F' || maze[pacmanX, pacmanY + 1] == 'H' || maze[pacmanX, pacmanY + 1] == 'V' || maze[pacmanX, pacmanY + 1] == 'R' || maze[pacmanX, pacmanY + 1] == 'J' || maze[pacmanX, pacmanY + 1] == '+')
			{

				gameover(ref pacmanX, ref pacmanY);
			}
			else if (maze[pacmanX, pacmanY + 1] != '#' && maze[pacmanX, pacmanY + 1] != '~' && maze[pacmanX, pacmanY + 1] != '@' && maze[pacmanX, pacmanY + 1] != '&' && maze[pacmanX, pacmanY + 1] != '|' && maze[pacmanX, pacmanY + 1] != '_' && maze[pacmanX, pacmanY + 1] != '<' && maze[pacmanX, pacmanY + 1] != '>' && maze[pacmanX, pacmanY + 1] != '(' && maze[pacmanX, pacmanY + 1] != ')' || maze[pacmanX, pacmanY + 1] == ' ' || maze[pacmanX, pacmanY + 1] == 'o' || maze[pacmanX, pacmanY + 1] == '*')
			{
				maze[pacmanX, pacmanY] = ' ';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write(" ");
				pacmanY = pacmanY + 1;
				/*if (maze[pacmanX][pacmanY] == '.')
				{
					calculateScore();
				}*/
				maze[pacmanX, pacmanY] = 'S';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write("S");
			}
		}
		static void gameover(ref int pacmanX, ref int pacmanY)
		{
			if (life == 0)
			{
				Console.Clear();
				printmaze();
				// printScore();
				Console.Write("GAME OVER.");
				Console.Write("\n");
				Thread.Sleep(500);
				Console.WriteLine("Press Any Key to continue...");
				Console.ReadKey();
				Console.Clear();
				Environment.Exit(0);
			}
			else
			{
				for (int row = 0; row < 25; row++)
				{
					for (int col = 0; col < 80; col++)
					{
						if (maze[row, col] == 'S')
						{
							maze[row, col] = ' ';
							Console.SetCursorPosition(col, row);
							Console.Write(" ");
						}
					}
				}
				maze[pacmanX, pacmanY] = ' ';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write(' ');
				life--;
				pacmanX = 1;
				pacmanY = 2;
				maze[pacmanX, pacmanY] = 'S';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write('S');
			}
		}
		static int ghostdirection(ref int pacmanX, ref int pacmanY)
		{
			firehor(ref pacmanX, ref pacmanY);
			firevert(ref pacmanX, ref pacmanY);
			if (moveCount == 5)
			{
				Random r = new Random();
				int result = 1 + r.Next(4);
				moveCount = 0;
				return result;
			}
			moveCount++;
			int horizontal = pacmanY - ghostY;
			int vertical = pacmanX - ghostX;
			int absX;
			int absY;
			absX = vertical;
			if (vertical < 0)
			{
				absX = absX * (-1);
			}
			absY = horizontal;
			if (horizontal < 0)
			{
				absY = absY * (-1);
			}
			if (absX > absY)
			{
				if (vertical < 0)
				{
					return 3;
				}
				else
				{
					return 4;
				}
			}
			else
			{
				if (horizontal < 0)
				{
					return 1;
				}
				else
				{
					return 2;
				}
			}
		}
		static bool ghostmovement(ref int pacmanX, ref int pacmanY)
		{
			int value = ghostdirection(ref pacmanX, ref pacmanY);
			if (value == 1)
			{
				if (maze[ghostX, ghostY - 1] == ' ' || maze[ghostX, ghostY - 1] == 'S' || maze[ghostX, ghostY - 1] == 'E')
				{
					maze[ghostX, ghostY] = previousItem;
					if (previousItem != 'S' || previousItem != 'E')
					{
						Console.SetCursorPosition(ghostY, ghostX);
						Console.Write(previousItem);
					}
					if (previousItem == 'S' || previousItem == 'E')
					{
						Console.SetCursorPosition(ghostY, ghostX);
						Console.Write(' ');
					}
					ghostY = ghostY - 1;
					if (previousItem != 'S' || previousItem != 'E')
					{
						previousItem = maze[ghostX, ghostY];
					}
					if (previousItem == 'S' || previousItem == 'E')
					{
						previousItem = ' ';
					}
					if (maze[ghostX, ghostY] == 'S')
					{

						gameover(ref pacmanX, ref pacmanY);
					}
					if (maze[ghostX, ghostY] == 'E')
					{

						hostover();
					}
					maze[ghostX, ghostY] = 'F';
					Console.SetCursorPosition(ghostY, ghostX);
					Console.Write("F");
				}
			}
			if (value == 2)
			{

				if (maze[ghostX, ghostY + 1] == ' ' || maze[ghostX, ghostY + 1] == 'S' || maze[ghostX, ghostY + 1] == 'E')
				{
					maze[ghostX, ghostY] = previousItem;
					if (previousItem != 'S' || previousItem != 'E')
					{
						Console.SetCursorPosition(ghostY, ghostX);
						Console.Write(previousItem);
					}
					if (previousItem == 'S' || previousItem == 'E')
					{
						Console.SetCursorPosition(ghostY, ghostX);
						Console.Write(' ');
					}
					ghostY = ghostY + 1;
					if (previousItem != 'S' || previousItem != 'E')
					{
						previousItem = maze[ghostX, ghostY];
					}
					if (previousItem == 'S' || previousItem != 'E')
					{
						previousItem = ' ';
					}
					if (maze[ghostX, ghostY] == 'S')
					{

						gameover(ref pacmanX, ref pacmanY);
					}
					if (maze[ghostX, ghostY] == 'E')
					{

						hostover();
					}
					maze[ghostX, ghostY] = 'F';
					Console.SetCursorPosition(ghostY, ghostX);
					Console.Write("F");
				}
			}
			if (value == 3)
			{
				if (maze[ghostX - 1, ghostY] == ' ' || maze[ghostX - 1, ghostY] == 'S' || maze[ghostX - 1, ghostY] == 'E')
				{
					maze[ghostX, ghostY] = previousItem;
					if (previousItem != 'S' || previousItem != 'E')
					{

						Console.SetCursorPosition(ghostY, ghostX);
						Console.Write(previousItem);
					}
					if (previousItem == 'S' || previousItem != 'E')
					{
						Console.SetCursorPosition(ghostY, ghostX);
						Console.Write(' ');
					}
					ghostX = ghostX - 1;
					if (previousItem != 'S' || previousItem != 'E')
					{
						previousItem = maze[ghostX, ghostY];
					}
					if (previousItem == 'S' || previousItem == 'E')
					{
						previousItem = ' ';
					}
					if (maze[ghostX, ghostY] == 'S')
					{

						gameover(ref pacmanX, ref pacmanY);
					}
					if (maze[ghostX, ghostY] == 'E')
					{

						hostover();
					}
					maze[ghostX, ghostY] = 'F';
					Console.SetCursorPosition(ghostY, ghostX);
					Console.Write("F");
				}
			}
			if (value == 4)
			{
				if (maze[ghostX + 1, ghostY] == ' ' || maze[ghostX + 1, ghostY] == 'S' || maze[ghostX + 1, ghostY] == 'E')
				{
					maze[ghostX, ghostY] = previousItem;
					if (previousItem != 'S' || previousItem != 'E')
					{

						Console.SetCursorPosition(ghostY, ghostX);
						Console.Write(previousItem);
					}
					if (previousItem == 'S' || previousItem == 'E')
					{
						Console.SetCursorPosition(ghostY, ghostX);
						Console.Write(' ');
					}
					ghostX = ghostX + 1;
					if (previousItem != 'S' || previousItem != 'E')
					{
						previousItem = maze[ghostX, ghostY];
					}
					if (previousItem == 'S' || previousItem == 'E')
					{
						previousItem = ' ';
					}
					if (maze[ghostX, ghostY] == 'S')
					{

						gameover(ref pacmanX, ref pacmanY);
					}
					if (maze[ghostX, ghostY] == 'E')
					{

						hostover();
					}
					maze[ghostX, ghostY] = 'F';
					Console.SetCursorPosition(ghostY, ghostX);
					Console.Write("F");
				}
			}
			return true;
		}
		static int ghostdirection1()
		{
			Random r = new Random();
			int result = 1 + r.Next(4);
			return result;
		}
		static bool ghostmovement1(ref int pacmanX, ref int pacmanY)
		{
			int value = ghostdirection1();
			if (value == 1)
			{
				if (maze[ghost1X, ghost1Y - 1] == ' ' || maze[ghost1X, ghost1Y - 1] == 'S' || maze[ghost1X, ghost1Y - 1] == 'E')
				{
					maze[ghost1X, ghost1Y] = previousItem1;
					if (maze[ghost1X, ghost1Y] != 'S' || maze[ghost1X, ghost1Y] != 'E')
					{
						Console.SetCursorPosition(ghost1Y, ghost1X);
						Console.Write(previousItem1);
					}
					if (maze[ghost1X, ghost1Y] == 'S' || maze[ghost1X, ghost1Y] == 'E')
					{
						Console.SetCursorPosition(ghost1Y, ghost1X);
						Console.Write(' ');
					}
					ghost1Y = ghost1Y - 1;
					if (maze[ghost1X, ghost1Y] != 'S' || maze[ghost1X, ghost1Y] != 'E')
					{
						previousItem1 = maze[ghost1X, ghost1Y];
					}
					if (maze[ghost1X, ghost1Y] == 'S' || maze[ghost1X, ghost1Y] == 'E')
					{
						previousItem1 = ' ';
					}
					if (maze[ghost1X, ghost1Y] == 'S')
					{
						gameover(ref pacmanX, ref pacmanY);
					}
					if (maze[ghost1X, ghost1Y] == 'E')
					{
						hostover();
					}
					maze[ghost1X, ghost1Y] = 'R';
					Console.SetCursorPosition(ghost1Y, ghost1X);
					Console.Write("R");
				}
			}
			if (value == 2)
			{
				if (maze[ghost1X, ghost1Y + 1] == ' ' || maze[ghost1X, ghost1Y + 1] == 'S' || maze[ghost1X, ghost1Y + 1] == 'E')
				{
					maze[ghost1X, ghost1Y] = previousItem1;
					if (maze[ghost1X, ghost1Y] != 'S' || maze[ghost1X, ghost1Y] != 'E')
					{
						Console.SetCursorPosition(ghost1Y, ghost1X);
						Console.Write(previousItem1);
					}
					if (maze[ghost1X, ghost1Y] == 'S' || maze[ghost1X, ghost1Y] == 'E')
					{
						Console.SetCursorPosition(ghost1Y, ghost1X);
						Console.Write(' ');
					}
					ghost1Y = ghost1Y + 1;
					if (maze[ghost1X, ghost1Y] != 'S' || maze[ghost1X, ghost1Y] != 'E')
					{
						previousItem1 = maze[ghost1X, ghost1Y];
					}
					if (maze[ghost1X, ghost1Y] == 'S' || maze[ghost1X, ghost1Y] == 'E')
					{
						previousItem1 = ' ';
					}
					if (maze[ghost1X, ghost1Y] == 'S')
					{
						gameover(ref pacmanX, ref pacmanY);
					}
					if (maze[ghost1X, ghost1Y] == 'E')
					{
						hostover();
					}
					maze[ghost1X, ghost1Y] = 'R';
					Console.SetCursorPosition(ghost1Y, ghost1X);
					Console.Write("R");
				}
			}
			if (value == 3)
			{
				if (maze[ghost1X - 1, ghost1Y] == ' ' || maze[ghost1X - 1, ghost1Y] == 'S' || maze[ghost1X - 1, ghost1Y] == 'E') //|| maze[ghost1X - 1][ghost1Y] == '.'
				{
					maze[ghost1X, ghost1Y] = previousItem1;
					if (maze[ghost1X, ghost1Y] != 'S' || maze[ghost1X, ghost1Y] != 'E')
					{
						Console.SetCursorPosition(ghost1Y, ghost1X);
						Console.Write(previousItem1);
					}
					if (maze[ghost1X, ghost1Y] == 'S' || maze[ghost1X, ghost1Y] == 'E')
					{
						Console.SetCursorPosition(ghost1Y, ghost1X);
						Console.Write(' ');
					}
					ghost1X = ghost1X - 1;
					if (maze[ghost1X, ghost1Y] != 'S' || maze[ghost1X, ghost1Y] != 'E')
					{
						previousItem1 = maze[ghost1X, ghost1Y];
					}
					if (maze[ghost1X, ghost1Y] == 'S' || maze[ghost1X, ghost1Y] == 'E')
					{
						previousItem1 = ' ';
					}
					if (maze[ghost1X, ghost1Y] == 'S')
					{
						gameover(ref pacmanX, ref pacmanY);
					}
					if (maze[ghost1X, ghost1Y] == 'E')
					{
						hostover();
					}
					maze[ghost1X, ghost1Y] = 'R';
					Console.SetCursorPosition(ghost1Y, ghost1X);
					Console.Write("R");
				}
			}
			if (value == 4)
			{
				if (maze[ghost1X + 1, ghost1Y] == ' ' || maze[ghost1X + 1, ghost1Y] == 'S' || maze[ghost1X + 1, ghost1Y] == 'E') //|| maze[ghost1X + 1][ghost1Y] == '.'
				{
					maze[ghost1X, ghost1Y] = previousItem1;
					if (maze[ghost1X, ghost1Y] != 'S' || maze[ghost1X, ghost1Y] != 'E')
					{
						Console.SetCursorPosition(ghost1Y, ghost1X);
						Console.Write(previousItem1);
					}
					if (maze[ghost1X, ghost1Y] == 'S' || maze[ghost1X, ghost1Y] == 'E')
					{
						Console.SetCursorPosition(ghost1Y, ghost1X);
						Console.Write(' ');
					}
					ghost1X = ghost1X + 1;
					if (maze[ghost1X, ghost1Y] != 'S' || maze[ghost1X, ghost1Y] != 'E')
					{
						previousItem1 = maze[ghost1X, ghost1Y];
					}
					if (maze[ghost1X, ghost1Y] == 'S' || maze[ghost1X, ghost1Y] == 'E')
					{
						previousItem1 = ' ';
					}
					if (maze[ghost1X, ghost1Y] == 'S')
					{
						gameover(ref pacmanX, ref pacmanY);
					}
					if (maze[ghost1X, ghost1Y] == 'E')
					{
						hostover();
					}
					maze[ghost1X, ghost1Y] = 'R';
					Console.SetCursorPosition(ghost1Y, ghost1X);
					Console.Write("R");
				}
			}
			return true;
		}
		//bool ghostmovement2();
		static int ghost_vertical()
		{
			Random r = new Random();
			int result = 3 + r.Next(2);
			return result;
		}
		static bool vertical_ghost(ref int pacmanX, ref int pacmanY)
		{
			int value = ghost_vertical();
			if (value == 3)
			{

				if (maze[verX - 1, verY] == ' ' || maze[verX - 1, verY] == 'S' || maze[verX - 1, verY] == 'E')
				{
					maze[verX, verY] = previousItem2;
					if (maze[verX, verY] != 'S' || maze[verX, verY] != 'E')
					{
						Console.SetCursorPosition(verY, verX);
						Console.Write(previousItem2);
					}
					if (maze[verX, verY] == 'S' || maze[verX, verY] == 'E')
					{
						Console.SetCursorPosition(verY, verX);
						Console.Write(' ');
					}
					verX = verX - 1;
					if (maze[verX, verY] != 'S' || maze[verX, verY] != 'E')
					{
						previousItem2 = maze[verX, verY];
					}
					if (maze[verX, verY] == 'S' || maze[verX, verY] == 'E')
					{
						previousItem2 = ' ';
					}
					if (maze[verX, verY] == 'S')
					{

						gameover(ref pacmanX, ref pacmanY);
					}
					if (maze[verX, verY] == 'E')
					{

						hostover();
					}
					maze[verX, verY] = 'V';
					Console.SetCursorPosition(verY, verX);
					Console.Write("V");
				}
			}
			if (value == 4)
			{
				if (maze[verX + 1, verY] == ' ' || maze[verX + 1, verY] == 'S' || maze[verX + 1, verY] == 'E')
				{
					maze[verX, verY] = previousItem2;
					if (maze[verX, verY] != 'S' || maze[verX, verY] != 'E')
					{
						Console.SetCursorPosition(verY, verX);
						Console.Write(previousItem2);
					}
					if (maze[verX, verY] == 'S' || maze[verX, verY] == 'E')
					{
						Console.SetCursorPosition(verY, verX);
						Console.Write(' ');
					}
					verX = verX + 1;
					if (maze[verX, verY] != 'S' || maze[verX, verY] != 'E')
					{
						previousItem2 = maze[verX, verY];
					}
					if (maze[verX, verY] == 'S' || maze[verX, verY] == 'E')
					{
						previousItem2 = ' ';
					}
					if (maze[verX, verY] == 'S')
					{
						gameover(ref pacmanX, ref pacmanY);
					}
					if (maze[verX, verY] == 'E')
					{
						hostover();
					}
					maze[verX, verY] = 'V';
					Console.SetCursorPosition(verY, verX);
					Console.Write("V");
				}
			}
			return true;
		}
		static int ghost_horizontal()
		{
			Random r = new Random();

			int result = 1 + r.Next(2);
			return result;
		}
		static bool horizontal_ghost(ref int pacmanX, ref int pacmanY)
		{
			int value = ghost_horizontal();
			if (value == 1)
			{
				if (maze[horX, horY - 1] == ' ' || maze[horX, horY - 1] == 'S' || maze[horX, horY - 1] == 'E')
				{
					maze[horX, horY] = previousItem3;
					if (maze[horX, horY] != 'S' || maze[horX, horY] != 'E')
					{
						Console.SetCursorPosition(horY, horX);
						Console.Write(previousItem3);
					}
					if (maze[horX, horY] == 'S' || maze[horX, horY] == 'E')
					{
						Console.SetCursorPosition(horY, horX);
						Console.Write(' ');
					}
					horY = horY - 1;
					if (maze[horX, horY] != 'S' || maze[horX, horY] != 'E')
					{
						previousItem3 = maze[horX, horY];
					}
					if (maze[horX, horY] == 'S' || maze[horX, horY] == 'E')
					{
						previousItem3 = ' ';
					}
					if (previousItem3 == 'S')
					{
						gameover(ref pacmanX, ref pacmanY);
					}
					if (previousItem3 == 'E')
					{
						hostover();
					}
					maze[horX, horY] = 'H';
					Console.SetCursorPosition(horY, horX);
					Console.Write("H");
				}
			}
			if (value == 2)
			{
				if (maze[horX, horY + 1] == ' ' || maze[horX, horY + 1] == 'S' || maze[horX, horY + 1] == 'E')
				{
					maze[horX, horY] = previousItem3;
					if (maze[horX, horY] != 'S' || maze[horX, horY] != 'E')
					{
						Console.SetCursorPosition(horY, horX);
						Console.Write(previousItem3);
					}
					if (maze[horX, horY] == 'S' || maze[horX, horY] == 'E')
					{
						Console.SetCursorPosition(horY, horX);
						Console.Write(' ');
					}
					horY = horY + 1;
					if (maze[horX, horY] != 'S' || maze[horX, horY] != 'E')
					{

						previousItem3 = maze[horX, horY];
					}
					if (maze[horX, horY] == 'S' || maze[horX, horY] == 'E')
					{
						previousItem3 = ' ';
					}
					if (previousItem3 == 'S')
					{
						gameover(ref pacmanX, ref pacmanY);
					}
					if (previousItem3 == 'E')
					{
						hostover();
					}
					maze[horX, horY] = 'H';
					Console.SetCursorPosition(horY, horX);
					Console.Write("H");
				}
			}
			return true;
		}
		static void energyleft(ref int pacmanX, ref int pacmanY)
		{
			if (maze[pacmanX, pacmanY - 1] == 'o')
			{
				mit = 30;
			}
			else if (maze[pacmanX, pacmanY - 1] != '#' && maze[pacmanX, pacmanY - 1] != '~' && maze[pacmanX - 1, pacmanY] != 'E' && maze[pacmanX, pacmanY - 1] != '@' && maze[pacmanX, pacmanY - 1] != '&' && maze[pacmanX, pacmanY - 1] != '|' && maze[pacmanX, pacmanY - 1] != '_' && maze[pacmanX, pacmanY - 1] != '<' && maze[pacmanX, pacmanY - 1] != '>' && maze[pacmanX, pacmanY - 1] != '(' && maze[pacmanX, pacmanY - 1] != ')' || maze[pacmanX, pacmanY - 1] == ' ' || maze[pacmanX, pacmanY - 1] == 'F' || maze[pacmanX, pacmanY - 1] == 'H' || maze[pacmanX, pacmanY - 1] == 'V' || maze[pacmanX, pacmanY - 1] == 'R' || maze[pacmanX, pacmanY - 1] == 'J' || maze[pacmanX, pacmanY - 1] == '*')
			{
				maze[pacmanX, pacmanY] = ' ';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write(" ");
				pacmanY = pacmanY - 1;
				maze[pacmanX, pacmanY] = 'S';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write("S");
			}
			if (maze[pacmanX, pacmanY - 1] == '*')
			{
				checkpost++;
			}
		}
		static void energyright(ref int pacmanX, ref int pacmanY)
		{
			if (maze[pacmanX, pacmanY + 1] == 'o')
			{
				mit = 30;
			}
			else if (maze[pacmanX, pacmanY + 1] != '#' && maze[pacmanX, pacmanY + 1] != '~' && maze[pacmanX - 1, pacmanY] != 'E' && maze[pacmanX, pacmanY + 1] != '@' && maze[pacmanX, pacmanY + 1] != '&' && maze[pacmanX, pacmanY + 1] != '|' && maze[pacmanX, pacmanY + 1] != '_' && maze[pacmanX, pacmanY + 1] != '<' && maze[pacmanX, pacmanY + 1] != '>' && maze[pacmanX, pacmanY + 1] != '(' && maze[pacmanX, pacmanY + 1] != ')' || maze[pacmanX, pacmanY + 1] == ' ' || maze[pacmanX, pacmanY + 1] == 'F' || maze[pacmanX, pacmanY + 1] == 'H' || maze[pacmanX, pacmanY + 1] == 'V' || maze[pacmanX, pacmanY + 1] == 'R' || maze[pacmanX, pacmanY + 1] == 'J' || maze[pacmanX, pacmanY + 1] == '*')
			{
				maze[pacmanX, pacmanY] = ' ';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write(" ");
				pacmanY = pacmanY + 1;
				/*if (maze[pacmanX][pacmanY] == '.')
				 {
					 calculateScore();
				 }*/
				maze[pacmanX, pacmanY] = 'S';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write("S");
			}
			if (maze[pacmanX, pacmanY + 1] == '*')
			{
				checkpost++;
			}
		}
		static void energyup(ref int pacmanX, ref int pacmanY)
		{
			if (maze[pacmanX - 1, pacmanY] == 'o')
			{
				mit = 30;
			}
			else if (maze[pacmanX - 1, pacmanY] != '#' && maze[pacmanX - 1, pacmanY] != '~' && maze[pacmanX - 1, pacmanY] != '@' && maze[pacmanX - 1, pacmanY] != 'E' && maze[pacmanX - 1, pacmanY] != '&' && maze[pacmanX - 1, pacmanY] != '|' && maze[pacmanX - 1, pacmanY] != '_' && maze[pacmanX - 1, pacmanY] != '<' && maze[pacmanX - 1, pacmanY] != '>' && maze[pacmanX - 1, pacmanY] != '(' && maze[pacmanX - 1, pacmanY] != ')' || maze[pacmanX - 1, pacmanY] == ' ' || maze[pacmanX - 1, pacmanY] == 'F' || maze[pacmanX - 1, pacmanY] == 'H' || maze[pacmanX - 1, pacmanY] == 'V' || maze[pacmanX - 1, pacmanY] == 'R' || maze[pacmanX - 1, pacmanY] == 'J' || maze[pacmanX - 1, pacmanY] == '*')
			{
				maze[pacmanX, pacmanY] = ' ';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write(" ");
				pacmanX = pacmanX - 1;
				/*if (maze[pacmanX][pacmanY] == '.')
				{

					calculateScore();
				}*/
				maze[pacmanX, pacmanY] = 'S';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write("S");
			}
			if (maze[pacmanX - 1, pacmanY] == '*')
			{
				checkpost++;
			}
		}
		static void energydown(ref int pacmanX, ref int pacmanY)
		{
			if (maze[pacmanX + 1, pacmanY] == 'o')
			{
				mit = 30;
			}
			if (maze[pacmanX + 1, pacmanY] == '*')
			{
				checkpost++;
			}
			else if (maze[pacmanX + 1, pacmanY] != '#' && maze[pacmanX + 1, pacmanY] != '~' && maze[pacmanX + 1, pacmanY] != '@' && maze[pacmanX + 1, pacmanY] != 'E' && maze[pacmanX + 1, pacmanY] != '&' && maze[pacmanX + 1, pacmanY] != '|' && maze[pacmanX + 1, pacmanY] != '_' && maze[pacmanX + 1, pacmanY] != '<' && maze[pacmanX + 1, pacmanY] != '>' && maze[pacmanX + 1, pacmanY] != '(' && maze[pacmanX + 1, pacmanY] != ')' || maze[pacmanX + 1, pacmanY] == ' ' || maze[pacmanX + 1, pacmanY] == 'F' || maze[pacmanX + 1, pacmanY] == 'H' || maze[pacmanX + 1, pacmanY] == 'V' || maze[pacmanX + 1, pacmanY] == 'R' || maze[pacmanX + 1, pacmanY] == 'J' || maze[pacmanX + 1, pacmanY] == '*')
			{
				maze[pacmanX, pacmanY] = ' ';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write(" ");
				pacmanX = pacmanX + 1;
				/*if (maze[pacmanX][pacmanY] == '.')
				{
					calculateScore();
				}*/
				maze[pacmanX, pacmanY] = 'S';
				Console.SetCursorPosition(pacmanY, pacmanX);
				Console.Write("S");
				if (maze[pacmanX + 1, pacmanY] == '*')
				{
					checkpost++;
				}
			}
		}
		static bool hostmovement(ref int pacmanX, ref int pacmanY)
		{
			int value = hostdirection(ref pacmanX, ref pacmanY);
			if (maze[15, 4] == 'E' || maze[15, 5] == 'E' || maze[15, 6] == 'E' || maze[15, 7] == 'E')
			{
				home();
			}
			if (value == 1)
			{
				if (maze[hostX, hostY - 1] == ' ' || maze[hostX, hostY - 1] == 'o') // || maze[hostX][hostY - 1] == 'S'
				{
					maze[hostX, hostY] = hostprevious;
					Console.SetCursorPosition(hostY, hostX);
					Console.Write(hostprevious);
					hostY = hostY - 1;
					hostprevious = maze[hostX, hostY];
					maze[hostX, hostY] = 'E';
					Console.SetCursorPosition(hostY, hostX);
					Console.Write("E");
				}
			}
			if (value == 2)
			{

				if (maze[hostX, hostY + 1] == ' ' || maze[hostX, hostY - 1] == 'o') //|| maze[hostX][hostY + 1] == 'S'
				{
					maze[hostX, hostY] = hostprevious;
					Console.SetCursorPosition(hostY, hostX);
					Console.Write(hostprevious);
					hostY = hostY + 1;
					hostprevious = maze[hostX, hostY];
					/*if (maze[hostX][hostY] == 'S')
					{

						return 0;

					}*/
					maze[hostX, hostY] = 'E';
					Console.SetCursorPosition(hostY, hostX);
					Console.Write("E");
				}
			}
			if (value == 3)
			{
				if (maze[hostX - 1, hostY] == ' ' || maze[hostX, hostY - 1] == 'o') // maze[hostX - 1][hostY] == 'S' ||
				{
					maze[hostX, hostY] = hostprevious;
					Console.SetCursorPosition(hostY, hostX);
					/*iE (maze[hostX][hostY] == '.')
					{
						cout << ".";
					}
					else
					{*/
					Console.Write(hostprevious);
					//}
					hostX = hostX - 1;
					hostprevious = maze[hostX, hostY];
					/*if (maze[hostX][hostY] == 'S')
					{

							return 0;

					}*/
					maze[hostX, hostY] = 'E';
					Console.SetCursorPosition(hostY, hostX);
					Console.Write("E");
				}
			}
			if (value == 4)
			{
				if (maze[hostX + 1, hostY] == ' ' || maze[hostX, hostY - 1] == 'o') //|| maze[hostX + 1][hostY] == 'S'
				{
					maze[hostX, hostY] = hostprevious;
					Console.SetCursorPosition(hostY, hostX);
					/*iE (maze[hostX][hostY] == '.')
					{
						cout << ".";
					}
					else
					{*/
					Console.Write(hostprevious);
					//}
					hostX = hostX + 1;
					hostprevious = maze[hostX, hostY];
					/*if (maze[hostX][hostY] == 'S')
					{

							return 0;

					}*/
					maze[hostX, hostY] = 'E';
					Console.SetCursorPosition(hostY, hostX);
					Console.Write("E");
				}
			}
			return true;
		}
		static int hostdirection(ref int pacmanX, ref int pacmanY)
		{
			if (moveCount == 3)
			{
				Random r = new Random();

				int result = 1 + r.Next(4);
				moveCounth = 0;
				return result;
			}
			moveCounth++;
			int horizontal = pacmanY - hostY;
			int vertical = pacmanX - hostX;
			int absX;
			int absY;
			absX = vertical;
			if (vertical < 0)
			{
				absX = absX * (-1);
			}
			absY = horizontal;
			if (horizontal < 0)
			{
				absY = absY * (-1);
			}
			if (absX > absY)
			{
				if (vertical < 0)
				{
					return 3;
				}
				else
				{
					return 4;
				}
			}
			else
			{
				if (horizontal < 0)
				{
					return 1;
				}
				else
				{
					return 2;
				}
			}
		}
		static void firehor(ref int pacmanX, ref int pacmanY)
		{
			firecount1++;
			if (firecount1 == 3)
			{
				firecount1 = 0;
				if (maze[firehorX, firehorY + 1] == '|' || maze[firehorX, firehorY + 1] == 'F' || maze[firehorX, firehorY + 1] == 'V' || maze[firehorX, firehorY + 1] == 'R' || maze[firehorX, firehorY + 1] == 'J')
				{
					maze[firehorX, firehorY] = ' ';
					Console.SetCursorPosition(firehorY, firehorX);
					Console.Write(' ');
					restart1 = true;
				}
				else
				{
					if (maze[firehorX, firehorY + 1] == 'S' || maze[firehorX, firehorY + 1] == 'E')
					{
						gameover(ref pacmanX, ref pacmanY);
					}
					maze[firehorX, firehorY] = ' ';
					Console.SetCursorPosition(firehorY, firehorX);
					Console.Write(' ');
					maze[firehorX, firehorY + 1] = '+';
					Console.SetCursorPosition(firehorY + 1, firehorX);
					Console.Write('+');
				}
				firehorY++;
				if (restart1)
				{
					firehorX = 12; firehorY = 3;
					restart1 = false;
				}
			}
		}
		static void firevert(ref int pacmanX, ref int pacmanY)

		{
			firecount2++;
			if (firecount2 == 3)
			{
				firecount2 = 0;
				if (maze[firevertX - 1, firevertY] == '#' || maze[firevertX - 1, firevertY] == 'F' || maze[firevertX - 1, firevertY] == 'V' || maze[firevertX - 1, firevertY] == 'R' || maze[firevertX - 1, firevertY] == 'J')
				{
					maze[firevertX, firevertY] = ' ';
					Console.SetCursorPosition(firevertY, firevertX);
					Console.Write(' ');
					restart2 = true;
				}
				else
				{
					if (maze[firevertX - 1, firevertY] == 'S' || maze[firevertX - 1, firevertY] == 'E')
					{
						gameover(ref pacmanX, ref pacmanY);
					}
					maze[firevertX, firevertY] = ' ';
					Console.SetCursorPosition(firevertY, firevertX);
					Console.Write(' ');
					maze[firevertX - 1, firevertY] = '+';
					Console.SetCursorPosition(firevertY, firevertX - 1);
					Console.Write('+');
				}
				firevertX--;
				if (restart2)
				{
					firevertX = 21;
					firevertY = 32;
					restart2 = false;
				}
			}
		}
		static void home()
		{
			Console.Clear();
			printmaze();
			// printScore();
			Console.Write("Level Passed");
			Console.Write("\n");
			Console.Write("Congrats..... You have saved the Hostage ..... ");
			Console.Write("\n");
			Thread.Sleep(500);
			Console.WriteLine("Press Any Key to continue..."); Console.ReadKey();
			Console.Clear();
			Environment.Exit(0);
		}
		static void hostover()
		{
			maze[hostX, hostY] = ' ';
			Console.SetCursorPosition(hostY, hostX);
			Console.Write(' ');
			hostX = 23;
			hostY = 63;
			maze[hostX, hostY] = 'E';
			Console.SetCursorPosition(hostY, hostX);
			Console.Write('E');
		}
		static void header()
		{
			Console.Write("        **************************************************        ");
			Console.Write("\n");
			Console.Write("        ****              SAVE THE HOSTAGE            ****        ");
			Console.Write("\n");
			Console.Write("        **************************************************        ");
			Console.Write("\n");
		}

		//                          Data Strucures



	}
}
