using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Algorithm8
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void Disp(BinTree<string> der, TreeView TV) {
            TV.Nodes.Add(new TreeNode(der.Root.Data.ToString()));
            DispNode(der.Root, TV.Nodes[0]);
        }
        static void DispNode(TreeNode<string> node, TreeNode TVn) {
            if (node.Left != null) {
                TVn.Nodes.Add(new TreeNode(node.Left.Data.ToString()));
                DispNode(node.Left, TVn.Nodes[0]);
            }
            else TVn.Nodes.Add(new TreeNode("<void>"));
            if (node.Right != null) {
                TVn.Nodes.Add(new TreeNode(node.Right.Data.ToString()));
                DispNode(node.Right, TVn.Nodes[1]);
            }
            else TVn.Nodes.Add(new TreeNode("<void>"));
        }
        public static void Ordered(TreeNode<string> node, TextBox txt) {
            if (node == null) {
                return;
            }
            Ordered(node.Left, txt);
            txt.Text += node.Data.ToString() + " ";
            Ordered(node.Right, txt);
        }
        public static void UnOrdered(TreeNode<string> node, TextBox txt)
        {
            if (node == null)
            {
                return;
            }
            UnOrdered(node.Right, txt);
            txt.Text += node.Data.ToString() + " ";
            UnOrdered(node.Left, txt);
        }
    }
}
