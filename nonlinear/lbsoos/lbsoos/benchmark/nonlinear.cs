using System;

namespace LearningBSOOS
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

            return result;
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
           
           sum = solution[0] * solution[0] + solution[1] * solution[1]
                + solution[2] * solution[2] + solution[3] * solution[3]
                + solution[4] * solution[4] + solution[5] * solution[5]
                + solution[6] * solution[6] + solution[7] * solution[7]
                + solution[8] * solution[8] + solution[9] * solution[9]
                + solution[10] * solution[10] + solution[11] * solution[11]
                + solution[12] * solution[12] + solution[13] * solution[13]
                + solution[14] * solution[14] + solution[15] * solution[15]
                + solution[16] * solution[16] + solution[17] * solution[17]
                + solution[18] * solution[18] + solution[19] * solution[19];           

            result = Math.Abs(sum - 1.0);

            sum = Math.Abs(solution[0] - solution[1])
                + solution[2] * solution[2] + solution[3] * solution[3]
                + solution[4] * solution[4] + solution[5] * solution[5]
                + solution[6] * solution[6] + solution[7] * solution[7]
                + solution[8] * solution[8] + solution[9] * solution[9]
                + solution[10] * solution[10] + solution[11] * solution[11]
                + solution[12] * solution[12] + solution[13] * solution[13]
                + solution[14] * solution[14] + solution[15] * solution[15]
                + solution[16] * solution[16] + solution[17] * solution[17]
                + solution[18] * solution[18] + solution[19] * solution[19];           

            result += Math.Abs(sum);

            return result;
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

            return result;
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

            return result;
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

            return result;
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

            result += Math.Abs(solution[0] * solution[0] * solution[0] * solution[4]
                + solution[1] * solution[1] * solution[1] * solution[5]);
            result += Math.Abs(solution[2] * solution[2] * solution[2] * solution[4]
                + solution[3] * solution[3] * solution[3] * solution[5]);

            result += Math.Abs(solution[0] * solution[2] * solution[2] * solution[4]
                + solution[1] * solution[3] * solution[3] * solution[5]);
            result += Math.Abs(solution[0] * solution[0] * solution[2] * solution[4]
                + solution[1] * solution[1] * solution[3] * solution[5]);

            return result;
        }
        #endregion

        #region nonlinear equations 7
        public static double n7(ref double[] solution)
        {
            double result = 0.0;
            double sum = 0;
            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (solution[i] > 1.0 || solution[i] < -1.0)
                {
                    Console.WriteLine("n7 input error");
                    Console.ReadKey();
                }
            }

            // k = 1
            result += Math.Abs((solution[0] + solution[0] * solution[1]
                + solution[2] * solution[3] + solution[3] * solution[4]
                + solution[4] * solution[5] + solution[5] * solution[6]
                + solution[6] * solution[7] + solution[7] * solution[8]
                + solution[8] * solution[9] + solution[9] * solution[10]
                + solution[10] * solution[11] + solution[11] * solution[12]
                + solution[12] * solution[13] + solution[13] * solution[14]
                + solution[14] * solution[15] + solution[15] * solution[16]
                + solution[16] * solution[17] + solution[17] * solution[18]
                ) * solution[19]);

            // k = 2
            result += Math.Abs((solution[1] + solution[0] * solution[2]
                + solution[1] * solution[3] + solution[2] * solution[4]
                + solution[3] * solution[5] + solution[4] * solution[6]
                + solution[5] * solution[7] + solution[6] * solution[8]
                + solution[7] * solution[9] + solution[8] * solution[10]
                + solution[9] * solution[11] + solution[10] * solution[12]
                + solution[11] * solution[13] + solution[12] * solution[14]
                + solution[13] * solution[15] + solution[14] * solution[16]
                + solution[15] * solution[17] + solution[16] * solution[18]
                ) * solution[19]);

            // k = 3
            result += Math.Abs((solution[2] + solution[0] * solution[3]
                + solution[1] * solution[4] + solution[2] * solution[5]
                + solution[3] * solution[6] + solution[4] * solution[7]
                + solution[5] * solution[8] + solution[6] * solution[9]
                + solution[7] * solution[10] + solution[8] * solution[11]
                + solution[9] * solution[12] + solution[10] * solution[13]
                + solution[11] * solution[14] + solution[12] * solution[15]
                + solution[13] * solution[16] + solution[14] * solution[17]
                + solution[15] * solution[18] 
                ) * solution[19]);

            // k = 4
            result += Math.Abs((solution[3] + solution[0] * solution[4]
                + solution[1] * solution[5] + solution[2] * solution[6]
                + solution[3] * solution[7] + solution[4] * solution[8]
                + solution[5] * solution[9] + solution[6] * solution[10]
                + solution[7] * solution[11] + solution[8] * solution[12]
                + solution[9] * solution[13] + solution[10] * solution[14]
                + solution[11] * solution[15] + solution[12] * solution[16]
                + solution[13] * solution[17] + solution[14] * solution[18]
                ) * solution[19]);

            // k = 5
            result += Math.Abs((solution[4] + solution[0] * solution[5]
                + solution[1] * solution[6] + solution[2] * solution[7]
                + solution[3] * solution[8] + solution[4] * solution[9]
                + solution[5] * solution[10] + solution[6] * solution[11]
                + solution[7] * solution[12] + solution[8] * solution[13]
                + solution[9] * solution[14] + solution[10] * solution[15]
                + solution[11] * solution[16] + solution[12] * solution[17]
                + solution[13] * solution[18] 
                ) * solution[19]);

            // k = 6
            result += Math.Abs((solution[5] + solution[0] * solution[6]
                + solution[1] * solution[7] + solution[2] * solution[8]
                + solution[3] * solution[9] + solution[4] * solution[10]
                + solution[5] * solution[11] + solution[6] * solution[12]
                + solution[7] * solution[13] + solution[8] * solution[14]
                + solution[9] * solution[15] + solution[10] * solution[16]
                + solution[11] * solution[17] + solution[12] * solution[18]
                ) * solution[19]);

            // k = 7
            result += Math.Abs((solution[6] + solution[0] * solution[7]
                + solution[1] * solution[8] + solution[2] * solution[9]
                + solution[3] * solution[10] + solution[4] * solution[11]
                + solution[5] * solution[12] + solution[6] * solution[13]
                + solution[7] * solution[14] + solution[8] * solution[15]
                + solution[9] * solution[16] + solution[10] * solution[17]
                + solution[11] * solution[18]
                ) * solution[19]);

            // k = 8
            result += Math.Abs((solution[7] + solution[0] * solution[8]
                + solution[1] * solution[9] + solution[2] * solution[10]
                + solution[3] * solution[11] + solution[4] * solution[12]
                + solution[5] * solution[13] + solution[6] * solution[14]
                + solution[7] * solution[15] + solution[8] * solution[16]
                + solution[9] * solution[17] + solution[10] * solution[18]
                 ) * solution[19]);

            // k = 9
            result += Math.Abs((solution[8] + solution[0] * solution[9]
                + solution[1] * solution[10] + solution[2] * solution[11]
                + solution[3] * solution[12] + solution[4] * solution[13]
                + solution[5] * solution[14] + solution[6] * solution[15]
                + solution[7] * solution[16] + solution[8] * solution[17]
                + solution[9] * solution[18]
                ) * solution[19]);

            // k = 10
            result += Math.Abs((solution[9] + solution[0] * solution[10]
                + solution[1] * solution[11] + solution[2] * solution[12]
                + solution[3] * solution[13] + solution[4] * solution[14]
                + solution[5] * solution[15] + solution[6] * solution[16]
                + solution[7] * solution[17] + solution[8] * solution[18]
                ) * solution[19]);

            // k = 11
            result += Math.Abs((solution[10] + solution[0] * solution[11]
                + solution[1] * solution[12] + solution[2] * solution[13]
                + solution[3] * solution[14] + solution[4] * solution[15]
                + solution[5] * solution[16] + solution[6] * solution[17]
                + solution[7] * solution[18]
                ) * solution[19]);

            // k = 12
            result += Math.Abs((solution[11] + solution[0] * solution[12]
                + solution[1] * solution[13] + solution[2] * solution[14]
                + solution[3] * solution[15] + solution[4] * solution[16]
                + solution[5] * solution[17] + solution[6] * solution[18]
                ) * solution[19]);

            // k = 13
            result += Math.Abs((solution[12] + solution[0] * solution[13]
                + solution[1] * solution[14] + solution[2] * solution[15]
                + solution[3] * solution[16] + solution[4] * solution[17]
                + solution[5] * solution[18] 
                ) * solution[19]);

            // k = 14
            result += Math.Abs((solution[13] + solution[0] * solution[14]
                + solution[1] * solution[15] + solution[2] * solution[16]
                + solution[3] * solution[17] + solution[4] * solution[18]
                ) * solution[19]);

            // k = 15
            result += Math.Abs((solution[14] + solution[0] * solution[15]
                + solution[1] * solution[16] + solution[2] * solution[17]
                + solution[3] * solution[18] 
                ) * solution[19]);

            // k = 16
            result += Math.Abs((solution[15] + solution[0] * solution[16]
                + solution[1] * solution[17] + +solution[2] * solution[18]
                ) * solution[19]);

            // k = 17
            result += Math.Abs((solution[16] + solution[0] * solution[17]
                + solution[1] * solution[18])
                * solution[19]);

            // k = 18
            result += Math.Abs((solution[17] + solution[0] * solution[18]) * solution[19]);

            // k = 19
            result += Math.Abs(solution[18] * solution[19]);


            for (int i = 0; i < Parameter.Dimension - 1; ++i)
            {
                sum += solution[i];
            }

            sum = Math.Abs(sum + 1.0);

            return result + sum;
        }
        #endregion

    }
}