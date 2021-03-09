using System;
using System.Collections.Generic;
using System.Text;

namespace B_Tree
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
        // удалить узел по значению
        public void RemoveItem(int value)
        {
            TreeNode<int> head = GetNodeByValue(value);
            if (head == null)
            {
                return;
            }

            var currentNodeSide = head.NodeSide;

            if (head.LeftChild == null && head.RightChild == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    head.Parent.LeftChild = null;
                }
                else
                {
                    head.Parent.RightChild = null;
                }
            }

            else if (head.LeftChild == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    head.Parent.LeftChild = head.RightChild;
                }
                else
                {
                    head.Parent.RightChild = head.RightChild;
                }

                head.RightChild.Parent = head.Parent;
            }

            else if (head.RightChild == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    head.Parent.LeftChild = head.LeftChild;
                }
                else
                {
                    head.Parent.RightChild = head.LeftChild;
                }

                head.LeftChild.Parent = head.Parent;
            }

            else
            {
                TreeNode<int> curTree;
                if (head.RightChild != null && head.LeftChild != null)
                {
                    curTree = head.RightChild;

                    while (curTree.LeftChild != null)
                    {
                        curTree = curTree.LeftChild;
                    }

                    //Если самый левый элемент является первым потомком
                    if (curTree.Parent == head)
                    {
                        curTree.LeftChild = head.LeftChild;
                        head.LeftChild.Parent = curTree;
                        curTree.Parent = head.Parent;
                        if (head == head.Parent.LeftChild)
                        {
                            head.Parent.LeftChild = curTree;
                        }
                        else if (head == head.Parent.RightChild)
                        {
                            head.Parent.RightChild = curTree;
                        }
                        return;
                    }
                    //Если самый левый элемент НЕ является первым потомком
                    else
                    {
                        if (curTree.RightChild != null)
                        {
                            curTree.RightChild.Parent = curTree.Parent;
                        }
                        curTree.Parent.LeftChild = curTree.RightChild;
                        curTree.RightChild = head.RightChild;
                        curTree.LeftChild = head.LeftChild;
                        head.LeftChild.Parent = curTree;
                        head.RightChild.Parent = curTree;
                        curTree.Parent = head.Parent;
                        if (head == head.Parent.LeftChild)
                        {
                            head.Parent.LeftChild = curTree;
                        }
                        else if (head == head.Parent.RightChild)
                        {
                            head.Parent.RightChild = curTree;

                        }
                    }
                }
            }
        }
        //получить узел дерева по значению
        public TreeNode<int> GetNodeByValue(int value)
        {
            TreeNode<int> head = GetRoot();
            while (head != null)
            {
               if (head.Value == value)
               {
                    return head;
               }
               else if (head.Value < value)
                {
                    head = head.RightChild;
                    continue;
                } 
                else
                {
                    head = head.LeftChild;
                    continue;
                }
            }
            throw new Exception("Node is not found");                  // Узел не найден
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
