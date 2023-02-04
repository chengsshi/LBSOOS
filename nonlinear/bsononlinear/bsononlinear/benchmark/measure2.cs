using System;

namespace BSOOS
{
    public class Measure2
    {
        readonly static double EPSILON = 1.0E-02;

        #region n1: nonlinear function 1
        public static int N1measure(ref double[,] position)
        {
            int global = 2;
            double fitness = 0.0;
            double radius = 0.5;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            bool[] flag = new bool[global];
            int count = 0;

            for (int num = 0; num < Parameter.Population; ++num)
            {
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    //Console.WriteLine(position[i, j]);
                    solution[dim] = position[num, dim];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n1(ref solution)) < EPSILON)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            real[0, dim] = position[num, dim];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int co = 0; co < count; ++co)
                        {
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                compare[dim] = real[co, dim];
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
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                real[count, dim] = position[num, dim];
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
        public static int N2measure(ref double[,] position)
        {
            int global = 2;
            double fitness = 0;
            double radius = 0.5;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            bool[] flag = new bool[global];
            int count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    //Console.WriteLine(position[i, j]);
                    solution[dim] = position[i, dim];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n2(ref solution)) < EPSILON)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            real[0, dim] = position[i, dim];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int co = 0; co < count; ++co)
                        {
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                compare[dim] = real[co, dim];
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
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                real[count, dim] = position[i, dim];
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
        public static int N3measure(ref double[,] position)
        {
            int global = 11;
            double fitness = 0.0;
            double radius = 0.05;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            bool[] flag = new bool[global];
            int count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    //Console.WriteLine(position[i, j]);
                    solution[dim] = position[i, dim];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n3(ref solution)) < EPSILON)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[0, j] = position[i, j];
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
                                compare[k] = real[j, k];
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
                                real[count, j] = position[i, j];
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
        public static int N4measure(ref double[,] position)
        {
            int global = 15;
            double fitness = 0.0;
            double radius = 0.05;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            bool[] flag = new bool[global];
            int count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[i, j]);
                    solution[j] = position[i, j];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n4(ref solution)) < EPSILON)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[0, j] = position[i, j];
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
                                compare[k] = real[j, k];
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
                                real[count, j] = position[i, j];
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
        public static int N5measure(ref double[,] position)
        {
            int global = 2000;
            double fitness = 0.0;
            double radius = 0.01;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            bool[] flag = new bool[global];
            int count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int j = 0; j < Parameter.Dimension; ++j)
                {
                    //Console.WriteLine(position[i, j]);
                    solution[j] = position[i, j];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n5(ref solution)) < EPSILON)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[0, j] = position[i, j];
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
                                compare[k] = real[j, k];
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
                                real[count, j] = position[i, j];
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
        public static int N6measure(ref double[,] position)
        {
            int global = 2000;
            double fitness = 0.0;
            double radius = 0.01;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            bool[] flag = new bool[global];
            int count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    //Console.WriteLine(position[i, j]);
                    solution[dim] = position[i, dim];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n6(ref solution)) < EPSILON)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int j = 0; j < Parameter.Dimension; ++j)
                        {
                            real[0, j] = position[i, j];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int co = 0; co < count; ++co)
                        {
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                compare[dim] = real[co, dim];
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
                                real[count, j] = position[i, j];
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
        public static int N7measure(ref double[,] position)
        {
            int global = 2000;
            double fitness = 0.0;
            double radius = 0.01;
            double[] solution = new double[Parameter.Dimension];
            double[] compare = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            bool[] flag = new bool[global];
            int count = 0;

            for (int i = 0; i < Parameter.Population; ++i)
            {
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    //Console.WriteLine(position[i, j]);
                    solution[dim] = position[i, dim];
                }

                // Console.WriteLine(Benchmark.f1(ref solution));
                if (Math.Abs(fitness - Nonlinear.n7(ref solution)) < EPSILON)
                {
                    if (count == 0)
                    {
                        flag[count] = true;
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            real[0, dim] = position[i, dim];
                        }
                        count += 1;
                    }
                    else
                    {
                        flag[count] = true;
                        for (int j = 0; j < count; ++j)
                        {
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                compare[dim] = real[j, dim];
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
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                real[count, dim] = position[i, dim];
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