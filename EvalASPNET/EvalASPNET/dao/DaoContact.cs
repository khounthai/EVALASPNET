using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Contacts.entity;
using System.Diagnostics;

namespace EvalASPNET.dao
{
    public class DaoContact
    {
        //public static List<Contact> findByIduserAndIdTemplate(long iduser, long idtemplate, bool actif, DateTime date)
        //{
        //    List<Contact> liste = new List<Contact>();

        //    try
        //    {                
        //        String sql = "select idcontact,dtcreation,favoris,actif from contact where iduser=@idcontact and actif=@actif";
        //        MySqlCommand cmd = new MySqlCommand(sql, DaoBD.MyConnection);
        //        cmd.Parameters.Add("@idcontact", MySqlDbType.Int32);
        //        cmd.Parameters["@idcontact"].Value = iduser;
        //        cmd.Parameters.Add("@actif", MySqlDbType.Int32);
        //        cmd.Parameters["@actif"].Value = (actif ? 1 : 0);
        //        cmd.Connection.Open();
        //        MySqlDataReader rs = cmd.ExecuteReader();

        //        while (rs.Read())
        //        {
        //            Contact c = new Contact(rs.GetInt64(1), rs.GetDateTime(2), rs.GetBoolean(3), iduser, rs.GetBoolean(4),
        //                    new List<Donnee>());
        //            liste.Add(c);
        //        }

        //        rs.Close();
        //        cmd.Connection.Close();

        //        liste.ForEach(x=> {
        //            List<Donnee> listeDonnees = donneeDao.findByIdContactAndIdTemplate(x.getIdcontact(), idtemplate, date);
        //            listeDonnees.sort(new DonneeComparator());
        //            x.setDonnees(listeDonnees);
        //        });

        //    }
        //    catch (Exception e)
        //    {                
        //        Debug.WriteLine(e.Message);
        //    }

        //    return liste;
        //}

     /*   public Contact findByIdcontactAndIdTemplate(long idcontact, long idtemplate, bool actif, DateTime date)
        {
            Contact c = null;

            try
            {
                Connection conn = (Connection)database.getSqlConnection();

                String sql = "select idcontact,dtcreation,favoris,iduser,actif from contact where idcontact=? and actif=?";
                PreparedStatement ps = (PreparedStatement)conn.prepareStatement(sql);
                ps.setLong(1, idcontact);
                ps.setBoolean(2, actif);

                //System.out.println(sql);
                ResultSet rs = ps.executeQuery();

                while (rs.next())
                {
                    c = new Contact(rs.getLong(1), rs.getDate(2), rs.getBoolean(3), rs.getLong(4), rs.getBoolean(5),
                            new ArrayList<Donnee>());
                }

                rs.close();
                ps.close();

                if (c != null)
                    c.setDonnees(donneeDao.findByIdContactAndIdTemplate(c.getIdcontact(), idtemplate, date));

            }
            catch (SQLException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }

            return c;
        }

        public long Save(Contact c)
        {
            long result = 0;
            long resultexecuteUpdate = 0;

            try
            {
                Connection conn = (Connection)database.getSqlConnection();

                String sql = "INSERT INTO CONTACT (idcontact,dtcreation,favoris,iduser,actif) VALUES (?,?,?,?,?) "
                        + "ON DUPLICATE KEY UPDATE dtcreation=VALUES(dtcreation), favoris=VALUES(favoris), iduser=VALUES(iduser), actif=VALUES(actif)";

                //System.out.println(sql);
                PreparedStatement ps = (PreparedStatement)conn.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);

                ps.setLong(1, c.getIdcontact());
                ps.setDate(2, c.getDtcreation());
                ps.setBoolean(3, c.getFavoris());
                ps.setLong(4, c.getIduser());
                ps.setBoolean(5, c.getActif());

                ps.executeUpdate();

                ResultSet rspk = ps.getGeneratedKeys();
                while (rspk.next())
                {
                    result = rspk.getLong(1);
                }
                rspk.close();

                ps.close();

                //si result=0: c'est un update, renvoie l'idcontact modifié
                if (result == 0)
                    result = c.getIdcontact();

            }
            catch (SQLException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
                result = 0;
            }

            return result;
        }

        public long ActiverDesactiverByIdContact(long idcontact, boolean actif) throws Exception
        {

        long result = 0;

		try {
			Connection conn = (Connection)database.getSqlConnection();

        String sql = "UPDATE CONTACT SET actif=? WHERE idcontact=?";

        //System.out.println(sql);
        PreparedStatement ps = (PreparedStatement)conn.prepareStatement(sql);

        ps.setBoolean(1, actif);
			ps.setLong(2, idcontact);

			result = ps.executeUpdate();
			ps.close();

		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		if (result == 0)
			throw new Exception(String.format("Erreur dans ContactDao.ActiverDesactiver: idcontact=%d, actif=%s",
                    idcontact, actif));

		return result;
	}

	public long ActiverDesactiverByContact(Contact c, boolean actif) throws Exception
            {
		            return ActiverDesactiverByIdContact(c.getIdcontact(), actif);
            }*/
    }
}