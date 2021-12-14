using CaseStudy.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.DAL
{
    class CountryRepository : SqlLiteBaseRepository
    {
        public CountryRepository()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
        }

        public int InsertCountry(Covid covid)
        {
            string sql = "INSERT INTO Covid (Code) Values (@Code);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, covid);
            }
        }
    }
}
