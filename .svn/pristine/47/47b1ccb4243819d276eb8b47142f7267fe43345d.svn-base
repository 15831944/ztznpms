using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraCharts;
using DevExpress.XtraScheduler.Drawing;

namespace ztznpms.UI.图纸管理
{
    public partial class Formtu : DevExpress.XtraEditors.XtraForm
    {
        public Formtu()
        {
            InitializeComponent();
        }

        private void Formtu_Load(object sender, EventArgs e)
        {

            this.schedulerControl1.ActiveView.DateTimeScrollbarVisible = true;
            reload();
        }

        private void reload()
        {


        }

        private void schedulerControl1_CustomDrawDayHeader(object sender, CustomDrawObjectEventArgs e)
        {
            //重绘Header部分,设置日程头部显示格式
            SchedulerControl control = this.schedulerControl1;
            SchedulerViewType svt = control.ActiveViewType;
            if (svt == SchedulerViewType.Day || svt == SchedulerViewType.FullWeek ||
                svt == SchedulerViewType.Week || svt == SchedulerViewType.WorkWeek)
            {
                DayHeader header = e.ObjectInfo as DayHeader;
                DateTime date = header.Interval.Start;
                header.Caption = string.Format("{0}({1})", date.ToString("MM月d日"), date.ToString("dddd", new System.Globalization.CultureInfo("zh-cn")));
            }
        }

        //private void schedulerControl1_AllowAppointmentConflicts(object sender, AppointmentConflictEventArgs e)
        //{
        //    e.Conflicts.Clear();

        //    AppointmentDependencyBaseCollection depCollectionDep =
        //        schedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(e.Appointment.Id);
        //    if (depCollectionDep.Count > 0)
        //    {
        //        if (CheckForInvalidDependenciesAsDependent(depCollectionDep, e.AppointmentClone))
        //            e.Conflicts.Add(e.AppointmentClone);
        //    }

        //    AppointmentDependencyBaseCollection depCollectionPar =
        //        schedulerStorage1.AppointmentDependencies.Items.GetDependenciesByParentId(e.Appointment.Id);
        //    if (depCollectionPar.Count > 0)
        //    {
        //        if (CheckForInvalidDependenciesAsParent(depCollectionPar, e.AppointmentClone))
        //            e.Conflicts.Add(e.AppointmentClone);
        //    }
        //}

        //private bool CheckForInvalidDependenciesAsParent(AppointmentDependencyBaseCollection depCollectionPar, Appointment appointmentClone)
        //{
        //foreach (AppointmentDependency dep in depCollection)
        //{
        //    if (dep.Type == AppointmentDependencyType.FinishToStart)
        //    {
        //        DateTime checkTime = schedulerStorage1.Appointments.Items.GetAppointmentById(dep.DependentId).Start;
        //        if (apt.End > checkTime)
        //            return true;
        //    }
        //}
        //return false;
        //}

        //private bool CheckForInvalidDependenciesAsDependent(AppointmentDependencyBaseCollection depCollectionDep, Appointment appointmentClone)
        //{
        //foreach (AppointmentDependency dep in depCollection)
        //{
        //    if (dep.Type == AppointmentDependencyType.FinishToStart)
        //    {
        //        DateTime checkTime = schedulerStorage1.Appointments.Items.GetAppointmentById(dep.ParentId).End;
        //        if (apt.Start < checkTime)
        //            return true;
        //    }
        //}
        //return false;
        //}
    }
}