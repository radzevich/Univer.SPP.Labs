using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int sourceSizeOfList = 10;
            const int indexOfItemToRemove = 8;

            var listOfTestData = new DynamicList<TestData>();
            FillList(listOfTestData, sourceSizeOfList);
            Print(listOfTestData);

            listOfTestData.RemoveAt(indexOfItemToRemove);
            Print(listOfTestData);

            var itemToRemove = listOfTestData[indexOfItemToRemove];
            ((ICollection<TestData>)listOfTestData).Remove(itemToRemove);
            Print(listOfTestData);

            var itemToAdd = new TestData();
            listOfTestData.Add(itemToAdd);
            Print(listOfTestData);

            Console.ReadKey();
        }

        private static void FillList(DynamicList<TestData> listToFill, int numberOfItemsToCreate)
        {
            for (var i = 0; i < numberOfItemsToCreate; i++)
            {
                listToFill.Add(new TestData());
            }
        }

        private static void Print(IEnumerable<TestData> listToPrint)
        {
            Console.WriteLine();
            Console.WriteLine("Count is: {0}", ((ICollection<TestData>)listToPrint).Count);
            foreach (var itemToPrint in listToPrint)
            {
                Console.Write("{0} ", itemToPrint.Id);
            }
            Console.WriteLine();
        }
    }
}
