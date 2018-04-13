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
    public class DaoChamp
    {
        public static void saveChamps(List<Champ> liste)
        {
            SqlCommand cmd = null ;
            try
            {
                int result = 0;
                String req = "saveChamp";
                cmd = new SqlCommand();
                cmd.Connection = DaoBD.MyConnection;
                cmd.CommandText = req;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection.Open();

                foreach (Champ c in liste)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@idchamp", SqlDbType.Int);
                    cmd.Parameters["@idchamp"].Value = c.idchamp;

                    cmd.Parameters.Add("@libelle", SqlDbType.VarChar);
                    cmd.Parameters["@libelle"].Value = c.libelle;

                    result = cmd.ExecuteNonQuery();
                }

                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                if (cmd != null && cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }

        public static List<Champ> GetChamps()
        {
            SqlCommand cmd = null;
            List<Champ> liste = null;

            try
            {                
                string req = "GetChamps";
                cmd = new SqlCommand();
                cmd.Connection = DaoBD.MyConnection;
                cmd.CommandText = req;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection.Open();

                SqlDataReader rs = cmd.ExecuteReader();

                liste = new List<Champ>();

                while (rs.Read())
                {
                    liste.Add(new Champ()
                    {
                        idchamp = rs.GetInt32(0),
                        libelle = rs.GetString(1)
                    });
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

            return liste;
        }

    }
}
