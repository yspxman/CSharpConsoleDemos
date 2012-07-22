using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GeneralTest
{
    class SandBox
    {

        public static void ClientTest()
        {
            int d = 10;
            Interlocked.Increment(ref d);
            Interlocked.ReferenceEquals(null, null);
            SandBox s = new SandBox();

            s.MultiThreadTest();
            Console.WriteLine("SandBox harsh code is {0}", s.GetHashCode());

            
        }


        public void MultiThreadTest()
        {
            for (int i = 0; i < 30; i++)
            {
                Thread testThread = new Thread(AddFunc);
                testThread.Start(this);
            }
        }

        public static int num1 = 1;
        public static int num2 = 99;
        public static int num3 = 0;
        public static void AddFunc(Object o)
        {
            Thread.Sleep(1000);
            int res;
            Interlocked.Increment(ref num1);
            //num1++;
            res = num1;
           
           Console.WriteLine("num1 is :{0} ", res);
           

        }
       
    }
}
