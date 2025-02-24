public delegate void EventHandler(string message);


class Publisher
{
    public event EventHandler OnEvent;

    public void RaiseEvent()
    {
        OnEvent?.Invoke("Event Raised!");
    }

}

