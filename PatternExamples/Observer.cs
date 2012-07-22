using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternExamples
{
    
    class ObserverClientTest
    {
        public static void test()
        {

            Console.WriteLine(Utility.HeaderString("Observer"));

            subject s = new subject();
            ConcreteObserver o1 = new ConcreteObserver();            
            s.AddObserver(o1);
            
            // delegate 和 event observer的调用方式
            // delegate 最大的好处的可以解耦，subject 和  observer没有依赖
            s.StatusChangeHandler += o1.StatusChanged;

            s.StatusChanged();
        }
    }


    interface IChangeObserver
    {
        void StatusChanged();
    }
    class ConcreteObserver : IChangeObserver
    {
        public void StatusChanged()
        {
            Console.WriteLine("Status Change get invoked!");
        }

        public void StatusChanged(string s)
        {
            Console.WriteLine("Status Change get invoked from delegate："+ s );
        }
    }


    delegate void StatusChangedDelegate(string s);


    class subject
    {
        private List<IChangeObserver> observers = new List<IChangeObserver>();

        public event StatusChangedDelegate StatusChangeHandler;

        // 经典observer的注册和反注册函数
        public void AddObserver(IChangeObserver observer)
        {
            observers.Add(observer);
        }
        public void DetachObserver(IChangeObserver observer)
        {
            observers.Remove(observer);
        }

        public void StatusChanged()
        {
            // 1. 经典observer的通知方式
            foreach (var o in observers)
            {
                o.StatusChanged();
            }

            //2. 用event通知的方式, event的注册和反注册函数其实就是+=和-=，已经被delegate框架实现了
            if (StatusChangeHandler != null)
            {
                StatusChangeHandler("msg from the traget object!");
            }
        }
    }



    
}
