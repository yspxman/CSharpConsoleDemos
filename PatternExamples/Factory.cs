using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternExamples
{
    class FactoryClientTest
    {
        public static void Test()
        {
            Console.WriteLine(Utility.HeaderString("Factory Pattern"));
            

            /*
            IFactory factoryA = new FactoryA();
            IProduct PA = factoryA.CreateProduct();

            IFactory factoryB = new FactoryB();
            IProduct PB = factoryB.CreateProduct();
            
            PA.foo();
            PB.foo();
            
            */

            // 使用reflection 
            string factoryName = "FactoryA";
            IFactory f = (IFactory)System.Reflection.Assembly.Load("PatternExamples").CreateInstance("PatternExamples." + factoryName);
            IProduct p = f.CreateProduct();

            p.foo();
        }
    }


    public interface IFactory
    {
        
        IProduct CreateProduct();
    }

    public class FactoryA: IFactory
    {

        private IProduct _p;
        public IProduct CreateProduct()
        {

            _p = new ProductA();
            return _p; 
        }         
    }

    public class FactoryB : IFactory
    {
        public IProduct CreateProduct()
        {
            return new ProductB();
        }
    }


    public interface IProduct
    {
        void foo();
    }

    public class ProductA : IProduct
    {
        public void foo() { Console.WriteLine("This is from ProductA"); }
    }
    class ProductB : IProduct
    {
        public void foo() { Console.WriteLine("This is from ProductB"); }
    }


  
}
