public class OverFlowEventArgs : EventArgs
{
    public int xPosition { get; set; }
    public int yPosition { get; set; }
}

public class OverFlowPublisher
{
    public EventHandler<OverFlowEventArgs> OverFlowed;

    public void CallEvent(int desiredX, int desiredY)
    {
        OnOverFlowed(desiredX, desiredY);
    }

    protected virtual void OnOverFlowed(int desiredX, int desiredY)
    {
        if (OverFlowed != null)
        {
            OverFlowed(this, new OverFlowEventArgs() {
                xPosition = desiredX,
                yPosition = desiredY
            });
        }
    }
}