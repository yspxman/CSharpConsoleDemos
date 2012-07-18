using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralTest
{

    //delegate是声明了一种类型而不是变量，event是变量， 类型是该Delegate
    public delegate string GeneralEventHandler(int num);

    public interface IPublisher
    {
        void dispose();
        // EventHandler 是.net库定义的一个委托
        event EventHandler GeneralEvent1;
        event GeneralEventHandler GeneralEvent2;
        int member1 { get; set; }
        
        // interface 可以包含以上三种，但不能有成员变量
        //int member2; 
    }

    // 定义一个事件发布者
    public class Publisher : IPublisher
    {
        public int member1 { get; set; }
        public void dispose() { ;}
        public event EventHandler GeneralEvent1;

        /*
         *  1.显式的声明了event 访问器。类似于属性的定义方式。其实按照默认的方式一个event如
         *  event EventHandler GeneralEvent1; 编译器也是会以如下方式生成默认的private delegate 变量，然后包装成一个event。
         *  2.为什么用event而不直接用delegate， 因为event在类外是不可调用的，只能赋值，即使是public的。而delegate 变量在类外是
         *  可以赋值并调用的。这就违反了定义event的初衷，event应该是从定义该event的对象中发出的，而不是从外部。  
        */
        private GeneralEventHandler generalEvent2;
        public event GeneralEventHandler GeneralEvent2
        {
            add {
                generalEvent2 += value;
                //如果希望该event只能有一个subscriber， 可以改成如下方式
                //generalEvent2 = value;
            }
            remove{
                generalEvent2 -= value;
            }
        }
        
        public void FireEvent()
        {
            // 对比有显示访问器和没有访问器时调用方法的异同。
            //1. 没有访问器，可以直接用该event做比较或调用 
            if (GeneralEvent1 != null)
            {
                GeneralEvent1(this, null);
            }
            //2. 有访问器，必须用相应的delegate变量来调用
            if (generalEvent2 != null)
            {
                string res = generalEvent2(10);
                //invoke和直接调用的效果是一样的。
                //string res = generalEvent2.Invoke(10);

                Console.WriteLine("Get GeneralEvent2's return value: {0}", res);
            }
        }
    }

    public class Subscriber 
    {
        // 对于subscriber来说，定义一个和delegate原形相同的函数作为event的receiver

        // event receiver
        public string OnEventOccurred(int num)
        {
            Console.WriteLine("Event received, OnEventOccurred {0} ", num);
            return num.ToString();
        }
    }

    class DelegateAndEvent
    {
        public static void ClientTest()
        {
            Publisher pub = new Publisher();
            Subscriber sub = new Subscriber();
            pub.GeneralEvent2 += sub.OnEventOccurred;
            pub.FireEvent();
        }
    }
    

}
