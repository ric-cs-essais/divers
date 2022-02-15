using Infrastructure.Authentication;
using Infrastructure.Authentication.Factories;

using Infrastructure.Persistence.Database.Common.Interfaces;
using Infrastructure.Persistence.Database.Common.Abstracts;


namespace Infrastructure.Persistence.Database.Sql.Config.SqlServer
{
    public class UserCredentialsList : AConfigItemsList<UserCredentials>, IConfigItemsList<UserCredentials>
    {
        protected override void _fillList()
        {
            this._oList.Add(
                this._iDefaultId,
                this._getUserCredentials("SA2", "SS2019PSw")

            );
        }

        private UserCredentials _getUserCredentials(string psUserName, string psUserPassword)
        {
            return UserCredentialsFactory.getInstance(
                UserNameFactory.getInstance(psUserName),
                UserPasswordFactory.getInstance(psUserPassword)
            );

        }

    }
}
