using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinicinfosys
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            this.panelMain.Controls.Clear();

            Doctor doctor = new Doctor()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            doctor.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Add(doctor);
            doctor.Show();
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();

            Appointment appointment = new Appointment()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            appointment.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Add(appointment);
            appointment.Show();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();

            Doctor doctor = new Doctor()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            doctor.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Add(doctor);
            doctor.Show();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();

            Patients patients = new Patients()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            patients.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Add(patients);
            patients.Show();
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();

            AddDoctor addDoctor = new AddDoctor()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            addDoctor.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Add(addDoctor);
            addDoctor.Show();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();

            AddPatient addPatient = new AddPatient()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };

            addPatient.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Add(addPatient);
            addPatient.Show();
        }
    }
}
