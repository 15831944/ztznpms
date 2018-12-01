using NetWork.util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ztznpms
{
    class sqlhelp111
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public static DataTable GetDataTable(string sql, CommandType type, params SqlParameter[] pars)
        {

            return getData.getdata(sql, "db_office");
        }

        public static int ExecuteNonquery(string sql, CommandType type, byte[] files, params SqlParameter[] pars)
        {

            return getData.ExecuteNonquery(sql, "db_office", files);
        }
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {

            return getData.ExecuteScalar(sql, "db_office");
        }
        public static int innn(string sql, CommandType type, params SqlParameter[] pars)
        {

            return getData.innn(sql, "db_ShengChanBu");
        }
        public static byte[] duqu(string sql, CommandType type, params SqlParameter[] pars)
        {

            byte[] bt = getData.duqu(sql, "db_office");
            return bt;

        }
    }
}
