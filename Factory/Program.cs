using Factory.Repository;
using System;
using System.IO;
using System.Xml;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location + "../../../../../vehicle.xml";
            Console.WriteLine(path);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
