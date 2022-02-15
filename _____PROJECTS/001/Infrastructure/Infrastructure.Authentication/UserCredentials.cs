

namespace Infrastructure.Authentication
{
    public class UserCredentials
    {
        private UserName _oUserName;
        private UserPassword _oUserPassword;

        public UserName UserName { get { return this._oUserName; } private set { this._oUserName = value; } }
        public UserPassword UserPassword { get { return this._oUserPassword; } private set { this._oUserPassword = value; } }
        public UserCredentials(UserName poUserName, UserPassword poUserPassword)
        {
            this._setUserName(poUserName);
            this._setUserPassword(poUserPassword);

        }

        private void _setUserName(UserName poUserName)
        {
            this.UserName = poUserName;
        }
        private void _setUserPassword(UserPassword poUserPassword)
        {
            this.UserPassword = poUserPassword;
        }
    }
}
