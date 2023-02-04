using System;
using System.Collections.Generic;

namespace ResultStatistic
{
    public class Cheng
    {
        public static void Main()
        {
            Console.WriteLine("start");
            string beginTime = DateTime.Now.ToString();
            Console.WriteLine("begin time: {0}", beginTime);

            statistic("f1", 1);
            statistic("f2", 1);
            statistic("f3", 1);
            statistic("f4", 2);
            statistic("f5", 2);
            statistic("f6", 2);
            statistic("f6", 3);
            statistic("f7", 2);
            statistic("f7", 3);
            statistic("f8", 2);
            Parameter.Iteration = 1000;
            statistic("f8", 16);

            //data.Clear();
            string endTime = DateTime.Now.ToString();
            Console.WriteLine("end time: {0}", endTime);
            Console.WriteLine("done");
            Console.ReadKey();
        }

        public static void statistic(string function, int dim)
        {
            string program = "particleSwarm";

            string dimension = dim.ToString();

            string type = "star";
            // multi modal
            // star, ring, fourClusters, vonNeumann, socialStar, socialRing, cognitive  
            string input = @"..\..\..\..\" + program + @"\bin" + @"\" + function
                + "." + type + "." + dimension + ".diversity.";
            // cognitive, 
            string output = @"..\" + function + "." + type + "." + dimension + ".diversity.txt";
            preprocess.loadFile(input, output);

            type = "ring";
            // multi modal
            // star, ring, fourClusters, vonNeumann, socialStar, socialRing, cognitive  
            input = @"..\..\..\..\" + program + @"\bin" + @"\" + function
               + "." + type + "." + dimension + ".diversity.";
            // cognitive, 
            output = @"..\" + function + "." + type + "." + dimension + ".diversity.txt";
            preprocess.loadFile(input, output);


            type = "fourClusters";
            // multi modal
            // star, ring, fourClusters, vonNeumann, socialStar, socialRing, cognitive  
            input = @"..\..\..\..\" + program + @"\bin" + @"\" + function
               + "." + type + "." + dimension + ".diversity.";
            // cognitive, 
            output = @"..\" + function + "." + type + "." + dimension + ".diversity.txt";
            preprocess.loadFile(input, output);

            type = "vonNeumann";
            // multi modal
            // star, ring, fourClusters, vonNeumann, socialStar, socialRing, cognitive  
            input = @"..\..\..\..\" + program + @"\bin" + @"\" + function
               + "." + type + "." + dimension + ".diversity.";
            // cognitive, 
            output = @"..\" + function + "." + type + "." + dimension + ".diversity.txt";
            preprocess.loadFile(input, output);

            type = "socialStar";
            // multi modal
            // star, ring, fourClusters, vonNeumann, socialStar, socialRing, cognitive  
            input = @"..\..\..\..\" + program + @"\bin" + @"\" + function
               + "." + type + "." + dimension + ".diversity.";
            // cognitive, 
            output = @"..\" + function + "." + type + "." + dimension + ".diversity.txt";
            preprocess.loadFile(input, output);

            type = "socialRing";
            // multi modal
            // star, ring, fourClusters, vonNeumann, socialStar, socialRing, cognitive  
            input = @"..\..\..\..\" + program + @"\bin" + @"\" + function
               + "." + type + "." + dimension + ".diversity.";
            // cognitive, 
            output = @"..\" + function + "." + type + "." + dimension + ".diversity.txt";
            preprocess.loadFile(input, output);

            type = "cognitive";

            // multi modal
            // star, ring, fourClusters, vonNeumann, socialStar, socialRing, cognitive  
            input = @"..\..\..\..\" + program + @"\bin" + @"\" + function
               + "." + type + "." + dimension + ".diversity.";
            // cognitive, 
            output = @"..\" + function + "." + type + "." + dimension + ".diversity.txt";
            preprocess.loadFile(input, output);


        }
    }
}
                                                                                    z