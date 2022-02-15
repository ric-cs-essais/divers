using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.DAO.Database.Sql.Common
{
    public class TableDefinition
    {
        public uint Id { get; }
        public string Name { get; }
        public FieldDefinition AutoIncrFieldDefinition { get; private set; } = null;

        private Dictionary<uint, FieldDefinition> _oFields;
        private uint? _iAutoIncrFieldId;

        TableDefinition(uint piId, string psName, List<FieldDefinition> poFieldsDefinition, uint? piAutoIncrFieldId)
        {
            this.Id = piId;
            this.Name = psName;
            this._iAutoIncrFieldId = piAutoIncrFieldId ?? null;

            this._defineFieldsDefinitionMap(poFieldsDefinition);
            this._defineAutoIncrFieldDefinition();
        }

        private void _defineAutoIncrFieldDefinition()
        {
            if (this._iAutoIncrFieldId != null)
            {
                this.AutoIncrFieldDefinition = this.getFieldDefinition((uint)this._iAutoIncrFieldId);

            }
        }

        public FieldDefinition getFieldDefinition(uint piId)
        {
            FieldDefinition retour;
            try
            {
                retour = this._oFields[piId];

            }
            catch (KeyNotFoundException oException)
            {
                throw new Exception("Champ d'id '" + piId + "' inexistant:\n" + oException.Message);
            }
            return (retour);
        }

        private void _defineFieldsDefinitionMap(List<FieldDefinition> poFieldsDefinition)
        {
            this._oFields = new Dictionary<uint, FieldDefinition>();
            foreach (FieldDefinition oFieldDefinition in poFieldsDefinition)
            {
                this._oFields.Add(oFieldDefinition.Id, oFieldDefinition);
            }
        }
    }
}
