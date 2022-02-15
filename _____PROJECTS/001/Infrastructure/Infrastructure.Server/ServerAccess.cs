using Infrastructure.Authentication;

namespace Infrastructure.Server
{
    public class ServerAccess
    {

        private ServerUrl _oServerUrl;
        private UserCredentials _oUserCredentials;

        public ServerUrl ServerUrl { get { return this._oServerUrl; }  set { this._oServerUrl = value; } }
        public UserCredentials UserCredentials { get { return this._oUserCredentials; }  set { this._oUserCredentials = value; } }
        public ServerAccess(ServerUrl poServerUrl, UserCredentials poUserCredentials)
        {
            this._setServerUrl(poServerUrl);
            this._seUserCredentials(poUserCredentials);

        }

        private void _setServerUrl(ServerUrl poServerUrl)
        {
            this.ServerUrl = poServerUrl;
        }
        private void _seUserCredentials(UserCredentials poUserCredentials)
        {
            this.UserCredentials = poUserCredentials;
        }
    }
}
