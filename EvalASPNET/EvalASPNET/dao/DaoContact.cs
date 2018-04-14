using EvalASPNET.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EvalASPNET.dao
{
    public class DaoContact
    {
        public static bool saveContacts(List<Donnee> liste)
        {
            SqlCommand cmd = null;
            try
            {
                int result = 0;
                String req = "SaveContact";
                cmd = new SqlCommand();
                cmd.Connection = DaoBD.MyConnection;
                cmd.CommandText = req;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection.Open();
                
                foreach (Donnee d in liste)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@idcontact", SqlDbType.Int);
                    cmd.Parameters["@idcontact"].Value = d.idcontact;

                    cmd.Parameters.Add("@iduser", SqlDbType.Int);
                    cmd.Parameters["@iduser"].Value = d.iduser;

                    cmd.Parameters.Add("@libellechamp", SqlDbType.VarChar);
                    cmd.Parameters["@libellechamp"].Value = d.libelleChamp;

                    cmd.Parameters.Add("@valeur", SqlDbType.VarChar);
                    cmd.Parameters["@valeur"].Value = d.valeur;

                    result = cmd.ExecuteNonQuery();
                }
                
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                if (cmd != null && cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
                return false;
            }
        }
      
        public static bool deleteContactByIDUser(int userid)
        {
            SqlCommand cmd = null;
            try
            {
                int result = 0;
                String req = "deleteContact";
                cmd = new SqlCommand();
                cmd.Connection = DaoBD.MyConnection;
                cmd.CommandText = req;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection.Open();

                cmd.Parameters.Add("@iduser", SqlDbType.Int);
                cmd.Parameters["@iduser"].Value = userid;
                result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                if (cmd != null && cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
                return false;
            }
        }

        public static bool deleteContactByID(int idcontact)
        {
            SqlCommand cmd = null;
            try
            {
                int result = 0;
                String req = "deleteContactByID";
                cmd = new SqlCommand();
                cmd.Connection = DaoBD.MyConnection;
                cmd.CommandText = req;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection.Open();

                cmd.Parameters.Add("@idcontact", SqlDbType.Int);
                cmd.Parameters["@idcontact"].Value = idcontact;
                result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                if (cmd != null && cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
                return false;
            }
        }
    }
}