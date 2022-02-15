using Infrastructure.Authentication;

namespace Infrastructure.Server.Factories
{
    public class ServerAccessFactory
    {
        public static ServerAccess getInstance(ServerUrl posServerUrl, UserCredentials poUserCredentials)
        {
            return new ServerAccess(posServerUrl, poUserCredentials);
        }
    }

}
