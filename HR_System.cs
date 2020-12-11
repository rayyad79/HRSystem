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
    public partial class HR_System : Form
    {
        public HR_System()
        {
            InitializeComponent();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            EmployeeList empProfile = new EmployeeList();
            empProfile.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VacationsList empAttendance = new VacationsList();
            empAttendance.ShowDialog();
        }

        private void btnAllowances_Click(object sender, EventArgs e)
        {
            EmployeeAllowancesList empAllowances = new EmployeeAllowancesList();
            empAllowances.ShowDialog();
        }

        private void btnDeductions_Click(object sender, EventArgs e)
        {
            EmployeeDeductionsList empDeduction = new EmployeeDeductionsList();
            empDeduction.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            EmployeeTraningCoursesList EmpTraining = new EmployeeTraningCoursesList();
            EmpTraining.ShowDialog();
        }
    }
}
