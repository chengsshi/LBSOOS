using System;
using System.Collections.Generic;

namespace PSOnonlinear
{
    public class Star
    {
        public static void Process(Function type)
        {
            #region variable definition
            Random rand = new Random();
            double maximum = double.MaxValue;
            int gbest = 0;
            int count = 0;

            double[] fitness = new double[Parameter.Population];
            double[,] velocity = new double[Parameter.Dimension, Parameter.Population];
            double[,] position = new double[Parameter.Dimension, Parameter.Population];
            double[] solution = new double[Parameter.Dimension];

            // position diversity
            double[] pivotPosition = new double[Parameter.Dimension];
            double[] diversityDimension = new double[Parameter.Dimension];
            double diversityPosition = 0.0;

            // personalBest: contains each particle's best position.  
            double[,] pbest = new double[Parameter.Dimension, Parameter.Population];

            List<double> bestFitness = new List<double>();

            List<string> log = new List<string>(); // write log
            string logSentence = String.Empty;
            string logName = String.Empty; // log file Name 

            string trajectoryName = String.Empty; // trajectory file name            

            // particle move trajectory
            double[] trajectory = new double[Parameter.Iteration];
            // particle position diversity trajectory
            double[] divertisyTrajectory = new double[Parameter.Iteration];

            #endregion
            //loop for runs
            for (int run = 0; run < Parameter.Run; ++run)
            {
                gbest = 0;    //initialy assume the first particle as the gbest
                #region initializes the individuals
                for (int part = 0; part < Parameter.Population; ++part)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        position[dim, part] = Parameter.Lower +
                            (Parameter.Upper - Parameter.Lower) * rand.NextDouble();

                        pbest[dim, part] = position[dim, part];
                        velocity[dim, part] =
                            2 * Parameter.Velocity * rand.NextDouble() - Parameter.Velocity;
                    }
                }
                #endregion

                // main work Loop for each run here
                for (int ite = 0; ite < Parameter.Iteration; ++ite)
                {
                    // update inertia weight
                    // time variant weight, linear from weight to 0.4
                    // weightUp = (Parameter.weight - 0.4) * (Parameter.maxIteration - iterator) / Parameter.maxIteration + 0.4;

                    for (int part = 0; part < Parameter.Population; ++part)
                    {
                        #region choose benchmark function

                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            solution[dim] = position[dim, part];
                        }

                        switch (type)
                        {
                            case Function.f1:
                                maximum = Benchmark.F1(ref solution);
                                break;

                            case Function.f2:
                                maximum = Benchmark.F2(ref solution);
                                break;

                            case Function.f3:
                                maximum = Benchmark.F3(ref solution);
                                break;

                            case Function.f4:
                                maximum = Benchmark.F4(ref solution);
                                break;

                            case Function.f5:
                                maximum = Benchmark.F5(ref solution);
                                break;

                            case Function.f6:
                                maximum = Benchmark.F6(ref solution);
                                break;

                            case Function.f7:
                                maximum = Benchmark.F7(ref solution);
                                break;

                            case Function.f8:
                                maximum = Benchmark.F8(ref solution);
                                break;

                            case Function.n1:
                                maximum = Nonlinear.n1(ref solution);
                                break;

                            case Function.n2:
                                maximum = Nonlinear.n2(ref solution);
                                break;

                            case Function.n3:
                                maximum = Nonlinear.n3(ref solution);
                                break;
                            case Function.n4:
                                maximum = Nonlinear.n4(ref solution);
                                break;
                            case Function.n5:
                                maximum = Nonlinear.n5(ref solution);
                                break;
                            case Function.n6:
                                maximum = Nonlinear.n6(ref solution);
                                break;
                            case Function.n7:
                                maximum = Nonlinear.n7(ref solution);
                                break;
                            default:
                                Console.WriteLine("Not a valid function type");
                                Console.ReadKey();
                                break;
                        }
                        #endregion

                        #region update personal best and global best
                        if (ite == 0) fitness[part] = maximum;

                        if (maximum > fitness[part])
                        {
                            fitness[part] = maximum;
                            for (int dimension = 0; dimension < Parameter.Dimension; ++dimension)
                                pbest[dimension, part] = position[dimension, part];
                            // star
                            // update global best
                            if (fitness[part] > fitness[gbest]) gbest = part;
                        }
                        #endregion

                        #region update velocity and position
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            // velocity
                            velocity[dim, part] = Parameter.Weight * velocity[dim, part]
                                + Parameter.c1 * rand.NextDouble() * (pbest[dim, part] - position[dim, part])
                                + Parameter.c2 * rand.NextDouble() * (pbest[dim, gbest] - position[dim, part]);

                            if (velocity[dim, part] > Parameter.Velocity)
                                velocity[dim, part] = Parameter.Velocity;
                            else if (velocity[dim, part] < -Parameter.Velocity)
                                velocity[dim, part] = -Parameter.Velocity;

                            // position
                            position[dim, part] += velocity[dim, part];
                            if (position[dim, part] > Parameter.Upper)
                                position[dim, part] = Parameter.Upper;

                            else if (position[dim, part] < Parameter.Lower)
                                position[dim, part] = Parameter.Lower;
                        }
                        #endregion
                    }

                    trajectory[ite] = fitness[gbest];
                    #region diversity
                    // initialization
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        pivotPosition[dim] = 0.0;
                        diversityDimension[dim] = 0.0;
                    }

                    diversityPosition = 0.0;

                    // calculate pivot of current position and personal best, average velocity
                    for (int part = 0; part < Parameter.Population; ++part)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            pivotPosition[dim] += position[dim, part];
                        }
                    }

                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        pivotPosition[dim] /= Parameter.Population;
                    }

                    for (int part = 0; part < Parameter.Population; ++part)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDimension[dim]
                              += Math.Abs(position[dim, part] - pivotPosition[dim]);
                        }
                    }

                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        diversityDimension[dim] /= Parameter.Population;
                        diversityPosition += diversityDimension[dim];
                    }

                    diversityPosition /= Parameter.Dimension;
                    divertisyTrajectory[ite] = diversityPosition;
                    #endregion
                }
                #region pso stopped after last iteration

                #region measurement
                switch (type)
                {
                    case Function.f1:
                        count += Measure.F1(ref position);
                        // Console.WriteLine(Measure.f1(ref position));
                        break;

                    case Function.f2:
                        count += Measure.F2(ref position);
                        // Console.WriteLine(Measure.f2(ref position));
                        break;

                    case Function.f3:
                        count += Measure.f3(ref position);
                        // Console.WriteLine(Measure.f3(ref position));
                        break;

                    case Function.f4:
                        count += Measure.f4(ref position);
                        // Console.WriteLine(Measure.f4(ref position));
                        break;

                    case Function.f6:
                        count += Measure.f6(ref position);
                        // Console.WriteLine(Measure.f6(ref position));
                        break;

                    case Function.f7:
                        count += Measure.f7(ref position);
                        // Console.WriteLine(Measure.f7(ref position));
                        break;

                    case Function.f8:
                        count += Measure.f8(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n1:
                        count += Measure.n1(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n2:
                        count += Measure.n2(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n3:
                        count += Measure.n3(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;
                    default:
                        Console.WriteLine("Not a valid function type");
                        Console.ReadKey();
                        break;
                }

                #endregion

                // write particles postion move trajectory
                trajectoryName = type.ToString() + ".star." + Parameter.Dimension.ToString()
                    + "." + run.ToString() + ".txt";
                Write.WriteTrajectory(trajectoryName, ref trajectory);

                // write particles postion diversity trajectory 
                trajectoryName = type.ToString() + ".star." + Parameter.Dimension.ToString()
                   + ".diversity." + run.ToString() + ".txt";
                Write.WriteTrajectory(trajectoryName, ref divertisyTrajectory);

                logSentence = type.ToString() + " fitness[star] " + fitness[gbest].ToString()
                    + ", run " + run.ToString();
                Console.WriteLine(logSentence);
                log.Add(logSentence);

                bestFitness.Add(fitness[gbest]);
                #endregion
            }

            logName = "_" + type.ToString() + ".star." + Parameter.Dimension.ToString() + ".txt";

            // global count
            logSentence = type.ToString() + " star global count "
                + count.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            #region sort result
            bestFitness.Sort();
            // best of global star best fitness
            logSentence = type.ToString() + " star best fitness "
                + bestFitness[Parameter.Run - 1].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // middle of global star best fitness
            logSentence = type.ToString() + " star middle fitness "
                + bestFitness[Parameter.Run / 2].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // worst of global star best fitness
            logSentence = type.ToString() + " star worst fitness "
                + bestFitness[0].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);
            #endregion

            #region mean of result
            // calculate mean of the best particle fitness in each round
            double bestSum = 0.0;
            foreach (double number in bestFitness)
            {
                bestSum += number;
            }
            double mean = bestSum / Parameter.Run;
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                + " runs, global statr best mean " + mean.ToString();
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

            bestFitness.Clear();

            Write.WriteLog(logName, ref log);
            #endregion
            log.Clear();
        }
    }
}

