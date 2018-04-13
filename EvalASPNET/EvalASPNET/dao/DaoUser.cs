using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using EvalASPNET.Entity;

namespace EvalASPNET.dao
{
    public class DaoUser
    {
        public static User findByLoginAndPassword(string login,string password)
        {
            SqlCommand cmd = null;
            User u=null;
            try
            {
                // String sql = "select iduser,login,password where login=@login and password=@password";
                string req = "GetUser";
                cmd = new SqlCommand();
                cmd.Connection = DaoBD.MyConnection;
                cmd.CommandText = req;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@login", SqlDbType.VarChar);
                cmd.Parameters["@login"].Value = login;
                cmd.Parameters.Add("@password", SqlDbType.VarChar);
                cmd.Parameters["@password"].Value = password;
                cmd.Connection.Open();

                SqlDataReader rs = cmd.ExecuteReader();

                while (rs.Read())
                {
                    u = new User() { iduser = rs.GetInt32(0), login = rs.GetString(1), password = rs.GetString(2) };                    
                }

                rs.Close();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                if (cmd != null && cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }

            return u;
        }

        public static int saveUser(User u)
        {
            int result=0;
            SqlCommand cmd = null;
            try
            {
                String req = "SaveUser";
                cmd = new SqlCommand();
                cmd.Connection = DaoBD.MyConnection;
                cmd.CommandText = req;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@iduser", SqlDbType.VarChar);
                cmd.Parameters["@iduser"].Value = u.iduser;


                cmd.Parameters.Add("@login", SqlDbType.VarChar);
                cmd.Parameters["@login"].Value = u.login;

                cmd.Parameters.Add("@password", SqlDbType.VarChar);
                cmd.Parameters["@password"].Value = u.password;
                cmd.Connection.Open();

                result = cmd.ExecuteNonQuery();
                
                cmd.Connection.Close();             
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                if (cmd != null && cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }

            return result;
        }
    
    }
}