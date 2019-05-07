using System.Web.Http;

namespace TemperatureServer
{
    public class TempController : ApiController
    {
        #region Static and Readonly Fields

        private readonly ITempHolder tempHolder;

        #endregion

        #region Constructors

        public TempController(ITempHolder tempHolder)
        {
            this.tempHolder = tempHolder;
        }

        #endregion

        #region Methods

        [HttpPost]
        public void Down()
        {
            tempHolder.Down();
        }

        [HttpGet]
        public int Current()
        {
            return tempHolder.Temp;
        }

        [HttpPost]
        public void Up()
        {
            tempHolder.Up();
        }

        #endregion
    }
}
