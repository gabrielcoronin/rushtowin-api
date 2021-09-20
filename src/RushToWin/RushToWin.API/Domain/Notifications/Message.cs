namespace RushToWin.Domain.Notifications
{
    public class Message
    {
        public Message(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}
