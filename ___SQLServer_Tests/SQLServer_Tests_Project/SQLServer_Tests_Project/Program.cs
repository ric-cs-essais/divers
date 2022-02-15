using SQLServer_Access;
using System.Windows.Forms;
using System; //Pour Exception


namespace SQLServer_Tests_Project
{
    class Program
    {
        static void Main(string[] args)
        {

            MyConnection mySqlServerConnection = new MyConnection();

            try
            {
                mySqlServerConnection.open();

                //------- INSERTS -----------------
                /*mySqlServerConnection.insertQuery( //Fonctionne très bien
                    "INSERT INTO dbo.Personnes (NOM, PRENOM, Homme, DateNaiss, DateHeureInscription, Chaine_Char_30, Chaine_NChar_30, Chaine_VarChar_30, Chaine_NVarChar_30)"+
                    " VALUES ('POULIGNAC', 'Raymond', 'true', '14/03/1950', '18/08/2012 14:35:20', 'é.à.€.œ', 'é.à.€.œ', 'é.à.€.œ', 'é.à.€.œ');"
                   //ATTENTION : chaînes à mettre mettre quotes et non entre guillemets !!! <<<
                   //Et pour les booléens, on peut mettre une chaîne entre quote : 'false' ou 'true'.
                );*/
                //mySqlServerConnection.insertQuery2( //Fonctionne très bien
                //    "INSERT INTO dbo.Personnes (NOM, PRENOM, Homme, DateNaiss, DateHeureInscription, Chaine_Char_30, Chaine_NChar_30, Chaine_VarChar_30, Chaine_NVarChar_30)"+
                //    " VALUES (@LeNom, @LePrenom, @MyBoolHomme, @DtNaiss, @DtHInsc, @CC30, @CNC30, @CVC30, @CNVC30);"
                //);
                //mySqlServerConnection.insertQuery3( //Fonctionne très bien
                //    "INSERT INTO dbo.Personnes (NOM, PRENOM, Homme, Chaine_Char_30, Chaine_NChar_30, Chaine_VarChar_30, Chaine_NVarChar_30)" +
                //    " VALUES (@LeNom, @LePrenom, @MyBoolHomme, @CC30, @CNC30, @CVC30, @CNVC30);"  //<<< Le symbole "@" est à utiliser impérativement lors d'une requête paramétrable comme celle-ci.
                //);

                //mySqlServerConnection.insertQuery4( //Fonctionne très bien, avec récup. du champ "ID" auto-increment, pour l'enreg. inséré. *******
                //    "INSERT INTO dbo.Personnes (NOM, PRENOM, Homme, Chaine_Char_30, Chaine_NChar_30, Chaine_VarChar_30, Chaine_NVarChar_30)" +
                //    " OUTPUT INSERTED.ID VALUES (@LeNom, @LePrenom, @MyBoolHomme, @CC30, @CNC30, @CVC30, @CNVC30);"  //<<< Le symbole "@" est à utiliser impérativement lors d'une requête paramétrable comme celle-ci.
                //);

            //------- UPDATEs -----------------
                //mySqlServerConnection.updateQuery( //Fonctionne très bien
                //    "UPDATE dbo.Personnes SET Homme=@HommeFemme, Chaine_Char_30=@CC30 Where PRENOM like @FiltrePrenom;"
                //);

            //------- DELETE -----------------
            mySqlServerConnection.deleteQuery( //Fonctionne très bien
                "DELETE FROM dbo.Personnes Where NOM like @FiltreNOM AND PRENOM like @FiltrePrenom;"
            );

            //---------- SELECT -----------------
            mySqlServerConnection.selectQuery("SELECT * FROM dbo.Personnes");


            }
            catch (Exception error)
            {
                MessageBox.Show("Erreur: " + error);
                MessageBox.Show(error.StackTrace);
            }
            finally
            {
                mySqlServerConnection.close();
            }

        }

    }
}