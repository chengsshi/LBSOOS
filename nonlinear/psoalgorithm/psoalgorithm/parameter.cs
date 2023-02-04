using System;

namespace PSOalgorithm
{
    public class Parameter
    {
        public static int Population = 100;
        public static int Dimension = 1;

        public static double Upper = 1.0;
        public static double Lower = -1.0;

        public static double VMax = (Upper - Lower) * 0.1;
        public static int Run = 50;
        // reciprocalRunNumber = 1.0 / Run

        public static int Iteration = 500;
        public static double Perce = 0.2;
        //public static double pe = 0.2;
        //public static double pone = 0.8;

        // PSO parameters
        public static double weight = 0.72984; // inertia weight
        public static double c1 = 1.496172;
        public static double c2 = 1.496172;

        public static void Display()
        {
            Console.WriteLine("population {0}", Population);
            Console.WriteLine("iteration {0}", Iteration);
            Console.WriteLine("dimension {0}", Dimension);
            Console.WriteLine("run {0}", Run);
            Console.WriteLine("upper bound {0}", Upper);
            Console.WriteLine("lower bound {0}", Lower);
        }

        public static void UpdateBoundary(double boundary)
        {
            Upper = boundary;
            Lower = -boundary;
            Display();
        }

        public static void UpdateParameter(int dim)
        {
            Dimension = dim;

            Display();
        }

        public static void UpdateParameter( int dim, int ite, int popu)
        {
            Dimension = dim;
            Iteration = ite;
            Population = popu;

            Display();
        }

        public static void UpdateParameter(double low, double up, int dim, int ite, int popu)
        {
            Lower = low;
            Upper = up;
            Dimension = dim;
            Iteration = ite;
            Population = popu;

            Display();
        }
    }
}
