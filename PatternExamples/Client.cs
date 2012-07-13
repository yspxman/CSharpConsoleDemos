﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Factory;
using System.Reflection;

namespace PatternExamples
{
    class Client
    {
        static void Main(string[] args)
        {
            SimpleFactoryClientTest();

            FactoryClientTest();

            AbstractFactoryClientTest();
        }



        static void AbstractFactoryClientTest()
        {
            Console.WriteLine("This is Abstract factory pattern");


            IAbstractFactory factoryBJ = new FactoryBJ();
            factoryBJ.CreateProductCloth().foo();
            factoryBJ.CreateProductShoes().foo();


            IAbstractFactory factorySH = new FactorySH();
            factorySH.CreateProductCloth().foo();
            factorySH.CreateProductShoes().foo();
           
        }

        static void FactoryClientTest()
        {
            Console.WriteLine("This is  factory pattern");

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
            IFactory f = (IFactory)Assembly.Load("PatternExamples").CreateInstance("Factory." + factoryName);
            IProduct p = f.CreateProduct();

            p.foo();
        }

        static void SimpleFactoryClientTest()
        { 
            Console.WriteLine("This is Simple factory pattern");

            SimpleProductFactory factory = new SimpleProductFactory();
            Product PA = factory.CreateProduct("a");
            Product PB = factory.CreateProduct("b");

            PA.foo();
            PB.foo();
        }
    }

}
