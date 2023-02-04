using System;

namespace PIOalgorithm
{
    class Cheng
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            string beginTime = DateTime.Now.ToString();
            Console.WriteLine("begin time: {0}", beginTime);

            Parameter.Display();
            Process();

            string endTime = DateTime.Now.ToString();
            Console.WriteLine("end time: {0}", endTime);
            Console.WriteLine("done");
            Console.ReadKey();
        }

        public static void Process()
        {
            int dim = 2;
            Preprocess.Initialization(dim);
            PIO.Process(Function.n1);
            PIOr.Process(Function.n1);
            PIOrs.Process(Function.n1);
            GPIO.Process(Function.n1);
            GPIOr.Process(Function.n1);
            GPIOrs.Process(Function.n1);

            dim = 20;
            Preprocess.Initialization(dim);
            PIO.Process(Function.n2);
            PIOr.Process(Function.n2);
            PIOrs.Process(Function.n2);
            GPIO.Process(Function.n2);
            GPIOr.Process(Function.n2);
            GPIOrs.Process(Function.n2);

            dim = 2;
            Preprocess.Initialization(dim);
            PIO.Process(Function.n3);
            PIOr.Process(Function.n3);
            PIOrs.Process(Function.n3);
            GPIO.Process(Function.n3);
            GPIOr.Process(Function.n3);
            GPIOrs.Process(Function.n3);

            dim = 2;
            Preprocess.Initialization(dim);
            PIO.Process(Function.n4);
            PIOr.Process(Function.n4);
            PIOrs.Process(Function.n4);
            GPIO.Process(Function.n4);
            GPIOr.Process(Function.n4);
            GPIOrs.Process(Function.n4);

            dim = 3;
            Preprocess.Initialization(dim);
            PIO.Process(Function.n5);
            PIOr.Process(Function.n5);
            PIOrs.Process(Function.n5);
            GPIO.Process(Function.n5);
            GPIOr.Process(Function.n5);
            GPIOrs.Process(Function.n5);

            dim = 6;
            Preprocess.Initialization(dim);
            PIO.Process(Function.n6);
            PIOr.Process(Function.n6);
            PIOrs.Process(Function.n6);
            GPIO.Process(Function.n6);
            GPIOr.Process(Function.n6);
            GPIOrs.Process(Function.n6);

            dim = 20;
            Preprocess.Initialization(dim);
            PIO.Process(Function.n7);
            PIOr.Process(Function.n7);
            PIOrs.Process(Function.n7);
            GPIO.Process(Function.n7);
            GPIOr.Process(Function.n7);
            GPIOrs.Process(Function.n7);
        }
    }
}
