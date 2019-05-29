using System.Threading.Tasks;
using System.Web.Http;

namespace LongPollingServer
{
    public class TempController : ApiController
    {
        private static readonly TempHolder tempHolder = new TempHolder();
        
        [HttpGet]
        public async Task<int> GetTemp()
        {
            int temp =  await tempHolder.TempChange;

            return temp;
        }

        [HttpGet]
        public void Up()
        {
            tempHolder.Temp++;
        }

        [HttpGet]
        public void Down()
        {
            tempHolder.Temp--;
        }
    }
}