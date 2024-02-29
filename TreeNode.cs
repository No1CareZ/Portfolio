using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm8
{
    public class TreeNode<T>
    {
        public enum Side
        {
            Left,
            Right
        }
        public TreeNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public TreeNode<T> Parent { get; set; }
        public Side? NodeSide =>
        Parent == null // Parent check
        ? (Side?)null // Side check
        : Parent.Left == this ? Side.Left : Side.Right; // Choosing
    }
}
