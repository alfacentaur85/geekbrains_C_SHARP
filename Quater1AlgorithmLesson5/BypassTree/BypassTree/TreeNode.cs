using System;
using System.Collections.Generic;
using System.Text;

namespace BypassTree
{
    public enum Side
    {
        Left,
        Right
    }
    public class TreeNode<T>
    {
        public Side? NodeSide =>
        Parent == null
        ? (Side?)null
        : Parent.LeftChild == this
            ? Side.Left
            : Side.Right;
        public T Value { get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }
        public TreeNode<T> Parent { get; set; }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode<T>;

            if (node == null)
                return false;

            return node.Value.Equals(Value);
        }
    }

}

