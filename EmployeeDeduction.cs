using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRSystem.Classes;
using TestHRSystem;

namespace HRSystem
{
    public partial class EmployeeDeduction : Form
    {
        public EmployeeDeduction()
        {
            InitializeComponent();

            FillDDLEmployees();
        }

        private void EmployeeDeduction_Load(object sender, EventArgs e)
        {

        }

        void FillDDLEmployees()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EmployeeID", typeof(string));
            dt.Columns.Add("EmployeeName", typeof(String));

            EmployeesClass empclass = new EmployeesClass();

            Employee[] Emps = empclass.GetEmployees();

            foreach (Employee emp in Emps)
            {
                DataRow row = dt.NewRow();
                row["EmployeeID"] = emp.EmployeeID;
                row["EmployeeName"] = emp.EmployeeName;
                dt.Rows.Add(row);
            }

            ddlEmployees.DisplayMember = "EmployeeName";
            ddlEmployees.ValueMember = "EmployeeID";

            ddlEmployees.DataSource = dt;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SubtractsClassTest deductionObj = new SubtractsClassTest();
         //   DeductionsClass deductionObj = new DeductionsClass();
            String sResult = deductionObj.AddNewDeductionTest(ddlEmployees.SelectedItem.ToString(), ddlDeductionType.SelectedItem.ToString(), ddlDeductionType.SelectedItem.ToString(), tbStartDate.Text, tbAmount.Text);
            MessageBox.Show(sResult);
        }

    }
}
