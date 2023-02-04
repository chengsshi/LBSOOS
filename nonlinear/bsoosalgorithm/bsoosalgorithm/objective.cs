using System;
using System.Collections.Generic;

namespace BSOOS
{
    class Objective
    {
        // fun = fitness_function
        // population_size; populationlation size
        // number_dimension; number of dimension
        // cluster_number: number of clusters;  
        // percentage_elitist ==  cluster_number
        // range_left; left boundary of the dynamic range
        // range_right; right boundary of the dynamic range            

        public static void BSOobjective(Function type)
        {
            #region variable definition
            Random rand = new Random();

            int count2 = 0;
            int count4 = 0;
            double[,] population = new double[Parameter.Population, Parameter.Dimension];
            double[,] population_temporary = new double[Parameter.Population, Parameter.Dimension];
            double[] trajectory = new double[Parameter.Iteration];
            double[] individual_temporary = new double[Parameter.Dimension];
            double[] fitness = new double[Parameter.Population];
            double stepSize = 1.0;
            double[] solution = new double[Parameter.Dimension];

            int[] index_original = new int[Parameter.Population];
            int[] fitness_population_sorted = new int[Parameter.Population];
            List<double> individualSort = new List<double>();
            List<double> bestFitness = new List<double>();
            List<string> log = new List<string>(); // write log
            string logSentence = String.Empty;
            string logName = String.Empty; // log file Name 
            #endregion
            // modify based on IJSIR BSO-I BSO in objective space

            //% ranking individuals according to fitness value
            //% take top k percentage as elitists, remaining 100-k percentage as normals
            //% randomly select one elitist to be disrupted, if better, replace, otherwise, do nothing 
            //% if rand < probability_elitist, 
            //%    generate new individuals based on elitists
            //%    if rand < probability_one, 
            //%       generate a new individual based on one randomly selected elitist
            //%    else 
            //%       generate a new individual based on two randomly selected elitists
            //%    endif
            //% else 
            //%    generate new individuals based on normals
            //%    if rand < probability_one, 
            //%       generate a new individual based on one randomly selected normal
            //%    else 
            //%       generate a new individual based on two randomly selected normals
            //%    endif
            //% endif

            // probability to determine whether a dimension is disrupted or not
            // probability_dimension_disruption = 0.2;
            // probability for disrupting elitists. one elitis every 5 generations, and only one dimension;
            double probabilityDisrupt = 0.1;
            // probability for select elitist, not normals, to generate new individual; 
            double probabilityElitist = 0.2;
            // probability for select one individual, not two, to generate new individual; 
            double probabilityOne = 0.8;
            // slope of the s-shape function
            double logsig_slope = 500;

            // effecting the step size of generating new individuals by adding random values
            stepSize = 1.0;

            for (int run = 0; run < Parameter.Run; ++run)
            {
                for (int num = 0; num < Parameter.Population; ++num)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        // initialize the populationlation of individuals
                        population[num, dim] = Parameter.Lower + (Parameter.Upper - Parameter.Lower) * rand.NextDouble();

                        // initialize the temporary populationlation of individuals 
                        population_temporary[num, dim] = Parameter.Lower + (Parameter.Upper - Parameter.Lower) * rand.NextDouble();
                    }
                }

                // initialize current iterantion  number
                // int current_iteration_number = 1;

                // number of elitists
                // Parameter.perce == percentage_elitist 
                int numberElitist = Convert.ToInt32(Math.Round(Parameter.Population * Parameter.Perce));
                // number of normals
                int numberNormal = Parameter.Population - numberElitist;

                // initialize corresponding original indexs in the population of sorted fitness values 
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    index_original[atom] = 101;
                }
                // store best fitness value for each iteration
                //% best_fitness = ones(max_iteration,1); 

                // store fitness value for each individual in each population
                // fitness_population = ones(population_size,1);  
                // store sorted fitness values
                for (int num = 0; num < Parameter.Population; ++num)
                {
                    fitness_population_sorted[num] = 1;
                }
                // store a temporary individual
                //individual_temporary = zeros(1,number_dimension);  

                // calculate fitness for each individual in the initialized populationlation
                for (int num = 0; num < Parameter.Population; ++num)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = population[num, dim];
                    }
                    fitness[num] = function(type, ref solution);
                }

                // start the main loop of the BSO algorithm       
                // compensate the fitness evaulation due to disruption
                int max_iteration_comp = Convert.ToInt32(Parameter.Iteration - (Parameter.Iteration * probabilityDisrupt) / Parameter.Population);
                // max_iteration_comp = max_iteration - (max_iteration/population_size); 
                // compensate the fitness evaulation due to disruption

                // store best fitness value for each iteration
                //best_fitness = ones(max_iteration_comp,1); 

                // use the compesented maximum iteration
                for (int ite = 0; ite < Parameter.Iteration; ++ite) //while current_iteration_number <= max_iteration_comp 
                {
                    #region disrupt individual
                    // don't do disruption for the first generation
                    if (ite > 0) // not the first iteration
                    {
                        // disrupt every genration but for one dimension of one individual
                        double r_1 = rand.NextDouble();  // generate a randon value
                        // decide whether to select one individual to be disrupted
                        if (r_1 < probabilityDisrupt)
                        {
                            // index of the selected individual
                            int idx = Convert.ToInt32(Math.Floor(Parameter.Population * rand.NextDouble()));

                            // temporary individual = selected individual
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                individual_temporary[dim] = population[idx, dim];
                            }
                            // one dimention of selected individual to be replaceed by a random number
                            individual_temporary[rand.Next(Parameter.Dimension)] = Parameter.Lower + (Parameter.Upper - Parameter.Lower) * rand.NextDouble();

                            // evaluate the disrupted individual
                            double fv = function(type, ref individual_temporary);
                            // if (fv < fitness_population[idx] { // if better
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                // replace the selected individual with the disrupted one
                                population[idx, dim] = individual_temporary[dim];
                            }

                            // assign the fitness value to the disrupted individual
                            fitness[idx] = fv;
                            //  }
                        }
                    }
                    #endregion // disrupt individual

                    #region sort individuals
                    for (int pop = 0; pop < Parameter.Population; ++pop)
                    {
                        individualSort.Add(fitness[pop]);
                    }
                    individualSort.Sort();
                    for (int i = 0; i < Parameter.Population; ++i)
                    {
                        for (int pop = 0; pop < Parameter.Population; ++pop)
                        {
                            if (fitness[pop] == individualSort[i])
                            {
                                index_original[i] = pop;
                            }
                        }
                    }

                    // sort individuals in a population based on their fitness values
                    //[fitness_population_sorted,index_original] = sort(fitness_population,'ascend');

                    #endregion // end sort

                    // record the best fitness in each iteration
                    trajectory[ite] = individualSort[0];

                    individualSort.Clear();
                    // generate population_size new individuals by adding Gaussian random values            
                    for (int idx = 0; idx < Parameter.Population; ++idx)
                    {
                        // form the seed individual 
                        // generate a randon value
                        double r_1 = rand.NextDouble();

                        if (r_1 < probabilityElitist) // select elitists to generate a new individual
                        {
                            double r = rand.NextDouble(); // generate a random number
                            int inx_selected_one = Convert.ToInt32(Math.Floor(numberElitist * rand.NextDouble()));
                            int inx_selected_two = Convert.ToInt32(Math.Floor(numberElitist * rand.NextDouble()));
                            if (r < probabilityOne)
                            {
                                // use one elitist to generate a new individual
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    individual_temporary[dim] = population[index_original[inx_selected_one], dim];
                                }
                            }
                            else // use two elitists to generate a new individual
                            {
                                double tem = rand.NextDouble();
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    individual_temporary[dim] = tem * population[index_original[inx_selected_one], dim]
                                        + (1 - tem) * population[index_original[inx_selected_two], dim];
                                }
                            }
                        }
                        else
                        {
                            // select normals to generate a new individual
                            double r = rand.NextDouble(); // generate a random number
                            int inx_selected_one = numberElitist + Convert.ToInt32(Math.Floor(numberNormal * rand.NextDouble()));
                            int inx_selected_two = numberElitist + Convert.ToInt32(Math.Floor(numberNormal * rand.NextDouble()));
                            if (r < probabilityOne) // use one normal to generate a new individual
                            {
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    individual_temporary[dim] = population[index_original[inx_selected_one], dim];
                                }
                            }
                            else // use two elitists to generate a new individual
                            {
                                double tem = rand.NextDouble();
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    individual_temporary[dim] = tem * population[index_original[inx_selected_one], dim]
                                        + (1 - tem) * population[index_original[inx_selected_two], dim];
                                }
                            }
                        }
                        //  add Gaussian random value to seed individual to generat a new individual
                        // step_size = Probability.logsig(((0.5 * Parameter.Iteration - ite) / logsig_slope)) * rand.Next(Parameter.Dimension);
                        stepSize = Probability.logsig((0.5 * Parameter.Iteration - ite) / logsig_slope) * rand.NextDouble();

                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            individual_temporary[dim] = individual_temporary[dim] 
                                + stepSize * Probability.Gaussian(0.0, 1.0);
                            if (individual_temporary[dim] > Parameter.Upper)
                            {
                                individual_temporary[dim] = Parameter.Upper;
                            }
                            else if (individual_temporary[dim] < Parameter.Lower)
                            {
                                individual_temporary[dim] = Parameter.Lower;
                            }
                        }

                        // selection between new one and the old one with the same index
                        double fv = function(type, ref individual_temporary); // calculate
                        if (fv < fitness[idx])  // better than the previous one, replace
                        {
                            fitness[idx] = fv;
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                population_temporary[idx, dim] = individual_temporary[dim];
                            }
                        }
                        else
                        {
                            // keep the previous one 
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                population_temporary[idx, dim] = population[idx, dim];
                            }
                        }
                    }

                    // copy temporary population to population to start next iteration
                    for (int num = 0; num < Parameter.Population; ++num)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            population[num, dim] = population_temporary[num, dim];
                        }
                    }
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

                // Console.WriteLine("function {0}, run {1}, result is {2}", type, run, trajectory[max_iteration_comp - 1]);

                logSentence = type.ToString() + " fitness [bsoos] " + trajectory[Parameter.Iteration - 1].ToString() + " run "
                    + run.ToString();
                Console.WriteLine(logSentence);
                log.Add(logSentence);

                bestFitness.Add(trajectory[max_iteration_comp - 1]);
                string trajectoryName = type.ToString() + ".D"
                    + Parameter.Dimension.ToString() + "." + run.ToString() + ".txt";
                Write.writeTrajectory(trajectoryName, ref trajectory);
            }

            logName = "_" + type.ToString() + ".bsoos." + Parameter.Dimension.ToString() + ".txt";
            // global count
            logSentence = type.ToString() + " bsoos count2 " + count2.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            logSentence = type.ToString() + " bsoos count4 " + count4.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            #region statistical indicator
            // best of local ring best fitness
            bestFitness.Sort();
            logSentence = type.ToString() + " bsoos best fitness "
                + bestFitness[0].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // middle of local ring best fitness
            logSentence = type.ToString() + " bsoos middle fitness "
                + bestFitness[Parameter.Run / 2].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // worst of local ring best fitness
            logSentence = type.ToString() + " bsoos worst fitness "
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
            logSentence = type.ToString() + " bsoos best mean "
                + mean.ToString();
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

            Write.writeLog(logName, ref log);
            #endregion
            log.Clear();

        }

        public static double function(Function type, ref double[] solution)
        {
            double maximum = double.MinValue;

            switch (type)
            {
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
            return maximum;
        }
    }
}