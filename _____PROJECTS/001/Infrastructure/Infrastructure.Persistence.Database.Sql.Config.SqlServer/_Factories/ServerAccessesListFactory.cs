

namespace Infrastructure.Persistence.Database.Sql.Config.SqlServer.Factories
{
    public class ServerAccessesListFactory
    {
        private static ServerAccessesList _oServerAccessesList = null;

        public static ServerAccessesList getSingleton()
        {
            if (_oServerAccessesList == null)
            {
                _oServerAccessesList = new ServerAccessesList();
            }
            return (_oServerAccessesList);
        }

    }
}
