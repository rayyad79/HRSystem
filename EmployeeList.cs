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
using System.IO;

namespace HRSystem
{
    public partial class EmployeeList : Form
    {
        public EmployeeList()
        {
            InitializeComponent();
            vFillEmpList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeesProfiles empDlg = new EmployeesProfiles();
            empDlg.ShowDialog();

            vFillEmpList();
        }

        void vFillEmpList()
        {
            String XMLFileName = ConfigurationSettings.AppSettings["FilesLocation"] + "Employee.XML";
            DataSet ds = new DataSet();

            if (File.Exists(XMLFileName))
            {

                ds.ReadXml(XMLFileName);

                DataRow[] rows = ds.Tables[0].Select(" EmployeeName like '%" + tbEmpName.Text + "%'");
                DataTable dt = ds.Tables[0].Clone();
                for (int i = 0; i < rows.Length; i++)
                {
                    dt.ImportRow(rows[i]);
                    dt.AcceptChanges();
                }


                dgEmp.DataSource = dt;
            }
           // dgEmp.Sort(dgCases.Columns[4], ListSortDirection.Descending);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            vFillEmpList();
        }
    }
}
