using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRSystem.Classes;
using System.IO;

using System.Reflection;
using System.Reflection.Emit;
using System.Configuration;

namespace HRSystem
{
    public partial class HR_Login : Form
    {
        public HR_Login()
        {
            InitializeComponent();
            tbpassword.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveToXml();
            if (tbusernane.Text == "" || tbpassword.Text == "")
            {
                MessageBox.Show("You must fill Username and Password!");
                return;
            }

            if (tbusernane.Text == "HRAdmin" && tbpassword.Text == "Ab@123")
            {
                HR_System HRObj = new HR_System();
                HRObj.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Username and Password");
            }
                       
        }

         void saveToXml()
        {
            String ClassesInfoFile = ConfigurationSettings.AppSettings["FilesLocation"] + "ClassesInfo.XML";
            if (File.Exists(ClassesInfoFile))
            {
                File.Delete(ClassesInfoFile);
            }

            String strNoOfMehods = "";
            Type myType = (typeof(Classes.AllowancesClass));
            // Get the public methods.
            MethodInfo[] myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            strNoOfMehods += myArrayMethodInfo.Length.ToString() + ",";

            myType = (typeof(Classes.DeductionsClass));
            // Get the public methods.
            myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            strNoOfMehods += myArrayMethodInfo.Length.ToString() + ",";

            myType = (typeof(Classes.EmployeesClass));
            // Get the public methods.
            myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            strNoOfMehods += myArrayMethodInfo.Length.ToString() + ",";

            myType = (typeof(Classes.EmpTrainingCoursesClass));
            // Get the public methods.
            myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            strNoOfMehods += myArrayMethodInfo.Length.ToString() + ",";

            myType = (typeof(Classes.EmpVacationsClass));
            // Get the public methods.
            myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            strNoOfMehods += myArrayMethodInfo.Length.ToString() + ",";

            myType = (typeof(Classes.EvaluationClass));
            // Get the public methods.
            myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            strNoOfMehods += myArrayMethodInfo.Length.ToString() + ",";

            myType = (typeof(Classes.HealthInsuranceClass));
            // Get the public methods.
            myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            strNoOfMehods += myArrayMethodInfo.Length.ToString() + ",";

            myType = (typeof(Classes.JobTitleClass));
            // Get the public methods.
            myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            myType = (typeof(Classes.LevelClass));
            // Get the public methods.
            myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            myType = (typeof(Classes.PrivilegeClass));
            // Get the public methods.
            myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            strNoOfMehods += myArrayMethodInfo.Length.ToString() + ",";

            myType = (typeof(Classes.QualificationClass));
            // Get the public methods.
            myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            strNoOfMehods += myArrayMethodInfo.Length.ToString() + ",";

            myType = (typeof(Classes.TrainingCoursesClass));
            // Get the public methods.
            myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            strNoOfMehods += myArrayMethodInfo.Length.ToString() ;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("ClassesDetails", typeof(string))});

            dt.Rows.Add(strNoOfMehods);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.AcceptChanges();
            ds.WriteXml(ClassesInfoFile);
               

        }

        public static void DisplayMethodInfo(MethodInfo[] myArrayMethodInfo, String flag)
        {
            // Display information for all methods.
            for (int i = 0; i < myArrayMethodInfo.Length; i++)
            {
                MethodInfo myMethodInfo = (MethodInfo)myArrayMethodInfo[i];
               // Console.WriteLine("\nThe name of the method is {0}.", myMethodInfo.Name);
                MessageBox.Show(myMethodInfo.Name + " ***** " + flag);
            }
        }

     
    }
}
