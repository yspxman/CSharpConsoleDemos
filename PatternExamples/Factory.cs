using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory
{
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
