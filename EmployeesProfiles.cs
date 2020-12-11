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
    public partial class EmployeesProfiles : Form
    {
        public EmployeesProfiles()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            /*EmployeesClass empClass = new EmployeesClass();
            
            String sResult = empClass.AddNewEmployee(tbEmployeeNo.Text,
                                                        tbEmployeeName.Text,
                                                        ddlGender.SelectedValue.ToString(),
                                                        BirthDate.Value.ToString(),
                                                        tbAddress.Text,
                                                        HieringDate.Value.ToString(),
                                                        tbVacationBalance.Text,
                                                        ddlJobTitle.SelectedValue.ToString(),
                                                        ddlDepartment.SelectedValue.ToString(),
                                                        ddlQualification.SelectedValue.ToString(),
                                                        tbMajor.Text,
                                                        tbAvg.Text,
                                                        tbBasicSalary.Text,
                                                        "0", "0");
            */


          //  EmployeesClass dd = new EmployeesClass();// TestHRSystem.EmployeesClassTest();
         //   TestHRSystem.StudentClassTest studentTest = new TestHRSystem.StudentClassTest();
         //   TestHRSystem.BankAccountsTest bankAccounts = new TestHRSystem.BankAccountsTest();
            EmployeesClassTest dd = new EmployeesClassTest(); 
            String sResult =dd.AddNewEmployeeTest(tbEmployeeNo.Text,
                                               tbEmployeeName.Text,
                                               ddlGender.SelectedItem == null ? "" : ddlGender.SelectedItem.ToString(),
                                               BirthDate.Value.ToString(),
                                               tbAddress.Text,
                                               HieringDate.Value.ToString(),
                                               tbVacationBalance.Text,
                                               ddlJobTitle.SelectedItem == null ? "" : ddlJobTitle.SelectedItem.ToString(),
                                               ddlDepartment.SelectedItem == null ? "" : ddlDepartment.SelectedItem.ToString(),
                                               ddlQualification.SelectedItem == null ? "" : ddlQualification.SelectedItem.ToString(),
                                               tbMajor.Text,
                                               tbAvg.Text,
                                               tbBasicSalary.Text,
                                               "0", "0");

            MessageBox.Show(sResult);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
