using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace clinicinfosys
{
    public partial class Appointment : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Appointment()
        {
            InitializeComponent();
            this.Load += LoadAppointment;
        }

        private async void LoadAppointment(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(
                    "http://localhost/jenApi/Appointment.php"
                );
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<Appointment2> appointment = JsonConvert.DeserializeObject<List<Appointment2>>(
                    jsonResponse
                );

                appointmentView.DataSource = appointment;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

    public class Appointment2
    {
        public int AppointmentID { get; set; }
        public string DoctorID { get; set; }
        public string AppointmentDate { get; set; }
        public string Notes { get; set; }
    }
}
