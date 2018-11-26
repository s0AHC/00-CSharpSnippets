/*使用BackgroundWorker（已经封装好的线程工具）控件在后台线程执行费时的操作，在主线程中打开一个进度条窗体显示进度。

实现步骤

第0步：创建一个具有进度条的窗体，以显示进度

新建窗体ProcessForm，设置属性FormBorderStyle为None，添加一个ProcessBar控件，如下图所示：

进度条窗体

PrcessBar的Style属性设置为MarQuee。在ProcessForm添加如下公共属性：*/

/// <summary>

/// 设置提示信息

/// </summary>

public string MessageInfo

{

    set { this.labelInfor.Text = value; }

}

/// <summary>

/// 设置进度条显示值

/// </summary>

public int ProcessValue

{

    set { this.progressBar1.Value = value; }

} 

/// <summary>

/// 设置进度条样式

/// </summary>

public ProgressBarStyle ProcessStyle

{

    set { this.progressBar1.Style = value; }

} 



/*第1步：创建进度条管理类ProcessOperator,在该类中添加如下字段：*/

private BackgroundWorker _backgroundWorker;     //后台线程

private ProcessForm _processForm;       //进度条窗体 

//添加如下公共属性、方法和事件：

#region 公共方法、属性、事件 

        /// <summary>

        /// 后台执行的操作

        /// </summary>

        public Action BackgroundWork { get; set; }

 

        /// <summary>

        /// 设置进度条显示的提示信息

        /// </summary>

        public string MessageInfo 

        {

            set { _processForm.MessageInfo = value; }

        }

        /// <summary>

        /// 后台任务执行完毕后事件

        /// </summary>

        public event EventHandler<EventArgs> BackgroundWorkerCompleted;
 

        /// <summary>

        /// 开始执行

        /// </summary>

        public void Start()

        {

            _backgroundWorker.RunWorkerAsync();

            _processForm.ShowDialog();

        } 

        #endregion 


/*其中，属性BackgroundWork可以指向一个无参数的方法，这里（客户端代码）用来指向要在后台执行的费时操作方法，
在_backgroundWorker的事件DoWork中调用该委托指向的方法*/
//后台执行的操作

       private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)

       {

           if (BackgroundWork != null)

           {

               BackgroundWork();

           }

       } 


/*public void Start() 为启动进度条的方法，调用该方法后，会在后台线程(_backgroundWorker.RunWorkerAsync(); )中执行费时操作
(DoWork事件中的委托指向的方法)。同时，_processForm.ShowDialog()方法负责打开进度条窗体。当后台方法执行完毕后，
会触发backgroundWorker的RunWorkerCompleted事件，在该事件中关闭进度条窗体*/

//操作进行完毕后关闭进度条窗体

       private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

       {

           if (_processForm.Visible == true)

           {

               _processForm.Close();

           }

           if (this.BackgroundWorkerCompleted != null)

           {

               this.BackgroundWorkerCompleted(null, null);

           }

       } 


//以下是完整的ProcessOperator类代码：

/*

 * author:Joey Zhao

 * date:2010-11-30 

 * describe:进度条，该类可以在后台线程处理一些费时操作，并显示进度条，进度条并未真实显示数据进度

 * 仅仅是告诉用户程序还活着，有待加强。使用方法：

 * 1, 实例化一个ProcessOperator对象；

 * 2，赋值BackgroundWork（类型为一个无参数无返回值的委托）属性为要在后台执行的方法（无参数无返回值的方法）

 * 3，调用Start方法开始执行

 * 4, 在事件BackgroundWorkerCompleted中执行后台任务完成后的操作

 */

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.ComponentModel;

 

namespace Sasp.Client.PublicUnits.Process

{

    public class ProcessOperator

    {

        private BackgroundWorker _backgroundWorker;//后台线程

        private ProcessForm _processForm;//进度条窗体

 

        public ProcessOperator()

        {

            _backgroundWorker = new BackgroundWorker();

            _processForm = new ProcessForm();

            _backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);

            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backgroundWorker_RunWorkerCompleted);

        }

 

        //操作进行完毕后关闭进度条窗体

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            if (_processForm.Visible == true)

            {

                _processForm.Close();

            }

            if (this.BackgroundWorkerCompleted != null)

            {

                this.BackgroundWorkerCompleted(null, null);

            }

        }

 

        //后台执行的操作

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)

        {

            if (BackgroundWork != null)

            {

                BackgroundWork();

            }

        }

 

        #region 公共方法、属性、事件

 

        /// <summary>

        /// 后台执行的操作

        /// </summary>

        public Action BackgroundWork { get; set; }

 

        /// <summary>

        /// 设置进度条显示的提示信息

        /// </summary>

        public string MessageInfo 

        {

            set { _processForm.MessageInfo = value; }

        }

 

        /// <summary>

        /// 后台任务执行完毕后事件

        /// </summary>

        public event EventHandler<EventArgs> BackgroundWorkerCompleted;

 

        /// <summary>

        /// 开始执行

        /// </summary>

        public void Start()

        {

            _backgroundWorker.RunWorkerAsync();

            _processForm.ShowDialog();

        } 

        #endregion

    }

} 

//第2步：客户端代码调用

PercentProcessOperator p = new PercentProcessOperator();

          p.BackgroundWork = this.LoadData;

          p.BackgroundWorkerCompleted += new EventHandler<EventArgs>(p_BackgroundWorkerCompleted);

          p.Start(); 


//扩展：实时报告后台处理进度
//将_backgroundWorker的属性WorkerReportsProgress设置为ture；这样就可以添加backgroundWorker的ProgressChanged事件了（该事件在调用方法_backgroundWorker.ReportProgress（int p）时触发。

//显示进度

        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)

        {

            _processForm.MessageInfo = "已完成："+e.ProgressPercentage.ToString()+"%";

            _processForm.ProcessValue = e.ProgressPercentage;

        } 


//_backgroundWorker.ReportProgress（int p）方法应该是在后台执行操作中调用，只有后台执行的操作才知道自己的完成进度。可以使用一个委托参数，客户端代码调用该委托设置进度，而该委托指向的方法设置为_backgroundWorker.ReportProgress（int p）即可。以下代码是带有进度预报的实现：

/*

 * author:Joey Zhao

 * date:2010-12-1

 * describe:带百分比的进度条,使用方法：

 * 1, 实例化一个ProcessOperator对象；

 * 2，赋值BackgroundWork（类型为一个参数，无返回值的委托，其中参数是一个具有一个int类型参数无返回值的委托，用来预报进度）属性为要在后台执行的方法，详见TestForm中的示例

 * 3，调用Start方法开始执行

 * 4, 在事件BackgroundWorkerCompleted中执行后台任务完成后的操作

 */

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.ComponentModel;

 

namespace Sasp.Client.PublicUnits.Process

{

    public class PercentProcessOperator

    {

        private BackgroundWorker _backgroundWorker;//后台线程

        private ProcessForm _processForm;//进度条窗体

 

        public PercentProcessOperator()

        {

            _processForm = new ProcessForm();

            _processForm.ProcessStyle = System.Windows.Forms.ProgressBarStyle.Continuous;

            _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.WorkerReportsProgress = true;

            _backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);

            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backgroundWorker_RunWorkerCompleted);

            _backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(_backgroundWorker_ProgressChanged);

        }

 

        //显示进度

        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)

        {

            _processForm.MessageInfo = "已完成："+e.ProgressPercentage.ToString()+"%";

            _processForm.ProcessValue = e.ProgressPercentage;

        }

 

        //操作进行完毕后关闭进度条窗体

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            if (_processForm.Visible == true)

            {

                _processForm.Close();

            }

            if (this.BackgroundWorkerCompleted != null)

            {

                this.BackgroundWorkerCompleted(null, null);

            }

        }

 

        //后台执行的操作

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)

        {

            if (BackgroundWork != null)

            {

                BackgroundWork(this.ReportPercent);

            }

        }

         #region 公共方法、属性、事件

         /// <summary>

        /// <para>后台执行的操作,参数为一个参数为int型的委托；

        /// 在客户端要执行的后台方法中可以使用Action&lt;int&gt;预报完成进度,如：

        /// <example>

        /// <code>

        /// PercentProcessOperator o = new PercentProcessOperator();

        /// o.BackgroundWork = this.DoWord;

        /// 

        /// private void DoWork(Action&lt;int&gt; Report)

        /// {

        ///     Report(0);

        ///     //do soming;

        ///     Report(10);

        ///     //do soming;

        ///     Report(50);

        ///     //do soming

        ///     Report(100);

        /// }

        /// </code>

        /// </example></para>

        /// </summary>

        public Action<Action<int>> BackgroundWork { get; set; }

 

        /// <summary>

        /// 后台任务执行完毕后事件

        /// </summary>

        public event EventHandler<EventArgs> BackgroundWorkerCompleted;

 

        /// <summary>

        /// 开始执行

        /// </summary>

        public void Start()

        {

            _backgroundWorker.RunWorkerAsync();

            _processForm.ShowDialog();

        } 

        #endregion

        //报告完成百分比

        private void ReportPercent(int i)

        {

            if (i >=0 && i<=100)

            {

                _backgroundWorker.ReportProgress(i);

            }

        }

    }

}                        