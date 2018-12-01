using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevComponents.DotNetBar;
using DevComponents.Schedule.Model;
using DevComponents.DotNetBar.Schedule;
using ztznpms.Common;

namespace ztznpms.UI.二维码
{
    public partial class Formshijianbiao : Office2007Form
    {
        public Formshijianbiao()
        {
            this.EnableGlass = false;
            InitializeComponent();
            calendarView1.CalendarModel = new CalendarModel();
            AddSampleAppointments();
        }

        private void Formshijianbiao_Load(object sender, EventArgs e)
        {

        }

        //  钳-
        //  加工中心--
        //  焊接（常规）--
        //  焊接（不锈钢）--
        //  火焰切割---
        //  龙门铣--
        //  刻字--
        //  氩弧焊--
        //  电火花--
        //  剪板折弯--
        //  水切割--
        //  普车--
        //  漆
        //  镗床--
        //  炮塔铣（键槽类）---
        //  普通铣床--
        //  锯--
        //  外协
        //  线切割--
        //  数车--
        //  立车--
        private void AddSampleAppointments()
        {
            calendarView1.CalendarModel.Appointments.Clear();

            string sql = "select * from db_Paichan where 设定开始时间 IS NOT NULL and 设定开始时间 != 设定结束时间 and 实际开始时间 IS NULL";

            //string sql = "select * from db_Paichan ";

            //string sql = "select * from db_Paichan where 设定开始时间 IS NOT NULL and 设定开始时间 != 设定结束时间";

            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DateTime kaishishijian = Convert.ToDateTime(dt.Rows[i]["设定开始时间"]);
                DateTime jieshushijian = Convert.ToDateTime(dt.Rows[i]["设定结束时间"]);

                //设定开始时间和设定结束时间不一样
                if(kaishishijian != jieshushijian)
                {
                    string gongxu = dt.Rows[i]["工序名称"].ToString();
                    if(gongxu == "钳")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryBlue, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "锯")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryGreen, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "普车")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryOrange, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "普通铣床")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryPurple, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "剪板折弯")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryRed, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "数车")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryYellow, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "加工中心")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryBlue, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "焊接（常规）")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryDefault, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "焊接（不锈钢）")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryGreen, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "火焰切割")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryOrange, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "龙门铣")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryPurple, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "刻字")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryRed, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "氩弧焊")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryYellow, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "水切割")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryBlue, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "镗床")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryDefault, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "线切割")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryGreen, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "立车")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryOrange, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "炮塔铣（键槽类）")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryPurple, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "电火花")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryRed, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "平磨")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryYellow, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                    if (gongxu == "二保焊")
                    {
                        string renyuan = dt.Rows[i]["负责人"].ToString();
                        string shebeimingcheng = dt.Rows[i]["工序设备"].ToString();
                        string lingjian = dt.Rows[i]["零件名称"].ToString();
                        string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                        string shebei = dt.Rows[i]["设备名称"].ToString();
                        string miaoshu = renyuan + ';' + gongzuolinghao + ';' + shebei + ';' + lingjian;
                        AddAppointment(gongxu,
                       kaishishijian, jieshushijian,
                       Appointment.CategoryGreen, Appointment.TimerMarkerDefault, shebeimingcheng, miaoshu);
                    }
                }


            }

        }
        private Appointment AddAppointment(string s,
   DateTime startTime, DateTime endTime, string color, string marker, string zhuti, string renyuan)
        {
            Appointment appointment = new Appointment();

            appointment.StartTime = startTime;
            appointment.EndTime = endTime;

            appointment.Subject = s;
            appointment.Description = renyuan;
            appointment.CategoryColor = color;
            appointment.TimeMarkedAs = marker;

            appointment.Tooltip = zhuti;
            appointment.Locked = true;
            calendarView1.CalendarModel.Appointments.Add(appointment);

            return (appointment);
        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.Day;
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.Week;
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.Month;
        }

        private void btnTimeLine_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.TimeLine;
        }

        private void calendarView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void calendarView1_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            AppointmentView item = sender as AppointmentView;

            if (item != null)
            {
                Appointment ap = item.Appointment;

                string s = string.Format(
                    "工序名称: {0}\n工序设备: {1}\n工序概况: {2}\n\n" +
                    "开始时间: {3}\n结束时间: {4}",
                    ap.Subject, ap.Tooltip, ap.Description,
                    ap.StartTime, ap.EndTime);

                MessageBox.Show(s);

            }
        }
    }
}