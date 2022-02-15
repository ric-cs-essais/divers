

namespace Infrastructure.Persistence.Database.Sql.Config.SqlServer.Factories
{
    public class UserCredentialsListFactory
    {
        private static UserCredentialsList _oUserCredentialsList = null;

        public static UserCredentialsList getSingleton()
        {
            if (_oUserCredentialsList == null)
            {
                _oUserCredentialsList = new UserCredentialsList();
            }
            return (_oUserCredentialsList);
        }

    }
}
