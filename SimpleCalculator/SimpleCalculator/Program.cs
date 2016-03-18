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
            CalcStack scStack = new CalcStack();
            string inputString = cExp.GetUserInput();
            cExp.EvaluateExpression(inputString);
            int result = cExp.calculate(cExp.terms, cExp.ops);
            scStack.lastqAccess = inputString;
            scStack.lastAccess = result.ToString();
            scStack.pushStack();
            scStack.peekStack();
            string test = scStack.lastqAccess;
            Console.WriteLine("Last Question pop = " + test);
            test = scStack.lastAccess;
            Console.WriteLine("Last Answer pop = " + test);
            Console.ReadKey();
        }
    }
}
