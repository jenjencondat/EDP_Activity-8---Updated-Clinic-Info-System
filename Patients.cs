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
    public partial class Patients : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Patients()
        {
            InitializeComponent();
            this.Load += LoadPatients;
        }

        private async void LoadPatients(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(
                    "http://localhost/jenApi/Patient.php"
                );
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<Patients2> patients = JsonConvert.DeserializeObject<List<Patients2>>(
                    jsonResponse
                );

                patientsView.DataSource = patients;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

    public class Patients2
    {
        public int PatientID { get; set; }
        public string PFirstName { get; set; }
        public string PLastName { get; set; }
        public string PGender { get; set; }
        public string PAddress { get; set; }
        public string PDateOfBirth { get; set; }
        public string PContactNum { get; set; }
    }
}
