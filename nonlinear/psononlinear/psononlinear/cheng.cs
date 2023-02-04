using System;

namespace PSOnonlinear
{
    public class Cheng
    {
        public static void Main()
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
            double up = 1.0;
            double low = -1.0;
            int dim = 1;
            int ite = 500;
            int popu = 100;
            Parameter.UpdateParameter(low, up, dim);

            // n1
            up = 1.0; low = -1.0;
            dim = 2; ite = 500; popu = 100;
            Parameter.UpdateParameter(low, up, dim, ite, popu);
            Star.Process(Function.n1);
            Ring.Process(Function.n1);

            // n2
            up = 1.0; low = -1.0;
            dim = 20; ite = 500; popu = 100;
            Parameter.UpdateParameter(low, up, dim, ite, popu);
            Star.Process(Function.n2);
            Ring.Process(Function.n2);

            // n3
            dim = 2; ite = 250; popu = 2000;
            Parameter.UpdateParameter(low, up, dim, ite, popu);
            Star.Process(Function.n3);
            Ring.Process(Function.n3);

            // f1
            Star.Process(Function.f1);
            Ring.Process(Function.f1);

            // f2
            up = 1.0; low = 0.0; dim = 1;
            Parameter.UpdateParameter(low, up, dim);
            Star.Process(Function.f2);
            Ring.Process(Function.f2);

            // f3
            up = 1.0; low = 0.0; dim = 1;
            Parameter.UpdateParameter(low, up, dim);
            Star.Process(Function.f3);
            Ring.Process(Function.f3);

            // f4
            up = 6.0; low = -6.0; dim = 2;
            Parameter.UpdateParameter(low, up, dim);
            Star.Process(Function.f4);
            Ring.Process(Function.f4);

            // f6
            up = 10.0; low = -10.0;
            dim = 2; ite = 500; popu = 400;
            Parameter.UpdateParameter(low, up, dim, ite, popu);
            Star.Process(Function.f6);
            Ring.Process(Function.f6);

            // f7
            up = 10.0; low = 0.25;
            dim = 2; ite = 500; popu = 400;
            Parameter.UpdateParameter(low, up, dim, ite);
            Star.Process(Function.f7);
            Ring.Process(Function.f7);

            // f6 -> 3 dimension
            up = 10.0; low = -10.0;
            dim = 3; ite = 500; popu = 800;
            Parameter.UpdateParameter(low, up, dim, ite, popu);
            Star.Process(Function.f6);
            Ring.Process(Function.f6);

            // f7 -> 3
            up = 10.0; low = 0.25;
            dim = 3; ite = 500; popu = 800;
            Parameter.UpdateParameter(low, up, dim, ite, popu);
            Star.Process(Function.f7);
            Ring.Process(Function.f7);

            // f8 
            up = 1.0; low = 0.0;
            dim = 2; ite = 500; popu = 400;
            Parameter.UpdateParameter(low, up, dim, ite, popu);
            Star.Process(Function.f8);
            Ring.Process(Function.f8);

            // f8 -> 16 D
            up = 1.0; low = 0.0;
            dim = 16; ite = 1000; popu = 2000;
            Parameter.UpdateParameter(low, up, dim, ite, popu);
            Star.Process(Function.f8);
            Ring.Process(Function.f8);
        }
    }
}