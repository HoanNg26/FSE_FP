using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL
    {
        private string connectionString;

        public AccountDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }

            set
            {
                connectionString = value;
            }
        }

        public bool insert(AccountDTO acc)
        {
            string query = "";
            query += @" INSERT INTO [dbo].[account] ";
            query += @"            ([fullname] ";
            query += @"            ,[username] ";
            query += @"            ,[password] ";
            query += @"            ,[createddate]) ";
            query += @"      VALUES ";
            query += @"            (@fullname ";
            query += @"            ,@username ";
            query += @"            ,@password ";
            query += @"            ,@createddate) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@fullname", acc.Fullname);
                    command.Parameters.AddWithValue("@username", acc.Username);
                    command.Parameters.AddWithValue("@password", acc.Password);
                    command.Parameters.AddWithValue("@createddate", acc.CreatedDate);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        connection.Close();
                        return false;
                    }

                }
            }
            return true;
        }

        public bool update(AccountDTO acc)
        {
            string query = "";
            query += @" UPDATE [dbo].[account] ";
            query += @"    SET [fullname] = @fullname ";
            query += @"       ,[password] = @password ";
            query += @"       ,[createddate] = @createddate ";
            query += @"  WHERE ";
            query += @" 	[username] = @username ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@fullname", acc.Fullname);
                    command.Parameters.AddWithValue("@username", acc.Username);
                    command.Parameters.AddWithValue("@password", acc.Password);
                    command.Parameters.AddWithValue("@createddate", acc.CreatedDate);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        connection.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool delete(AccountDTO acc)
        {
            string query = "";
            query += @" DELETE FROM [dbo].[account] ";
            query += @"       WHERE [username] = @username ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@username", acc.Username);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        connection.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool selectAll(List<AccountDTO> listAccount)
        {
            string query = "";
            query += @" SELECT [fullname] ";
            query += @"       ,[username] ";
            query += @"       ,[password] ";
            query += @"       ,[createddate] ";
            query += @"   FROM [dbo].[account] ";

            using (SqlConnection connection = new SqlConnection(connectionString)){
                using (SqlCommand command = new SqlCommand()){

                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    try
                    {
                        connection.Open();
                        listAccount.Clear();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    AccountDTO acc = new AccountDTO();
                                    acc.Fullname = dr["fullname"].ToString();
                                    acc.Username = dr["username"].ToString();
                                    acc.Password = dr["password"].ToString();
                                    acc.CreatedDate = DateTime.Parse(dr["createddate"].ToString());
                                    listAccount.Add(acc);
                                }
                            }
                        }
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        connection.Close();
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
