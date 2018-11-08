using NetStudy.Core;
using System;

namespace NetStudy.Algorithms.Btree
{
    public class BTreeRunner : IRunner
    {
        public void Run()
        {
            var t = new BTree(3); // A B-Tree with minium degree 3
            t.Insert(10);
            t.Insert(20);
            t.Insert(5);
            t.Insert(6);
            t.Insert(12);
            t.Insert(30);
            t.Insert(7);
            t.Insert(17);
            t.Insert(18);
            t.Insert(19);
            t.Insert(21);
            t.Insert(22);
            t.Insert(23);
            t.Insert(24);
            t.Insert(25);
            //10,
            //5,6,7      12,17,20,30

            Console.WriteLine("Traversal of the constucted tree is ");
            t.traverse();

            int k = 6;
            Console.WriteLine(t.search(k) != null ? "\nPresent" : "\nNot Present");

            k = 15;
            Console.WriteLine(t.search(k) != null ? "\nPresent" : "\nNot Present");
        }
    }
}
