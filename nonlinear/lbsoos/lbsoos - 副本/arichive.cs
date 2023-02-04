using System;

namespace LearningBSOOS
{
    public class Archive
    {
        public static int Number = 200;

        public static double metric = 1.0E-4;
        public static int num = 0;
        // public static double repara = 0.1;
        // int num = 0;

        public static void ArchiveUpdate(ref double[,] population, ref double[] fitness, ref double[,] enough)
        {
            double[] solution = new double[Parameter.Dimension];

            int minIdx = 0;

            Random rand = new Random();

            for (int idx = 0; idx < Parameter.Population; ++idx)
            {
                if (fitness[idx] < metric)
                {
                    if (num < Number)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            enough[num, dim] = population[idx, dim];
                        }
                        num++;
                    }
                    else
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            solution[dim] = population[idx, dim];
                        }
                        minIdx = Distance.minimumIndex(ref solution, ref enough);

                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            enough[minIdx, dim] = solution[dim];
                        }

                        //if (rand.NextDouble() < repara)
                        //{
                        //    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        //    {
                        //        population[idx, dim] = Parameter.Lower + (Parameter.Upper - Parameter.Lower) * rand.NextDouble();
                        //    }
                        //}
                    }
                }
            }
        }

        public static void AchiveMeasure(Function type, ref int count2, ref int count4, ref double[,] enough)
        {
            switch (type)
            {
                case Function.n1:
                    count2 += Measure2.N1measure(ref enough);
                    count4 += Measure4.N1measure(ref enough);
                    break;

                case Function.n2:
                    count2 += Measure2.N2measure(ref enough);
                    count4 += Measure4.N2measure(ref enough);
                    break;

                case Function.n3:
                    count2 += Measure2.N3measure(ref enough);
                    count4 += Measure4.N3measure(ref enough);
                    break;

                case Function.n4:
                    count2 += Measure2.N4measure(ref enough);
                    count4 += Measure4.N4measure(ref enough);
                    break;

                case Function.n5:
                    count2 += Measure2.N5measure(ref enough);
                    count4 += Measure4.N5measure(ref enough);
                    break;

                case Function.n6:
                    count2 += Measure2.N6measure(ref enough);
                    count4 += Measure4.N6measure(ref enough);
                    break;

                case Function.n7:
                    count2 += Measure2.N7measure(ref enough);
                    count4 += Measure4.N7measure(ref enough);
                    break;

                default:
                    Console.WriteLine("Not a valid function type");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

