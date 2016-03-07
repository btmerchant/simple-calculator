using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class ParseInput
    {
        public static List<string> ops = new List<string>();
        public static List<string> terms = new List<string>();
        public static string userString = "";

        public static void EvaluateExpression(string expr)
        {
            ExtractTerms(expr);
        }

        public static void ExtractTerms(string expr)
        {
            string exprOut = expr.Replace(" ", "");
            string termTemp = "";
            string opTemp = "";
            int i = 0;
            while(i < exprOut.Length)
            {
                char l = exprOut[i];
                if(l >= '0' && l <= '9')    // catch teh terms
                {
                    if (opTemp != "")
                    {
                        ops.Add(opTemp);
                        opTemp = "";
                    }
                    termTemp = termTemp + exprOut[i];
                }
                else if(l == '+' || l == '-' || l == '/' || l == '*')   // catch the operators
                {
                    if(termTemp != "")
                    {
                        terms.Add(termTemp);
                        termTemp = "";
                    }
                    opTemp = opTemp + exprOut[i];
                }
                
                i++;
                if(i == exprOut.Length)     //catch the last term
                {
                    terms.Add(termTemp);
                    termTemp = "";
                }

            }

        }
        public static void GetUserInput()
        {
            int count = 0;
            string inputString = "";

            userString = "[";
            userString = userString + count;
            userString = userString + "]>";
            Console.Write(userString);
            inputString = Console.ReadLine();
            Console.Write("    " + inputString);

            EvaluateExpression(inputString);
             
        }

        public static void redo()
        {
        Console.WriteLine("First term is NotFiniteNumberException an integer, press a key to retry");
        Console.ReadKey();
        GetUserInput();
        }
    }     
}
