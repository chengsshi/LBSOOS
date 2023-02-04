using System;

namespace BSOBSOOS
{
    public class Parameter
    {
        // public static int multiple = 8;
        public static int Population = 100;
        public static int Dimension = 2;
        // reciprocalDimension = 1.0 / Dimension
        public static double reciprocalDimension = 0.02;
        public static double boundary = 100.0;

        public static double Lower = -1.0;
        public static double Upper = 1.0;
        public static int Run = 50;
        // reciprocalRunNumber = 1.0 / Run
        public static double reciprocalRun = 0.025;
        public static int Iteration = 500;
        public static double Perce = 0.4;
        public static double size = 400.0f;
        public static int cluster = 20;

        public static void Display()
        {
            Console.WriteLine("population {0}", Population);
            Console.WriteLine("iteration {0}", Iteration);
            Console.WriteLine("dimension {0}", Dimension);
            Console.WriteLine("run {0}", Run);
            Console.WriteLine("upper bound {0}", Upper);
            Console.WriteLine("lowe bound {0}", Lower);
        }

        public static void updateBoundary(double boundary)
        {
            Upper = boundary;
            Lower = -boundary;
            Display();
        }

        public static void UpdateParameter(int dim)
        {
            Parameter.Dimension = dim;
            Display();
        }
    }
}
