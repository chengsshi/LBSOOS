using System;
using System.IO;
using System.Text;

namespace PIOalgorithm
{
    public class Parameter
    {
        public static int Population = 100; // population size
        //public static int ArchiveNum = 500;

        // public static double epsilon = 0.0;
        public static double clamp = 0.1;
        public static double Upper = 1.0;
        public static double Lower = -1.0;


        // public static int Iteration = 500; // maximum of iteration
        public static int Nc1max = 450;
        public static int Nc2max = 50;

        public static int Nc1 = 90;
        public static int Nc2 = 10;
        public static int NCsum = 100; // 90 + 10

        public static int NUM = 6;

        public static int Ncmax = Nc1max + Nc2max;
        // public static double varepsilon = 1e-10;
        // public static double Weight = 0.72984; // inertia weight
        public static int Dimension = 2; // dimension
        public static int Run = 50; //numbre of runs
        public static double decreaseK = 1.25;  

        // the map and compass factor
        public static double R = 0.2;       

        public static void Display()
        {
            Console.WriteLine("population{0}", Population);
            // Console.WriteLine("Velocity {0}", Velocity);
            Console.WriteLine("Position {0}", Upper);
            Console.WriteLine("Iteration {0}", Ncmax);
            // Console.WriteLine("weight {0}", Weight);
            Console.WriteLine("dimension {0}", Dimension);
            Console.WriteLine("run {0}", Run);
        }

        //public static void updateParameter(double low, double up, int dimesion)
        //{
        //    Parameter.Upper = up;
        //    Parameter.Lower = low;
        //    Parameter.Dimension = dimesion;

        //    Parameter.Velocity = 0.1 * (up - low);
        //}

        //public static void updateParameter(double low, double up, int dimesion, int ite)
        //{
        //    Parameter.Upper = up;
        //    Parameter.Lower = low;
        //    Parameter.Dimension = dimesion;
        //    Parameter.Iteration = ite;

        //    Parameter.Velocity = 0.1 * (up - low);
        //}

        //public static void updateParameter(double low, double up, int dimesion, int ite, int popu)
        //{
        //    Parameter.Upper = up;
        //    Parameter.Lower = low;
        //    Parameter.Dimension = dimesion;
        //    Parameter.Population = popu;
        //    Parameter.Iteration = ite;

        //    Parameter.Velocity = 0.1 * (up - low);
        //}
    }
}
