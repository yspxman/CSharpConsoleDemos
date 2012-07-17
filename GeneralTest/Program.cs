using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralTest
{

    //delegate是声明了一种类型而不是变量，event是变量， 类型是该Delegate
    public delegate string MyDelegate(int num);

    public interface Iface
    {
        void dispose();
        event EventHandler Event1;
        event MyDelegate delegate2;
        int member1 { get; set; }
        
        // interface 可以包含以上三种，但不能有成员变量
        //int member2; 
    }

    public class MyFace : Iface
    {
       public void dispose(){;}
       public event EventHandler Event1;
       public event MyDelegate delegate2;
       public int member1 { get; set; }
      
        void foo()
        {
            // windows phone 中不支持beginInvoke方法
           // delegate2.BeginInvoke(

        }
    }

    public class MyFace2 : MyFace
    {
        //EventHandler<
        public void InvokeEvent()
        {
            // event 没有继承下来，下面的语句编译不通过
            //if (Event1 != null){}
        }
    }

    /*
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    */

}
