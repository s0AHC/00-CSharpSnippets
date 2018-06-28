/*FormProgress是放置了ProgressBar的另一个窗体，backgroundWorker1由设计器生成，在设计窗口，可以直接从工具箱中把BackgroundWorker拖到设计器窗口上。

代码没有难度，相信小姑娘能看懂的。下面我们总结一下BackgroundWorker的用法，相信很多书上都有介绍，哪怕是抄MSDN的书。

1、如果希望报告进度，WorkerReportsProgress属性必须为true，否则报告进度时会异常。如果允许通过调用CancelAsync方法取消任务，WorkerSupportsCancellation属性要为true。

2、处理DoWork事件，后台要处理的任务代码就写在该事件的处理方法中。

3、ProgressChanged事件，当调用ReportProgress方法报告进度后，会引发该事件，处理该事件实时更新进度条的显示。

4、当任务执行完成后会引发RunWorkerCompleted事件，如果后台任务需要返回结果，可从事件参数RunWorkerCompletedEventArgs.Result属性中取得结果。
那么，这个结果是怎么设置的呢？不妨再看看前面的DoWork事件，它的事件参数DoWorkEventArgs的Result属性，当我们的任务执行完成时，把结果赋给该属性，随后引发RunWorkerCompleted事件时，
会把结果传递到RunWorkerCompletedEventArgs.Result属性。*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
 
namespace MyApp
{
    public partial class Form1 : Form
    {
        static string SaveDir = string.Empty;
        private FormProgress fpro = null;
        public Form1()
        {
            InitializeComponent();
            fpro = new FormProgress();
        }
 
 
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int fileCount = Convert.ToInt32(e.Argument);
            Random rand = new Random();
            byte[] buffer = new byte[2048];
            for (int i = 0; i < fileCount; i++)
            {
                try
                {
                    string fileName = Path.Combine(SaveDir, i.ToString() + ".tmp");
                    using (var stream = File.Create(fileName))
                    {
                        int n = 0;
                        int maxByte = 8 * 1024 * 1024;
                        while (n < maxByte)
                        {
                            rand.NextBytes(buffer);
                            stream.Write(buffer, 0, buffer.Length);
                            n += buffer.Length;
                        }
                    }
                }
                catch
                {
                    continue;
                }
                finally
                {
                    // 报告进度
                    this.backgroundWorker1.ReportProgress(i + 1);
                }
            }
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(SaveDir) == false)
            {
                return;
            }
            button1.Enabled = false;
            int cout = Convert.ToInt32(this.nmbud.Value);
            this.fpro.progressBar1.Minimum = 0;
            this.fpro.progressBar1.Maximum = cout;
            this.fpro.progressBar1.Value = this.fpro.progressBar1.Minimum;
            this.backgroundWorker1.RunWorkerAsync(cout);
            // 在开始异步操作后ShowDialog
            // 这样即使代码停在那里也不会影响后台任务的执行
            fpro.ShowDialog(this);
        }
 
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int val = e.ProgressPercentage;
            this.fpro.lblText.Text = string.Format("已生成{0}个文件。", val);
            this.fpro.progressBar1.Value = val;
        }
 
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            fpro.Hide();
            MessageBox.Show("操作完成。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
 
        private void btnBrowsFd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.RootFolder = Environment.SpecialFolder.Desktop;
            if (DialogResult.OK == fd.ShowDialog())
            {
                SaveDir = fd.SelectedPath;
            }
            fd.Dispose();
        }
    }
}