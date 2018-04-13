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
    public class DaoDonnee
    {
        public static List<Donnee> findDonneesByidUser(int iduser)
        {
            SqlCommand cmd = null;
            List<Donnee> liste = null;
            try
            {
                //String sql = "select iddonnee,iduser,libellechamp,valeur where iduser=@iduser";
                string req = "GetDonnees";
                cmd = new SqlCommand();
                cmd.Connection = DaoBD.MyConnection;
                cmd.CommandText = req;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@iduser", SqlDbType.Int);
                cmd.Parameters["@iduser"].Value = iduser;

                cmd.Connection.Open();

                SqlDataReader rs = cmd.ExecuteReader();

                liste = new List<Donnee>();

                while (rs.Read())
                {
                    liste.Add(new Donnee() { iddonnee = rs.GetInt32(0), iduser = rs.GetInt32(1),idcontact=rs.GetInt32(2),
                                            libelleChamp = rs.GetString(3), valeur = rs.GetString(4)});
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

        public static bool saveDonnee(List<Donnee> liste)
        {
            SqlCommand cmd = null;
            try
            {
                int result = 0;
                String req = "SaveDonnee";
                cmd = new SqlCommand();
                cmd.Connection = DaoBD.MyConnection;
                cmd.CommandText = req;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection.Open();

                foreach (Donnee d in liste)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@iddonnee", SqlDbType.Int);
                    cmd.Parameters["@iddonnee"].Value = d.iddonnee;

                    cmd.Parameters.Add("@iduser", SqlDbType.Int);
                    cmd.Parameters["@iduser"].Value = d.iduser;

                    cmd.Parameters.Add("@idcontact", SqlDbType.Int);
                    cmd.Parameters["@idcontact"].Value = d.idcontact;

                    cmd.Parameters.Add("@libellechamp", SqlDbType.VarChar);
                    cmd.Parameters["@libellechamp"].Value = d.libelleChamp;

                    cmd.Parameters.Add("@valeur", SqlDbType.VarChar);
                    cmd.Parameters["@valeur"].Value = d.valeur;

                    cmd.Parameters.Add("@ordre", SqlDbType.Int);
                    cmd.Parameters["@ordre"].Value = d.ordre;

                    cmd.Parameters.Add("@accueil", SqlDbType.Bit);
                    cmd.Parameters["@accueil"].Value = d.accueil;

                    result=cmd.ExecuteNonQuery();
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

    }
}