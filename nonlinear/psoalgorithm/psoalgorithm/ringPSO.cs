using System;
using System.Collections.Generic;

namespace PSOalgorithm
{
    public class RingPSO
    {
        public static void Process(Function type)
        {
            #region variable definition
            Random rand = new Random();
            double minimum = double.MaxValue;
            int globalIndex = 0;
            int count2 = 0;
            int count4 = 0;

            double globalValue = double.MaxValue;
            double[] globalOptimum = new double[Parameter.Dimension];

            double[] fitness = new double[Parameter.Population];
            double[,] position = new double[Parameter.Population, Parameter.Dimension];
            double[,] velocity = new double[Parameter.Population, Parameter.Dimension];
            double[] solution = new double[Parameter.Dimension];

            // personalBest: contains each particle's best position.  
            double[,] pbest = new double[Parameter.Population, Parameter.Dimension];
            int[] lbest = new int[Parameter.Population];

            List<double> fitnessRun = new List<double>();

            List<string> log = new List<string>(); // write log
            string logSentence = String.Empty;
            string logName = String.Empty; // log file Name 

            string trajectoryName = String.Empty; // trajectory file name            

            // particle move trajectory
            double[] fitnessTrajectory = new double[Parameter.Iteration];
            #endregion
            //loop for runs
            for (int run = 0; run < Parameter.Run; ++run)
            {
                globalIndex = 0;    //initialy assume the first particle as the gbest
                globalValue = Double.MaxValue;
                minimum = double.MaxValue;

                #region initializes the individuals
                for (int idx = 0; idx < Parameter.Population; ++idx)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        position[idx, dim] = Parameter.Lower +
                            (Parameter.Upper - Parameter.Lower) * rand.NextDouble();
                        pbest[idx, dim] = position[idx, dim];
                        solution[dim] = position[idx, dim];
                        velocity[idx, dim] = Parameter.VMax * (rand.NextDouble() - 0.5);
                        lbest[idx] = idx; //initialy assume self the lbest
                    }
                    #region choose benchmark function
                    switch (type)
                    {
                        case Function.n1:
                            fitness[idx] = Nonlinear.n1(ref solution);
                            break;
                        case Function.n2:
                            fitness[idx] = Nonlinear.n2(ref solution);
                            break;
                        case Function.n3:
                            fitness[idx] = Nonlinear.n3(ref solution);
                            break;
                        case Function.n4:
                            fitness[idx] = Nonlinear.n4(ref solution);
                            break;
                        case Function.n5:
                            fitness[idx] = Nonlinear.n5(ref solution);
                            break;
                        case Function.n6:
                            fitness[idx] = Nonlinear.n6(ref solution);
                            break;
                        case Function.n7:
                            fitness[idx] = Nonlinear.n7(ref solution);
                            break;

                        default:
                            Console.WriteLine("Not a valid function type");
                            Console.ReadKey();
                            break;
                    }
                    #endregion

                    if (fitness[idx] < globalValue)
                    {
                        globalIndex = idx;
                        globalValue = fitness[idx];
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            globalOptimum[dim] = position[idx, dim];
                        }
                    }
                }
                #endregion

                #region main iterations
                // main work Loop for each run here
                for (int ite = 0; ite < Parameter.Iteration; ++ite)
                {
                    // update inertia weight
                    // time variant weight, linear from weight to 0.4
                    // weight = (Parameter.weight - 0.4) * (Parameter.iterationNumber - iterate) / Parameter.iterationNumber + 0.4;

                    //constant inertia weight
                    for (int part = 0; part < Parameter.Population; ++part)
                    {
                        #region choose benchmark function
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            solution[dim] = position[part, dim];
                        }
                        switch (type)
                        {
                            case Function.n1:
                                minimum = Nonlinear.n1(ref solution);
                                break;
                            case Function.n2:
                                minimum = Nonlinear.n2(ref solution);
                                break;
                            case Function.n3:
                                minimum = Nonlinear.n3(ref solution);
                                break;
                            case Function.n4:
                                minimum = Nonlinear.n4(ref solution);
                                break;
                            case Function.n5:
                                minimum = Nonlinear.n5(ref solution);
                                break;
                            case Function.n6:
                                minimum = Nonlinear.n6(ref solution);
                                break;
                            case Function.n7:
                                minimum = Nonlinear.n7(ref solution);
                                break;

                            default:
                                Console.WriteLine("Not a valid function type");
                                Console.ReadKey();
                                break;
                        }
                        #endregion

                        #region update pbest, lbest, and gbest
                        // update pbest
                        //if (ite == 0)
                        //{
                        //    fitness[part] = minimum;
                        //    if (fitness[part] < globalValue)
                        //    {
                        //        globalIndex = part;
                        //        globalValue = fitness[part];
                        //        for (int dim = 0; dim < Parameter.dimension; ++dim)
                        //        {
                        //            globalOptimum[dim] = position[part, dim];
                        //        }
                        //    }
                        //}
                        if (minimum < fitness[part])
                        {
                            fitness[part] = minimum;
                            for (int dim = 0; dim < Parameter.Dimension; dim++)
                                pbest[part, dim] = position[part, dim];
                            // ring
                            // update local best
                            lbest[part] = part;
                            if (part == 0)
                            {
                                // left neighbor
                                if (fitness[Parameter.Population - 1] < fitness[part])
                                    lbest[part] = Parameter.Population - 1;
                                // right neighbor
                                if (fitness[1] < fitness[lbest[part]])
                                    lbest[part] = 1;
                            }
                            else if (part == Parameter.Population - 1)
                            {
                                // left
                                if (fitness[part - 1] < fitness[part])
                                    lbest[part] = part - 1;
                                // right
                                if (fitness[0] < fitness[lbest[part]])
                                    lbest[part] = 0;
                            }
                            else
                            {
                                if (fitness[part - 1] < fitness[part])
                                    lbest[part] = part - 1;
                                if (fitness[part + 1] < fitness[lbest[part]])
                                    lbest[part] = part + 1;
                            }
                            // update global best
                            if (fitness[part] < globalValue)
                            {
                                globalIndex = part;
                                globalValue = fitness[part];
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    globalOptimum[dim] = position[part, dim];
                                }
                            }
                        }
                        #endregion

                        #region update velocity and position
                        for (int dim = 0; dim < Parameter.Dimension; dim++)
                        {
                            // velocity
                            velocity[part, dim] = Parameter.weight * velocity[part, dim]
                                + Parameter.c1 * rand.NextDouble() * (pbest[part, dim] - position[part, dim])
                                + Parameter.c2 * rand.NextDouble() * (pbest[lbest[part], dim] - position[part, dim]);

                            if (velocity[part, dim] > Parameter.Upper)
                                velocity[part, dim] = Parameter.Upper;
                            else if (velocity[part, dim] < Parameter.Lower)
                                velocity[part, dim] = Parameter.Lower;

                            // position
                            // Tx allows simultaneous updates
                            // tx[b][particle] = xx[b][particle] + vx(b, particle);
                            position[part, dim] += velocity[part, dim];
                            if (position[part, dim] > Parameter.Upper)
                                position[part, dim] = Parameter.Upper;
                            else if (position[part, dim] < Parameter.Lower)
                                position[part, dim] = Parameter.Lower;
                        }
                        #endregion
                    }

                    fitnessTrajectory[ite] = globalValue;
                }
                #endregion // main iterations

                #region measurement
                switch (type)
                {
                    case Function.n1:
                        count2 += Measure2.N1measure(ref position);
                        count4 += Measure4.N1measure(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n2:
                        count2 += Measure2.N2measure(ref position);
                        count4 += Measure4.N2measure(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n3:
                        count2 += Measure2.N3measure(ref position);
                        count4 += Measure4.N3measure(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n4:
                        count2 += Measure2.N4measure(ref position);
                        count4 += Measure4.N4measure(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n5:
                        count2 += Measure2.N5measure(ref position);
                        count4 += Measure4.N5measure(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n6:
                        count2 += Measure2.N6measure(ref position);
                        count4 += Measure4.N6measure(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n7:
                        count2 += Measure2.N7measure(ref position);
                        count4 += Measure4.N7measure(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    default:
                        Console.WriteLine("Not a valid function type");
                        Console.ReadKey();
                        break;
                }
                #endregion

                // write particles postion move trajectory
                trajectoryName = type.ToString() + ".ring." + Parameter.Dimension.ToString()
                    + "." + run.ToString() + ".txt";
                Write.writeTrajectory(trajectoryName, ref fitnessTrajectory);

                logSentence = type.ToString() + " fitness[ring] " + fitness[globalIndex].ToString()
                    + ", run " + run.ToString();
                Console.WriteLine(logSentence);
                log.Add(logSentence);

                fitnessRun.Add(fitness[globalIndex]);

            }

            logName = "_" + type.ToString() + ".ring." + Parameter.Dimension.ToString() + ".txt";

            // global count
            logSentence = type.ToString() + " ring count2 " + count2.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            logSentence = type.ToString() + " ring count4 " + count4.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            #region sort result
            // best of local ring best fitness
            fitnessRun.Sort();
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                + " runs, local ring best fitness " + fitnessRun[0].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // middle of local ring best fitness
            logSentence = type.ToString() + " " + Parameter.Run.ToString() + " runs, local ring middle fitness "
                + fitnessRun[Parameter.Run / 2].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // worst of local ring best fitness
            logSentence = type.ToString() + " " + Parameter.Run.ToString() + " runs, local ring worst fitness "
                + fitnessRun[Parameter.Run - 1].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);
            #endregion

            #region mean of result
            // calculate mean of the best particle fitness in each round
            double mean = 0.0;
            foreach (double number in fitnessRun)
            {
                mean += number;
            }
            mean /= Parameter.Run;
            logSentence = type.ToString() + " " + Parameter.Run.ToString() + " runs, local ring best mean "
                + mean.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // variance
            double variance = 0.0;
            foreach (double number in fitnessRun)
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
            fitnessRun.Clear();

            Write.writeLog(logName, ref log);
            #endregion
            log.Clear();
        }
    }
}

