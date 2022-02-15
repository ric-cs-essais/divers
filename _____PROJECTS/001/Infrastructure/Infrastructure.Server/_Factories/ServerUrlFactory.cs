
namespace Infrastructure.Server.Factories
{
    public class ServerUrlFactory
    {
        public static ServerUrl getInstance(string psServerUrl)
        {
            return new ServerUrl(psServerUrl);
        }
    }

}
