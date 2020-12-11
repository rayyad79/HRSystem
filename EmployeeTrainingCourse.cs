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
    public partial class EmployeeTrainingCourse : Form
    {
        public EmployeeTrainingCourse()
        {
            InitializeComponent();
            FillDDLEmployees();
        }

        void FillDDLEmployees()
        {
            DataTable dt = new DataTable ();
dt.Columns.Add("EmployeeID", typeof(string));
dt.Columns.Add("EmployeeName", typeof(String));

            EmployeesClass empclass = new EmployeesClass();

            Employee [] Emps = empclass.GetEmployees();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
           EmpTrainingCoursesClass empTrainingCourse = new EmpTrainingCoursesClass();// EmpTrainingCoursesClassTest();
           String sResult =  empTrainingCourse.AddNewTrainingCourse(DateTime.Now.Ticks.ToString(), ddlTrainingType.SelectedItem.ToString(), ddlEmployees.SelectedItem.ToString(), DateTime.Parse( FromDate.Value.ToString()), DateTime.Parse(ToDate.Value.ToString()));

            MessageBox.Show(sResult);
        }

    }
}
