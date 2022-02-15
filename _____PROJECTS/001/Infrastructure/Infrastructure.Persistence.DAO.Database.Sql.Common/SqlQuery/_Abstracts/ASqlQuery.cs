using Infrastructure.Persistence.DAO.Database.Sql.Common.SqlQueryParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.DAO.Database.Sql.Common.SqlQuery.Abstracts
{
    //public abstract class ASqlQuery
    public class ASqlQuery
    {
        public string AsRawString { get; }
        
        public IReadOnlyCollection<IntSqlQueryParameter> IntParametersList { get; private set; }
        public IReadOnlyCollection<StringSqlQueryParameter> StringParametersList { get; private set; }
        public IReadOnlyCollection<BoolSqlQueryParameter> BoolParametersList { get; private set; }

        private List<IntSqlQueryParameter> _oIntParametersList;
        private List<StringSqlQueryParameter> _oStringParametersList;
        private List<BoolSqlQueryParameter> _oBoolParametersList;

        //protected ASqlQuery(string psSqlQuery)
        public ASqlQuery(string psSqlQuery)
        {
            this.AsRawString = psSqlQuery;

            this._initLists();
        }

        private void _initLists()
        {
            this._oIntParametersList = new List<IntSqlQueryParameter>();
            this.IntParametersList = this._oIntParametersList.AsReadOnly();

            this._oStringParametersList = new List<StringSqlQueryParameter>();
            this.StringParametersList = this._oStringParametersList.AsReadOnly();

            this._oBoolParametersList = new List<BoolSqlQueryParameter>();
            this.BoolParametersList = this._oBoolParametersList.AsReadOnly();

        }

        public ASqlQuery setParameter(IntSqlQueryParameter poParameter)
        {
            this._oIntParametersList.Add(poParameter);
            return (this);
        }

        public ASqlQuery setParameter(StringSqlQueryParameter poParameter)
        {
            this._oStringParametersList.Add(poParameter);
            return (this);
        }

        public ASqlQuery setParameter(BoolSqlQueryParameter poParameter)
        {
            this._oBoolParametersList.Add(poParameter);
            return (this);
        }
    }
}
