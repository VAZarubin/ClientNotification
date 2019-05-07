namespace TemperatureServer
{
    public interface ITempHolder
    {
        #region Properties

        int Temp { get; }

        #endregion

        #region Methods

        void Down();

        void Up();

        #endregion
    }
}
