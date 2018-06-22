//Form of ProgressBar.Marquee 

class ProgressForm : Form
{
    public ProgressForm()
    {
        ControlBox = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterScreen;
        TopMost = true;
        FormBorderStyle = FormBorderStyle.None;
        var progreassBar = new ProgressBar() { Style = ProgressBarStyle.Marquee, 
            Size = new System.Drawing.Size(200, 20), 
            ForeColor = Color.Orange, MarqueeAnimationSpeed = 40 };
        Size = progreassBar.Size;
        Controls.Add(progreassBar);
    }
}

public class WaitIndicator : IDisposable
{
    ProgressForm progressForm;
    Thread thread;
    bool disposed = false; //to avoid redundant call
    public WaitIndicator()
    {
        progressForm = new ProgressForm();
        thread = new Thread(_ => progressForm.ShowDialog());
        thread.Start();
    }
 
    public void Dispose()
    {
        Dispose(true);
    }
 
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            thread.Abort();
            progressForm = null;
        }
        disposed = true;
    }
}
 




//调用方法：
using (new WaitIndicator())
{
    //code to process
}