using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace TreeViewLearn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTotal_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("请填写要添加的节点名称！");
                return;
            }
            string sql = "insert into TreeTest(nodeName,parentId) output inserted.id values"+"("+" "+"'"+textBox1.Text.Trim()+"'"+","+"'"+0+"'"+")";
            int id = (int)sqlHelper.ExecuteScalar(sql);
            TreeNode node1 = new TreeNode();
            node1.Tag = id;
            node1.Text = textBox1.Text.Trim();
            treeView1.Nodes.Add(node1);
            textBox1.Text = "";
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            int id;
            if(string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                return;
            }
            if(treeView1.SelectedNode==null)
            {
                MessageBox.Show("请选择父节点");
                return;
            }
            id =(int)treeView1.SelectedNode.Tag;
            string sql = "insert into TreeTest(nodeName,parentId) output inserted.id values"+"(" + " " + "'" + textBox1.Text.Trim() + "'" + "," + "'" + id + "'" + ")";
            int id1 = (int)sqlHelper.ExecuteScalar(sql);
            TreeNode node1 = new TreeNode();
            node1.Tag = id1;
            node1.Text = textBox1.Text.Trim();
            treeView1.SelectedNode.Nodes.Add(node1);
            textBox1.Text = "";
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            //失去焦点事件
            //treeView1.SelectedNode.BackColor = Color.Blue;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = treeView1.SelectedNode.Name;
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
         
            setTreeView(treeView1, 0);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connec = sqlHelper.getcon();
            if(connec.State==ConnectionState.Open)
            {
                MessageBox.Show(connec.State.ToString());
                MessageBox.Show("成功连接数据库");
            }
        }
        //调用的时候parentId以0值开始 setTreeView(treeView1, 0);
        private void setTreeView(TreeView tr1,int parentId)
        {
            string sql = "select * from TreeTest where parentId=" + parentId;
          
            DataTable ds= sqlHelper.ExecuteDataTable(sql);
            if (ds.Rows.Count > 0)
            {
                int pId = -1;
                foreach (DataRow row in ds.Rows)
                {
                    TreeNode node = new TreeNode();
                    node.Text = row["nodeName"].ToString();
                    node.Tag = (int)row["id"];
                    pId = (int)row["parentId"];
                    if (pId == 0)
                    {
                        //添加根节点
                        tr1.Nodes.Add(node);
                    }
                    else
                    {
                        //添加根节点之外的其他节点
                        RefreshChildNode(tr1,node,pId);
                    }
                    //查找以node为父节点的子节点
                    setTreeView(tr1,(int)node.Tag);

                }
            }

        }
        //处理根节点的子节点
        private void RefreshChildNode(TreeView tr1,TreeNode treeNode, int parentId)
        {
            foreach (TreeNode node in tr1.Nodes)
            {
                if((int)node.Tag==parentId)
                {
                    node.Nodes.Add(treeNode);
                    return;
                }else if (node.Nodes.Count > 0)
                {
                    FindChildNode(node, treeNode,  parentId);
                }
            }
        }
        //处理根节点的子节点的子节点
        private void FindChildNode(TreeNode  tNode,TreeNode treeNode, int parentId)
        {

            foreach (TreeNode node in tNode.Nodes)
            {
                if ((int)node.Tag == parentId)
                {
                    node.Nodes.Add(treeNode);
                    return;
                }else if (node.Nodes.Count > 0)
                {
                    FindChildNode(node,treeNode,parentId);

                }

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode==null)
            {
                MessageBox.Show("请选择要删除的节点！");
                return;
            }
            //选中节点的主键id，也是其子节点的parentId
            int id = (int)treeView1.SelectedNode.Tag;
            nodeDelete(id);
            treeView1.SelectedNode.Remove();

        }
        //数据表中的数据的递归删除方法
        public void nodeDelete(int id)
        {
            string sql = "select * from TreeTest where parentId="+id;
            DataTable ds = sqlHelper.ExecuteDataTable(sql);
            if (ds.Rows.Count > 0)
            {
                //有子节点
                foreach(DataRow row in ds.Rows)
                {
                    //先删除父节点
                    string delete = "delete from TreeTest where id=" + id;
                    int k = sqlHelper.ExecuteNonQuery(delete);
                    //查找子节点，删除
                    int id1 = (int)row["id"];
                    nodeDelete(id1);
                }
            }
            else
            { 
               //没有子节点
                string delete = "delete from TreeTest where id="+id;
                int k = sqlHelper.ExecuteNonQuery(delete);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Action!=TreeViewAction.Unknown)
            {
                if(e.Node.Checked)
                {
                   
                }
            }
        }
    }
}
