using System;

namespace LearningBSOOS
{
    public class Cheng
    {
        public static void Main()
        {
            Console.WriteLine("start");
            string beginTime = DateTime.Now.ToString();
            Console.WriteLine("begin time: {0}", beginTime);

            process();

            string endTime = DateTime.Now.ToString();
            Console.WriteLine("end time: {0}", endTime);
            Console.WriteLine("done");
            Console.ReadKey();
        }

        public static void process()
        {
            int dim = 2;

            //// n1
            //Parameter.UpdateParameter(dim);
            //Objective.BSOobjective(Function.n1);

            //// n2
            //dim = 20;
            //Parameter.UpdateParameter(dim);
            //Objective.BSOobjective(Function.n2);

            ////n3
            //dim = 2;
            //Parameter.UpdateParameter(dim);
            //Objective.BSOobjective(Function.n3);

            // n4
            dim = 2;
            Parameter.UpdateParameter(dim);
            Objective.BSOobjective(Function.n4);

            // n5
            //dim = 3; 
            //Parameter.UpdateParameter(dim);
            //Objective.BSOobjective(Function.n5);

            // n6
            //dim = 6; 
            //Parameter.UpdateParameter(dim);
            //Objective.BSOobjective(Function.n6);

            //// n7
            //dim = 20; 
            //Parameter.UpdateParameter(dim);
            //Objective.BSOobjective(Function.n7);
        }
    }
}
