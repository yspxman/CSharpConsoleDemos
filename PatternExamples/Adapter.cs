using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternExamples
{

    class AdapterClientTest
    {

       public static void Test()
        {
            Console.WriteLine(Utility.HeaderString("Adapter"));
            Target t = new Adapter();
            t.PrintSth(12);
        }
    }
    // Client 定义的interface, 接受一个int参数
    public class Target
    {
       public virtual void PrintSth(int a){Console.WriteLine("Print an integer "+a.ToString());}
    }


    // 现有的功能，接受string参数
    public class Adaptee
    {
        public void PrintStr(string s)
        {
            Console.WriteLine("Print a string " + s);
        }
    }

    // 适配器，协调这两个接口
    public class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void PrintSth(int a)
        {
            adaptee.PrintStr(a.ToString());
        }
    }

}
