﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternExamples
{

    public interface Product
    {
        void foo();
    }

    public class ConcreteProductA : Product
    {
        public void foo() { Console.WriteLine("This is from ConcreteProductA"); }
    }
    class ConcreteProductB : Product
    {
        public void foo() { Console.WriteLine("This is from ConcreteProductB"); }
    }


    class SimpleProductFactory
    {

        private Product pp;

        public Product CreateProduct(String productName)
        {
            switch (productName.Trim().ToLower())
            {
                case "a":
                    pp = new ConcreteProductA();
                    break;
                case "b":
                    pp = new ConcreteProductB();
                    break;
                default:
                    throw new Exception("Not Found!");
            }
            return pp;
        }
    }
}
