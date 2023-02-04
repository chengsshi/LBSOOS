using System;
using System.Collections.Generic;
using System.Text;

namespace BSOBSOOS
{
    class Kmeans
    {
        // 数据的数量
        // Cluster for all the solutions
        // The number of data is equal to the population size 
        // 原始数据
        // The data is the brainstorm.group, i.e., the solutions of swarm

        Dictionary<int, double> result = new Dictionary<int, double>();
        // 聚类的数量
        int kCluster;
        // 聚类
        private Cluster[] clusters;

        // 定义一个变量用于记录和跟踪每个资料点属于哪个群聚类
        // record the cluster of a solution
        int[] clusterAssignment;

        // 定义一个变量用于记录和跟踪每个资料点离聚类最近
        // record the nearest cluster for a solution
        static int[] nearCluster;

        // 定义一个变量，来表示资料点到中心点的距离,
        // 其中 distanceCache[i,j]表示第i个solution
        // 到第j个群聚对象中心点的距离；

        double[,] distanceCache;

        // 用来初始化的随机种子
        private static readonly Random rand = new Random();

        public Kmeans(int k, ref double[,] group)
        {
            kCluster = k;
            clusters = new Cluster[k];
            clusterAssignment = new int[Parameter.Population];
            nearCluster = new int[Parameter.Population];
            distanceCache = new double[Parameter.Population, Parameter.Population];
            initializeCenter(ref group);
        }

        public void KmeansProcess(ref double [,] group)
        {
            // int iter = 0;
            while (true)
            {
                // Console.WriteLine("Iteration " + (iter++) + "...");
                // 1. 重新计算每个聚类的均值
                for (int i = 0; i < kCluster; i++)
                {
                    clusters[i].updateMean(ref group);
                }

                // 2. 计算每个数据和每个聚类中心的距离
                double[] solution = new double[Parameter.Dimension];

                for (int atom = 0; atom < Parameter.Population; atom++)
                {
                    for (int dim = 0; dim < Parameter.Dimension; dim++)
                    {
                        solution[dim] = group[atom, dim];
                    }
                    for (int clu = 0; clu < kCluster; clu++)
                    {
                        double dist = getDistance(ref solution, ref clusters[clu].mean);
                        distanceCache[atom, clu] = dist;
                    }
                }

                //3、计算每个数据离哪个聚类最近
                for (int i = 0; i < Parameter.Population; i++)
                {
                    nearCluster[i] = nearestCluster(i);
                }

                // 4、比较每个数据最近的聚类是否就是它所属的聚类
                // 如果全相等表示所有的点已经是最佳距离了，直接返回；
                int k = 0;
                for (int atom = 0; atom < Parameter.Population; atom++)
                {
                    if (nearCluster[atom] == clusterAssignment[atom])
                        k++;

                }
                if (k == Parameter.Population)
                {
                    for (int atom = 0; atom < Parameter.Population; atom++)
                    {
                        LearningBSO.cluster[atom] = nearCluster[atom];
                    }
                    break;
                }
                // 5、否则需要重新调整资料点和群聚类的关系, 调整完毕后再重新开始循环;
                // 需要修改每个聚类的成员和表示某个数据属于哪个聚类的变量
                for (int j = 0; j < kCluster; j++)
                {
                    clusters[j].member.Clear();
                }
                for (int i = 0; i < Parameter.Population; i++)
                {
                    clusters[nearCluster[i]].member.Add(i);
                    clusterAssignment[i] = nearCluster[i];
                }
            }              
        }

        // 计算某个数据离哪个聚类最近
        int nearestCluster(int textIndex)
        {
            int nearest = -1;
            double dis = 0.0;
            double min = Double.MaxValue;
            for (int center = 0; center < kCluster; center++)
            {
                dis = distanceCache[textIndex, center];
                if (dis < min)
                {
                    min = dis;
                    nearest = center;
                }
            }
            return nearest;
        }

        // calculate the distance between solution and cluster center
        static double getDistance(ref double[] solution, ref double[] center)
        {
            // Euclidean Distance
            // return Distance.euclidean(ref solution, ref center);

            // Manhattan
            return Distance.manhattan(ref solution, ref center);
        }

        // random initialize k cluster center
        private void initializeCenter(ref double[,] group)
        {
            double[] centerValue = new double[Parameter.Dimension];
            for (int clu = 0; clu < kCluster; clu++)
            {
                int center = rand.Next(Parameter.Population);
                clusterAssignment[center] = clu; // record 第temp个资料属于第i个聚类
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    centerValue[dim] = group[center, dim];
                clusters[clu] = new Cluster(center, ref centerValue);
            }
        }
    }
}