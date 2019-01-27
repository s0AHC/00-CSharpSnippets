using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewLearn
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        /// <summary>

        /// 递归函数 递归的吧父亲接到的选择状态传递给孩子结点

        /// </summary>

        /// <param name="treeNode">当前结点</param>

        /// <param name="check">当前结点的选择状态</param> 
        /// 该函数参考http://blog.csdn.net/lilongherolilong/article/details/6689642
        private void RefreshChildNode(TreeNode treeNode, bool check)
        {

            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = check;

                if (node.Nodes.Count > 0)
                {
                    RefreshChildNode(node, check);

                }

            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
       
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
         

            if (e.Action != TreeViewAction.Unknown)
            {
                CheckAllChildNodes(e.Node, e.Node.Checked);
                //通过选中子节点来选择父节点
                bool bol = true;
                int j = 0;
                if (e.Node.Parent != null)
                {
                    j = e.Node.Parent.Nodes.Count;//获得父节点的所有子节点数
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        if (!e.Node.Parent.Nodes[i].Checked)
                        {
                            //判断子节点是否选中，未选中j的值减1
                            j = j - 1;
                        }

                    }
                    if (j == 0)
                    {
                        //子节点都未选中时，父节点取消选中
                        bol = false;
                    }
                    else
                    { bol = true; }//子节点有一个被选中，父节点就会被选中
                    e.Node.Parent.Checked = bol;//选中父节点

                }
            }
        }
        public void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            //用递归的方法，把父节点的选择状态传递给子节点
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

    }
}
