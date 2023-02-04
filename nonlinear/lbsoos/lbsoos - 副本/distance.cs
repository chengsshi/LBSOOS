using System;
using System.Collections.Generic;

namespace LearningBSOOS
{
    class Distance
    {
        public static double euclidean(ref double[] solution, ref double[] cluster)
        {
            double distance = 0.0;
            for (int dim = 0; dim < Parameter.Dimension; ++dim)
            {
                distance += (solution[dim] - cluster[dim]) * (solution[dim] - cluster[dim]);
            }
            distance = Math.Sqrt(distance);

            return distance;
        }

        public static int minimumIndex(ref double[] solution, ref double[,] enough)
        {
            int idx = 0;
            double[] distanceValue = new double[Archive.Number];

            // List<double> individualSort = new List<double>();

            double distance = double.MaxValue;
            for (int num = 0; num < Archive.Number; num++)
            {
                for (int dim = 0; dim < Parameter.Dimension; dim++)
                {
                    distanceValue[num] += (solution[dim] - enough[num, dim]) * (solution[dim] - enough[num, dim]);
                }

                distanceValue[num] = Math.Sqrt(distanceValue[num]);

                if (distanceValue[num] < distance)
                {
                    distance = distanceValue[num];
                    idx = num;
                }
            }

            return idx;
        }

        public static double manhattan(ref double[] solution, ref double[] cluster)
        {
            double distance = 0.0;

            for (int dim = 0; dim < Parameter.Dimension; ++dim)
            {
                distance += Math.Abs(solution[dim] - cluster[dim]);
            }

            return distance;
        }
    }
}