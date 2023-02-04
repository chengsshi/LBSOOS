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

            // n1:n7
            string problem = "n6"; 
            // n1  2
            // n2  20
            // n3  2
            // n4  2
            // n5  3
            // n6  6
            // n7  20

            string program = "bsoosalgorithm";

            // brain storm
            string input = @"..\..\..\..\" + program + @"\bin" + @"\" + problem + ".D6.";
            string output = @"..\bsoos." + problem + ".txt";
            preprocess.loadFile(input, output);



            //string file = @"..\log.txt";
            //List<double> data = new List<double>();  
            //Indicator.indicator(file, ref data);

            //data.Clear();
            string endTime = DateTime.Now.ToString();
            Console.WriteLine("end time: {0}", endTime);
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
