using System;
using System.IO;
using System.Text;

namespace PSOnonlinear
{
    public class Parameter
    {
        public static int Population = 100; // population size
        // public static double epsilon = 0.0;
        public static double Velocity = 1;
        public static double Upper = 1.0;
        public static double Lower = 0.0;

        public static int Iteration = 500; // maximum of iteration
        public static double Weight = 0.72984; // inertia weight
        public static int Dimension = 1; // dimension
        public static int Run = 50; //numbre of runs

        public static double c1 = 1.496172;
        public static double c2 = 1.496172;

        public static void Display()
        {
            Console.WriteLine("population{0}", Population);
            Console.WriteLine("Velocity {0}", Velocity);
            Console.WriteLine("Position {0}", Upper);
            Console.WriteLine("Iteration {0}", Iteration);
            Console.WriteLine("weight {0}", Weight);
            Console.WriteLine("dimension {0}", Dimension);
            Console.WriteLine("run {0}", Run);
        }

        public static void UpdateParameter(double low, double up, int dimesion)
        {
            Parameter.Upper = up;
            Parameter.Lower = low;
            Parameter.Dimension = dimesion;

            Parameter.Velocity = 0.1 * (up - low);
        }

        public static void UpdateParameter(double low, double up, int dimesion, int ite)
        {
            Parameter.Upper = up;
            Parameter.Lower = low;
            Parameter.Dimension = dimesion;
            Parameter.Iteration = ite;

            Parameter.Velocity = 0.1 * (up - low);
        }

        public static void UpdateParameter(double low, double up, int dimesion, int ite, int popu)
        {
            Parameter.Upper = up;
            Parameter.Lower = low;
            Parameter.Dimension = dimesion;
            Parameter.Population = popu;
            Parameter.Iteration = ite;

            Parameter.Velocity = 0.1 * (up - low);
        }
    }
}
