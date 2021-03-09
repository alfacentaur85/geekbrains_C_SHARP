using System;
using System.Collections.Generic;
using System.Text;

namespace BypassTree
{
    class Test
    {

        BTree tree;
        public Test(BTree bt)
        {
            tree = bt;
            GenerateBTree();
        }

        void GenerateBTree()
        {
            byte[] arrValue = { 50, 25, 75, 13, 37, 63, 87, 6, 21, 29, 45, 55, 68, 82, 95, 1, 7, 18, 23, 27, 35, 40, 48, 51, 58, 65, 70, 78, 85, 90, 100 };
            for (byte i = 0; i < arrValue.Length; i++)
            {
                tree.AddItem(arrValue[i]);
            }

            Console.WriteLine("Source tree:");
            tree.PrintTree();

            ByPass byPass = new ByPass();

            byPass.ByPassBfs(tree);
            Console.WriteLine();

            byPass.ByPassDfs(tree);
            Console.WriteLine();





        }



    }
}
