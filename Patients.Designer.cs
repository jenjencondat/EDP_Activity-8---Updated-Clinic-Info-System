namespace clinicinfosys
{
    partial class Patients
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
            this.patientsView = new System.Windows.Forms.DataGridView();
            this.PatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PContactNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.patientsView)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // patientsView
            // 
            this.patientsView.AllowUserToAddRows = false;
            this.patientsView.AllowUserToDeleteRows = false;
            this.patientsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientID,
            this.PFirstName,
            this.PLastName,
            this.PGender,
            this.PAddress,
            this.PDateOfBirth,
            this.PContactNum});
            this.patientsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientsView.Location = new System.Drawing.Point(0, 0);
            this.patientsView.Name = "patientsView";
            this.patientsView.ReadOnly = true;
            this.patientsView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.patientsView.RowHeadersVisible = false;
            this.patientsView.RowHeadersWidth = 62;
            this.patientsView.RowTemplate.Height = 28;
            this.patientsView.Size = new System.Drawing.Size(1178, 644);
            this.patientsView.TabIndex = 0;
            // 
            // PatientID
            // 
            this.PatientID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PatientID.DataPropertyName = "PatientID";
            this.PatientID.FillWeight = 30F;
            this.PatientID.HeaderText = "ID";
            this.PatientID.MinimumWidth = 8;
            this.PatientID.Name = "PatientID";
            this.PatientID.ReadOnly = true;
            // 
            // PFirstName
            // 
            this.PFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PFirstName.DataPropertyName = "PFirstName";
            this.PFirstName.HeaderText = "First Name";
            this.PFirstName.MinimumWidth = 8;
            this.PFirstName.Name = "PFirstName";
            this.PFirstName.ReadOnly = true;
            // 
            // PLastName
            // 
            this.PLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PLastName.DataPropertyName = "PLastName";
            this.PLastName.HeaderText = "Last Name";
            this.PLastName.MinimumWidth = 8;
            this.PLastName.Name = "PLastName";
            this.PLastName.ReadOnly = true;
            // 
            // PGender
            // 
            this.PGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PGender.DataPropertyName = "PGender";
            this.PGender.HeaderText = "Gender";
            this.PGender.MinimumWidth = 8;
            this.PGender.Name = "PGender";
            this.PGender.ReadOnly = true;
            // 
            // PAddress
            // 
            this.PAddress.DataPropertyName = "PAddress";
            this.PAddress.HeaderText = "Address";
            this.PAddress.MinimumWidth = 8;
            this.PAddress.Name = "PAddress";
            this.PAddress.ReadOnly = true;
            this.PAddress.Width = 150;
            // 
            // PDateOfBirth
            // 
            this.PDateOfBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PDateOfBirth.DataPropertyName = "PDateOfBirth";
            this.PDateOfBirth.HeaderText = "Birthdate";
            this.PDateOfBirth.MinimumWidth = 8;
            this.PDateOfBirth.Name = "PDateOfBirth";
            this.PDateOfBirth.ReadOnly = true;
            // 
            // PContactNum
            // 
            this.PContactNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PContactNum.DataPropertyName = "PContactNum";
            this.PContactNum.HeaderText = "Contact";
            this.PContactNum.MinimumWidth = 8;
            this.PContactNum.Name = "PContactNum";
            this.PContactNum.ReadOnly = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.patientsView);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1178, 644);
            this.panel8.TabIndex = 3;
            // 
            // Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 644);
            this.Controls.Add(this.panel8);
            this.Name = "Patients";
            this.Text = "Patients";
            ((System.ComponentModel.ISupportInitialize)(this.patientsView)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView patientsView;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn PDateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn PContactNum;
    }
}