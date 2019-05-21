namespace OwinPushServer
{
    public interface IChangeNotifier
    {
        void NotifyClients(int temp);
    }
}