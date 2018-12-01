using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.项目管理
{
    public partial class FormShixiang : Form
    {
        public string yonghu;
        public FormShixiang()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void FormShixiang_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            string sql = "select * from db_gongxu1 where 负责人='" + yonghu + "'";//全部事项
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 待办工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sql = "select * from db_gongxu1 where 负责人='" + yonghu + "' and 开始时间 IS NULL and 结束时间 IS NULL";//"+ yonghu +"
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 进行中工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //string sql1 = "select * from db_gongxu1 where 负责人='严鹏' and 开始时间 IS NULL";
            //string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
            //if(ret1 != "")
            //{
            //    return;
            //}
            //else
            //{
                string sql = "select * from db_gongxu1 where 实际操作人='" + yonghu + "' and 开始时间 IS NOT NULL and 结束时间 IS NULL";//"+ yonghu +"
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                this.dataGridView1.DataSource = dt;
            //}


        }

        /// <summary>
        /// 已完成工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string sql = "select * from db_gongxu1 where 实际操作人='" + yonghu + "' and 开始时间 IS NOT NULL and 结束时间 IS NOT NULL";//"+ yonghu +"
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 全部事项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            reload();
        }
    }
}
