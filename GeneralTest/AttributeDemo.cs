
#define Yan

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace GeneralTest
{
    [Serializable]
    class AttributeDemo
    {
        /// <summary>
        ///  Conditional Attribute 的作用是符合这个Conditional string 这个函数才会被编译
        /// </summary>

        [Conditional("Yan")]
        public void fun1()
        {
            Console.WriteLine("This is written by Yan");
        }
        
        [Conditional("Li")]
        public void fun2()
        {
            Console.WriteLine("This is written by Li");
        }


        public static void ClientTest()
        {
            AttributeDemo attribute = new AttributeDemo();

            attribute.fun1();
            attribute.fun2();
        }

    }
}
