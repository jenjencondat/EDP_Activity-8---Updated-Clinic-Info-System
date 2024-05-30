namespace clinicinfosys
{
    partial class Doctor
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.doctorsView = new System.Windows.Forms.DataGridView();
            this.DoctorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DSpecialization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DContactNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.doctorsView);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1178, 644);
            this.panel8.TabIndex = 1;
            // 
            // doctorsView
            // 
            this.doctorsView.AllowUserToAddRows = false;
            this.doctorsView.AllowUserToDeleteRows = false;
            this.doctorsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doctorsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DoctorID,
            this.DFirstName,
            this.DLastName,
            this.gender,
            this.DSpecialization,
            this.address,
            this.birthdate,
            this.DContactNum});
            this.doctorsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doctorsView.Location = new System.Drawing.Point(0, 0);
            this.doctorsView.Name = "doctorsView";
            this.doctorsView.ReadOnly = true;
            this.doctorsView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.doctorsView.RowHeadersVisible = false;
            this.doctorsView.RowHeadersWidth = 62;
            this.doctorsView.RowTemplate.Height = 28;
            this.doctorsView.Size = new System.Drawing.Size(1178, 644);
            this.doctorsView.TabIndex = 0;
            // 
            // DoctorID
            // 
            this.DoctorID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DoctorID.DataPropertyName = "DoctorID";
            this.DoctorID.FillWeight = 30F;
            this.DoctorID.HeaderText = "ID";
            this.DoctorID.MinimumWidth = 8;
            this.DoctorID.Name = "DoctorID";
            this.DoctorID.ReadOnly = true;
            // 
            // DFirstName
            // 
            this.DFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DFirstName.DataPropertyName = "DFirstName";
            this.DFirstName.HeaderText = "First Name";
            this.DFirstName.MinimumWidth = 8;
            this.DFirstName.Name = "DFirstName";
            this.DFirstName.ReadOnly = true;
            // 
            // DLastName
            // 
            this.DLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DLastName.DataPropertyName = "DLastName";
            this.DLastName.HeaderText = "Last Name";
            this.DLastName.MinimumWidth = 8;
            this.DLastName.Name = "DLastName";
            this.DLastName.ReadOnly = true;
            // 
            // gender
            // 
            this.gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gender.DataPropertyName = "gender";
            this.gender.HeaderText = "Gender";
            this.gender.MinimumWidth = 8;
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            // 
            // DSpecialization
            // 
            this.DSpecialization.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DSpecialization.DataPropertyName = "DSpecialization";
            this.DSpecialization.HeaderText = "Specialization";
            this.DSpecialization.MinimumWidth = 8;
            this.DSpecialization.Name = "DSpecialization";
            this.DSpecialization.ReadOnly = true;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "Address";
            this.address.MinimumWidth = 8;
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 150;
            // 
            // birthdate
            // 
            this.birthdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.birthdate.DataPropertyName = "birthdate";
            this.birthdate.HeaderText = "Birthdate";
            this.birthdate.MinimumWidth = 8;
            this.birthdate.Name = "birthdate";
            this.birthdate.ReadOnly = true;
            // 
            // DContactNum
            // 
            this.DContactNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DContactNum.DataPropertyName = "DContactNum";
            this.DContactNum.HeaderText = "Contact";
            this.DContactNum.MinimumWidth = 8;
            this.DContactNum.Name = "DContactNum";
            this.DContactNum.ReadOnly = true;
            // 
            // Doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 644);
            this.Controls.Add(this.panel8);
            this.Name = "Doctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "JenCare";
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.doctorsView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView doctorsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn DSpecialization;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DContactNum;
    }
}

