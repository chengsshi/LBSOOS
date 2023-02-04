using System;
using System.Text;

namespace ResultStatistic
{
    class preprocess
    {
        public static void loadFile(string input, string output)
        {
            double[] mean = new double[Parameter.Iteration]; 
            string filename = String.Empty; 
            for (int item = 0; item < Parameter.Run; ++item)
            {
                filename = input + item.ToString() + ".txt";
                Read.readFile(filename, ref mean);
            }
            for (int item = 0; item < Parameter.Iteration; ++item)
            {
                mean[item] /= Parameter.Run;
            }

            Write.write(output, ref mean);
        }
    }
}