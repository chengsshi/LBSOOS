using System.Collections.Generic;

namespace BSOalgorithm
{
    internal class Cluster
    {
        // 该聚类的数据成员索引
        public List<int> member = new List<int>();

        // 该聚类的中心
        public double[] mean = new double[Parameter.Dimension];

        public Cluster(int centerIndex, ref double[] pivot)
        {
            member.Add(centerIndex);
            for (int i = 0; i < Parameter.Dimension; ++i)
                mean[i] = pivot[i];
        }

        // 该方法计算聚类对象的均值 
        public void updateMean(ref double[,] coordinates)
        {
            // 根据 member 取得原始 text 对象 coord ，该对象是 coordinates 的一个子集；
            // 然后取出该子集的均值；取均值的算法很简单，可以把 coordinates 想象成一个 m*n 的距阵 ,
            // 每个均值就是每个纵向列的取和平均值 , 
            // 该值保存在 center 中
            // 根据 Cluster中的member 取得原始text ID；
            // 将所有文本包含term和frequency想象成一个 m*n 的距阵 ,
            // 每个均值就是每个纵向列的取和平均值 , 该值保存在 center 中，即为新的聚类中心

            for (int i = 0; i < member.Count; i++)
            {
                // mean.Length = Parameter.Dimension
                for (int dim = 0; dim < Parameter.Dimension; dim++)
                {
                    mean[dim] += coordinates[member[i], dim]; // 得到每个纵向列的和；
                }
            }

            for (int dim = 0; dim < Parameter.Dimension; dim++)
            {
                mean[dim] /= member.Count;
                // mean[k] /= coord.Length; // 对每个纵向列取平均值
            }
        }
    }
}
