using System;

namespace PSOnonlinear
{
    public class Measure
    {
        static int global = 0;
        static double fitness = 0.0;
        static double radius = 0.0;
        static int count = 0;
        static double epsilon = 1.0E-04;

        #region f1: Five-Uneven-Peak Trap /1D
        public static int F1(ref double[,] position)
        {
            global = 2;
            fitness = 200;
            radius = 0.01;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];
            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[j, i]);
                    solution[j] = position[j, i];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Benchmark.F1(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, 0] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            // Console.WriteLine(distance(ref solution, ref compare));
                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return count;
        }
        #endregion

        #region f2: Equal Maxima /1D
        public static int F2(ref double[,] position)
        {
            global = 5;
            fitness = 1.0;
            radius = 0.01;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];
            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[j, i]);
                    solution[j] = position[j, i];
                }

                // Console.WriteLine(Benchmark.f2(ref solution));
                if (Math.Abs(fitness - Benchmark.F2(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, 0] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            // Console.WriteLine(distance(ref solution, ref compare));
                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return count;
        }
        #endregion

        #region f3: Uneven Decreasing Maxima /1D
        public static int f3(ref double[,] population)
        {
            global = 1;
            fitness = 1.0;
            radius = 0.01;

            double[] solution = new double[Parameter.Dimension];
            //double real = 0.1;
            count = 0;
            for (int i = 0; i < Parameter.Population; ++i)
            {

                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    solution[j] = population[j, i];
                }
                if (Math.Abs(fitness - Benchmark.F3(ref solution)) < epsilon)
                {
                    count = 1;
                    break;
                }
            }
            return count;
        }
        #endregion

        #region f4: Himmelblau /2D
        public static int f4(ref double[,] position)
        {
            global = 4;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];
            fitness = 200.0;
            radius = 0.01;

            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[j, i]);
                    solution[j] = position[j, i];
                }

                // Console.WriteLine(Benchmark.f4(ref solution));
                if (Math.Abs(fitness - Benchmark.F4(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, 0] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            // Console.WriteLine(distance(ref solution, ref compare));
                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return count;
        }
        #endregion

        #region f5: Six-Hump Camel Back/2D
        public static int f5(ref double[,] solution)
        {
            global = 2;
            fitness = 1.03163;
            radius = 0.5;

            return count;
        }
        #endregion

        #region f6: Shubert /2D
        public static int f6(ref double[,] position)
        {
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];

            if (Parameter.Dimension == 2)
            {
                global = 18;
                fitness = 186.731;
                radius = 0.5;
            }
            else if (Parameter.Dimension == 3)
            {
                global = 81;
                fitness = 2709.0935;
                radius = 0.5;
            }
            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    solution[j] = position[j, i];
                }

                if (Math.Abs(fitness - Benchmark.F6(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, count] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return count;
        }
        #endregion

        #region f7: Vincent /2D
        public static int f7(ref double[,] position)
        {
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];
            if (Parameter.Dimension == 2)
            {
                global = 36;
                fitness = 1.0;
                radius = 0.2;
            }
            else if (Parameter.Dimension == 3)
            {
                global = 216;
                fitness = 1.0;
                radius = 0.2;
            }

            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    solution[j] = position[j, i];
                }

                if (Math.Abs(fitness - Benchmark.F7(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, count] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return count;
        }
        #endregion

        #region f8: Modified Rastrigin - All Global Optima /2D
        public static int f8(ref double[,] position)
        {
            radius = 0.01;
            if (Parameter.Dimension == 2)
            {
                global = 12;
                fitness = -2.0;
            }
            else if (Parameter.Dimension == 16)
            {
                global = 48;
                fitness = -16.0;
            }

            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];

            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    solution[j] = position[j, i];
                }

                if (Math.Abs(fitness - Benchmark.F8(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, count] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return count;
        }
        #endregion

        #region n1: nonlinear function 1
        public static int n1(ref double[,] position)
        {
            global = 2;
            fitness = 0;
            radius = 0.1;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];
            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[j, i]);
                    solution[j] = position[j, i];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n1(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, 0] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            // Console.WriteLine(distance(ref solution, ref compare));
                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return count;
        }
        #endregion

        #region n2: nonlinear function 2
        public static int n2(ref double[,] position)
        {
            global = 11;
            fitness = 0;
            radius = 0.05;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];
            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[j, i]);
                    solution[j] = position[j, i];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n2(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, 0] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            // Console.WriteLine(distance(ref solution, ref compare));
                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return count;
        }
        #endregion

        #region n3: nonlinear function 3
        public static int n3(ref double[,] position)
        {
            global = 11;
            fitness = 0;
            radius = 0.05;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];
            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[j, i]);
                    solution[j] = position[j, i];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n3(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, 0] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            // Console.WriteLine(distance(ref solution, ref compare));
                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return count;
        }
        #endregion

        #region n4: nonlinear function 4
        public static int n4(ref double[,] position)
        {
            global = 15;
            fitness = 0;
            radius = 0.05;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];
            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[j, i]);
                    solution[j] = position[j, i];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n4(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, 0] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            // Console.WriteLine(distance(ref solution, ref compare));
                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return count;
        }
        #endregion

        #region n5: nonlinear function 5
        public static int n5(ref double[,] position)
        {
            global = 2000;
            fitness = 0;
            radius = 0.01;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];
            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[j, i]);
                    solution[j] = position[j, i];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n5(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, 0] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            // Console.WriteLine(distance(ref solution, ref compare));
                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return count;
        }
        #endregion

        #region n6: nonlinear function 6
        public static int n6(ref double[,] position)
        {
            global = 2000;
            fitness = 0;
            radius = 0.01;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];
            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[j, i]);
                    solution[j] = position[j, i];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n6(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, 0] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            // Console.WriteLine(distance(ref solution, ref compare));
                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return count;
        }
        #endregion

        #region n7: nonlinear function 7
        public static int n7(ref double[,] position)
        {
            global = 2000;
            fitness = 0;
            radius = 0.01;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[Parameter.Dimension, global];
            bool[] flag = new bool[global];
            count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[j, i]);
                    solution[j] = position[j, i];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n7(ref solution)) < epsilon)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[j, 0] = position[j, i];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int k = 0; k < Parameter.Dimension; ++k)
                            {
                                compare[k] = real[k, j];
                            }

                            // Console.WriteLine(distance(ref solution, ref compare));
                            if (distance(ref solution, ref compare) < radius)
                            {
                                flag[count] = false;
                                break;
                            }
                        }

                        if (flag[count])
                        {
                            for (int j = 0; j < Parameter.Dimension; ++j)
                            {
                                real[j, count] = position[j, i];
                            }
                            count += 1;
                            if (count == global)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return count;
        }
        #endregion

        #region distance
        public static double distance(ref double[] source, ref double[] destination)
        {
            double result = 0.0;

            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                result += (source[i] - destination[i]) * (source[i] - destination[i]);
            }

            return Math.Sqrt(result);
        }
        #endregion
    }
}