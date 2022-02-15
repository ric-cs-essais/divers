

namespace Infrastructure.Server
{
    public class ServerUrl
    {
        private string _sValue;

        public string Value { get { return this._sValue; } private set { this._sValue = value; } }
        public ServerUrl(string psValue)
        {
            this._setValue(psValue);

        }

        private void _setValue(string psValue)
        {
            this.Value = psValue;
        }

    }
}
