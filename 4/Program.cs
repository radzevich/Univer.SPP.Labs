using System;
using System.Collections.Generic;
using System.IO;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pathToAssembly = GetPathToAssembly();
                if (pathToAssembly != "")
                {
                    var assemblyManager = new AssemblyManager();
                    List<string> assemblyTypesNames = assemblyManager.FromAssembly(pathToAssembly)
                                                                     .GetPublickMembers()
                                                                     .SortByNamespaceAndName()
                                                                     .GetAssemblyTypesNames();
                    DisplayNames(assemblyTypesNames);
                }
                else
                {
                    throw new FileLoadException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }

        static string GetPathToAssembly()
        {
            Console.WriteLine("Enter path to assembly..");
            string path = Console.ReadLine();

            return path;
        }

        static void DisplayNames(IEnumerable<string> namesToDisplay)
        {
            foreach (var name in namesToDisplay)
            {
                Console.WriteLine(name);
            }
        }
    }
}
