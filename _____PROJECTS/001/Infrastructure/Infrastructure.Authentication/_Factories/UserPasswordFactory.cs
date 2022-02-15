
namespace Infrastructure.Authentication.Factories
{
    public class UserPasswordFactory
    {
        public static UserPassword getInstance(string psUserPassword)
        {
            return new UserPassword(psUserPassword);
        }
    }

}
