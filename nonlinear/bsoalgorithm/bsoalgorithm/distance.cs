using System;

namespace BSOalgorithm
{
    class Distance
    {
        public static double euclidean(ref double[] solution, ref double[] cluster)
        {
            double distance = 0.0;
            for (int dim = 0; dim < Parameter.Dimension; ++dim)
            {
                distance += (solution[dim] - cluster[dim])
                    * (solution[dim] - cluster[dim]);
            }
            distance = Math.Sqrt(distance);

            return distance;
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