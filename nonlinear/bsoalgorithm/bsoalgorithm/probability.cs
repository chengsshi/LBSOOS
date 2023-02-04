using System;

namespace BSOalgorithm
{
    class Probability
    {
        public static double cauchy(double variate)
        {
            return 1.0 / (Math.PI * (1 + variate * variate));
        }

        // \mu -> mean \mu = 0.0
        // \sigma -> standard deviation \sigma = 1.0
        public static double gaussian(double variate)
        {
            // Console.WriteLine(Math.Exp(-0.5 * variate * variate));
            double result = Math.Exp(-0.5 * variate * variate) / Math.Sqrt(2.0 * Math.PI);
            return result;
        }

        // Logistic function: logsig(x) = 1.0 / (1.0 + \exp(-x))
        public static double logsig(double variate)
        {
            return 1.0 / (1.0 + Math.Exp(-1.0 * variate));
        }
    }
}