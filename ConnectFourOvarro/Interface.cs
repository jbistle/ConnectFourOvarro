using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourOvarro
{
    public static class Interface
    {
        public static int StringMenu(string[] Options)
        {
            for (int i = 1; i < Options.Length - 1 ; i++)
            {
                Console.WriteLine(i.ToString() + ". " + Options[i]);
            }

            Console.WriteLine("Please input option");

            int ans = 0;

            while (ans == 0) 
            {
                string input = Console.ReadLine();

                try
                {
                    ans = Int32.Parse(input);
                    if (ans < Options.Length-1) { throw new Exception(); }
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



    }
}
