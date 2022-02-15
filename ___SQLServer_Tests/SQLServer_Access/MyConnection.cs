using System.Data.Common; //Pour DbDataReader
using System.Data.SqlClient; //Pour SqlConnection, SqlCommand, SqlParameter
using System.Data; //pour SqlDbType
using System; //Pour Convert

using System.Windows.Forms; //Pour MessageBox
    //A NOTER que pour pouvoir faire usage de Windows.Forms,
    // Il a fallu remplacer rdans le fichier projet :
    //    <TargetFramework>net5.0</TargetFramework> <!-- Pour autoriser la console -->
    // PAR :
    //    < TargetFramework > net5.0 - windows </ TargetFramework > <!-- Rem. : n'autorisera pas la console -->
    //    < UseWindowsForms > true </ UseWindowsForms >


using System.Collections.Generic; //List


namespace SQLServer_Access
{
    public class MyConnection
    {
        private SqlConnection sqlConnection = null;


        public void open() //<<< Pour que le type SqlConnection (et d'autres...) soient connus, il faut bien ajouter le Package NuGet "System.Data.SqlClient" au présent Projet
                           //    via le menu "Outils > Gestionnaire de packages NuGet", et là il ne faudra cocher l'inclusion que pour ce projet donc.
        {
            if (this.sqlConnection == null) {
                string sqlServerName = "PC-RP-VM-W10PRO\\SQL_SERVER_2019";
                string sqlServerUser = "SA2";
                string sqlServerUserPsw = "SS2019PSw";

                string sqlServerDatabase = "MY_TEST_DATABASE"; //Nom de la base de données visée pour cette connexion.

                string connectionString = string.Format(
                    "Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
                    sqlServerName, sqlServerDatabase, sqlServerUser, sqlServerUserPsw
                );

                this.sqlConnection = new SqlConnection(connectionString);
                this.sqlConnection.Open();
            }
        }

        public void close()
        {
            if (this.sqlConnection != null)
            {
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
        }

        public void selectQuery(string sqlSelectQuery)
        {
            SqlCommand sqlCommand = this.createSqlCommand(sqlSelectQuery);
            using (DbDataReader recordReader = sqlCommand.ExecuteReader())
            {
                if (recordReader.HasRows)
                {

                    while (recordReader.Read()) //Pour un enregistrement donné parmi ceux retournés
                    {
                        //--------------------------------- Lecture index(dans la requête) des champs retournés (idem pour chaque enreg. en fait!) ---------------
                        int idField_Index = recordReader.GetOrdinal("ID");  //0, car ID est la colonne 0 dans les champs que retournera la requête SELECT.
                        int nomField_Index = recordReader.GetOrdinal("NOM");  //1, car NOM est la colonne 1 dans les champs que retournera la requête SELECT.
                        int prenomField_Index = recordReader.GetOrdinal("PRENOM");  //2, car PRENOM est la colonne 2 dans les champs que retournera la requête SELECT.
                        int hommeField_Index = recordReader.GetOrdinal("Homme");  //3, car PRENOM est la colonne 3 dans les champs que retournera la requête SELECT.
                        int dateNaissanceField_Index = recordReader.GetOrdinal("DateNaiss");  //4, car PRENOM est la colonne 4 dans les champs que retournera la requête SELECT.
                        int dateHeureInscriptionField_Index = recordReader.GetOrdinal("DateHeureInscription");  //5, car PRENOM est la colonne 5 dans les champs que retournera la requête SELECT.
                        int chaineChar30_Field_Index = recordReader.GetOrdinal("Chaine_Char_30"); //...6
                        int chaineNChar30_Field_Index = recordReader.GetOrdinal("Chaine_NChar_30"); //...7
                        int chaineVarChar30_Field_Index = recordReader.GetOrdinal("Chaine_VarChar_30"); //...8
                        int chaineNVarChar30_Field_Index = recordReader.GetOrdinal("Chaine_NVarChar_30"); //...9


                        //------------------------ Lecture valeur des champs ---------
                        int id = Convert.ToInt32(recordReader.GetValue(idField_Index));
                        string nom = recordReader.GetString(nomField_Index);
                        string prenom = recordReader.GetString(prenomField_Index);
                        bool estHomme = recordReader.GetBoolean(hommeField_Index);

                        DateTime? dateNaissance = this.getNullableDateTime(recordReader, dateNaissanceField_Index);
                        DateTime? dateHeureInscription = this.getNullableDateTime(recordReader, dateHeureInscriptionField_Index);
                        string? sDateNaissance = (dateNaissance != null) ? ((DateTime)dateNaissance).ToString("dd/MM/yyyy") : null;
                        string? sDateHeureInscription = (dateHeureInscription != null) ? ((DateTime)dateHeureInscription).ToString("dd/MM/yyyy HH:mm:ss") : null;

                        string? chaineChar30 = (recordReader[chaineChar30_Field_Index] as string) ?? null; //"...[index] as string", pour le cas où le champ vaudrait NULL en base
                                                                                                             // (Rem.: cette syntaxe "as ..." pour gérer la lecture des NULL en base,
                                                                                                             //        ne fonctionne cependant pas sur un type non basique, comme DateTime).
                        string? chaineNChar30 = (recordReader[chaineNChar30_Field_Index] as string) ?? null;
                        string? chaineVarChar30 = (recordReader[chaineVarChar30_Field_Index] as string) ?? null;
                        string? chaineNVarChar30 = (recordReader[chaineNVarChar30_Field_Index] as string) ?? null;


                        //----- Formatage de l'affichage pour debug ---------------
                        List<string> aAfficher = new List<string>(){
                          string.Format("ID={0}", id),
                          string.Format("NOM='{0}'", nom),
                          string.Format("PRENOM='{0}'", prenom),
                          string.Format("Homme={0}", estHomme),
                          string.Format("DateNaiss={0}",  (sDateNaissance==null)? "null" : sDateNaissance),
                          string.Format("DateHeureInscription={0}", (sDateHeureInscription==null)? "null" : sDateHeureInscription),
                          string.Format("chaineChar30={0} {1}", (chaineChar30==null)? "null" : "'"+chaineChar30+"'", (chaineChar30==null)? "": "; Longueur brute: "+chaineChar30.Length),
                          string.Format("chaineNChar30={0} {1}", (chaineNChar30==null)? "null" : "'"+chaineNChar30+"'", (chaineNChar30==null)? "": "; Longueur brute: "+chaineNChar30.Length),
                          string.Format("chaineVarChar30={0} {1}", (chaineVarChar30==null)? "null" : "'"+chaineVarChar30+"'", (chaineVarChar30==null)? "": "; Longueur brute: "+chaineVarChar30.Length),
                          string.Format("chaineNVarChar30={0} {1}", (chaineNVarChar30==null)? "null" : "'"+chaineNVarChar30+"'", (chaineNVarChar30==null)? "": "; Longueur brute: "+chaineNVarChar30.Length),

                        };

                        //Affichage
                        MessageBox.Show(string.Join("\n", aAfficher));
                    }
                }
            }
        }

        //Insert avec requête en dur.
        public void insertQuery(string insertQuery)
        {
            SqlCommand sqlCommand = this.createSqlCommand(insertQuery);
            sqlCommand.ExecuteNonQuery();

        }

        //Insert avec requête paramétrée.
        public void insertQuery2(string insertQueryAvecParams)
        {
            SqlCommand sqlCommand = this.createSqlCommand(insertQueryAvecParams);

            this.addSqlParameter(sqlCommand, "LeNom", SqlDbType.VarChar).Value = "POULIGNACK";
            this.addSqlParameter(sqlCommand, "LePrenom", SqlDbType.VarChar).Value = "Bernard";
            this.addSqlParameter(sqlCommand, "MyBoolHomme", SqlDbType.Bit).Value = true;
            this.addSqlParameter(sqlCommand, "DtNaiss", SqlDbType.Date).Value = "16/04/1952";
            this.addSqlParameter(sqlCommand, "DtHInsc", SqlDbType.DateTime).Value = "16/04/1972 14:29:32";
            this.addSqlParameter(sqlCommand, "CC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.1"; //Je dirais : peu importe SqlDbType.VarChar ou SqlDbType.NVarChar, SqlDbType.NChar, ou SqlDbType.Char
            this.addSqlParameter(sqlCommand, "CNC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.2";
            this.addSqlParameter(sqlCommand, "CVC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.3";
            this.addSqlParameter(sqlCommand, "CNVC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.4";

            sqlCommand.ExecuteNonQuery();
        }

        //Insert avec champs non renseignés, et requête paramétrée.
        public void insertQuery3(string insertQueryAvecParams)
        {
            SqlCommand sqlCommand = this.createSqlCommand(insertQueryAvecParams);

            this.addSqlParameter(sqlCommand, "LeNom", SqlDbType.VarChar).Value = "POULIGNACK";
            this.addSqlParameter(sqlCommand, "LePrenom", SqlDbType.VarChar).Value = "Bernardine";
            this.addSqlParameter(sqlCommand, "MyBoolHomme", SqlDbType.Bit).Value = true;
            //this.addSqlParameter(sqlCommand, "DtNaiss", SqlDbType.Date).Value = "16/04/1952"; //Puisque le champ n'est pas renseigné, il sera NULL en base, si la table l'autorise bien sûr
            //this.addSqlParameter(sqlCommand, "DtHInsc", SqlDbType.DateTime).Value = "16/04/1972 14:29:32"; //Puisque le champ n'est pas renseigné, il sera NULL en base, si la table l'autorise bien sûr
            this.addSqlParameter(sqlCommand, "CC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.1";
            this.addSqlParameter(sqlCommand, "CNC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.2";
            this.addSqlParameter(sqlCommand, "CVC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.3";
            this.addSqlParameter(sqlCommand, "CNVC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.4";



            sqlCommand.ExecuteNonQuery();
        }

        //Insert avec récup. inserted ID, et requête paramétrée.
        public void insertQuery4(string insertQueryAvecParams)
        {
            SqlCommand sqlCommand = this.createSqlCommand(insertQueryAvecParams);

            this.addSqlParameter(sqlCommand, "LeNom", SqlDbType.VarChar).Value = "POULIGNACK";
            this.addSqlParameter(sqlCommand, "LePrenom", SqlDbType.VarChar).Value = "Bernardinette";
            this.addSqlParameter(sqlCommand, "MyBoolHomme", SqlDbType.Bit).Value = false;
            this.addSqlParameter(sqlCommand, "DtNaiss", SqlDbType.Date).Value = "16/04/1952"; //Puisque le champ n'est pas renseigné, il sera NULL en base, si la table l'autorise bien sûr
            this.addSqlParameter(sqlCommand, "DtHInsc", SqlDbType.DateTime).Value = "16/04/1972 14:29:32"; //Puisque le champ n'est pas renseigné, il sera NULL en base, si la table l'autorise bien sûr
            this.addSqlParameter(sqlCommand, "CC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.1";
            this.addSqlParameter(sqlCommand, "CNC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.2";
            this.addSqlParameter(sqlCommand, "CVC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.3";
            this.addSqlParameter(sqlCommand, "CNVC30", SqlDbType.VarChar).Value = "é.à.€.œ.ë.4";



            int insertedID = (int)sqlCommand.ExecuteScalar(); //<<<<< RECUP de l' inserted ID !!!! Bien sûr, avec "OUTPUT INSERTED.ID" dans la requête Sql
                                                              // où "ID" est le nom du champ auto-increment.
            MessageBox.Show("Inserted ID = "+ insertedID);

        }


        //Update avec requête paramétrée.
        public void updateQuery(string updateQueryAvecParams)
        {
            SqlCommand sqlCommand = this.createSqlCommand(updateQueryAvecParams);

            this.addSqlParameter(sqlCommand, "HommeFemme", SqlDbType.Bit).Value = false;
            this.addSqlParameter(sqlCommand, "CC30", SqlDbType.VarChar).Value = "nimporte";
            this.addSqlParameter(sqlCommand, "FiltrePrenom", SqlDbType.VarChar).Value = "Bernardine%";

            int nbAffectedRows = sqlCommand.ExecuteNonQuery();
            MessageBox.Show("UPDATE Nb. affected rows = " + nbAffectedRows);
        }



        //Delete avec requête paramétrée.
        public void deleteQuery(string deleteQueryAvecParams)
        {
            
            SqlCommand sqlCommand = this.createSqlCommand(deleteQueryAvecParams);

            this.addSqlParameter(sqlCommand, "FiltrePrenom", SqlDbType.VarChar).Value = "Bernard";
            this.addSqlParameter(sqlCommand, "FiltreNOM", SqlDbType.VarChar).Value = "POULIGNACK";

            int nbDeletedRows = sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Nb. deleted rows = " + nbDeletedRows);
        }


        //-----------------------------------------------------------------------------------------------------------
        private SqlParameter addSqlParameter(SqlCommand sqlCommand, string psParameterId, SqlDbType dataType)
        {
            SqlParameter sqlParameter = new SqlParameter("@"+ psParameterId, dataType);
            sqlCommand.Parameters.Add(sqlParameter);
            return (sqlParameter);
        }

        private SqlCommand createSqlCommand(string sqlQuery)
        {
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, this.sqlConnection);
            return (sqlCommand);
        }

        private DateTime? getNullableDateTime(DbDataReader recordReader, int dateField_Index)
        {
            DateTime? retour = (recordReader.IsDBNull(dateField_Index)) ? null : recordReader.GetDateTime(dateField_Index);
            return (retour);
        }

    }
}
