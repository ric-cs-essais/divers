using System;

using Infrastructure.Authentication;
using Infrastructure.Authentication.Factories;
using Infrastructure.Server;
using Infrastructure.Server.Factories;

using Infrastructure.Persistence.Database.Common;
using Infrastructure.Persistence.Database.Common.Factories;

using Infrastructure.Persistence.Database.Sql.Access;
using System.Collections.ObjectModel;
using System.Data;
using System.Collections.Generic;

namespace ConsoleTests
{
    enum Sexe
    {
        homme = 0,
        femme = 1
    }
    class Personne
    {
        public string nom;
        public string prenom;
        public Sexe sexe;
    }
    class Program
    {
        static (string, string, bool) oneRecord;
        static Personne oPersonne;

        static void Main(string[] args)
        {
            ServerUrl oServerUrl = ServerUrlFactory.getInstance("PC-RP-VM-W10PRO\\SQL_SERVER_2019");
            UserCredentials oUserCredentials = UserCredentialsFactory.getInstance(
                UserNameFactory.getInstance("SA2"),
                UserPasswordFactory.getInstance("SS2019PSw")
            );
            ServerAccess oServerAccess = ServerAccessFactory.getInstance(oServerUrl, oUserCredentials);
            DatabaseName oDatabaseName = DatabaseNameFactory.getInstance("MY_TEST_DATABASE");
            SqlServerAccess oSqlAccess = new SqlServerAccess(oServerAccess, oDatabaseName);

            //oSqlAccess.treatSqlSelectQuery(
            //    "SELECT NOM, PRENOM, Homme FROM dbo.Personnes ORDER BY PRENOM DESC;",
            //    new ReadOnlyCollection<SqlDbType>(new List<SqlDbType> { 
            //        SqlDbType.Char, SqlDbType.Char, SqlDbType.Bit
            //    })
            //);

            //(int, string) tuples;
            //tuples.[1]= 10;
            //tuples.Item2 = "";

            oPersonne = new Personne();

            Console.ReadKey();
        }

        static void catchValue(ushort piColumnIndex, string psValue)
        {
            oneRecord.Item1 = psValue;
            
        }

        static void catchValue(ushort piColumnIndex, int piValue)
        {

        }

        static void catchValue(ushort piColumnIndex, bool psValue)
        {

        }


    }
}
