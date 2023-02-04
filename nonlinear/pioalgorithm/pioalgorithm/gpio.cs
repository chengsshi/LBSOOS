﻿using System;
using System.Collections.Generic;

namespace PIOalgorithm
{
    public class GPIO
    {
        public static void Process(Function type)
        {
            #region variable definition
            Random rand = new Random();
            double minimum = double.MaxValue;
            int gbest = 0;
            double gbestValue = double.MaxValue;
            int count2 = 0;
            int count4 = 0;
            int np = Parameter.Population;

            double[] fitnessCurrent = new double[Parameter.Population];
            double[,] velocity = new double[Parameter.Population, Parameter.Dimension];
            double[,] position = new double[Parameter.Population, Parameter.Dimension];
            double[] solution = new double[Parameter.Dimension];

            // Landmark operator
            double[] centerPosition = new double[Parameter.Dimension];

            // neighborhoodBest: contains each particle's best neighborhood position.  
            double[,] nbest = new double[Parameter.Population, Parameter.Dimension];
            List<double> fitnessRank = new List<double>();

            List<double> fitnessRun = new List<double>();

            List<string> log = new List<string>(); // write log
            string logSentence = String.Empty;
            string logName = String.Empty; // log file Name 

            string trajectoryName = String.Empty; // trajectory file name            

            // particle move trajectory
            double[] trajectory = new double[Parameter.Ncmax];

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
                        position[part, dim] = Parameter.Lower +
                            (Parameter.Upper - Parameter.Lower) * rand.NextDouble();

                        nbest[part, dim] = position[part, dim];
                        velocity[part, dim] =
                            2 * Parameter.clamp * rand.NextDouble() - Parameter.clamp;
                    }
                    fitnessCurrent[part] = double.MaxValue;
                }
                #endregion

                #region main loop
                int n = 1;
                for (int nc = 0; nc < Parameter.Ncmax; ++nc)
                {
                    #region Map and Compass Operator
                    if ((nc >= (n - 1) * Parameter.NCsum) && (nc < (n - 1) * Parameter.NCsum + Parameter.Nc1))
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

                            #region update global best                        
                            if (minimum < fitnessCurrent[part])
                            {
                                fitnessCurrent[part] = minimum;
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                    nbest[part, dim] = position[part, dim];
                                // star
                                // update global best
                                if (fitnessCurrent[part] < fitnessCurrent[gbest])
                                {
                                    gbest = part;
                                    gbestValue = fitnessCurrent[part];
                                }
                            }
                            #endregion

                            #region update velocity and position
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                // velocity
                                velocity[part, dim] = velocity[part, dim] * Math.Exp(-Parameter.R * nc)
                                    + rand.NextDouble() * (nbest[gbest, dim] - position[part, dim]);

                                if (velocity[part, dim] > Parameter.clamp)
                                    velocity[part, dim] = Parameter.clamp;
                                else if (velocity[part, dim] < -Parameter.clamp)
                                    velocity[part, dim] = -Parameter.clamp;

                                // position
                                position[part, dim] += velocity[part, dim];
                                if (position[part, dim] > Parameter.Upper)
                                    position[part, dim] = Parameter.Upper;

                                else if (position[part, dim] < Parameter.Lower)
                                    position[part, dim] = Parameter.Lower;
                            }
                            #endregion
                        }

                        //if (nc == 100)
                        //{
                        //    Console.WriteLine("100");
                        //    Console.WriteLine("n is {0}", n);
                        //}
                        trajectory[nc] = gbestValue;

                    }

                    //if (nc == 100)
                    //{
                    //    Console.WriteLine("100");
                    //}
                    #endregion // Map and Compass Operator

                    #region Landmark Operator
                    if ((nc >= Parameter.Nc1 + (n - 1) * Parameter.NCsum) && (nc < n * Parameter.NCsum))
                    {
                        // update inertia weight
                        // time variant weight, linear from weight to 0.4
                        // weightUp = (Parameter.weight - 0.4) * (Parameter.maxIteration - iterator) / Parameter.maxIteration + 0.4;

                        for (int part = 0; part < Parameter.Population; ++part)
                        {
                            fitnessRank.Add(fitnessCurrent[part]);
                        }
                        fitnessRank.Sort();

                        np = Convert.ToInt32(Math.Ceiling(np / Parameter.decreaseK));

                        double Fx = 0.0;
                        double sumFx = 0.0;
                        for (int part = 0; part < Parameter.Population; ++part)
                        {
                            //if (currentFitness[part] == 0)
                            //{
                            //    Fx = 1.0 / Parameter.varepsilon;
                            //}
                            //else

                            if (fitnessCurrent[part] <= fitnessRank[Parameter.Population - np])
                            {
                                if (fitnessRank[part] < 0)
                                {
                                    Fx = fitnessCurrent[part] + Math.Abs(fitnessRank[0]);
                                }
                                else
                                {
                                    Fx = fitnessCurrent[part];
                                }

                                sumFx += Fx;
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    centerPosition[dim] += position[part, dim] * Fx;
                                }
                            }
                        }

                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            centerPosition[dim] /= (np * sumFx);
                        }

                        fitnessRank.Clear();
                        for (int part = 0; part < Parameter.Population; ++part)
                        {
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                // position
                                position[part, dim] += rand.NextDouble() * (centerPosition[dim] - position[part, dim]);
                                if (position[part, dim] > Parameter.Upper)
                                    position[part, dim] = Parameter.Upper;

                                else if (position[part, dim] < Parameter.Lower)
                                    position[part, dim] = Parameter.Lower;
                            }

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

                            #region update neighborhood best

                            if (minimum < fitnessCurrent[part])
                            {
                                fitnessCurrent[part] = minimum;
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                    nbest[part, dim] = position[part, dim];
                                // star
                                // update global best
                                if (fitnessCurrent[part] < fitnessCurrent[gbest])
                                {
                                    gbest = part;
                                    gbestValue = fitnessCurrent[part];
                                }
                            }
                            #endregion
                        }

                        trajectory[nc] = gbestValue;
                        //++nc;
                    }
                    #endregion // Landmark Operator

                    //if (nc == 99)
                    //{
                    //    Console.WriteLine("nc is {0}", nc);
                    //}

                    if ((nc > 0) && ((nc + 1) % Parameter.NCsum == 0))
                    {
                        // Console.WriteLine("nc is {0}", nc);
                        np = Parameter.Population;
                        ++n;
                    }
                }
                #endregion // main loop

                #region measurement
                switch (type)
                {
                    case Function.n1:
                        count2 += Measure2.N1measure(ref nbest);
                        count4 += Measure4.N1measure(ref nbest);
                        // Console.WriteLine(Measure.f1(ref position));
                        break;

                    case Function.n2:
                        count2 += Measure2.N1measure(ref nbest);
                        count4 += Measure4.N2measure(ref nbest);
                        // Console.WriteLine(Measure.f2(ref position));
                        break;

                    case Function.n3:
                        count2 += Measure2.N3measure(ref nbest);
                        count4 += Measure4.N3measure(ref nbest);
                        // Console.WriteLine(Measure.f3(ref position));
                        break;

                    case Function.n4:
                        count2 += Measure2.N4measure(ref nbest);
                        count4 += Measure4.N4measure(ref nbest);
                        // Console.WriteLine(Measure.f4(ref position));
                        break;

                    case Function.n5:
                        count2 += Measure2.N5measure(ref nbest);
                        count4 += Measure4.N5measure(ref nbest);
                        // Console.WriteLine(Measure.f6(ref position));
                        break;

                    case Function.n6:
                        count2 += Measure2.N6measure(ref nbest);
                        count4 += Measure4.N6measure(ref nbest);
                        // Console.WriteLine(Measure.f7(ref position));
                        break;

                    case Function.n7:
                        count2 += Measure2.N7measure(ref nbest);
                        count4 += Measure4.N7measure(ref nbest);
                        // Console.WriteLine(Measure.f8(ref position));
                        break;

                    default:
                        Console.WriteLine("Not a valid function type");
                        Console.ReadKey();
                        break;
                }
                #endregion

                // write particles postion move trajectory
                trajectoryName = type.ToString() + ".gpio." + Parameter.Dimension.ToString()
                                    + "." + run.ToString() + ".txt";
                Write.writeTrajectory(trajectoryName, ref trajectory);

                logSentence = type.ToString() + " fitness[gpio] " + gbestValue.ToString()
                    + ", run " + run.ToString();
                Console.WriteLine(logSentence);
                log.Add(logSentence);

                fitnessRun.Add(gbestValue);
                //#endregion // stopped after last iteration
            }

            logName = "_" + type.ToString() + ".gpio." + Parameter.Dimension.ToString() + ".txt";

            // global count
            logSentence = type.ToString() + " gpio count2 " + count2.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            logSentence = type.ToString() + " gpio count4 " + count4.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            #region sort result
            fitnessRun.Sort();
            // best of global star best fitness
            logSentence = type.ToString() + " gPIO best fitness "
                + fitnessRun[0].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // middle of global star best fitness
            logSentence = type.ToString() + " gPIO middle fitness "
                + fitnessRun[Parameter.Run / 2].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // worst of global star best fitness
            logSentence = type.ToString() + " gPIO worst fitness "
                + fitnessRun[Parameter.Run - 1].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);
            #endregion

            #region mean of result
            // calculate mean of the best particle fitness in each round
            double bestSum = 0.0;
            foreach (double number in fitnessRun)
            {
                bestSum += number;
            }
            double mean = bestSum / Parameter.Run;
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                        + " runs, gPIO global best mean " + mean.ToString();
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

