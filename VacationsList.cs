using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using HRSystem.Classes;
using System.Xml;

namespace HRSystem
{
    public partial class VacationsList : Form
    {
        public VacationsList()
        {
            InitializeComponent();
            vFillEmpList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeAttendance empDlg = new EmployeeAttendance();
            empDlg.ShowDialog();

        }

        void vFillEmpList()
        {
            String XMLFileName = ConfigurationSettings.AppSettings["FilesLocation"] + "EmpVacations.XML";
            DataSet ds = new DataSet();
            ds.ReadXml(XMLFileName);

            DataRow[] rows = ds.Tables[0].Select(" EmployeeID like '%" + tbEmpName.Text + "%'");
            DataTable dt = ds.Tables[0].Clone();
            for (int i = 0; i < rows.Length; i++)
            {
                dt.ImportRow(rows[i]);
                dt.AcceptChanges();
            }


            dgEmpVac.DataSource = dt;
            // dgEmp.Sort(dgCases.Columns[4], ListSortDirection.Descending);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            vFillEmpList();
        }
    }
}
