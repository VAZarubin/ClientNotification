namespace MessageProducer
{
    public class TempChangeNotifier : ITempChangerNotifier
    {
        private readonly IMessageSender messageSender;

        public TempChangeNotifier(IMessageSender messageSender)
        {
            this.messageSender = messageSender;
        }

        public void NotifyTempChange(int temp)
        {
            messageSender.SendMessage(temp.ToString());
        }
    }
}