using System;
using System.Collections.Generic;
using System.Text;

namespace BypassTree
{
    public interface ITree<T>
    {
        TreeNode<T> GetRoot();
        void AddItem(T value); // добавить узел
        void PrintTree(); //вывести дерево в консоль
    }

}

