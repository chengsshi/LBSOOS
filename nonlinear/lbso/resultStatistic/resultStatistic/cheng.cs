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

            // f0:f4 -> f0Unimode; f5:f9-> f5Multimode
            string problem = "f10Multimode"; // f0Unimode

            string program = "brainStorm";

            // brain storm
            string input = @"..\..\..\..\" + program + @"\bin" + @"\" + problem + ".50.";
            string output = @"..\" + problem + ".50.txt";
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
