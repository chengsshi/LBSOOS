using System;

namespace BSOnonlinear
{
    public class Cheng
    {
        public static void Main()
        {
            Console.WriteLine("start");
            string beginTime = DateTime.Now.ToString();
            Console.WriteLine("begin time: {0}", beginTime);

            RunFunction();

            string endTime = DateTime.Now.ToString();
            Console.WriteLine("end time: {0}", endTime);
            Console.WriteLine("done");
            Console.ReadKey();
        }

        public static void RunFunction()
        {
            double up = 1.0;
            double low = -1.0;
            int dim = 1;
            int ite = 500;
            int popu = 100;

            // nonlinear
            up = 1.0; low = -1.0;
            dim = 2; ite = 500; popu = 100;
            Parameter.UpdateParameter(low, up, dim, ite, popu);
            FunctionEvaluation(Function.n1);

            up = 1.0; low = -1.0;
            dim = 20; ite = 500; popu = 100;
            Parameter.UpdateParameter(low, up, dim, ite, popu);
            FunctionEvaluation(Function.n2);

            dim = 2; ite = 250; popu = 2000;
            Parameter.UpdateParameter(low, up, dim, ite, popu);
            FunctionEvaluation(Function.n3);

            FunctionEvaluation(Function.n4);
            FunctionEvaluation(Function.n5);
            FunctionEvaluation(Function.n6);
            FunctionEvaluation(Function.n7);

            // multimode
            FunctionEvaluation(Function.f1);
            FunctionEvaluation(Function.f2);
            FunctionEvaluation(Function.f3);
            FunctionEvaluation(Function.f4);
            FunctionEvaluation(Function.f5);
            FunctionEvaluation(Function.f6);
            FunctionEvaluation(Function.f7);
            FunctionEvaluation(Function.f8);
        }

        public static void FunctionEvaluation(Function func)
        {
            SynchronousBSO.Process(func);
            AsynchronousBSO.Process(func);
            StarPSO.Process(func);
            RingPSO.Process(func);
        }
    }
}
