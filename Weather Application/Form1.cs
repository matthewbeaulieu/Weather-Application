using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather_Application
{
    public partial class Form1 : Form
    {
        string Weather;
        string Tempature;
        string wind;
        string Humidity;
        public Form1()
        {
            InitializeComponent();
           
        }
        public void GetWeatherData(string Location)
        {
            var Clinet = new RestClient($"https://wttr.in/{WebUtility.UrlEncode(Location)}?format=%C+%T+%w+%h");
            var request = new RestRequest();
            request.AddParameter("Method", "get");

            var response = Clinet.Execute(request);

            if (response.IsSuccessful)
            {
                string[] WeatherParameters = Regex.Split(response.Content, " ");
                
            }
            else
            {
                MessageBox.Show("Error" + response.StatusCode);
            }
        }
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (LocationTextBox.Text != "")
            {
                try
                {
                    GetWeatherData(LocationTextBox.Text);
                } 
                catch (Exception)
                {
                    Console.WriteLine("ERROR");
                }
            }
        }
    }
}
