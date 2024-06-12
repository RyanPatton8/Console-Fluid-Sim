public class OverFlowPublisher
{
    public delegate void OverFlowedEventHandler(object sender, EventArgs e);
    
    public event OverFlowedEventHandler OverFlowed;

    public void CallEvent()
    {
        OnOverFlowed();
    }

    protected virtual void OnOverFlowed()
    {
        if (OverFlowed != null)
        {
            OverFlowed(this, EventArgs.Empty);
        }
    }
}