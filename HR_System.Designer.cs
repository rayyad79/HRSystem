namespace HRSystem
{
    partial class HR_System
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEmployees = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDeductions = new System.Windows.Forms.Button();
            this.btnAllowances = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(35, 48);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(117, 78);
            this.btnEmployees.TabIndex = 0;
            this.btnEmployees.Text = "Employee Profiles";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 78);
            this.button1.TabIndex = 1;
            this.button1.Text = "Employees Vacations";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeductions
            // 
            this.btnDeductions.Location = new System.Drawing.Point(262, 178);
            this.btnDeductions.Name = "btnDeductions";
            this.btnDeductions.Size = new System.Drawing.Size(117, 78);
            this.btnDeductions.TabIndex = 3;
            this.btnDeductions.Text = "Employees Deductions";
            this.btnDeductions.UseVisualStyleBackColor = true;
            this.btnDeductions.Click += new System.EventHandler(this.btnDeductions_Click);
            // 
            // btnAllowances
            // 
            this.btnAllowances.Location = new System.Drawing.Point(101, 178);
            this.btnAllowances.Name = "btnAllowances";
            this.btnAllowances.Size = new System.Drawing.Size(117, 78);
            this.btnAllowances.TabIndex = 2;
            this.btnAllowances.Text = "Employees Allowances";
            this.btnAllowances.UseVisualStyleBackColor = true;
            this.btnAllowances.Click += new System.EventHandler(this.btnAllowances_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(356, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 78);
            this.button2.TabIndex = 4;
            this.button2.Text = "Employee Training Courses";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // HR_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 323);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDeductions);
            this.Controls.Add(this.btnAllowances);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEmployees);
            this.MinimizeBox = false;
            this.Name = "HR_System";
            this.Text = "HR System";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDeductions;
        private System.Windows.Forms.Button btnAllowances;
        private System.Windows.Forms.Button button2;
    }
}