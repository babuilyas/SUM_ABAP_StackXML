using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new System.Xml.XmlDocument();
            a.Load("input.xml");
            var b = System.IO.File.ReadAllLines("stack_errors.txt");
            var c = b.ToDictionary(d => d.Split(' ')[1], d => d.Split(' '));
                    
            foreach (var item in c)
            {
                var sel = a.SelectSingleNode("descendant::software-component-entry[name='" + item.Key + "']");
                
                switch (item.Value.Length)
                {
                    case 12:
                        sel.ChildNodes[2].InnerText = item.Value[8];
                        Console.WriteLine("correct current SP-LEVEL for " + item.Key + " in output.xml manually.");
                        break;
                    case 15:
                        sel.ChildNodes[5].InnerText = item.Value[11];
                        break;
                    default:
                        Console.WriteLine(item.Key + " may cause error");
                        break;
                }
            }

            a.Save("output.xml");

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
