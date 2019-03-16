using System;
using System.Collections.Generic;

namespace lab2
{
    class Program
    {
        private Dictionary<string, Matrix> dictionary = new Dictionary<string, Matrix>();
        private Dictionary<string, double> doubles = new Dictionary<string, double>();

        static void Main(string[] args) => new Program().run();

        private void run()
        {
            Console.WriteLine(@"Enter any valid expression with matrixes or doubles
Matrix's syntax: rows are separated by ',', columns are separated by ' '
Use operators: '+', '-' or '*'
varName = [expression] # - defines a variable 'varName'
list  - prints all variables
clear - removes all variables
For example:
m1 = 1 2, 3 4, 5 6 # define a matrix m1 with 3 rows and 2 columns
ones = 1 1, 1 1, 1 1
m1 + ones # fold two matrixes
m1 - ones # substract
m2 = m1 * 1 2 3, 4 5 6 # multiply m1 with a new expressed matrix
d = 1,5 # define a new double-variable
m2 * d # all values of an m2 multiply by a double
list # print all variables
clear # clear all variables");
            while (true)
            {
                Console.Write(">");
                string key = null;
                string expr = Console.ReadLine();
                if (expr.Contains("#"))
                {
                    expr = expr.Substring(0, expr.IndexOf("#"));
                }
                if (CommandEntered(expr))
                {
                    continue;
                }
                int equalsIndex = expr.IndexOf('=');
                if (equalsIndex > 0)
                {
                    key = expr.Split('=')[0].Trim();
                    expr = expr.Split('=')[1];
                }

                double doubleValue;
                if (TryToFindOrParceDouble(expr, out doubleValue))
                {
                    if (key != null)
                    {
                        dictionary.Remove(key);
                        doubles[key] = doubleValue;
                    }
                    Console.WriteLine(doubleValue);
                    continue;
                }
                Matrix matrix;
                if (!TryGetMatrixFromExpr(expr, out matrix))
                {
                    continue;
                }
                if (key != null)
                {
                    doubles.Remove(key);
                    dictionary[key] = matrix;
                }
                Console.WriteLine(matrix.ToString());
            }
        }

        private bool CommandEntered(string expr)
        {
            expr = expr.Trim();
            if (expr.Equals("list"))
            {
                foreach (var item in dictionary)
                {
                    Console.WriteLine(item);
                }
                foreach (var item in doubles)
                {
                    Console.WriteLine(item);
                }
                return true;
            }
            else if (expr.Equals("clear"))
            {
                dictionary.Clear();
                doubles.Clear();
                return true;
            }
            return false;
        }

        private bool TryGetMatrixFromExpr(string expr, out Matrix result)
        {
            result = null;
            int operatorIndex = expr.LastIndexOfAny(new char[] { '+', '-', '*' });
            if (operatorIndex > 0)
            {
                string leftSubExpr = expr.Substring(0, operatorIndex);
                char matrixOperator = char.Parse(expr.Substring(operatorIndex, 1));
                string rightSubExpr = expr.Substring(operatorIndex + 1);

                Matrix left;
                if (!TryGetMatrixFromExpr(leftSubExpr, out left))
                {
                    return false;
                }

                if (matrixOperator == '*')
                {
                    double rightOperand;
                    if (TryToFindOrParceDouble(rightSubExpr, out rightOperand))
                    {
                        result = left * rightOperand;
                        return true;
                    }
                }

                Matrix right;
                if (!TryToFindOrParceFromExpr(rightSubExpr, out right))
                {
                    return false;
                }
                switch (matrixOperator)
                {
                    case '+':
                        result = left + right;
                        return true;
                    case '-':
                        result = left - right;
                        return true;
                    case '*':
                        result = left * right;
                        return true;
                }
            }
            else
            {
                if (!TryToFindOrParceFromExpr(expr, out result))
                {
                    return false;
                }
            }
            return true;
        }

        private bool TryToFindOrParceDouble(string expr, out double result)
        {
            expr = expr.Trim();
            if (doubles.TryGetValue(expr, out result))
            {
                return true;
            }
            if (!expr.Contains(" ") && double.TryParse(expr, out result))
            {
                return true;
            }
            return false;
        }

        private bool TryToFindOrParceFromExpr(string expr, out Matrix result)
        {
            expr = expr.Trim();
            // in case if an expr is a key, try to find it in a dictionary
            if (dictionary.TryGetValue(expr, out result))
            {
                return true;
            }
            if (Matrix.TryParse(expr, out result)) // in other case, try to parce
            {
                return true;
            }
            return false;
        }
    }
}
