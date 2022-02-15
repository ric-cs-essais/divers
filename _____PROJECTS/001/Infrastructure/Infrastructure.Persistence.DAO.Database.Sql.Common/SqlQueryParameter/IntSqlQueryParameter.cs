
using Infrastructure.Persistence.DAO.Database.Sql.Common.SqlQueryParameter.Abstracts;

namespace Infrastructure.Persistence.DAO.Database.Sql.Common.SqlQueryParameter
{
    public class IntSqlQueryParameter : ASqlQueryParameter<int>
    {
        public IntSqlQueryParameter(string psKey) : base(psKey) { }
        public IntSqlQueryParameter(string psKey, int pValue) : base(psKey, pValue) { }

        public override FieldType getType()
        {
            return FieldType.integer;
        }
    }
}
