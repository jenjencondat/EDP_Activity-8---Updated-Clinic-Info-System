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
    public partial class AddPatient : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public AddPatient()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (
                string.IsNullOrWhiteSpace(tbPFirstName.Text)
                || string.IsNullOrWhiteSpace(tbPLastName.Text)
                || string.IsNullOrWhiteSpace(tbPGender.Text)
                || string.IsNullOrWhiteSpace(tbPAddress.Text)
                || string.IsNullOrWhiteSpace(tbPDateOfBirth.Text)
                || string.IsNullOrWhiteSpace(tbPContactNum.Text)
            )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            var patientData = new
            {
                PFirstName = tbPFirstName.Text,
                PLastName = tbPLastName.Text,
                PGender = tbPGender.Text,
                PAddress = tbPAddress.Text,
                PDateOfBirth = tbPDateOfBirth.Text,
                PContactNum = tbPContactNum.Text
            };

            string json = JsonConvert.SerializeObject(patientData);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(
                    "http://localhost/jenApi/Patient.php",
                    content
                );
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Patient added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
