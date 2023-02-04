using System;

namespace PSOnonlinear
{
    public class Nonlinear
    {
        #region nonlinear equations 1 
        public static double n1(ref double[] solution)
        {
            double result = 1.0;
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (solution[i] > 1.0 || solution[i] < -1.0)
                {
                    Console.WriteLine("n1 input error");
                    Console.ReadKey();
                }
            }

            result = Math.Abs(solution[0] - solution[1])
                + Math.Abs(solution[0] * solution[0] + solution[1] * solution[1] - 1.0);

            return -result;
        }
        #endregion

        #region nonlinear equations 2
        public static double n2(ref double[] solution)
        {
            double result = 0.0;
            double sum = 0.0;
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (solution[i] > 1.0 || solution[i] < -1.0)
                {
                    Console.WriteLine("n2 input error");
                    Console.ReadKey();
                }
            }

            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                sum += solution[i] * solution[i];
            }

            result = Math.Abs(sum - 1.0);

            sum = Math.Abs(solution[0] - solution[1]);
            for (int i = 2; i < Parameter.Dimension; ++i)
            {
                sum += solution[i] * solution[i];
            }

            result += Math.Abs(sum);

            //if (result < 0.01)
            //{
            //    Console.ReadKey();
            //}

            return -result;
        }
        #endregion

        #region n3: nonlinear equations 3
        public static double n3(ref double[] solution)
        {
            double result = 1.0;
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (solution[i] > 1.0 || solution[i] < -1.0)
                {
                    Console.WriteLine("n3 input error");
                    Console.ReadKey();
                }
            }

            result = Math.Abs(solution[0] - solution[1])
                + Math.Abs(solution[0] - Math.Sin(5 * Math.PI * solution[1]));

            return -result;
        }
        #endregion

        #region nonlinear equations 4
        public static double n4(ref double[] solution)
        {
            double result = 1.0;
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (solution[i] > 1.0 || solution[i] < -1.0)
                {
                    Console.WriteLine("n4 input error");
                    Console.ReadKey();
                }
            }

            result = Math.Abs(solution[0] * solution[0] + solution[1] * solution[1] - 1.0)
                + Math.Abs(solution[0] - Math.Cos(4 * Math.PI * solution[1]));

            return -result;
        }
        #endregion

        #region nonlinear equations 5
        public static double n5(ref double[] solution)
        {
            double result = 1.0;
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (solution[i] > 1.0 || solution[i] < -1.0)
                {
                    Console.WriteLine("n5 input error");
                    Console.ReadKey();
                }
            }

            result = Math.Abs(solution[0] + solution[1] + solution[2] - 1.0)
                + Math.Abs(solution[0] - (solution[1] * solution[1] * solution[1]));

            return -result;
        }
        #endregion

        #region nonlinear equations 6
        public static double n6(ref double[] solution)
        {
            double result = 0.0;
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (solution[i] > 1.0 || solution[i] < -1.0)
                {
                    Console.WriteLine("n6 input error");
                    Console.ReadKey();
                }
            }

            result = Math.Abs(solution[0] * solution[0] + solution[2] * solution[2] - 1.0);
            result += Math.Abs(solution[1] * solution[1] + solution[3] * solution[3] - 1.0);
            result += Math.Abs(solution[4] * solution[2] * solution[2] * solution[2]
                + solution[5] * solution[3] * solution[3] * solution[3]);
            result += Math.Abs(solution[4] * solution[0] * solution[0] * solution[0]
                + solution[5] * solution[1] * solution[1] * solution[1]);
            result += Math.Abs(solution[4] * solution[2] * solution[2] * solution[2]
                + solution[5] * solution[3] * solution[3] * solution[3]);
            result += Math.Abs(solution[4] * solution[2] * solution[2] * solution[2]
                + solution[5] * solution[3] * solution[3] * solution[3]);

            return -result;
        }
        #endregion

        #region nonlinear equations 7
        public static double n7(ref double[] solution)
        {
            double result = 1.0;
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (solution[i] > 1.0 || solution[i] < -1.0)
                {
                    Console.WriteLine("n7 input error");
                    Console.ReadKey();
                }
            }
			// k = 1
			

            result = Math.Abs(solution[0] - solution[1])
                + Math.Abs(solution[0] - Math.Sin(5 * Math.PI * solution[1]));

            return -result;
        }
        #endregion

    }
}