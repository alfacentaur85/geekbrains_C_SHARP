using System;
using System.Collections.Generic;
using System.Text;

namespace BypassTree
{
    class ByPass
    {
        static Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();

        static Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();

        public void ByPassBfs(BTree tree)
        {

            Console.WriteLine("\nByPass BFS:");
            tree.Node = tree.GetRoot();
            queue.Enqueue(tree.Node);
            Bfs(tree.Node);

        }
        void Bfs(TreeNode<int> node)
        {
            if (queue.Count == 0 || node == null)
            {
                return;
            }
            node = queue.Dequeue();
            Console.Write($"{node.Value} -> ");
            if (node.LeftChild != null)
            {
                queue.Enqueue(node.LeftChild);
            }
            if (node.RightChild != null)
            {
                queue.Enqueue(node.RightChild);
            }
            Bfs(node);


        }

        public void ByPassDfs(BTree tree)
        {
            
            Console.WriteLine("\nByPass DFS:");
            tree.Node = tree.GetRoot();
            stack.Push(tree.Node);
            Dfs(tree.Node);

        }

        void Dfs(TreeNode<int> node)
        {
            if (stack.Count == 0 || node == null)
            {
                return;
            }
            node = stack.Pop();
            Console.Write($"{node.Value} -> ");
            if (node.RightChild != null)
            {
                stack.Push(node.RightChild);
            }
            if (node.LeftChild != null)
            {
                stack.Push(node.LeftChild);
            }
            Dfs(node);

        }


    }
}
