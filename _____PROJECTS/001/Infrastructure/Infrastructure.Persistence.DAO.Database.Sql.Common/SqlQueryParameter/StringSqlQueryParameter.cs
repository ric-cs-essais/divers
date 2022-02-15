
using Infrastructure.Persistence.DAO.Database.Sql.Common.SqlQueryParameter.Abstracts;

namespace Infrastructure.Persistence.DAO.Database.Sql.Common.SqlQueryParameter
{
    public class StringSqlQueryParameter : ASqlQueryParameter<string>
    {
        public StringSqlQueryParameter(string psKey) : base(psKey) { }
        public StringSqlQueryParameter(string psKey, string pValue) : base(psKey, pValue) { }

        public override FieldType getType()
        {
            return FieldType.str;
        }
    }
}
