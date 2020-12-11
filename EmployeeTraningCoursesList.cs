using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using HRSystem.Classes;

namespace HRSystem
{
    public partial class EmployeeTraningCoursesList : Form
    {
        public EmployeeTraningCoursesList()
        {
            InitializeComponent();
            vFillEmpList();
        }


        void vFillEmpList()
        {
            String XMLFileName = ConfigurationSettings.AppSettings["FilesLocation"] + "EmpTrainingCourses.XML";
            DataSet ds = new DataSet();
            ds.ReadXml(XMLFileName);

            DataRow[] rows = ds.Tables[0].Select(" EmployeeID like '%" + tbEmpName.Text + "%'");
            DataTable dt = ds.Tables[0].Clone();
            for (int i = 0; i < rows.Length; i++)
            {
                dt.ImportRow(rows[i]);
                dt.AcceptChanges();
            }


            dgEmp.DataSource = dt;
            // dgEmp.Sort(dgCases.Columns[4], ListSortDirection.Descending);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeTrainingCourse empDlg = new EmployeeTrainingCourse();
            empDlg.ShowDialog();

            vFillEmpList();

        }

    }
}
