using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadDemo
{
    class ThreadDemo
    {

        
        public void foo1(){
        
            Console.WriteLine("foo1 from internal class!");
        }

        public static void staticfoo(object c)
        { 
        
            ThreadDemo p = (ThreadDemo)c;
            //(c)(Program)
            p.foo1();
        }


        static void Main(string[] args)
        {
            //ThreadStartTest t = new ThreadStartTest();
            //ShowFatherAndSonThread(Thread.CurrentThread);
            //ThreadJoin();
            //ThreadJoin2();
            ThreadInterrupt();
        }


        public static void ThreadInterrupt()
        {

            Console.WriteLine("现在演示interrupt用法！");

            Thread t1 = new Thread(new ThreadStart(
                () =>
                {
                    Console.WriteLine("我是子线程， 我睡觉去5s！");
                    try
                    {
                        Thread.Sleep(5000);
                        Console.WriteLine("我是子线程， 我被interrupt唤醒了！");

                    }
                    catch
                    {
                        Console.WriteLine("被interrupt唤醒了！");
                    }
                    
                }
                )
                );

            t1.Start();

            for (int i = 0; i< 8; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("我是主线程， 已经过了{0}s！, 子线程状态是{1}", i + 1, t1.ThreadState);
                if (i == 2)
                {
                    t1.Interrupt();
                    Console.WriteLine("我是主线程， 已经过了{0}s！,唤醒主线程 子线程状态是{1}", i + 1, t1.ThreadState);
                }
            }

            //t1.Join();
            Console.WriteLine("我是主线程， exit");
            
        }

        public static void ThreadJoin()
        {
            Console.WriteLine("我是主线程,子线程马上要来工作了我得准备下让个位给他。");
            Thread t1 = new Thread(
                new ThreadStart
                    (
                     () =>
                     {
                         for (int i = 0; i < 10; i++)
                         {
                             if (i == 0)
                                 Console.WriteLine("我是子线程{0}, 完成计数任务后我会把工作权交换给主线程", Thread.CurrentThread.Name);
                             else
                             {
                                 Console.WriteLine("我是子线程{0}, SUM:{1}", Thread.CurrentThread.Name, i);
                             }
                             Thread.Sleep(1000);
                         }
                     }
                    )
                );
            t1.Name = "T1";
            Console.WriteLine("我是主线程,子线程要调用join来block我， 但是子线程之间无法通过join来block");
            t1.Start();
            //调用join后调用线程被阻塞
           
            t1.Join();
            Console.WriteLine("终于轮到主线程干活了。。。");
            Thread.Sleep(1000);
            Console.WriteLine("Oh, I'm done!");
        }

        public static void ThreadJoin2()
        {
            IList<Thread> threads = new List<Thread>();
            for (int i = 0; i < 3; i++)
            {
                Thread t = new Thread(
                    new ThreadStart(
                        () =>
                        {

                            for (int j = 0; j < 3; j++)
                            {
                                if (j == 0)
                                    Console.WriteLine("我是线层{0}, 完成计数任务后我会把工作权交换给其他线程", Thread.CurrentThread.Name);
                                else
                                {
                                    Console.WriteLine("我是线层{0}, 计数值:{1}", Thread.CurrentThread.Name, j);
                                }

                                Thread.Sleep(1000);
                            }
                        }));
                t.Name = "线程" + i;
                //将线程加入集合
                threads.Add(t);
            }

            //让子线程们按顺序执行
            foreach (var thread in threads)
            {
                thread.Start();
                //每次按次序阻塞调用次方法的线程， 开启一个线程后，阻止下一个start
                thread.Join();
            }
            Console.WriteLine("主线程退出！");
        }

        public static void ShowFatherAndSonThread(Thread grandFatherThread)
        {
            Console.WriteLine("爷爷主线程名：{0}", grandFatherThread.Name);
            Thread brotherThread = new Thread(new ThreadStart(() => { Console.WriteLine("兄弟线程名：{0}", Thread.CurrentThread.Name); }));
            Thread fatherThread = new Thread(new ThreadStart(
                () =>
                {
                    Console.WriteLine("父亲线程名：{0}", Thread.CurrentThread.Name);
                    Thread sonThread = new Thread(new ThreadStart(() =>
                    {
                        Console.WriteLine("儿子线程名：{0}", Thread.CurrentThread.Name);
                    }));
                    sonThread.Name = "SonThread";
                    sonThread.Start();
                }
                    ));
            fatherThread.Name = "FatherThread";
            brotherThread.Name = "BrotherThread";
            fatherThread.Start();
            brotherThread.Start();
        }
    }




    public class ThreadStartTest
    {
        //无参数的构造函数
        Thread thread = new Thread(new ThreadStart(ThreadMethod));
        //带有object参数的构造函数
        Thread thread2 = new Thread(new ParameterizedThreadStart(ThreadMethodWithPara));
        public ThreadStartTest()
        {
            //启动线程1
            thread.Start();
            //启动线程2
            thread2.Start(new Parameter { paraName = "Test" });

            thread.Join();

        }
        static void ThreadMethod()
        {
            //....
        }
        static void ThreadMethodWithPara(object o)
        {
            if (o is Parameter)
            {
                // (o as Parameter).paraName.............
            }
        }
    }

    public class Parameter
    {
        public string paraName { get; set; }
    }
}
