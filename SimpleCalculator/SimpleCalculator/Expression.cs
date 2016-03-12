using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleCalculator
{
    public class Expression
    {
        public int count = 1;
        public int[] terms = new int[2] { 0, 0 };
        //public static int[] terms;
        public char op = '\n';
        public int step = 0; // counts the steps to build the expression (used to verify correct sequence T+O+T)

        public void EvaluateExpression(string expr)
        {          
            terms = ExtractTerms(expr);
            op = ExtractOps(expr);
        }

        public int[] ExtractTerms(string expr)
        {
            int[] termsLocal = new int[2] { 0, 0 };
            string exprIn = expr.Replace(" ", "");
            int i = 0;
            int x = 0;
            step++;
            string termTemp = "";
            while (i < exprIn.Length)
            {
                char l = exprIn[i];
                if (l >= '0' && l <= '9')    // catch the terms
                {
                    if (step == 2)
                    {
                        Console.WriteLine("Incorrect input, Good input example = 3+5 4*2 etc");
                        Console.WriteLine("Please press enter and try again");
                        Console.ReadKey();
                        step = 0;
                        GetUserInput();
                    }
                    termTemp = termTemp + l;
                    termsLocal[x] = l - 48;
                    x++;
                    termTemp = "";
                }
                step++;
                i++;
            }
            step = 0;
            return termsLocal;
        }

        public char ExtractOps(string expr)
        {
            char opsLocal = '\n';
            string exprIn = expr.Replace(" ", "");
            int i = 0;
            int y = 0;
            step++;
            string opTemp = "";
            while (i < exprIn.Length)
            {
                char l = exprIn[i];
                if (l == '+' || l == '-' || l == '/' || l == '*')    // catch the ops
                {
                    if (step != 2)
                    {
                        Console.WriteLine("Incorrect input, Good input example = 3+5 4*2 etc");
                        Console.WriteLine("Please press enter and try again");
                        Console.ReadKey();
                        step = 0;
                        GetUserInput();
                    }
                    opTemp = opTemp + l;
                    opsLocal = l;
                    y++;
                    opTemp = "";
                }
                step++;
                i++;
            }
            step = 0;
            return opsLocal;
        }

        public string GetUserInput()
        {
            string userString = "";
            string inputString = "";

            userString = "[";
            userString = userString + count;
            userString = userString + "]>";
            Console.Write(userString);
            inputString = Console.ReadLine();
            Console.Write("    " + inputString);
            Console.WriteLine();
            Console.WriteLine("-------");
            //Console.ReadKey();
            return inputString; 
        }
    }
}
