namespace TreeViewLearn
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("郑州");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("洛阳");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("开封");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("河南", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("石家庄");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("唐山");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("河北", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(13, 24);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.Text = "郑州";
            treeNode2.Name = "节点2";
            treeNode2.Text = "洛阳";
            treeNode3.Name = "节点3";
            treeNode3.Text = "开封";
            treeNode4.Name = "节点0";
            treeNode4.Text = "河南";
            treeNode5.Name = "节点5";
            treeNode5.Text = "石家庄";
            treeNode6.Name = "节点6";
            treeNode6.Text = "唐山";
            treeNode7.Name = "节点4";
            treeNode7.Text = "河北";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7});
            this.treeView1.Size = new System.Drawing.Size(436, 444);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 494);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "利用递归选择子节点";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}