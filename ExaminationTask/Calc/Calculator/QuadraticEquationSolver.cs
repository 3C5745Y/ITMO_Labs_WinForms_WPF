using System;

namespace Calculator
{
    public static class QuadraticEquationSolver
    {
        public static int Solve(double a, double b, double c, out double[] roots)
        {
            if (a == 0)
            {
                roots = new double[0];
                return 0;
            }

            var d = Discriminant(a, b, c);
            if (d < 0)
            {
                roots = new double[0];
                return 0;
            }
            else if (d == 0)
            {
                roots = new double[1] { -b / (2 * a) };
                return 1;
            }
            else
            {
                roots = new double[2];
                roots[0] = (-b + Math.Sqrt(d)) / (2 * a);
                roots[1] = (-b - Math.Sqrt(d)) / (2 * a);
                return 2;
            }
        }
        
        public static string RootsToString(double[] roots)
        {
            if (roots.Length == 0)
                return "No real roots";
            else if (roots.Length == 1)
                return "Root: " + roots[0].ToString("0.##");
            else
                return "Roots: " + roots[0].ToString("0.##") + "; " + roots[1].ToString("0.##");

        }

        private static double Discriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }
    }
}
