using Infrastructure.Authentication;
using Infrastructure.Server;
using Infrastructure.Server.Factories;

using Infrastructure.Persistence.Database.Common.Interfaces;
using Infrastructure.Persistence.Database.Common.Abstracts;

using Infrastructure.Persistence.Database.Sql.Config.SqlServer.Factories;

namespace Infrastructure.Persistence.Database.Sql.Config.SqlServer
{
    public class ServerAccessesList: AConfigItemsList<ServerAccess>, IConfigItemsList<ServerAccess>
    {
        protected override void _fillList()
        {
            this._oList.Add(
                this._iDefaultId, 
                this._getServerAccess(
                    ServerUrlsListFactory.getSingleton().getDefault(),
                    UserCredentialsListFactory.getSingleton().getDefault()
                )

            );
        }

        private ServerAccess _getServerAccess(ServerUrl poServerUrl, UserCredentials poUserCredentials)
        {
            return ServerAccessFactory.getInstance(poServerUrl, poUserCredentials);

        }

    }
}
