namespace TemperatureServer
{
    public class TempHolder : ITempHolder
    {
        #region Constructors

        public TempHolder(int initValue)
        {
            Temp = initValue;
        }

        #endregion

        #region ITempHolder Members

        public int Temp { get; private set; }

        public void Down()
        {
            Temp--;
        }

        public void Up()
        {
            Temp++;
        }

        #endregion
    }
}
