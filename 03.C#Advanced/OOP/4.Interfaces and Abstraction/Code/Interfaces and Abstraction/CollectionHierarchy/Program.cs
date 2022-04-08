using CollectionHierarchy.Interfaces;
using System;
using CollectionHierarchy.Models;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int remuverdOperation = int.Parse(Console.ReadLine());

            var addCollection = new AddCollection();
            var addRemuveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var addCResult = new List<string>();
            var addRcResult = new List<string>();
            var mLResult = new List<string>();

            foreach (var item in input)
            {
                addCResult.Add(addCollection.Add(item));
                addRcResult.Add(addRemuveCollection.Add(item));
                mLResult.Add(myList.Add(item));
            }

            Console.WriteLine(string.Join(" ",addCResult));
            Console.WriteLine(string.Join(" ",addRcResult));
            Console.WriteLine(string.Join(" ",mLResult));

            addRcResult.Clear();
            mLResult.Clear();

            for (int i = 0; i < remuverdOperation; i++)
            {
                addRcResult.Add(addRemuveCollection.Remuve());
                mLResult.Add(myList.Remuve());
            }

            Console.WriteLine(string.Join(" ", addRcResult));
            Console.WriteLine(string.Join(" ", mLResult));
        }
    }
}
