using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using NetWork.util;

namespace ztznpms.Common
{
    class SQLhelp
    {
        //定义一个连接字符串
        //readonly 修饰的变量，只有在初始化的时候赋值
        //private static readonly string connStr = ConfigurationManager.ConnectionStrings["mysqlserver"].ConnectionString;

        //1.执行增、删、改的方法insert、delete、updata
        //(ExecuteNonQuery())
        public static int ExecuteNonquery(string sql, CommandType type, params SqlParameter[] pars)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            cmd.Parameters.AddRange(pars);
            //        }
            //        cmd.CommandType = type;
            //        conn.Open();
            //        return cmd.ExecuteNonQuery();

            //    }
            //}
            return getData.innn(sql, "db_ShengChanBu");
        }

        //2、执行查询，返回单个值得方法  执行ExecuteScalar()方法
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            cmd.Parameters.AddRange(pars);
            //        }
            //        cmd.CommandType = type;
            //        conn.Open();
            //        return cmd.ExecuteScalar(); 
            //    }
            //}
            return getData.ExecuteScalar(sql, "db_ShengChanBu");
        }

        //3、执行查询，返回多个行的方法
        //public static SqlDataReader ExecuteReader(string sql, CommandType type, params SqlParameter[] pars)
        //{
            //SqlConnection conn = new SqlConnection(connStr);

            //using (SqlCommand cmd = new SqlCommand(sql, conn))
            //{
            //    if (pars != null)
            //    {
            //        cmd.Parameters.AddRange(pars);
            //    }
            //    try
            //    {
            //        cmd.CommandType = type;
            //        conn.Open();
            //        return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            //    }
            //    catch
            //    {
            //        conn.Close();
            //        conn.Dispose();
            //        throw;//将异常抛上去
            //    }
            //}
        //}

        //4、返回查询到的Datatable
        public static DataTable GetDataTable(string sql, CommandType type, params SqlParameter[] pars)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlDataAdapter apter = new SqlDataAdapter(sql, conn))
            //    {
            //        if (pars  != null)
            //        {
            //            apter.SelectCommand.Parameters.AddRange(pars );
            //        }
            //        apter.SelectCommand.CommandType = type;
            //        DataTable da = new DataTable();
            //        apter.Fill(da);

            //        return da;
            //    }
            //}
            return getData.getdata(sql, "db_ShengChanBu");
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static byte[] duqu(string sql, CommandType type, params SqlParameter[] pars)
        {

            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            cmd.Parameters.AddRange(pars);
            //        }
            //        cmd.CommandType = type;
            //        conn.Open();
            //        SqlDataReader dr = cmd.ExecuteReader();
            //        byte[] mybuffer = null;
            //        while (dr.Read())
            //        {
            //            mybuffer = (byte[])dr.GetValue(0);

            //        }
            //        return mybuffer;

            //    }
            //}
            byte[] bt = getData.duqu(sql, "db_ShengChanBu");
            return bt;

        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static byte[] duqu1(string sql, CommandType type, params SqlParameter[] pars)
        {

            byte[] bt = getData.duqu(sql, "db_xiangmuguanli");
            return bt;

        }

        //项目管理系统读取表格
        public static DataTable GetDataTable1(string sql, CommandType type, params SqlParameter[] pars)
        {
            //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_xiangmuguanli;user id=sa;password=zttZTT123";
            //using (SqlConnection conn = new SqlConnection(ConStr))
            //{
            //    using (SqlDataAdapter apter = new SqlDataAdapter(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            apter.SelectCommand.Parameters.AddRange(pars);
            //        }
            //        apter.SelectCommand.CommandType = type;
            //        DataTable da = new DataTable();
            //        apter.Fill(da);

            //        return da;
            //    }
            //}
            return getData.getdata(sql, "db_xiangmuguanli");
        }


        //2、执行查询，返回单个值得方法  执行ExecuteScalar()方法
        public static object ExecuteScalar1(string sql, CommandType type, params SqlParameter[] pars)
        {
            //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_xiangmuguanli;user id=sa;password=zttZTT123";
            //using (SqlConnection conn = new SqlConnection(ConStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            cmd.Parameters.AddRange(pars);
            //        }
            //        cmd.CommandType = type;
            //        conn.Open();
            //        return cmd.ExecuteScalar();
            //    }
            //}
            return getData.ExecuteScalar(sql, "db_xiangmuguanli");
        }

        /// <summary>
        /// 用来更新项目管理软件的tb_caigouliaodan里面的"制造类型='自制零部件'"的当前状态
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        //1.执行增、删、改的方法insert、delete、updata
        //(ExecuteNonQuery())
        public static int ExecuteNonquery1(string sql, CommandType type, params SqlParameter[] pars)
        {
            //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_xiangmuguanli;user id=sa;password=zttZTT123";
            //using (SqlConnection conn = new SqlConnection(ConStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            cmd.Parameters.AddRange(pars);
            //        }
            //        cmd.CommandType = type;
            //        conn.Open();
            //        return cmd.ExecuteNonQuery();

            //    }
            //}
            return getData.innn(sql, "db_xiangmuguanli");
        }

        public static int ExecuteNonqueryByte(string sql, CommandType type, byte[] files, params SqlParameter[] pars)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        //if (pars != null)
            //        //{
            //        //    cmd.Parameters.AddRange(pars);
            //        //}
            //        conn.Open();
            //        cmd.Parameters.Clear();

            //        cmd.Parameters.Add("@pic", SqlDbType.VarBinary).Value = files;
            //        return cmd.ExecuteNonQuery();
            //    }
            //}
            return getData.ExecuteNonquery(sql, "db_ShengChanBu", files);
        }

        public static DataTable GetDataTable2(string sql, CommandType type, params SqlParameter[] pars)
        {

            return getData.getdata(sql, "db_office");
        }

        public static int ExecuteNonquery2(string sql, CommandType type, byte[] files, params SqlParameter[] pars)
        {

            return getData.ExecuteNonquery(sql, "db_office", files);
        }
        public static object ExecuteScalar2(string sql, CommandType type, params SqlParameter[] pars)
        {

            return getData.ExecuteScalar(sql, "db_office");
        }

    }
}


