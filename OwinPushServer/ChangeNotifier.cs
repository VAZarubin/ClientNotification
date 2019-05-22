using Flurl.Http;

namespace OwinPushServer
{
    public class ChangeNotifier : IChangeNotifier
    {
        private readonly ISubscriberHolder subscriberHolder;

        public ChangeNotifier(ISubscriberHolder subscriberHolder)
        {
            this.subscriberHolder = subscriberHolder;
        }


        public void NotifyClients(int temp)
        {
            foreach (var sub in subscriberHolder.GetSubscribers)
                $"{sub}/temp/current".PostJsonAsync(new TempChange(temp));
        }
    }
}