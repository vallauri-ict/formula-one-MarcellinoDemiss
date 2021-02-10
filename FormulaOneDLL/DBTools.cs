using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class DBTools
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"formulaOne.mdf;Integrated Security=True";

        public DataTable getTableData(string tablename)
        {
            DataTable dTable = new DataTable();
            using (SqlConnection dbConn = new SqlConnection())
            {
                String sql = $"SELECT * FROM " + tablename;
                dbConn.ConnectionString = CONNECTION_STRING;
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataAdapter dAdapter = new SqlDataAdapter(command))
                    {
                        dAdapter.Fill(dTable);
                    }
                }
            }
            return dTable;
        }

        public List<string> getTableName()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection(CONNECTION_STRING))
            {
                String sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return retVal;
        }

        public List<string> GetCountries()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\nQuery data example: ");
                Console.WriteLine("\n=========================================\n");
                String sql = "SELECT * FROM country";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string countryCode = reader.GetString(0);
                            string countryName = reader.GetString(1);
                            Console.WriteLine("{0} {1} ", countryCode, countryName);
                            retVal.Add(countryCode + " - " + countryName);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Country> GetCountriesObj()
        {
            List<Country> retVal = new List<Country>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                String sql = "SELECT * FROM country";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string countryCode = reader.GetString(0);
                            string countryName = reader.GetString(1);
                            Console.WriteLine("{0} {1} ", countryCode, countryName);
                            retVal.Add(new Country(countryCode, countryName));
                        }
                    }
                }
            }
            return retVal;
        }

        public Country GetCountry(string isoCode)
        {
            Country retVal = null;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                String sql = "SELECT * FROM country WHERE countryCode='" + isoCode + "';";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string countryCode = reader.GetString(0);
                            string countryName = reader.GetString(1);
                            Console.WriteLine("{0} {1} ", countryCode, countryName);
                            retVal = new Country(countryCode, countryName);
                        }
                    }
                }
            }
            return retVal;
        }
    }
}
