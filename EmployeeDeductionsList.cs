using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace HRSystem
{
    public partial class EmployeeDeductionsList : Form
    {
        public EmployeeDeductionsList()
        {
            InitializeComponent();
            vFillEmpList();
        }

        void vFillEmpList()
        {
            String XMLFileName = ConfigurationSettings.AppSettings["FilesLocation"] + "Deductions.XML";
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
            EmployeeDeduction empdlg = new EmployeeDeduction();
            empdlg.ShowDialog();

            vFillEmpList();
        }

    }
}
