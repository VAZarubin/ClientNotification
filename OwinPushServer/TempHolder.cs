namespace OwinPushServer
{
    public class TempHolder : ITempSetter
    {
        private readonly IChangeNotifier changeNotifier;

        private int temp = 25;

        public TempHolder(IChangeNotifier changeNotifier)
        {
            this.changeNotifier = changeNotifier;
        }

        public int Temp
        {
            get => temp;
            set
            {
                if (temp == value) return;

                temp = value;

                changeNotifier.NotifyClients(temp);
            }
        }
    }
}