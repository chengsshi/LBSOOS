using System;

namespace BSOOS
{
    class Probability
    {
        public static double cauchy(double variate)
        {
            return 1.0 / (Math.PI * (1 + variate * variate));
        }

        // \mu -> mean \mu = 0.0
        // \sigma -> standard deviation \sigma = 1.0
        //public static double gaussian(double variate)
        //{
        //    // Console.WriteLine(Math.Exp(-0.5 * variate * variate));
        //    double result = Math.Exp(-0.5 * variate * variate) / Math.Sqrt(2.0 * Math.PI);
        //    return result;
        //}

        //public static double GaussRand(double dExpect, double dVariance)
        //{
        //    double V1 =0;
        //    double V2 = 0;
        //    double S = 0;
        //    int phase = 0;
        //    double X;
        //    Random rand = new Random();

        //    if (phase == 0)
        //    {
        //        do
        //        {
        //            double U1 =  rand.NextDouble();
        //            double U2 =  rand.NextDouble();

        //            V1 = 2 * U1 - 1;
        //            V2 = 2 * U2 - 1;
        //            S = V1 * V1 + V2 * V2;
        //        } while (S >= 1 || S == 0);

        //        X = V1 * Math.Sqrt(-2 * Math.Log(S) / S);
        //    }
        //    else
        //    {
        //        X = V2 * Math.Sqrt(-2 * Math.Log(S) / S);
        //    }

        //    phase = 1 - phase;

        //    return (X * dVariance + dExpect);
        //}

        // \mu -> mean \mu = 0.0
        // \sigma -> standard deviation \sigma = 1.0
        public static double gaussian(double variate)
        {
            // Console.WriteLine(Math.Exp(-0.5 * variate * variate));
            double result = Math.Exp(-0.5 * variate * variate) / Math.Sqrt(2.0 * Math.PI);
            return result;
        }

        public static double Gaussian(double dExpect, double dVariance)
        {
            double V1 = 0;
            double V2 = 0;
            double S = 0.0;
            double result = 0.0;
            int phase = 0;
            double x = 0.0;
            Random rand = new Random();
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            rand = new Random(iSeed);
            // Console.WriteLine(Guid.NewGuid().ToString());

            if (phase == 0)
            {
                do
                {
                    double U1 = rand.NextDouble();
                    // Console.WriteLine("rand value U1 {0}", U1);
                    double U2 = rand.NextDouble();
                    //Console.WriteLine("U2 rand value {0}", U2);

                    V1 = 2 * U1 - 1;
                    V2 = 2 * U2 - 1;
                    S = V1 * V1 + V2 * V2;
                } while (S >= 1.0 || S == 0.0);

                x = V1 * Math.Sqrt(-2 * Math.Log(S) / S);
            }
            else
            {
                x = V2 * Math.Sqrt(-2 * Math.Log(S) / S);
            }

            phase = 1 - phase;
            result = x * dVariance + dExpect;

            // Console.WriteLine("Gaussian value {0}", result);
            // Console.ReadKey();
            return result;
        }

        // Logistic function: logsig(x) = 1.0 / (1.0 + \exp(-x))
        public static double logsig(double variate)
        {
            return 1.0 / (1.0 + Math.Exp(-1.0 * variate));
        }
    }
}