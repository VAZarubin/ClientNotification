using System.Web.Http;
using Flurl.Http;

namespace TemperatureServer
{
    public class TempController : ApiController
    {
        #region Static and Readonly Fields


        #endregion

        #region Constructors

        private static volatile int currentTemp = 25;
        
        #endregion

        #region Methods

        [HttpGet]
        public int Current()
        {
            return currentTemp;
        }

        [HttpPost]
        public void Down()
        {
            currentTemp--;
        }

        [HttpPost]
        public void Up()
        {
            currentTemp++;
        }

        #endregion
    }
}
