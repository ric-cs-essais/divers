

namespace Infrastructure.Persistence.DAO.Database.Sql.Common.SqlQueryParameter.Abstracts
{
    public abstract class ASqlQueryParameter<T>
    {
        public T Value { get; set; }
        public string Key { get; }

        public abstract FieldType getType();

        protected ASqlQueryParameter(string psKey)
        {
            this.Key = psKey;
        }

        protected ASqlQueryParameter(string psKey, T pValue): this(psKey)
        {
            this.Value = pValue;
        }

    }
}
