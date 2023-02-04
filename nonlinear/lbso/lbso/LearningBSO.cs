using System;
using System.Collections.Generic;

namespace LBSO
{
    class LearningBSO
    {
        public static int[] cluster = new int[Parameter.Population];

        public static void process(Function type)
        {
            #region variable definition
            int global = 0;
            int count2 = 0;
            int count4 = 0;

            double[,] population = new double[Parameter.Population, Parameter.Dimension];

            Random rand = new Random();

            int[] best = new int[Parameter.cluster];

            // probability for select one cluster to form new individual;
            double oneCluster = 0.6;

            // effecting the step size of generating new individuals by adding random values
            double[] stepSize = new double[Parameter.Dimension];

            // initialize best individual in each cluster
            double[,] centers = new double[Parameter.cluster, Parameter.Dimension];
            double[] probable = new double[Parameter.cluster];

            // number in cluster
            int[] numberInCluster = new int[Parameter.cluster];
            // counter cluster
            int[] counterCluster = new int[Parameter.cluster];
            // acculate number cluster 
            // 已经有多少个 sample 进入 cluster了，如第一个有 40个，第二个有 50 个
            // 则 acculateNumCluster[0] = 40, acculateNumCluster[1] = 40+50 = 90;
            int[] acculateNumCluster = new int[Parameter.cluster];

            // initialize best individual-COPY in each cluster 
            // FOR the purpose of introduce random best
            double[,] centersCopy = new double[Parameter.cluster, Parameter.Dimension];
            // initialize the  population of individuals sorted according to clusters
            double[,] popuSorted = new double[Parameter.Population, Parameter.Dimension];
            double[] fitnessPopu = new double[Parameter.Population];
            double[] fitnessPopuSorted = new double[Parameter.Population];

            double[] fitValues = new double[Parameter.cluster];

            double[] solution = new double[Parameter.Dimension];

            double[] tempSolution = new double[Parameter.Dimension];
            double[] fitness = new double[Parameter.Population];
            List<double> bestFitness = new List<double>();

            List<string> log = new List<string>(); // write log
            string logSentence = String.Empty;
            string logName = String.Empty; // log file Name
            string trajectoryName = String.Empty; // trajectory file name 
            // particle move trajectory
            double[] trajectory = new double[Parameter.Iteration];
            #endregion

            //loop for runs
            for (int run = 0; run < Parameter.Run; ++run)
            {
                global = 0;    //initialy assume the first atom as the gbest
                // initialize the population of individuals
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        population[atom, dim] = Parameter.Lower + (Parameter.Upper - Parameter.Lower) * rand.NextDouble();
                    }

                    // store fitness value for each individual
                    fitnessPopu[atom] = Double.MaxValue;
                    // store fitness value for each sorted individual
                    fitnessPopuSorted[atom] = Double.MaxValue;
                }

                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    fitness[atom] = Double.MaxValue;
                }
                // store temperary individual
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    tempSolution[dim] = 0;
                }

                // main work Loop for each run here
                for (int ite = 0; ite < Parameter.Iteration; ++ite)
                {
                    for (int part = 0; part < Parameter.Population; ++part)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            solution[dim] = population[part, dim];
                        }
                        fitnessPopu[part] = function(type, ref solution);

                        #region update personal best and global best
                        if (fitnessPopu[part] < fitness[part])
                        {
                            fitness[part] = fitnessPopu[part];
                        }

                        // update global best
                        if (fitness[part] < fitness[global]) global = part;
                        #endregion
                    }



                    #region new solutions generation
                    // k means cluster
                    //cluster = kmeans(popu, n_c,'Distance','cityblock','Start',centers,'EmptyAction','singleton') 
                    Kmeans kmeans = new Kmeans(Parameter.cluster, ref population);
                    kmeans.KmeansProcess(ref population);

                    // clustering    
                    for (int index = 0; index < Parameter.cluster; ++index)
                    {
                        // assign a initial big fitness value  as best fitness 
                        // for each cluster in minimization problems
                        fitValues[index] = System.Double.MaxValue;
                        // initialize 0 individual in each cluster
                        numberInCluster[index] = 0;
                    }
                    for (int atom = 0; atom < Parameter.Population; ++atom)
                    {
                        numberInCluster[cluster[atom]] += 1;
                        // find the best individual in each cluster
                        // minimization
                        if (fitValues[cluster[atom]] > fitnessPopu[atom])
                        {
                            fitValues[cluster[atom]] = fitnessPopu[atom];
                            best[cluster[atom]] = atom;
                        }
                    }

                    // number_in_cluster
                    // form population sorted according to clusters
                    // initialize cluster counter to be 0
                    for (int index = 0; index < Parameter.cluster; ++index)
                    {
                        counterCluster[index] = 0;
                        acculateNumCluster[index] = 0;
                    }
                    // initialize accumulated number of individuals in previous clusters
                    for (int index = 1; index < Parameter.cluster; ++index)
                    {
                        acculateNumCluster[index] = acculateNumCluster[index - 1]
                            + numberInCluster[index - 1];
                    }

                    // start form sorted population
                    for (int atom = 0; atom < Parameter.Population; ++atom)
                    {
                        counterCluster[cluster[atom]] += 1;
                        int temIdx = acculateNumCluster[cluster[atom]] + counterCluster[cluster[atom]] - 1; // -1 变为 序号
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            popuSorted[temIdx, dim] = population[atom, dim];
                        }
                        fitnessPopuSorted[temIdx] = fitnessPopu[atom];
                    }

                    // record the best individual in each cluster
                    for (int index = 0; index < Parameter.cluster; ++index)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            centers[index, dim] = population[best[index], dim];
                        }
                    }

                    // make a copy
                    for (int index = 0; index < Parameter.cluster; ++index)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            centersCopy[index, dim] = centers[index, dim];
                        }
                    }
                    //  select one cluster center to be replaced by a randomly generated center
                    if (rand.NextDouble() < 0.2)
                    {
                        int index = Convert.ToInt32(Math.Floor(rand.NextDouble() * Parameter.cluster));
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            centers[index, dim] = Parameter.Lower
                                + (Parameter.Upper - Parameter.Lower) * rand.NextDouble();
                        }
                    }
                    // calculate cluster probabilities based on number of individuals
                    // in each cluster
                    for (int index = 0; index < Parameter.cluster; ++index)
                    {
                        probable[index] = numberInCluster[index] * 1.0 / Parameter.Population;
                        if (index > 0)
                        {
                            probable[index] = probable[index] + probable[index - 1];
                        }
                    }

                    // generate n_p new individuals by adding Gaussian random values                   
                    for (int atom = 0; atom < Parameter.Population; ++atom)
                    {
                        // probability for select one cluster to form new individual
                        double r_1 = rand.NextDouble();
                        // select one cluster
                        if (r_1 < oneCluster)
                        {
                            double r = rand.NextDouble();
                            for (int index = 0; index < Parameter.cluster; ++index)
                            {
                                if (r < probable[index])
                                {
                                    // use the center
                                    if (rand.NextDouble() < 0.4)
                                    {
                                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                        {
                                            tempSolution[dim] = centers[index, dim];
                                        }
                                    }
                                    // use one randomly selected cluster
                                    else
                                    {
                                        int indi_1 = Convert.ToInt32(Math.Floor(rand.NextDouble() * numberInCluster[index]));
                                        indi_1 += acculateNumCluster[index];
                                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                        {
                                            tempSolution[dim] = popuSorted[indi_1, dim];
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        // select two clusters
                        else
                        {
                            // pick two clusters 
                            int cluster_1 = Convert.ToInt32(Math.Floor(rand.NextDouble() * Parameter.cluster));
                            int indi_1 = acculateNumCluster[cluster_1]
                                + Convert.ToInt32(Math.Floor(rand.NextDouble() * numberInCluster[cluster_1]));
                            int cluster_2 = Convert.ToInt32(Math.Floor(rand.NextDouble() * Parameter.cluster));
                            int indi_2 = acculateNumCluster[cluster_2]
                                + Convert.ToInt32(Math.Floor(rand.NextDouble() * numberInCluster[cluster_2]));

                            if (indi_1 == Parameter.Population)
                            {
                                indi_1 = Convert.ToInt32(Math.Floor(indi_1 * rand.NextDouble()));
                            }
                            if (indi_2 == Parameter.Population)
                            {
                                indi_2 = Convert.ToInt32(Math.Floor(indi_2 * rand.NextDouble()));
                            }

                            // use center
                            double tem = rand.NextDouble();
                            if (rand.NextDouble() < 0.5)
                            {
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    tempSolution[dim] = tem * centers[cluster_1, dim]
                                        + (1 - tem) * centers[cluster_2, dim];
                                }
                            }
                            // use randomly selected individuals from each cluster
                            else
                            {
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    tempSolution[dim] = tem * popuSorted[indi_1, dim] + (1 - tem) * popuSorted[indi_2, dim];
                                }
                            }
                        }
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            // stepSize[dim] = Probability.logsig((0.5 * Parameter.Iteration - iter) / 20.0) * rand.NextDouble();
                            stepSize[dim] = 0.1 * Math.Pow(10.0, Math.Exp((-1.0 * ite) / (Parameter.Iteration - ite)));

                            //Console.WriteLine(tempSolution[dim]);
                            tempSolution[dim] += stepSize[dim] * Probability.gaussian(rand.NextDouble()
                                * (ite / Parameter.size + 5)) * (rand.NextDouble() - 0.5);

                            // tempSolution[dim] += stepSize[dim] * rand.NextDouble() * Probability.Gaussian(0.0, 1.0);

                            // Console.WriteLine(tempSolution[dim]);
                            if (tempSolution[dim] > Parameter.Upper)
                            {
                                tempSolution[dim] = Parameter.Upper;
                            }
                            else if (tempSolution[dim] < Parameter.Lower)
                            {
                                tempSolution[dim] = Parameter.Lower;
                            }
                        }

                        // if better than the previous one, replace it
                        double fv = function(type, ref tempSolution);

                        // better than the previous one, replace
                        if (fv < fitnessPopu[atom])
                        {
                            fitnessPopu[atom] = fv;
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                population[atom, dim] = tempSolution[dim];
                            }
                        }
                    }
                    // keep the best for each cluster
                    for (int index = 0; index < Parameter.cluster; ++index)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            population[best[index], dim] = centersCopy[index, dim];
                            fitnessPopu[best[index]] = fitValues[index];
                        }
                    }
                    #endregion




                    // record the global best on one iteration
                    trajectory[ite] = fitness[global];
                }

                #region measurement
                switch (type)
                {
                    case Function.n1:
                        count2 += Measure2.N1measure(ref population);
                        count4 += Measure4.N1measure(ref population);
                        break;

                    case Function.n2:
                        count2 += Measure2.N2measure(ref population);
                        count4 += Measure4.N2measure(ref population);
                        break;

                    case Function.n3:
                        count2 += Measure2.N3measure(ref population);
                        count4 += Measure4.N3measure(ref population);
                        break;

                    case Function.n4:
                        count2 += Measure2.N4measure(ref population);
                        count4 += Measure4.N4measure(ref population);
                        break;

                    case Function.n5:
                        count2 += Measure2.N5measure(ref population);
                        count4 += Measure4.N5measure(ref population);
                        break;

                    case Function.n6:
                        count2 += Measure2.N6measure(ref population);
                        count4 += Measure4.N6measure(ref population);
                        break;

                    case Function.n7:
                        count2 += Measure2.N7measure(ref population);
                        count4 += Measure4.N7measure(ref population);
                        break;

                    default:
                        Console.WriteLine("Not a valid function type");
                        Console.ReadKey();
                        break;
                }
                #endregion

                #region BSO stopped after last iteration
                // write particles postion move trajectory
                trajectoryName = type.ToString() + "." + Parameter.Dimension.ToString()
                    + "." + run.ToString() + ".txt";
                Write.writeTrajectory(trajectoryName, ref trajectory);

                logSentence = type.ToString() + " fitness[bso] " + fitness[global].ToString()
                    + ", runtime " + run.ToString();
                Console.WriteLine(logSentence);
                log.Add(logSentence);

                bestFitness.Add(fitness[global]);

                #endregion
            }

            logName = "_" + type.ToString() + ".bso." + Parameter.Dimension.ToString() + ".txt";
            // global count
            logSentence = type.ToString() + " bso count2 " + count2.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            logSentence = type.ToString() + " bso count4 " + count4.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            #region statistical indicator
            bestFitness.Sort();
            // best of best fitness
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                + " runs, best fitness "
                + bestFitness[0].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // middle of best fitness
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                + " runs, median fitness "
                + bestFitness[Parameter.Run / 2].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // worst of best fitness
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                + " runs, worst fitness "
                + bestFitness[Parameter.Run - 1].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // calculate mean of the best particle fitness in each round
            double mean = 0.0;
            foreach (double number in bestFitness)
            {
                mean += number;
            }
            mean /= Parameter.Run;
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                + " runs, best mean " + mean.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // variance
            double variance = 0.0;
            foreach (double number in bestFitness)
            {
                variance += (number - mean) * (number - mean);
            }
            variance /= Parameter.Run;
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                + " runs, variance " + variance.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // standard deviation
            double deviation = 0.0;
            deviation = Math.Sqrt(variance);
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                + " runs, standard deviation " + deviation.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);
            #endregion

            Write.writeLog(logName, ref log);
            log.Clear();
        }

        public static double function(Function type, ref double[] evaluation)
        {
            double minimum = 0;

            switch (type)
            {
                case Function.n1:
                    minimum = Nonlinear.n1(ref evaluation);
                    break;

                case Function.n2:
                    minimum = Nonlinear.n2(ref evaluation);
                    break;

                case Function.n3:
                    minimum = Nonlinear.n3(ref evaluation);
                    break;

                case Function.n4:
                    minimum = Nonlinear.n4(ref evaluation);
                    break;

                case Function.n5:
                    minimum = Nonlinear.n5(ref evaluation);
                    break;

                case Function.n6:
                    minimum = Nonlinear.n6(ref evaluation);
                    break;

                case Function.n7:
                    minimum = Nonlinear.n7(ref evaluation);
                    break;

                default:
                    Console.WriteLine("Not a valid function type");
                    Console.ReadKey();
                    break;
            }
            return minimum;
        }
    }
}
