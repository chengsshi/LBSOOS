using System;

namespace BSOOS
{
    public class Parameter
    {
        public static int Population = 100;
        public static int Dimension = 2;
        public static double Boundary = 1.0;

        public static double Lower = -1.0;
        public static double Upper = 1.0;
        public static int Run = 50;
        // reciprocalRunNumber = 1.0 / Run

        public static int Iteration = 500;
        //public static double slope = 25;
        public static double Perce = 0.1;
        //public static double pe = 0.2;
        //public static double pone = 0.8;     
        
        public static void Display()
        {
            Console.WriteLine("population {0}", Population);
            Console.WriteLine("iteration {0}", Iteration);
            Console.WriteLine("dimension {0}", Dimension);
            Console.WriteLine("run {0}", Run);
            Console.WriteLine("upper bound {0}", Upper);
            Console.WriteLine("lowe bound {0}", Lower);
        }

        public static void UpdateParameter(int dim)
        {
            Parameter.Dimension = dim;

            Display();
        }

        public static void UpdateParameter(int dimesion, int ite, int popu)
        {
            Parameter.Dimension = dimesion;
            Parameter.Iteration = ite;
            Parameter.Population = popu;

            Display();
        }
    }
}
