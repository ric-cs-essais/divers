using Infrastructure.Server;
using Infrastructure.Server.Factories;

using Infrastructure.Persistence.Database.Common.Interfaces;
using Infrastructure.Persistence.Database.Common.Abstracts;


namespace Infrastructure.Persistence.Database.Sql.Config.SqlServer
{
    public class ServerUrlsList: AConfigItemsList<ServerUrl>, IConfigItemsList<ServerUrl>
    {
        protected override void _fillList()
        {
            this._oList.Add(
                this._iDefaultId, 
                ServerUrlFactory.getInstance("PC-RP-VM-W10PRO\\SQL_SERVER_2019")

            );
        }

    }
}
