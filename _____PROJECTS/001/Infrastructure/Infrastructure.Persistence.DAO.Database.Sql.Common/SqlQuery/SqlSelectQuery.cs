using System.Collections.Generic;

using Transverse.Functions.Delegates;

namespace Infrastructure.Persistence.DAO.Database.Sql.Common.SqlQuery
{
    public class SqlSelectQuery
    {
        public string Text;
        public SimpleFunctionCall fOnStartRecord;
        public IReadOnlyCollection<FieldAffectation> oFieldsAffectionOrderedList;
        public SimpleFunctionCall fOnEndRecord;
    }
}
