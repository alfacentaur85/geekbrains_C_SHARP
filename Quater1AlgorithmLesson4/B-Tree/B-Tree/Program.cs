using System;

namespace B_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BTree bt = new BTree();
            
            Test test = new Test(bt);

            int userAnswer = -1;
            while (userAnswer != 0)
            {
                Console.WriteLine("\n Choose action: ");
                Console.WriteLine("0 - Exit ");
                Console.WriteLine("1 - Add Node By Value ");
                Console.WriteLine("2 - Remove Node By Value ");
                Console.WriteLine("3 - Find Node By Value ");
                Console.WriteLine();
                userAnswer = Convert.ToInt32(Console.ReadLine());

                switch (userAnswer)
                {
                    
                    case 1:
                        Console.Write("Input value for Adding and press Enter: ");
                        bt.AddItem(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine();
                        bt.PrintTree();
                        break;
                    case 2:
                        Console.Write("Input value for Removing and press Enter: ");
                        bt.RemoveItem(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine();
                        bt.PrintTree();
                        break;
                    case 3:
                        Console.Write("Input value for Finding and press Enter: ");
                        bt.Node = bt.GetNodeByValue(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine();
                        Console.Write($"Value: {bt.Node.Value}; Parent: {bt.Node.Parent.Value}; LeftChild: {bt.Node.LeftChild.Value}; RigthChild: {bt.Node.RightChild.Value}");
                        break;
                    case 0:
                    default:
                        break;

                }
                Console.WriteLine();
            }
        }
    }
}
