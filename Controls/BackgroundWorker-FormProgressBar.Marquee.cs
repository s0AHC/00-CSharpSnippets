///.net Framework 2.0版本以上支持此控件    
///命名空间：  
System.ComponentModel  
  
///此控件一般是用来实现“多线程”操作，解决了UI界面处于停止响应的状态。   
///此控件可以视图支持，也可以像编程那样来创建它  
BackgroundWorker worker = new BackgroundWorker();
  
///注意几个重要的事件处理程序(Event)：    
///1. 事件处理程序   
DoWorkEventHandler(object sender , DoWorkerEventArgs e);   
     
///2. 若要收到进度更新通知,请使用  
ProgressChangedEventHandler(object sender , ProgressChangedEventArgs e);  
  
///3. 若要在操作完成时收到通知,请使用   
RunWorkerCompletedeventHandler(object sender , RunWorkerEventArgs e);  
  
///加两个方法(Method):  
///开始执行后台操作  
RrunWorkerAsync();   
  
///请求取消挂起的后台操作  
CancelAsync();   
  
  
/// 功能 backgroundworder + progressbar 控件实现进度条功能  
  
/// button1_Click  
private void button1_Click(object sender, EventArgs e)  
{  
  
frmProcessBar frmPB = new frmProcessBar();  
frmPB.Show();         //这里使用的是拖动控件形式来实现。也可以用创建形式来实现
 
///添加一个事件处理程序  
this.backgroundworker1.DoWorker += new DoWorkerEventHandler(DoWorker);  
///再添加一个事件处理程序（这里是实现您的功能，我这里是向数据库里添加数据）  
this.backgroudworker1.DoWorker += DoWorkerEventHandler(InsertDataWorker);  
///添加一个显示进度条的事件  
this.backgroundworker.ProgressChanged += new ProgressEventHandler(frmPB.ProgressChanged);  //frmPB.ProgressChanged 是显示进度条Method  
///后台已操作完成，关闭frmPB窗体  
this.backgroundworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(frmPB.CloseForm); // frmPB.CloseForm()调用关闭F2窗体  
///开始执行后台操作  
this.backgroundworker.RunWorkerAsyuc();  
         }  
///  
private void DoWorker(object sender , DoWorkEvnetArgs e)  
{  
e.Result = (WorkTimer(this.backgroundworker1,e));  
}  
/// 这里写您要实现的功能，我这里是向数据库添加数据  
private void InsertDataWork(object sender , DoWorkEventArgs e)  
{  
// do something...  
}  
/// <summary>  
        /// 设置进度条显示长度  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        /// PCount 是设置F2窗体里的progressbar控件里的Maximum的值  
        private int WorkTimer(object sender, DoWorkEventArgs e)  
        {  
            for (int i = 0; i < PCount; i++)  
            {  
                if (this.backgroundWorker1.CancellationPending)  
                {  
                    e.Cancel = true;  
                    return -1;  
                }  
                else  
                {  
                    this.backgroundWorker1.ReportProgress(i);  
                }  
                ///   将当前线程挂起指定的时间  
                System.Threading.Thread.Sleep(100);  
            }  
            return -1;  
        }  
  
  
////frmProcessBar里代码  
  
public partial class frmProcessBar : Form  
    {  
        public void ProcessbarForm()  
        {  
            InitializeComponent();  
        }  
        /// <summary>  
        /// 关闭进度条显示窗体  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        public void CloseForm(object sender, RunWorkerCompletedEventArgs e)  
        {  
            this.Close();  
        }  
        /// <summary>  
        /// 显示进度条  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        public void ProgessChanged(object sender, ProgressChangedEventArgs e)  
        {  
            this.progressBar1.Style = ProgressBarStyle.Continuous;  
            this.progressBar1.Value = e.ProgressPercentage;  
        }  
    } 