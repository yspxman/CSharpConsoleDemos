using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralTest
{
    //演示如何从派生类调用基类的event

    class DerivedClassEvent
    {
        public static void ClientTest()
        {
            Circle c = new Circle(10);
            Console.WriteLine("Circle area is {0}", c.Area);

            Shape shape = c;
            shape.ShapeChanged += HandleShapeChanged;
            c.Update(100);

            Console.WriteLine("Shape harsh code is {0}", c.GetHashCode());
        }
        private static void HandleShapeChanged(object sender, ShapeEventArgs e)
        {
            Shape s = (Shape)sender;
            Console.WriteLine("Received event.Shape area is now {0}", e.NewArea);
            s.Draw();
        }
    }

    public class ShapeEventArgs : EventArgs
    {
        private double newArea;
        public double NewArea
        {
            get { return newArea; }
        }
        public ShapeEventArgs(double s)
        {
            newArea = s;
        }
    }
    /// <summary>
    /// 定义一个图形抽象类
    /// 在该抽象类中声明一个事件
    /// 并定义在图形发生改变时，触发一个事件
    /// </summary>
    public abstract class Shape
    {
        protected double area;
        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        public event EventHandler<ShapeEventArgs> ShapeChanged;
        public abstract void Draw();
        protected virtual void OnShapeChanged(ShapeEventArgs e)
        {
            EventHandler<ShapeEventArgs> handler = ShapeChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
    /// <summary>
    /// 定义一个关于圆的类继承图形抽象类
    /// </summary>
    public class Circle : Shape
    {
        private double radius;
        public Circle(double d)
        {
            radius = d;
            area = 3.14 * radius * radius;
        }
        public void Update(double d)
        {
            radius = d;
            area = 3.14 * radius * radius;
            OnShapeChanged(new ShapeEventArgs(area));
        }
        /// <summary>
        /// 重写基类方法，然后用base关键字调用基类方法
        /// 间接实现在子类中调用事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            base.OnShapeChanged(e);
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }


}
