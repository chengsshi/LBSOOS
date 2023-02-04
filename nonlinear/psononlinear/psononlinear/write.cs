﻿using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace PSOnonlinear
{
    public class Write
    {
        public static void WriteTrajectory(string fileName, ref List<double> output)
        {
            string content = String.Empty;
            foreach (double number in output)
            {
                content += number.ToString()+ "\n";
            }
            fileName = @"..\" + fileName;
            using (FileStream fileStream = new FileStream(fileName,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(content);
                }
            }
        }

        public static void WriteTrajectory(string fileName, ref double[] output)
        {
            string content = String.Empty;
            for (int ite = 0; ite < Parameter.Iteration; ++ite)
            {
                content += output[ite].ToString() + "\n";
            }
            fileName = @"..\" + fileName;
            using (FileStream fileStream = new FileStream(fileName,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(content);
                }
            }
        }

        public static void WriteLog(string fileName, ref List<string> log)
        {
            string content = String.Empty;
            foreach (string item in log)
            {
                content += item + "\n";
            }
            fileName = @"..\" + fileName;
            using (FileStream fileStream = new FileStream(fileName,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(content);
                }
            }
        }
    }
}