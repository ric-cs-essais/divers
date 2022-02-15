

namespace Infrastructure.Authentication.Factories
{
    public class UserCredentialsFactory
    {
        public static UserCredentials getInstance(UserName poUserName, UserPassword poUserPassword)
        {
            return new UserCredentials(poUserName, poUserPassword);
        }
    }

}
