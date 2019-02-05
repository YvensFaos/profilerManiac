using ProfilerManiac.Utils;
using System.Collections.Generic;
using System;

namespace CastingCompare
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            uint amountOfSimpleClasses = (args.Length > 0 && args[0] != null) ? uint.Parse(args[0]) : 1000000;

            #region Initialize Test Array
            Timer timer = new Timer();
            List<SimpleClass> simpleClasses = new List<SimpleClass>();

            for (uint i = 0; i < amountOfSimpleClasses; i++)
            {
                simpleClasses.Add(new SimpleClass());
            }
            #endregion

            uint repetition = (args.Length > 0 && args[1] != null) ? uint.Parse(args[1]) : 100;
            uint counter = repetition;
            double[] results = new double[4];

            Console.WriteLine("Test;{0};{1}", amountOfSimpleClasses.ToString(), repetition.ToString());

            while (--counter > 0)
            {
                timer.StartRunning();
                simpleClasses.ForEach((SimpleClass simpleClass) =>
                {
                    if (simpleClass is SimpleInterface)
                    {
                        simpleClass.InterfaceMethod();
                    }
                });
                results[0] += timer.StopRunning();

                timer.StartRunning();
                simpleClasses.ForEach((SimpleClass simpleClass) =>
                {
                    if (simpleClass is SimpleInterface simple)
                    {
                        simple.InterfaceMethod();
                    }
                });
                results[1] += timer.StopRunning();

                timer.StartRunning();
                simpleClasses.ForEach((SimpleClass simpleClass) =>
                {
                    SimpleInterface simple = ((SimpleInterface)simpleClass);
                    if(simple != null)
                    {
                        simple.InterfaceMethod();
                    }

                });
                results[2] += timer.StopRunning();

                timer.StartRunning();
                simpleClasses.ForEach((SimpleClass simpleClass) =>
                {
                    SimpleInterface simple = simpleClass as SimpleInterface;
                    if(simple != null)
                    {
                        simple.InterfaceMethod();
                    }
                });
                results[3] += timer.StopRunning();
            }

            Console.WriteLine("Using IS;{0}", (results[0] / repetition).ToString());
            Console.WriteLine("Using IS + named variable;{0}", (results[1] / repetition).ToString());
            Console.WriteLine("Using simple cast;{0}", (results[2] / repetition).ToString());
            Console.WriteLine("Using AS;{0}", (results[3] / repetition).ToString());
        }
    }
}
