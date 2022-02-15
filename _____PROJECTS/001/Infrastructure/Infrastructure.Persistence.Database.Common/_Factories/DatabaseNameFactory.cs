

namespace Infrastructure.Persistence.Database.Common.Factories
{
    public class DatabaseNameFactory
    {
        public static DatabaseName getInstance(string psDatabaseName)
        {
            return new DatabaseName(psDatabaseName);
        }
    }

}
