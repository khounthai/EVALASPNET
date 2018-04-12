using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Resources;
using System.Reflection;

namespace EvalASPNET.dao
{
    public class DaoBD
    {
        private static MySqlConnection _myConnection;
        private static DaoBD instance;

        private DaoBD()
        {
            _myConnection = new MySqlConnection();
            _myConnection.ConnectionString = EvalASPNET.Properties.Resources.ConnectionString;
        }

        public static MySqlConnection MyConnection
        {
            get
            {
                if (instance == null)
                    instance = new DaoBD();

                return _myConnection;
            }

        }
    }
}