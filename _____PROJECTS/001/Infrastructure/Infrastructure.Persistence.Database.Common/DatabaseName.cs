

namespace Infrastructure.Persistence.Database.Common
{
    public class DatabaseName
    {
        private string _sValue;

        public string Value { get { return this._sValue; } private set { this._sValue = value; } }
        public DatabaseName(string psValue)
        {
            this._setValue(psValue);

        }

        private void _setValue(string psValue)
        {
            this.Value = psValue;
        }

    }
}
