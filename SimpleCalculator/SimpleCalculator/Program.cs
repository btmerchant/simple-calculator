using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression cExp = new Expression();
            Console.WriteLine("Please enter 2 numbers between 0 and 9");
            Console.WriteLine("With an operator between (ex 5+2, or 5*4)");
            Console.WriteLine();
            top:
            string inputString = cExp.GetUserInput();
            cExp.EvaluateExpression(inputString);
            try
            {
                int result = 0;
                int a = (cExp.terms[0]);
                int b = (cExp.terms[1]);
                if (cExp.op == '+') { result = a + b; }
                else if (cExp.op == '-') { result = a - b; }
                else if (cExp.op == '/') { result = a / b; }
                else if (cExp.op == '*') { result = a * b; }
                else Console.WriteLine("No good operator input!");
                Console.Write(" =  ");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                throw;
            }
            cExp.count++;
            Console.WriteLine();
            goto top;
        }
    }
}
