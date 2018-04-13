using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Resources;
using System.Reflection;

namespace EvalASPNET.dao
{
    public class DaoBD
    {
        private static SqlConnection _myConnection;
        private static DaoBD instance;

        private DaoBD()
        {
            _myConnection = new SqlConnection();
            _myConnection.ConnectionString = EvalASPNET.Properties.Resources.ConnectionString;
        }

        public static SqlConnection MyConnection
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