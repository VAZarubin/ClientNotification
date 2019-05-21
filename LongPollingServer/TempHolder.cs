using System.Threading.Tasks;

namespace LongPollingServer
{
    public class TempHolder
    {
        private int temp = 25;
        private TaskCompletionSource<int> tempHolder;

        public TempHolder()
        {
            tempHolder = new TaskCompletionSource<int>();
        }

        public Task<int> TempChange => tempHolder.Task;

        public int Temp
        {
            get => temp;
            set
            {
                if (temp == value) return;

                temp = value;

                tempHolder.SetResult(value);

                tempHolder = new TaskCompletionSource<int>();
            }
        }
    }
}