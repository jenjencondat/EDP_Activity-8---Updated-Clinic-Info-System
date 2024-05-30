using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace clinicinfosys
{
    public partial class AddDoctor : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public AddDoctor()
        {
            InitializeComponent();
        }

        private async void btAdd_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (
                string.IsNullOrWhiteSpace(tbDFirstName.Text)
                || string.IsNullOrWhiteSpace(tbDLastName.Text)
                || string.IsNullOrWhiteSpace(tbGender.Text)
                || string.IsNullOrWhiteSpace(tbDSpecialization.Text)
                || string.IsNullOrWhiteSpace(tbAddress.Text)
                || string.IsNullOrWhiteSpace(tbBirthdate.Text)
                || string.IsNullOrWhiteSpace(tbDContactNum.Text)
            )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            var doctorData = new
            {
                DFirstName = tbDFirstName.Text,
                DLastName = tbDLastName.Text,
                gender = tbGender.Text,
                DSpecialization = tbDSpecialization.Text,
                address = tbAddress.Text,
                birthdate = tbBirthdate.Text,
                DContactNum = tbDContactNum.Text
            };

            string json = JsonConvert.SerializeObject(doctorData);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(
                    "http://localhost/jenApi/Doctor.php",
                    content
                );
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Doctor added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
