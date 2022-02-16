using System;


namespace Infrastructure.Persistence.DAO.Database.Sql.Common
{
    public class FieldAffectation
    {
        public FieldType FieldType;
        public Action<object> fAffectRecordField; //Type : Function dans val. de retour, et recevant en param. un type object (c-à-d n'importe quel type, même basique).
    }
}
