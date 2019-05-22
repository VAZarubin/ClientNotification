using Microsoft.AspNet.SignalR;

namespace SignalRServer
{
    public class TempHub : Hub<IClient>
    {
        public static int temp = 25;

        public void Up()
        {
            temp++;
            Clients.All.CurrentTemp(temp);
        }

        public void Down()
        {
            temp--;
            Clients.All.CurrentTemp(temp);
        }
    }
}