namespace TreeViewLearn
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNodeName = new System.Windows.Forms.TextBox();
            this.btnAddRootNode = new System.Windows.Forms.Button();
            this.btnAddSonNode = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加子节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.删除选中节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加根节点ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "treeview1";
            // 
            // treeView1
            // 
            this.treeView1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(13, 29);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(331, 533);
            this.treeView1.TabIndex = 1;
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(571, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称：";
            // 
            // txtNodeName
            // 
            this.txtNodeName.Location = new System.Drawing.Point(605, 160);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(197, 21);
            this.txtNodeName.TabIndex = 3;
            // 
            // btnAddRootNode
            // 
            this.btnAddRootNode.Location = new System.Drawing.Point(565, 200);
            this.btnAddRootNode.Name = "btnAddRootNode";
            this.btnAddRootNode.Size = new System.Drawing.Size(75, 23);
            this.btnAddRootNode.TabIndex = 4;
            this.btnAddRootNode.Text = "添加根节点";
            this.btnAddRootNode.UseVisualStyleBackColor = true;
            this.btnAddRootNode.Click += new System.EventHandler(this.btnAddRootNode_Click);
            // 
            // btnAddSonNode
            // 
            this.btnAddSonNode.Location = new System.Drawing.Point(646, 200);
            this.btnAddSonNode.Name = "btnAddSonNode";
            this.btnAddSonNode.Size = new System.Drawing.Size(84, 23);
            this.btnAddSonNode.TabIndex = 5;
            this.btnAddSonNode.Text = "添加子节点";
            this.btnAddSonNode.UseVisualStyleBackColor = true;
            this.btnAddSonNode.Click += new System.EventHandler(this.btnAddSonNode_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(747, 200);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除选中节点";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加子节点ToolStripMenuItem,
            this.toolStripSeparator1,
            this.删除选中节点ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 54);
            // 
            // 添加子节点ToolStripMenuItem
            // 
            this.添加子节点ToolStripMenuItem.Name = "添加子节点ToolStripMenuItem";
            this.添加子节点ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加子节点ToolStripMenuItem.Text = "添加子节点";
            this.添加子节点ToolStripMenuItem.Click += new System.EventHandler(this.添加子节点ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // 删除选中节点ToolStripMenuItem
            // 
            this.删除选中节点ToolStripMenuItem.Name = "删除选中节点ToolStripMenuItem";
            this.删除选中节点ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除选中节点ToolStripMenuItem.Text = "删除选中节点";
            this.删除选中节点ToolStripMenuItem.Click += new System.EventHandler(this.删除选中节点ToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加根节点ToolStripMenuItem1,
            this.清空ToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(137, 48);
            // 
            // 添加根节点ToolStripMenuItem1
            // 
            this.添加根节点ToolStripMenuItem1.Name = "添加根节点ToolStripMenuItem1";
            this.添加根节点ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.添加根节点ToolStripMenuItem1.Text = "添加根节点";
            this.添加根节点ToolStripMenuItem1.Click += new System.EventHandler(this.添加根节点ToolStripMenuItem1_Click);
            // 
            // 清空ToolStripMenuItem1
            // 
            this.清空ToolStripMenuItem1.Name = "清空ToolStripMenuItem1";
            this.清空ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.清空ToolStripMenuItem1.Text = "清空";
            this.清空ToolStripMenuItem1.Click += new System.EventHandler(this.清空ToolStripMenuItem1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 564);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddSonNode);
            this.Controls.Add(this.btnAddRootNode);
            this.Controls.Add(this.txtNodeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.Button btnAddRootNode;
        private System.Windows.Forms.Button btnAddSonNode;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加子节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 删除选中节点ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 添加根节点ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem1;
    }
}