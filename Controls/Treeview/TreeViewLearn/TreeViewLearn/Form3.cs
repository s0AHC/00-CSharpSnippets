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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            //自已绘制  
            this.treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.treeView1.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode);  
        }

        private void btnAddRootNode_Click(object sender, EventArgs e)
        {
            //要添加的节点名称为空，即文本框是否为空
            if(string.IsNullOrEmpty(txtNodeName.Text.Trim()))
            {
                MessageBox.Show("要添加的节点名称不能为空！");
                return;
            }
            //添加根节点
            treeView1.Nodes.Add(txtNodeName.Text.Trim());
            txtNodeName.Text = "";
        }

        private void btnAddSonNode_Click(object sender, EventArgs e)
        {
            //要添加的节点名称为空，即文本框是否为空
            //添加子节点
            if (string.IsNullOrEmpty(txtNodeName.Text.Trim()))
            {
                MessageBox.Show("要添加的节点名称不能为空！");
                return;
            }
            if(treeView1.SelectedNode==null)
            {
                MessageBox.Show("请选择要添加子节点的节点！");
                return;
            }
            treeView1.SelectedNode.Nodes.Add(txtNodeName.Text.Trim());
            txtNodeName.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择要删除的节点！");
                return;
            }
            treeView1.SelectedNode.Remove();
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                int x = e.X;
                int y = e.Y;
                TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
                if (CurrentNode is TreeNode)//判断你点的是不是一个节点
                {               
                    treeView1.SelectedNode = CurrentNode;
                    CurrentNode.ContextMenuStrip = this.contextMenuStrip1;                    
                    contextMenuStrip1.Show(MousePosition);
                }
                else
                {
                    treeView1.ContextMenuStrip = this.contextMenuStrip2;
                    contextMenuStrip2.Show(MousePosition);
                }
            }
        }
        /// <summary>
        /// 右键菜单中的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f5 = new Form4();
            if (f5.ShowDialog() == DialogResult.OK)
            {
              treeView1.SelectedNode.Nodes.Add(f5.nodeName);
            }
        }
        /// <summary>
        /// 右键菜单中的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除选中节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }
        /// <summary>
        /// 右键菜单中的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加根节点ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            if (f4.ShowDialog() == DialogResult.OK)
            {
                treeView1.Nodes.Add(f4.nodeName);
            }
        }
        /// <summary>
        /// 右键菜单中的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 清空ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }

     

        private void Form3_Load(object sender, EventArgs e)
        {
            this.treeView1.HideSelection = false;
        }
        //在绘制节点事件中，按自已想的绘制  
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true; //我这里用默认颜色即可，只需要在TreeView失去焦点时选中节点仍然突显  
            return;

            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                //演示为绿底白字  
                e.Graphics.FillRectangle(Brushes.DarkBlue, e.Node.Bounds);

                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, Rectangle.Inflate(e.Bounds, 2, 0));
            }
            else
            {
                e.DrawDefault = true;
            }

            if ((e.State & TreeNodeStates.Focused) != 0)
            {
                using (Pen focusPen = new Pen(Color.Black))
                {
                    focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    Rectangle focusBounds = e.Node.Bounds;
                    focusBounds.Size = new Size(focusBounds.Width - 1,
                    focusBounds.Height - 1);
                    e.Graphics.DrawRectangle(focusPen, focusBounds);
                }
            }

        } 
     
    }
}
