using System;
using System.Collections.Generic;

namespace BSOnonlinear
{
    public class StarPSO
    {
        public static void Process(Function type)
        {
            #region variable definition
            Random rand = new Random();
            double minimum = double.MaxValue;
            int globalIndex = 0;
            int count = 0;

            double globalValue = Double.MaxValue;
            double[] globalOptimum = new double[Parameter.Dimension];

            double[] fitness = new double[Parameter.Population];
            double[,] velocity = new double[Parameter.Population, Parameter.Dimension];
            double[,] position = new double[Parameter.Population, Parameter.Dimension];
            double[] solution = new double[Parameter.Dimension];

            // personalBest: contains each particle's best position.  
            double[,] pbest = new double[Parameter.Population, Parameter.Dimension];

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
                minimum = Double.MaxValue;
                #region initializes the individuals
                for (int idx = 0; idx < Parameter.Population; ++idx)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        position[idx, dim] = Parameter.Lower +
                            (Parameter.Upper - Parameter.Lower) * rand.NextDouble();

                        solution[dim] = position[idx, dim];
                        pbest[idx, dim] = position[idx, dim];
                        velocity[idx, dim] = Parameter.Lower +
                            (Parameter.Upper - Parameter.Lower) * rand.NextDouble();
                    }

                    #region choose benchmark function
                    switch (type)
                    {
                        case Function.f1:
                            fitness[idx] = Multimode.f1(ref solution);
                            break;
                        case Function.f2:
                            fitness[idx] = Multimode.f2(ref solution);
                            break;
                        case Function.f3:
                            fitness[idx] = Multimode.f3(ref solution);
                            break;
                        case Function.f4:
                            fitness[idx] = Multimode.f4(ref solution);
                            break;
                        case Function.f5:
                            fitness[idx] = Multimode.f5(ref solution);
                            break;
                        case Function.f6:
                            fitness[idx] = Multimode.f6(ref solution);
                            break;
                        case Function.f7:
                            fitness[idx] = Multimode.f7(ref solution);
                            break;
                        case Function.f8:
                            fitness[idx] = Multimode.f8(ref solution);
                            break;
                        case Function.n1:
                            fitness[idx] = Nonlinear.N1(ref solution);
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

                    // fitness[part] = function(type, ref solution);
                    // update global best
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
                    // weightUp = (Parameter.weight - 0.4) * (Parameter.maxIteration - iterator) / Parameter.maxIteration + 0.4;

                    for (int part = 0; part < Parameter.Population; ++part)
                    {
                        #region choose benchmark function
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            solution[dim] = position[part, dim];
                        }

                        switch (type)
                        {
                            case Function.f1:
                                minimum = Multimode.f1(ref solution);
                                break;
                            case Function.f2:
                                minimum = Multimode.f2(ref solution);
                                break;
                            case Function.f3:
                                minimum = Multimode.f3(ref solution);
                                break;
                            case Function.f4:
                                minimum = Multimode.f4(ref solution);
                                break;
                            case Function.f5:
                                minimum = Multimode.f5(ref solution);
                                break;
                            case Function.f6:
                                minimum = Multimode.f6(ref solution);
                                break;
                            case Function.f7:
                                minimum = Multimode.f7(ref solution);
                                break;
                            case Function.f8:
                                minimum = Multimode.f8(ref solution);
                                break;
                            case Function.n1:
                                minimum = Nonlinear.N1(ref solution);
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

                        #region update personal best and global best
                        if (minimum < fitness[part])
                        {
                            fitness[part] = minimum;
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                pbest[part, dim] = position[part, dim];
                            // star
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
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            // velocity
                            velocity[part, dim] = Parameter.weight * velocity[part, dim]
                                + Parameter.c1 * rand.NextDouble() * (pbest[part, dim] - position[part, dim])
                                + Parameter.c2 * rand.NextDouble() * (pbest[globalIndex, dim] - position[part, dim]);

                            if (velocity[part, dim] > Parameter.Upper)
                                velocity[part, dim] = Parameter.Upper - rand.NextDouble() * 0.01;
                            else if (velocity[part, dim] < Parameter.Lower)
                                velocity[part, dim] = Parameter.Lower + rand.NextDouble() * 0.01;

                            // position
                            position[part, dim] += velocity[part, dim];
                            if (position[part, dim] > Parameter.Upper)
                                position[part, dim] = Parameter.Upper - rand.NextDouble() * 0.01;

                            else if (position[part, dim] < Parameter.Lower)
                                position[part, dim] = Parameter.Lower + rand.NextDouble() * 0.01;
                        }
                        #endregion                        
                    }

                    fitnessTrajectory[ite] = globalValue;
                }
                #endregion // main iterations

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
                        count += Measure.F3(ref position);
                        // Console.WriteLine(Measure.f3(ref position));
                        break;

                    case Function.f4:
                        count += Measure.F4(ref position);
                        // Console.WriteLine(Measure.f4(ref position));
                        break;

                    case Function.f6:
                        count += Measure.F6(ref position);
                        // Console.WriteLine(Measure.f6(ref position));
                        break;

                    case Function.f7:
                        count += Measure.F7(ref position);
                        // Console.WriteLine(Measure.f7(ref position));
                        break;

                    case Function.f8:
                        count += Measure.F8(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n1:
                        count += Measure.N1(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n2:
                        count += Measure.N2(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n3:
                        count += Measure.N3(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n4:
                        count += Measure.N4(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n5:
                        count += Measure.N5(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n6:
                        count += Measure.N6(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    case Function.n7:
                        count += Measure.N7(ref position);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    default:
                        Console.WriteLine("Not a valid function type");
                        Console.ReadKey();
                        break;
                }
                #endregion

                #region pso stopped after last iteration
                // write particles postion move trajectory
                trajectoryName = type.ToString() + ".star." + Parameter.Dimension.ToString()
                    + "." + run.ToString() + ".txt";
                Write.writeTrajectory(trajectoryName, ref fitnessTrajectory);

                logSentence = type.ToString() + " fitness[star] " + globalValue.ToString() + ", run " + run.ToString();
                Console.WriteLine(logSentence);
                log.Add(logSentence);

                fitnessRun.Add(globalValue);
                #endregion
            }

            logName = "_" + type.ToString() + ".star." + Parameter.Dimension.ToString() + ".txt";
            // global count
            logSentence = type.ToString() + " global count " + count.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            #region sort result
            fitnessRun.Sort();
            // best of global star best fitness
            logSentence = type.ToString() + " star best fitness "
                + fitnessRun[0].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // middle of global star best fitness
            logSentence = type.ToString() + " star middle fitness "
                + fitnessRun[Parameter.Run / 2].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // worst of global star best fitness
            logSentence = type.ToString() + " star worst fitness "
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
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                + " runs, global star best mean " + mean.ToString();
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

