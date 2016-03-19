using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleCalculator
{
    public class Stack // stk data format = question answer (ex. 3+1 4)
    {
        public static  Dictionary<char, int> Constants = new Dictionary<char, int>();

        public void addConstant(char C, int I)
        {
            try
            {
                Constants.Add(C, I);                
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public int getConstant(char C)
        {
            int value = 0;
            if(Constants.TryGetValue(C, out value))
            {
                return value;
            }
            else
            {
                return 0;
            }
            
        }

        Stack<string> stk = new Stack<string>();
        private string last = "";
        private string lastq = "";

        public string lastqAccess
        {
            get { return lastq; }
            set { lastq = value; }
        }

        public string lastAccess
        {
            get { return last; }
            set { last = value; }
        }

        public void pushStack()
        {
            string stackSet = lastq + " " + last;
            stk.Push(stackSet);         
        }

        public void peekStack()
        {
            string lastQuestion = stk.Peek();
            string[] lastQuestionArray = lastQuestion.Split(' ');
            lastq = lastQuestionArray[0];
            last = lastQuestionArray[1];
        }
    }

    public class Expression
    {
        public int count = 1;
        public int[] terms = new int[3] { 0, 0, 0 }; //contains term1 term2 & success bool(1=good, 0=bad)
        public string[] ops = new string[2] { "", "" }; // contains operator & sucess bool ("1"=good "0"=bad)
        //public static int[] terms;
        public char op = '\n';
        public int step = 0; // counts the steps to build the expression (used to verify correct sequence T+O+T)

        public void EvaluateExpression(string expr)
        {     
            terms = ExtractTerms(expr);
            ops = ExtractOps(expr);
        }

        public int[] ExtractTerms(string expr)
        {
            if(expr.Length < 3) { throw new ArgumentException("Not enough expression elements"); }
            int[] termsLocal = new int[3] { 0, 0, 0 };
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
                        termsLocal[2] = 0; // signal bad term extraction
                        throw new ArgumentException("Bad Term Error");
                    }
                    else
                    {
                        termsLocal[2] = 1; // signal good term extraction
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

        public string[] ExtractOps(string expr)
        {
            string[] opsLocal = new string[2] {"", "" };
            string exprIn = expr.Replace(" ", "");
            int i = 0;
            int y = 0;
            step++;
            string opTemp = "";
            while (i < exprIn.Length)
            {
                char l = exprIn[i];
                if (l == '+' || l == '-' || l == '/' || l == '*' || l == '%')    // catch the ops
                {
                    if (step != 2) // error trap
                    {
                        opsLocal[1] = "0";
                        throw new ArgumentException("Bad Operator Error");
                    }
                    else
                    {
                        opsLocal[1] = "1";
                    }
                    opTemp = opTemp + l;
                    opsLocal[y] = l.ToString();
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

        public int calculate(int[] terms, string[] ops)
        {
            int result = 0;
            try
            {                         
                int a = (terms[0]);
                int b = (terms[1]);
                string c = (ops[0]);
                //char[] d = c.ToCharArray();
                //char o = c[0];
                if (c == "+") { result = a + b; }
                else if (c == "-") { result = a - b; }
                else if (c == "/") { result = a / b; }
                else if (c == "*") { result = a * b; }
                else if (c == "%") { result = a % b; }
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
            count++;
            return result;
        }
    }

    public class Calc
    {
        public int add(int[] terms)
        {
            int a = (terms[0]);
            int b = (terms[1]);
            int result;
            return result = a + b;
        }

        public int sub(int[] terms)
        {
            int a = (terms[0]);
            int b = (terms[1]);
            int result;
            return result = a - b;
        }

        public int mult(int[] terms)
        {
            int a = (terms[0]);
            int b = (terms[1]);
            int result;
            return result = a * b;
        }

        public int div(int[] terms)
        {
            int a = (terms[0]);
            int b = (terms[1]);
            int result;
            return result = a / b;
        }

        public int mod(int[] terms)
        {
            int a = (terms[0]);
            int b = (terms[1]);
            int result;
            return result = a % b;
        }
    }

    

}
