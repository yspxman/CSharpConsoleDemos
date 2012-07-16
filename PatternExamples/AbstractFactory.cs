using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternExamples
{
    class AbstractFactoryClientTest
    {
        public static void Test()
        {
            Console.WriteLine(Utility.HeaderString("Abstract Factory"));

            IAbstractFactory factoryBJ = new FactoryBJ();
            factoryBJ.CreateProductCloth().foo();
            factoryBJ.CreateProductShoes().foo();

            IAbstractFactory factorySH = new FactorySH();
            factorySH.CreateProductCloth().foo();
            factorySH.CreateProductShoes().foo();
        }
    }

    public interface IAbstractFactory
    {
        IProductShoes CreateProductShoes();
        IProductCloth CreateProductCloth();
    }

    public class FactoryBJ : IAbstractFactory
    {
        private IProductShoes shoes;
        private IProductCloth cloth;
        public IProductShoes CreateProductShoes()
        {
            shoes = new SlipperShoes();
            return shoes;
        }

        public IProductCloth CreateProductCloth()
        {
            cloth = new TShirt();
            return cloth;
        }
    }

    public class FactorySH : IAbstractFactory
    {
        private IProductShoes shoes;
        private IProductCloth cloth;
        public IProductShoes CreateProductShoes()
        {
            shoes = new SportsShoes();
            return shoes;
        }

        public IProductCloth CreateProductCloth()
        {
            cloth = new Pants();
            return cloth;
        }
    }


    public interface IProductShoes
    {
        void foo();
    }

    public class SlipperShoes : IProductShoes
    {
        public void foo() { Console.WriteLine("This is SlipperShoes"); }
    }
    class SportsShoes : IProductShoes
    {
        public void foo() { Console.WriteLine("This is SportsShoes"); }
    }

    public interface IProductCloth
    {
        void foo();
    }

    public class TShirt : IProductCloth
    {
        public void foo() { Console.WriteLine("This is TShirt"); }
    }
    class Pants : IProductCloth
    {
        public void foo() { Console.WriteLine("This is Pants"); }
    }
}
