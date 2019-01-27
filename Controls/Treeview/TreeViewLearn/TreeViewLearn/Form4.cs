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
    public partial class Form4 : Form
    {
        public string nodeName
        {
            get { return textBox1.Text.Trim(); }
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("请填写节点名称！");
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
