using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GeneralTest
{
    class program
    {
        // this is the main method.
        static void Main(string[] args)
        {
            DerivedClassEvent.ClientTest();
            DelegateAndEvent.ClientTest();

            //Console.Write("SandBox harsh code is {0}", DerivedClassEvent..GetHashCode());
            SandBox.ClientTest();


        }
    }
}
