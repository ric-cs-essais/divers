using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.DAO.Database.Sql.Common
{
    public class FieldDefinition
    {
        public uint Id { get; }
        public string Name { get; }
        public FieldType Type { get; }

        FieldDefinition(uint piId, string psName, FieldType pFieldType)
        {
            this.Id = piId;
            this.Name = psName;
            this.Type = pFieldType;
        }
    }
}
