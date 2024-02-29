using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm8
{
    public class BinTree<T>
    {
        public TreeNode<T> Root { get; set; }
        public TreeNode<T> Add(TreeNode<T> node, TreeNode<T> curPar = null) {
            if (Root == null) {
                node.Parent = null;
                return Root = node;
            }
            curPar = curPar ?? Root;
            node.Parent = curPar;
            int check = node.Data.ToString().CompareTo(curPar.Data.ToString());
            return (check == 0)
                ? curPar
                : check < 0
                    ? curPar.Left == null
                        ? curPar.Left = node
                        : Add(node, curPar.Left)
                    : curPar.Right == null
                        ? curPar.Right = node
                        : Add(node, curPar.Right);
        }
        public TreeNode<T> Add(T data) {
            return Add(new TreeNode<T>(data));
        }
        public TreeNode<T> Find(T data, TreeNode<T> curPar = null)
        {
            curPar = curPar ?? Root;
            int check = data.ToString().CompareTo(curPar.Data.ToString());
            return check == 0
            ? curPar
            : check < 0
                ? curPar.Left == null
                    ? null //not exists
                    : Find(data, curPar.Left)
                : curPar.Right == null
                    ? null //not exists
                    : Find(data, curPar.Right);
        }
    }
}
