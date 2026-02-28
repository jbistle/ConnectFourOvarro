using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourOvarro
{
    
    public static class Interface
    {
        
        

        public static int SelectInt(int lower, int upper, string instruction)
        {
            if (lower < 0 || upper < lower || upper == lower)
            {
                throw new Exception("Lower and upper bounds not accepted");
            }

            Console.WriteLine(instruction);
            Console.WriteLine("Input must be between " + lower.ToString() + " and " + upper.ToString());

            int ans = 0;

            while (ans == 0)
            {
                string input = Console.ReadLine();

                try
                {
                    ans = Int32.Parse(input);
                    if (ans < lower || ans > upper) { throw new Exception(); }
                }
                catch
                {
                    Console.WriteLine("Input valid option");
                    ans = 0;

                }
            }

            Console.Clear();

            return ans;
        }

        public static void DisplayBoard(int[,] Board)
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J"); //as clearing board doesn't work with larger boards
            Console.WriteLine("Current Board");
            Console.WriteLine();

            for (int i = 0; i<Board.GetLength(1); i++) 
            {
                if (i < 10)
                {
                    Console.Write("  " + (i + 1).ToString() + " ");
                }
                else
                {
                    Console.Write(" " + (i + 1).ToString() + " ");
                }
                
            
            }

            Console.WriteLine() ;

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    switch (Board[i, j])
                    {
                        case 0:
                            Console.Write("  - ");
                            break;
                        case 1: 
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("  R ");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("  Y ");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                    }

                    
                }
                Console.WriteLine();

            }

            Console.WriteLine();
        }

        public static void TurnText(int player, int turn)
        {
            Console.WriteLine("Turn " + turn.ToString());

            switch (player)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }



            Console.WriteLine("Player " + player.ToString() + ": ");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void FullColumn(int[,] Board, int player, int turn)
        {
            
            DisplayBoard(Board);
            TurnText(player, turn);

            Console.WriteLine();
            Console.WriteLine("Column is full, choose different column");
            Console.WriteLine();
        }

        public static void WinText(int player)
        {


            switch (player)
            {
                case 1:
                    Console.ForegroundColor= ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    break;
            }

            Console.WriteLine("Player " + player.ToString() + " wins!");
            Console.ForegroundColor = ConsoleColor.White;
        }



    }
}
