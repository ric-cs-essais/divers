

namespace Infrastructure.Persistence.Database.Sql.Config.SqlServer.Factories
{
    public class ServerUrlsListFactory
    {
        private static ServerUrlsList _oServerUrlsList = null;

        public static ServerUrlsList getSingleton()
        {
            if (_oServerUrlsList == null)
            {
                _oServerUrlsList = new ServerUrlsList();
            }
            return (_oServerUrlsList);
        }

    }
}
