using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRSystem.Classes;


namespace HRSystem
{
    public partial class EmployeeAllowances : Form
    {
        public EmployeeAllowances()
        {
            InitializeComponent();
            FillDDLEmployees();
        }


        void FillDDLEmployees()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EmployeeID", typeof(string));
            dt.Columns.Add("EmployeeName", typeof(String));

            EmployeesClass empclass = new EmployeesClass();

            Employee[] Emps = empclass.GetEmployees();
            List<Employee> arr = Emps.ToList();


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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
         /*   AllowancesClass allowancesObj = new AllowancesClass();// TestHRSystem.AllowancesClassTest();
           String sResult = allowancesObj.AddNewAllowance(ddlEmployees.SelectedItem.ToString(), ddlAllowanceType.SelectedItem.ToString(), ddlAllowanceType.SelectedItem.ToString(), tbStartDate.Text, tbAmount.Text);
          * */

           TestHRSystem.AllowancesClassTest allowancesObj = new TestHRSystem.AllowancesClassTest();
            String sResult = allowancesObj.AddNewAllowanceTest( ddlEmployees.SelectedItem.ToString(), 
                                                                ddlAllowanceType.SelectedItem.ToString(), 
                                                                ddlAllowanceType.SelectedItem.ToString(), 
                                                                tbStartDate.Text, 
                                                                tbAmount.Text);
           
          
           MessageBox.Show(sResult);
        }
    }
}
