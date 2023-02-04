using System;

namespace BSOnonlinear
{
    // 8 multimodal functions
    public class Multimode
    {
        #region f1: Five-Uneven-Peak Trap /1D
        public static double f1(ref double[] solution)
        {
            double result = 0.0;

            if (solution[0] > 30 || solution[0] < 0)
            {
                Console.WriteLine("f1 input error");
                Console.ReadKey();
            }
            else if (solution[0] < 2.5)
                result = 80 * (2.5 - solution[0]);
            else if (solution[0] >= 2.5 && solution[0] < 5.0)
                result = 64 * (solution[0] - 2.5);
            else if (solution[0] >= 5.0 && solution[0] < 7.5)
                result = 64 * (7.5 - solution[0]);
            else if (solution[0] >= 7.5 && solution[0] < 12.5)
                result = 28 * (solution[0] - 7.5);
            else if (solution[0] >= 12.5 && solution[0] < 17.5)
                result = 28 * (17.5 - solution[0]);
            else if (solution[0] >= 17.5 && solution[0] < 22.5)
                result = 32 * (solution[0] - 17.5);
            else if (solution[0] >= 22.5 && solution[0] < 27.50)
                result = 32 * (27.5 - solution[0]);
            else result = 80 * (solution[0] - 27.5);

            return result;
        }
        #endregion

        #region f2: Equal Maxima /1D
        public static double f2(ref double[] solution)
        {
            double result = 0.0;

            if (solution[0] > 1 || solution[0] < 0)
            {
                Console.WriteLine("f2 input error");
                Console.ReadKey();
            }
            else
                result = Math.Pow(Math.Sin(5 * Math.PI * solution[0]), 6.0);

            return result;
        }
        #endregion

        #region f3: Uneven Decreasing Maxima /1D
        public static double f3(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > 1.0 || solution[0] < 0.0)
            {
                Console.WriteLine("f3 input error, input:{0}", solution[0]);
                Console.ReadKey();
            }
            result = Math.Exp(-2 * Math.Log(2) * ((solution[0] - 0.08) / 0.854) * ((solution[0] - 0.08) / 0.854))
                * Math.Pow(Math.Sin(5 * Math.PI * (Math.Pow(solution[0], 0.75) - 0.05)), 6.0);

            return result;
        }
        #endregion

        #region f4: Himmelblau /2D
        public static double f4(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > 6.0 || solution[0] < -6.0 || solution[1] > 6.0 || solution[1] < -6.0)
            {
                Console.WriteLine("f4 input error");
                Console.ReadKey();
            }
            result = 200 - (solution[0] * solution[0] + solution[1] - 11)
                * (solution[0] * solution[0] + solution[1] - 11)
                - (solution[0] + solution[1] * solution[1] - 7)
                * (solution[0] + solution[1] * solution[1] - 7);
            return result;
        }
        #endregion

        #region f5: Six-Hump Camel Back/2D
        public static double f5(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > 1.9 || solution[0] < -1.9 || solution[1] > 1.1 || solution[1] < -1.1)
            {
                Console.WriteLine("f5 input error");
                Console.ReadKey();
            }
            result = -4 * ((4 - 2.1 * solution[0] * solution[0] + Math.Pow(solution[0], 4.0) / 3.0)
                * solution[0] * solution[0] + solution[0] * solution[1]
                + (4 * solution[1] * solution[1] - 4) *
                solution[1] * solution[1]);

            return result;
        }
        #endregion

        #region f6: Shubert /2D
        public static double f6(ref double[] solution)
        {
            double result = 1.0;
            double sum = 0.0;
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (solution[i] > 10.0 || solution[i] < -10.0)
                {
                    Console.WriteLine("f6 input error");
                    Console.ReadKey();
                }
            }
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                sum = 0.0;
                for (int j = 1; j < 6; ++j)
                {
                    sum += j * Math.Cos((j + 1.0) * solution[i] + j);
                }
                result *= sum;
            }
            return -result;
        }
        #endregion

        #region f7: Vincent /2D
        public static double f7(ref double[] solution)
        {
            double result = 0.0;
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (solution[i] > 10.0 || solution[i] < 0.25)
                {
                    Console.WriteLine("f7 input error");
                    Console.ReadKey();
                }
            }
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                result += Math.Sin(10 * Math.Log(solution[i]));
            }
            return result / Parameter.Dimension;
        }
        #endregion

        #region f8: Modified Rastrigin - All Global Optima /2D
        public static double f8(ref double[] solution)
        {
            double result = 0.0;
            double[] k = new double[Parameter.Dimension];

            if (Parameter.Dimension == 2)
            {
                k[0] = 3; k[1] = 4;
            }
            else if (Parameter.Dimension == 16)
            {
                k[0] = 1; k[1] = 1; k[2] = 1; k[3] = 2;
                k[4] = 1; k[5] = 1; k[6] = 1; k[7] = 2;
                k[8] = 1; k[9] = 1; k[10] = 1; k[11] = 3;
                k[12] = 1; k[13] = 1; k[14] = 1; k[15] = 4;
            }
            else
            {
                Console.WriteLine("f8 input k_{i} error");
                Console.ReadKey();
            }

            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (solution[i] > 1.0 || solution[0] < 0.0)
                {
                    Console.WriteLine("f8 input error");
                    Console.ReadKey();
                }
            }

            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                result += 10 + 9 * Math.Cos(2 * Math.PI * k[i] * solution[i]);
            }
            return -result;
        }
        #endregion
    }
}