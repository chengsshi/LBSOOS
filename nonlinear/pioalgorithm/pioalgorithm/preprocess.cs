using System;

namespace PIOalgorithm
{
    public class Preprocess
    {
        // fastFractal
        //    initialization(ref f3bound, );
        //    initialization(ref f4bound, );

        //    initialization(ref f5bound, 10.0);
        //    initialization(ref f6bound, 5.12);
        //    initialization(ref f7bound, 5.12);
        //    initialization(ref f8bound, 32.0);
        //    initialization(ref f9bound, 600);
        //    initialization(ref f10bound, 50.0);

        //public static void preprocess()
        //{
        //    initialization(ref f0, 100.0);
        //    initialization(ref f1, 10.0);
        //    initialization(ref f2, 100.0);
        //    initialization(ref f3, 100.0);
        //    initialization(ref f4, 1.28);

        //    initialization(ref f5, 10.0);
        //    initialization(ref f6, 5.12);
        //    initialization(ref f7, 5.12);
        //    initialization(ref f8, 32.0);
        //    initialization(ref f9, 600);
        //    initialization(ref f10, 50.0);
        //}

        public static void initialization(double up, double low)
        {
            Parameter.Upper = up;
            Parameter.Lower = low;
            Parameter.clamp = 0.1 * (up - low);
        }

        public static void Initialization(int dim)
        {
            Parameter.Dimension = dim;
        }

        public static void Initialization(int dim, double up, double low)
        {
            Parameter.Dimension = dim;
            Parameter.Upper = up;
            Parameter.Lower = low;
            Parameter.clamp = 0.1 * (up - low);
        }

        //public static void initialization(ref double[] function, double clamp)
        //{
        //    Random rand = new Random(); 
        //    for (int i = 0; i < Parameter.Dimension; i++)
        //    {
        //        function[i] = 2 * clamp * rand.NextDouble() - clamp;
        //    }
        //}

    }
}
