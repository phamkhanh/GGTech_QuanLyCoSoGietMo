using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GGTech_DataAccessLayer
{
    public class SqlDataProvider
    {
        private static string _datasource = "ADMIN\\SQLEXPRESS2012";

        public string DataSource
        {
            get { return _datasource; }
            set { _datasource = value; }
        }

        private static string _database = "ThuVienDb";

        public string Database
        {
            get { return _database; }
            set { _database = value; }
        }

        private string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True; Connection Timeout=3", _datasource, _database); }
            set { _connectionString = value; }
        }

        private static SqlDataProvider instance; // Ctrl + R + E

        public static SqlDataProvider Instance
        {
            get { if (instance == null) instance = new SqlDataProvider(); return SqlDataProvider.instance; }
            private set { SqlDataProvider.instance = value; }
        }

        private SqlDataProvider()
        {
        }

        public bool CheckConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            string strItem = "";
                            if (item.Contains(','))
                            {
                                strItem = item.Trim(',');
                            }
                            else
                            {
                                strItem = item;
                            }
                            command.Parameters.AddWithValue(strItem, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            string strItem = "";
                            if (item.Contains(','))
                            {
                                strItem = item.Trim(',');
                            }
                            else
                            {
                                strItem = item;
                            }
                            command.Parameters.AddWithValue(strItem, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            string strItem = "";
                            if (item.Contains(','))
                            {
                                strItem = item.Trim(',');
                            }
                            else
                            {
                                strItem = item;
                            }
                            command.Parameters.AddWithValue(strItem, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
}