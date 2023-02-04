using System;
using System.Collections.Generic;

namespace BSOnonlinear
{
    class SynchronousBSO
    {
        // fun = fitness_function
        // population_size; populationlation size
        // number_dimension; number of dimension
        // cluster_number: number of clusters;  
        // percentage_elitist ==  cluster_number
        // range_left; left boundary of the dynamic range
        // range_right; right boundary of the dynamic range


        public static void Process(Function type)
        {
            int globalIndex = 0;
            double globalValue = Double.MaxValue;
            double minimum = double.MaxValue;
            int count = 0;

            double[] globalOptimum = new double[Parameter.Dimension];

            double[,] position = new double[Parameter.Population, Parameter.Dimension];
            double[,] groupSynchronous = new double[Parameter.Population, Parameter.Dimension]; // synchronous update
            double[] fitnessTrajectory = new double[Parameter.Iteration];

            double[] solution = new double[Parameter.Dimension];
            double[] fitness = new double[Parameter.Population];
            double stepSize = 1.0; // effecting the step size of generating new individuals by adding random values
            // double[] solution = new double[Parameter.Dimension];

            int[] indexOriginal = new int[Parameter.Population];
            //int[] fitness_population_sorted = new int[Parameter.Population];

            List<double> individualList = new List<double>();

            List<double> fitnessRun = new List<double>();
            List<string> log = new List<string>(); // write log
            string logSentence = String.Empty;
            string logName = String.Empty; // log file Name 

            #region time variables
            //double diffTime = 0.0;
            //TimeSpan diff = TimeSpan.Zero;
            //DateTime start = DateTime.Now;
            //Console.WriteLine("Hour: {0}, Minute: {1}, Second:{2}", start.Hour, start.Minute, start.Second);
            //DateTime end = DateTime.Now;
            #endregion

            #region variable definition
            Random rand = new Random();
            //byte[] buffer = Guid.NewGuid().ToByteArray();
            //int iSeed = BitConverter.ToInt32(buffer, 0);
            //rand = new Random(iSeed);

            #endregion

            // probability Disrupt
            double probabilityDisrupt = 0.0;
            // probability for select elitist, not normals, to generate new individual; 
            double probabilityElitist = 0.2;
            double probabilityHybrid = 0.8;

            // probability for select one individual, not two, to generate new individual; 
            double probabilityOne = 0.5;

            for (int run = 0; run < Parameter.Run; ++run)
            {
                #region initialization
                globalValue = Double.MaxValue;
                minimum = double.MaxValue;
                for (int num = 0; num < Parameter.Population; ++num)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        // initialize the populationlation of individuals
                        position[num, dim] = Parameter.Lower + (Parameter.Upper - Parameter.Lower) * rand.NextDouble();

                        // initialize the temporary populationlation of individuals
                        // groupSynchronous[num, dim] = Parameter.Lower + (Parameter.Upper - Parameter.Lower) * rand.NextDouble();
                    }
                }

                // initialize current iterantion  number
                //    int current_iteration_number = 1;

                // number of elitists
                // Parameter.perce == percentage_elitist 
                int numberElitist = Convert.ToInt32(Math.Round(Parameter.Population * Parameter.Perce));
                // number of normals
                int numberNormal = Parameter.Population - numberElitist;

                // initialize corresponding original indexs in the population of sorted fitness values 
                //for (int atom = 0; atom < Parameter.Population; ++atom)
                //{
                //    indexOriginal[atom] = 101;
                //}
                // store best fitness value for each iteration
                //% best_fitness = ones(max_iteration,1); 

                // store fitness value for each individual in each population
                // fitness_population = ones(population_size,1);  
                // store sorted fitness values
                //for (int atom = 0; atom < Parameter.Population; ++atom)
                //{
                //    fitness_population_sorted[atom] = 1;
                //}
                // store a temporary individual
                //individual_temporary = zeros(1,number_dimension);  
                #endregion // initialization

                #region first calculation 
                // calculate fitness for each individual in the initialized populationlation
                for (int num = 0; num < Parameter.Population; ++num)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = position[num, dim];
                    }

                    //fitness[part] = function(type, ref solution);
                    #region choose benchmark function
                    switch (type)
                    {
                        case Function.f1:
                            fitness[num] = Multimode.f1(ref solution);
                            break;
                        case Function.f2:
                            fitness[num] = Multimode.f2(ref solution);
                            break;
                        case Function.f3:
                            fitness[num] = Multimode.f3(ref solution);
                            break;
                        case Function.f4:
                            fitness[num] = Multimode.f4(ref solution);
                            break;
                        case Function.f5:
                            fitness[num] = Multimode.f5(ref solution);
                            break;
                        case Function.f6:
                            fitness[num] = Multimode.f6(ref solution);
                            break;
                        case Function.f7:
                            fitness[num] = Multimode.f7(ref solution);
                            break;
                        case Function.f8:
                            fitness[num] = Multimode.f8(ref solution);
                            break;
                        case Function.n1:
                            fitness[num] = Nonlinear.N1(ref solution);
                            break;
                        case Function.n2:
                            fitness[num] = Nonlinear.n2(ref solution);
                            break;
                        case Function.n3:
                            fitness[num] = Nonlinear.n3(ref solution);
                            break;
                        case Function.n4:
                            fitness[num] = Nonlinear.n4(ref solution);
                            break;
                        case Function.n5:
                            fitness[num] = Nonlinear.n5(ref solution);
                            break;
                        case Function.n6:
                            fitness[num] = Nonlinear.n6(ref solution);
                            break;
                        case Function.n7:
                            fitness[num] = Nonlinear.n7(ref solution);
                            break;

                        default:
                            Console.WriteLine("Not a valid function type");
                            Console.ReadKey();
                            break;
                    }
                    #endregion

                    if (fitness[num] < globalValue)
                    {
                        globalValue = fitness[num];
                        globalIndex = num;
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            globalOptimum[dim] = position[num, dim];
                        }
                    }
                }
                #endregion // first calculation

                // start the main loop of the BSO algorithm       
                // compensate the fitness evaulation due to disruption
                // int maxIteration = Convert.ToInt32(Parameter.Iteration - (Parameter.Iteration * probabilityDisrupt) / Parameter.Population);
                // maxIteration = max_iteration - (max_iteration/population_size); 
                // compensate the fitness evaulation due to disruption

                // store best fitness value for each iteration
                //best_fitness = ones(maxIteration,1); 

                // use the compesented maximum iteration
                #region Main Iteration
                for (int ite = 0; ite < Parameter.Iteration; ++ite) //while current_iteration_number <= maxIteration 
                {
                    #region sort individuals
                    for (int idx = 0; idx < Parameter.Population; ++idx)
                    {
                        individualList.Add(fitness[idx]);

                        // find global information
                        if (fitness[idx] < globalValue)
                        {
                            globalValue = fitness[idx];
                            globalIndex = idx;
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                globalOptimum[dim] = position[idx, dim];
                            }
                        }
                    }

                    // sort individuals in a population based on their fitness values
                    individualList.Sort();
                    for (int i = 0; i < Parameter.Population; ++i)
                    {
                        for (int pop = 0; pop < Parameter.Population; ++pop)
                        {
                            if (fitness[pop] == individualList[i])
                            {
                                indexOriginal[i] = pop;
                            }
                        }
                    }

                    //[fitness_population_sorted,index_original] = sort(fitness_population,'ascend');

                    #endregion // end sort

                    // record the best fitness in each iteration
                    fitnessTrajectory[ite] = globalValue; // == individualList[0];

                    individualList.Clear();

                    #region generate new individual
                    // generate population_size new individuals by adding Gaussian random values            
                    for (int idx = 0; idx < Parameter.Population; ++idx)
                    {
                        // form the seed individual 
                        // generate a randon value
                        double r_1 = rand.NextDouble();

                        if (r_1 < probabilityElitist) // select elitists to generate a new individual
                        {
                            // double r = rand.NextDouble(); // generate a random number
                            int indexOne = rand.Next(numberElitist);// 
                            int indexTwo = rand.Next(numberElitist); // Convert.ToInt32(Math.Floor(number_elitist * rand.NextDouble()));
                            if (indexOne == indexTwo) // avoid same index
                            {
                                indexTwo = numberElitist - indexOne - 1;
                            }
                            if (rand.NextDouble() < probabilityOne)
                            {
                                // use one elitist to generate a new individual
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    solution[dim] = position[indexOriginal[indexOne], dim];
                                }
                            }
                            else // use two elitists to generate a new individual
                            {
                                double tem = rand.NextDouble(); // combine from two individuals
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    solution[dim] = tem * position[indexOriginal[indexOne], dim]
                                        + (1.0 - tem) * position[indexOriginal[indexTwo], dim];
                                }
                            }
                        }
                        else if (r_1 > probabilityHybrid) // hybrid mode
                        {
                            int indexOne = rand.Next(numberElitist);
                            int indexTwo = numberElitist + rand.Next(numberNormal);
                            double tem = rand.NextDouble(); // combine from two individuals
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                solution[dim] = tem * position[indexOriginal[indexOne], dim]
                                    + (1.0 - tem) * position[indexOriginal[indexTwo], dim];
                            }
                        }
                        else
                        {
                            // select normals to generate a new individual
                            double r = rand.NextDouble(); // generate a random number
                            int indexOne = numberElitist + rand.Next(numberNormal); // Convert.ToInt32(Math.Floor(number_normal * rand.NextDouble()));
                            int indexTwo = numberElitist + rand.Next(numberNormal); // Convert.ToInt32(Math.Floor(number_normal * rand.NextDouble()));
                            if (indexOne == indexTwo) // avoid same index
                            {
                                // inx_selected_two = number_elitist + number_normal - (inx_selected_one - number_elitist) - 1;
                                indexTwo = numberElitist + Parameter.Population - indexOne - 1;
                            }

                            if (r < probabilityOne) // use one normal to generate a new individual
                            {
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    solution[dim] = position[indexOriginal[indexOne], dim];
                                }
                            }
                            else // use two elitists to generate a new individual
                            {
                                double tem = rand.NextDouble();
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    solution[dim] = tem * position[indexOriginal[indexOne], dim]
                                        + (1 - tem) * position[indexOriginal[indexTwo], dim];
                                }
                            }
                        }

                        // add Gaussian random value to seed individual to generat a new individual
                        stepSize = 0.1 * Math.Pow(10.0, Math.Exp((-1.0 * ite) / (Parameter.Iteration - ite)));

                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            solution[dim] = solution[dim] + stepSize * rand.NextDouble() * Probability.Gaussian(0.0, 1.0);
                            // + stepSize * Probability.cauchy(1.0);

                            if (solution[dim] > Parameter.Upper)
                            {
                                solution[dim] = Parameter.Upper;
                            }
                            else if (solution[dim] < Parameter.Lower)
                            {
                                solution[dim] = Parameter.Lower;
                            }
                        }

                        #region selection between new individual and the previous
                        // selection between new one and the old one with the same index
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
                        // double fitnessValue = function(type, ref solution); // calculate
                        if (minimum < fitness[idx])  // better than the previous one, replace
                        {
                            fitness[idx] = minimum;
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                groupSynchronous[idx, dim] = solution[dim];
                            }
                        }
                        else
                        {
                            // keep the previous one 
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                groupSynchronous[idx, dim] = position[idx, dim];
                            }
                        }
                    }
                    // copy temporary population to population to start next iteration
                    for (int idx = 0; idx < Parameter.Population; ++idx)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            position[idx, dim] = groupSynchronous[idx, dim];
                        }
                    }
                    #endregion // selection                                            
                    #endregion // generate new individual

                    #region disrupt individual // local search
                    // don't do disruption for the first generation
                    //if (ite > 0) // not the first iteration
                    //{
                    // disrupt every genration but for one dimension of one individual
                    // double r_1 = rand.NextDouble();  // generate a randon value
                    // decide whether to select one individual to be disrupted
                    if (rand.NextDouble() < probabilityDisrupt)
                    {
                        // index of the selected individual
                        int idx = Convert.ToInt32(Math.Floor(Parameter.Population * rand.NextDouble()));

                        if (idx == globalIndex)
                        {
                            if (idx > Parameter.Population / 2.0)
                            {
                                idx--;
                            }
                            else
                            { idx++; }
                        }

                        // temporary individual = selected individual
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            solution[dim] = position[idx, dim];
                        }
                        // one dimention of selected individual to be replaceed by a random number
                        solution[rand.Next(Parameter.Dimension)] = Parameter.Lower + (Parameter.Upper - Parameter.Lower) * rand.NextDouble();

                        // evaluate the disrupted individual
                        // double fv = function(type, ref solution);
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

                        // if (fv < fitness_population[idx] { // if better
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            // replace the selected individual with the disrupted one
                            position[idx, dim] = solution[dim];
                        }

                        // assign the fitness value to the disrupted individual
                        // fitness[idx] = fv;
                        //  }
                    }
                    //}
                    #endregion // disrupt individual
                }
                #endregion // stopped after last iteration

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

                // bso-os stopped after last iteration
                string trajectory = type.ToString() + ".sy." + Parameter.Dimension.ToString() + "." + run.ToString() + ".txt";
                Write.writeTrajectory(trajectory, ref fitnessTrajectory);

                logSentence = type.ToString() + " fitness[sy bsoos] " + globalValue.ToString() + " run " + run.ToString();
                Console.WriteLine(logSentence);
                log.Add(logSentence);

                fitnessRun.Add(globalValue);
            }

            logName = "_" + type.ToString() + ".sy.bsoos." + Parameter.Dimension.ToString() + ".txt";

            // global count
            logSentence = type.ToString() + " global count " + count.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            #region statistical indicator
            // best of local ring best fitness
            fitnessRun.Sort();
            logSentence = type.ToString() + " sy bsoos best fitness "
                + fitnessRun[0].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // middle of local ring best fitness
            logSentence = type.ToString() + " sy bsoos middle fitness "
                + fitnessRun[Parameter.Run / 2].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // worst of local ring best fitness
            logSentence = type.ToString() + " sy bsoos worst fitness "
                + fitnessRun[Parameter.Run - 1].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // calculate mean of the best particle fitness in each round
            double mean = 0.0;
            foreach (double number in fitnessRun)
            {
                mean += number;
            }
            mean /= Parameter.Run;
            logSentence = type.ToString() + " " + Parameter.Run.ToString() + " runs, sy bsoos best mean "
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