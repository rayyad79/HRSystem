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
    public partial class EmployeeAttendance : Form
    {
        public EmployeeAttendance()
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
          //  MessageBox.Show(ddlEmployees.SelectedItem.ToString());

         /*   EmpVacationsClass empvac = new EmpVacationsClass();// TestHRSystem.EmpVacationsClassTest();
            String sResult = empvac.AddNewVacation(DateTime.Now.Ticks.ToString(), ddlVacationType.SelectedItem.ToString(), ddlEmployees.SelectedItem.ToString(), DateTime.Parse(FromDate.Value.ToString()), DateTime.Parse( ToDate.Value.ToString()));*/

            EmpVacationsClass empvac = new EmpVacationsClass();// TestHRSystem.EmpVacationsClassTest();
            String sResult = empvac.AddNewVacation(DateTime.Now.Ticks.ToString(), ddlVacationType.SelectedItem.ToString(), ddlEmployees.SelectedValue.ToString(), DateTime.Parse(FromDate.Value.ToString()), DateTime.Parse(ToDate.Value.ToString()));
            MessageBox.Show(sResult);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
