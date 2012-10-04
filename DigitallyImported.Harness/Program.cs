using System;
using System.Collections.Generic;
using System.Text;

using DigitallyImported.Harness.DIService;

namespace DigitallyImported.Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();

            Console.WriteLine("Press any key when the service is ready.");
            Console.ReadKey();

            Console.WriteLine(client.GetChannels().ToString());
            Console.ReadLine();
        }
    }
}
