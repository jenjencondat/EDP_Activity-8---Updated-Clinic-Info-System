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
    public partial class Doctor : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Doctor()
        {
            InitializeComponent();
            this.Load += LoadDoctors;
        }

        private async void LoadDoctors(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(
                    "http://localhost/jenApi/Doctor.php"
                );
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<Doctor2> doctors = JsonConvert.DeserializeObject<List<Doctor2>>(jsonResponse);

                doctorsView.DataSource = doctors;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

    public class Doctor2
    {
        public int DoctorID { get; set; }
        public string DFirstName { get; set; }
        public string DLastName { get; set; }
        public string gender { get; set; }
        public string DSpecialization { get; set; }
        public string address { get; set; }
        public string birthdate { get; set; }
        public string DContactNum { get; set; }
    }
}
