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
            string inputString = cExp.GetUserInput();
            cExp.EvaluateExpression(inputString);
            cExp.calculate(cExp.terms, cExp.ops);
            Console.ReadKey();
        }
    }
}
