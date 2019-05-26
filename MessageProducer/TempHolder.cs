namespace MessageProducer
{
    public class TempHolder : ITempHolder
    {
        private readonly ITempChangerNotifier tempChangerNotifier;
        private int currentTemp = 25;

        public TempHolder(ITempChangerNotifier tempChangerNotifier)
        {
            this.tempChangerNotifier = tempChangerNotifier;
        }


        public int CurrentTemp
        {
            get => currentTemp;
            private set

            {
                if (value == currentTemp) return;

                currentTemp = value;

                tempChangerNotifier.NotifyTempChange(currentTemp);
            }
        }

        public void Up()
        {
            CurrentTemp++;
        }

        public void Down()
        {
            CurrentTemp--;
        }
    }
}