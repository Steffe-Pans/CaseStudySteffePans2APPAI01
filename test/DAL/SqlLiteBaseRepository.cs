using Dapper;
using Microsoft.Data.Sqlite;
using System.IO;

namespace CaseStudy.DAL
{
    class SqlLiteBaseRepository
    {
        public static SqliteConnection DbConnectionFactory()
        {
            return new SqliteConnection(@"DataSource=CovidDB.sqlite");

        }

        protected static bool DatabaseExists()
        {
            return File.Exists(@"CovidDB.sqlite");
        }

        protected static void CreateDatabase()
        {
            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                connection.Execute(
                    @"CREATE TABLE Covid (
                      Id INTEGER PRIMARY KEY AUTOINCREMENT,
                      Code VARCHAR(4)
                        )"
                    );
            }
        }

   }
}
