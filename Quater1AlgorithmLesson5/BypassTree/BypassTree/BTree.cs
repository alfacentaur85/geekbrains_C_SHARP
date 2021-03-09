using System;
using System.Collections.Generic;
using System.Text;

namespace BypassTree
{

    class BTree : ITree<int>
    {

        public TreeNode<int> Node { get; set; }
        TreeNode<int> GetFreeNode(int value, TreeNode<int> parent)
        {
            return new TreeNode<int>
            {
                Parent = parent,
                Value = value
            };
        }

        public TreeNode<int> GetRoot()
        {
            if (Node != null)
            {
                while (Node.Parent != null)
                {
                    Node = Node.Parent;
                }
                return Node;
            }
            else
            {
                return null;
            }

        }
        // добавить узел
        public void AddItem(int value)
        {
            TreeNode<int> tmp = null;
            TreeNode<int> head = GetRoot();
            if (head == null)
            {
                head = GetFreeNode(value, null);
                this.Node = head;
                return;
            }
            tmp = head;
            while (tmp != null)
            {
                if (value > tmp.Value)
                {
                    if (tmp.RightChild != null)
                    {
                        tmp = tmp.RightChild;
                        continue;
                    }
                    else
                    {
                        tmp.RightChild = GetFreeNode(value, tmp);
                        return;
                    }
                }
                else if (value < tmp.Value)
                {
                    if (tmp.LeftChild != null)
                    {
                        tmp = tmp.LeftChild;
                        continue;
                    }
                    else
                    {
                        tmp.LeftChild = GetFreeNode(value, tmp);
                        return;
                    }
                }
                else
                {
                    throw new Exception("Wrong tree state");                  // Дерево построено неправильно
                }
            }
            return;

        }

        //вывести дерево в консоль
        public void PrintTree()
        {
            PrintTree(GetRoot());
        }

        private void PrintTree(TreeNode<int> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}] - {startNode.Value}");
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.LeftChild, indent, Side.Left);
                PrintTree(startNode.RightChild, indent, Side.Right);
            }
        }


    }
}
