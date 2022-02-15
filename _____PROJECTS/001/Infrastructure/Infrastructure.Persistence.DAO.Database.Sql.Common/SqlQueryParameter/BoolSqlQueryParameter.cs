
using Infrastructure.Persistence.DAO.Database.Sql.Common.SqlQueryParameter.Abstracts;

namespace Infrastructure.Persistence.DAO.Database.Sql.Common.SqlQueryParameter
{
    public class BoolSqlQueryParameter : ASqlQueryParameter<bool>
    {
        public BoolSqlQueryParameter(string psKey) : base(psKey) { }
        public BoolSqlQueryParameter(string psKey, bool pValue) : base(psKey, pValue) { }

        public override FieldType getType()
        {
            return FieldType.boolean;
        }
    }
}
