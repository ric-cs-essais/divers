

namespace Infrastructure.Authentication.Factories
{
    public class UserNameFactory
    {
        public static UserName getInstance(string psUserName)
        {
            return new UserName(psUserName);
        }
    }

}
