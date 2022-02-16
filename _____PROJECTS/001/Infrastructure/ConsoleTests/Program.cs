using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using Infrastructure.Authentication;
using Infrastructure.Authentication.Factories;
using Infrastructure.Server;
using Infrastructure.Server.Factories;

using Infrastructure.Persistence.Database.Common;
using Infrastructure.Persistence.Database.Common.Factories;

using Infrastructure.Persistence.Database.Sql.Access;

using Infrastructure.Persistence.DAO.Database.Sql.Common;
using Infrastructure.Persistence.DAO.Database.Sql.Common.SqlQuery;

namespace ConsoleTests
{
    enum Sexe
    {
        homme = 0,
        femme = 1
    }

    class Program
    {

        static string toString(object pFieldValue) //<<<<<<< A METTRE DANS Infrastructure.Persistence.DAO.Database.Sql.Common
        {
            return $"{((string)pFieldValue).Trim()}";
        }
        // ET passer les Field*.cs dans un dossier Field/


        class PersonneRecord
        {
            public string nom;
            public string prenom;
            public Sexe sexe;
        };


        static Sexe toSexe(object pFieldValue)
        {
            return ((bool)pFieldValue) ? Sexe.homme : Sexe.femme;
        }


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


            List<PersonneRecord> oPersonneRecords = new List<PersonneRecord>();
            PersonneRecord oPersonneRecord = null;

            new SqlSelectQuery
            {
                Text = "SELECT NOM, PRENOM, Homme FROM dbo.Personnes ORDER BY PRENOM DESC;",
                fOnStartRecord = () => { oPersonneRecord = new PersonneRecord(); },
                oFieldsAffectionOrderedList = new ReadOnlyCollection<FieldAffectation>(new List<FieldAffectation>
                {
                    new FieldAffectation {
                        FieldType = FieldType.str,
                        fAffectRecordField = (object pFieldValue) => { oPersonneRecord.nom = toString(pFieldValue); }
                    },
                    new FieldAffectation {
                        FieldType = FieldType.str,
                        fAffectRecordField = (object pFieldValue) => { oPersonneRecord.prenom = toString(pFieldValue); }
                    },
                    new FieldAffectation {
                        FieldType = FieldType.boolean,
                        fAffectRecordField = (object pFieldValue) => { oPersonneRecord.sexe = toSexe(pFieldValue); }
                    }
                }),
                fOnEndRecord = () => { oPersonneRecords.Add(oPersonneRecord); }
            };

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(oPersonneRecords));

            Console.ReadKey();
        }


    }
}
