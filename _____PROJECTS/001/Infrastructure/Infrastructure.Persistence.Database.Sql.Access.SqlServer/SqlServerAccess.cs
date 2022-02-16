using System.Data.Common; //Pour DbDataReader
using System.Data.SqlClient; //Pour SqlConnection, SqlCommand, SqlParameter
using System.Data; //pour SqlDbType
using System; //Pour Convert

using Infrastructure.Server;
using Infrastructure.Persistence.Database.Common;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Database.Sql.Access
{
    public class SqlServerAccess
    {
        private ServerAccess _oSeverAccess;
        private DatabaseName _oDefaultDatabaseName;
        private SqlConnection _oConnection = null;

        public SqlServerAccess(ServerAccess poSeverAccess, DatabaseName poDefaultDatabaseName)
        {
            this._setSeverAccess(poSeverAccess);
            this.setDefaultDatabaseName(poDefaultDatabaseName);

            //this._open(); this._close();
        }

        private void _setSeverAccess(ServerAccess poSeverAccess)
        {
            this._oSeverAccess = poSeverAccess;
        }
        public void setDefaultDatabaseName(DatabaseName poDefaultDatabaseName)
        {
            this._close();

            this._oDefaultDatabaseName = poDefaultDatabaseName;
        }

        private bool _isOpened()
        {
            return (this._oConnection?.State == ConnectionState.Open);
        }

        private void _open()
        {
            if (!this._isOpened())
            {
                string sConnectionString = this._getConnectionString();

                try
                {
                    this._oConnection = new SqlConnection(sConnectionString);
                    this._oConnection.Open();

                }
                catch (Exception oException)
                {
                    throw new Exception("Échec de la connexion SQL à : \n'" + sConnectionString + "'\n\n" + oException.Message + "\n\n");
                }

            }
        }
        private void _close()
        {
            if (this._isOpened())
            {
                this._oConnection.Close();
                this._oConnection.Dispose();
                this._oConnection = null;
            }
        }

        private string _getConnectionString()
        {
            string retour = string.Format(
                "Data Source={0};User ID={1};Password={2};Initial Catalog={3};",
                this._oSeverAccess.ServerUrl.Value,
                this._oSeverAccess.UserCredentials.UserName.Value,
                this._oSeverAccess.UserCredentials.UserPassword.Value,
                this._oDefaultDatabaseName.Value
            );

            //Console.WriteLine(retour);

            return (retour);
        }

        public void treatSqlSelectQuery(string psSqlSelectQuery, IReadOnlyCollection<SqlDbType> poReturnedColumnsType, Action<ushort, object> pfReadValue)
        {
            try
            {
                this._open();

                SqlCommand oSqlCommand = this._createSqlCommand(psSqlSelectQuery);
                this._readSqlQueryResult(oSqlCommand, poReturnedColumnsType, pfReadValue);

            }
            catch (Exception oException)
            {
                throw new Exception($"Erreur lors de la requête SQL '{psSqlSelectQuery}\n{oException.Message}");
            }
            finally
            {
                this._close();
            }
        }

        private void _readSqlQueryResult(SqlCommand poSqlCommand, IReadOnlyCollection<SqlDbType> poReturnedColumnsType, Action<ushort, object> pfReadValue)
        {
            using (DbDataReader oRecordReader = poSqlCommand.ExecuteReader())
            {
                if (oRecordReader.HasRows)
                {

                    while (oRecordReader.Read()) //Pour un enregistrement donné parmi ceux retournés
                    {
                        this._treatSqlSelectQueryResultRecord(oRecordReader, poReturnedColumnsType, pfReadValue);
                    }
                }
            }
        }

        private void _treatSqlSelectQueryResultRecord(DbDataReader oRecordReader, IReadOnlyCollection<SqlDbType> poReturnedColumnsType, Action<ushort, object> pfReadValue)
        {
            ushort iColumnIndex = 0;
            try
            {
                object fieldValue = null;
                foreach (SqlDbType pReturnedColumnType in poReturnedColumnsType) //Lecture des colonnes récupérées
                {
                    switch (pReturnedColumnType)
                    {
                        case SqlDbType.Int:
                            fieldValue = this._treatSqlSelectQueryResultRecordColumnAsInt(iColumnIndex, oRecordReader);
                            break;

                        case SqlDbType.Char:
                            fieldValue = this._treatSqlSelectQueryResultRecordColumnAsString(iColumnIndex, oRecordReader);
                            break;

                        case SqlDbType.Bit:
                            fieldValue = this._treatSqlSelectQueryResultRecordColumnAsBool(iColumnIndex, oRecordReader);
                            break;

                        case SqlDbType.Date:
                        case SqlDbType.DateTime:

                        default:
                            break;
                    }

                    pfReadValue(iColumnIndex, fieldValue);
                    //Console.WriteLine("\n");

                    iColumnIndex++;

                }
            }
            catch (Exception oException)
            {
                throw new Exception($"Erreur lors de la lecture de la colonne No {iColumnIndex} du résultat de la requête.\n{oException.Message}");
            }

            //Console.WriteLine("\n");
        }

        private int _treatSqlSelectQueryResultRecordColumnAsInt(ushort piColumnIndex, DbDataReader poRecordReader)
        {
            int iFieldValue = Convert.ToInt32(poRecordReader.GetValue(piColumnIndex));
            //Console.WriteLine($"Colonne No{piColumnIndex} ; Entier = {iFieldValue}");
            return (iFieldValue);
        }
        private string _treatSqlSelectQueryResultRecordColumnAsString(ushort piColumnIndex, DbDataReader poRecordReader)
        {
            string sFieldValue = poRecordReader.GetString(piColumnIndex);
            //Console.WriteLine($"Colonne No{piColumnIndex} ; Chaîne = {sFieldValue}");
            return (sFieldValue);
        }
        private bool _treatSqlSelectQueryResultRecordColumnAsBool(ushort piColumnIndex, DbDataReader poRecordReader)
        {
            bool bFieldValue = poRecordReader.GetBoolean(piColumnIndex);
            //Console.WriteLine($"Colonne No{piColumnIndex} ; Bool = {bFieldValue}");
            return (bFieldValue);
        }

        private SqlParameter _addSqlParameter(SqlCommand poSqlCommand, string psParameterId, SqlDbType pDataType)
        {
            SqlParameter oSqlParameter = new SqlParameter("@" + psParameterId, pDataType);
            poSqlCommand.Parameters.Add(oSqlParameter);
            return (oSqlParameter);
        }

        private SqlCommand _createSqlCommand(string psSqlQuery)
        {
            SqlCommand oSqlCommand = new SqlCommand(psSqlQuery, this._oConnection);
            return (oSqlCommand);
        }

        private DateTime? _getNullableDateTimeFromRecord(DbDataReader poRecordReader, int piRecordFieldIndex)
        {
            DateTime? retour = (poRecordReader.IsDBNull(piRecordFieldIndex)) ? null : poRecordReader.GetDateTime(piRecordFieldIndex);
            return (retour);
        }

    }
}
