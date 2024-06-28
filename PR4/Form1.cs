﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR4
{
    public partial class Buses : Form
    {
        List<Bus<int, string, string, bool>> bus = new List<Bus<int, string, string, bool>>();
        ErrorProvider errorProvider = new ErrorProvider();
        public Buses()
        {
            InitializeComponent();
        }
        private async void AddBus()
        {
            if (int.TryParse(txt_BusNumber.Text, out int busNumber) &&
                !string.IsNullOrEmpty(txt_DriverNameAndSurname.Text) &&
                !string.IsNullOrEmpty(txt_RouteNumber.Text))
            {
                bool onTheRoute = chk_OnTheRoute.Checked;
                Bus<int, string, string, bool> newBus = new Bus<int, string, string, bool>(busNumber, txt_DriverNameAndSurname.Text, txt_RouteNumber.Text, onTheRoute);
                bus.Add(newBus);
                UpdateBusInformation();
            }
            else if (String.IsNullOrWhiteSpace(txt_BusNumber.Text))
            {
                errorProvider.SetError(txt_BusNumber, "Пожалуйста, введите корректные значения для номера автобуса.");
                await Task.Delay(2000);
                errorProvider.SetError(txt_BusNumber, "");
            }
            if (String.IsNullOrWhiteSpace(txt_DriverNameAndSurname.Text))
            {
                errorProvider.SetError(txt_DriverNameAndSurname, "Пожалуйста, введите корректные значения для имени водителя.");
                await Task.Delay(2000);
                errorProvider.SetError(txt_DriverNameAndSurname, "");
            }
            if (String.IsNullOrWhiteSpace(txt_RouteNumber.Text))
            {
                errorProvider.SetError(txt_RouteNumber, "Пожалуйста, введите корректные значения для номера маршрута.");
                await Task.Delay(2000);
                errorProvider.SetError(txt_RouteNumber, "");
            }
        }
        private void UpdateBusInformation()
        {
            buses_TextBox.Clear();
            foreach (Bus<int, string, string, bool> b in bus)
            {
                string status = b.OnTheRoute ? "На маршруте" : "В парке";
                string busInfo = $"Номер автобуса: {b.BusNumber}\r\nВодитель: {b.DriverNameAndSurname}\r\nМаршрут: {b.RouteNumber}\r\nСтатус: {status}\r\n";
                buses_TextBox.AppendText(busInfo + Environment.NewLine);
            }
        }
        private void btn_InThePark_Click(object sender, EventArgs e)
        {
            txt_SearchBuses.Clear();
            List<Bus<int, string, string, bool>> parkedBuses = bus.Where(b => !b.OnTheRoute).ToList();
            foreach (Bus<int, string, string, bool> b in parkedBuses)
            {
                string busInfo = $"Номер автобуса: {b.BusNumber}\r\nВодитель: {b.DriverNameAndSurname}\r\nМаршрут: {b.RouteNumber}\r\nСтатус: В парке";
                txt_SearchBuses.AppendText(busInfo + "\r\n\r\n");
            }
        }
        private void btn_OnTheRoute_Click(object sender, EventArgs e)
        {
            txt_SearchBuses.Clear();
            List<Bus<int, string, string, bool>> busesOnRoute = bus.Where(b => b.OnTheRoute).ToList();
            foreach (Bus<int, string, string, bool> b in busesOnRoute)
            {
                string busInfo = $"Номер автобуса: {b.BusNumber}\r\nВодитель: {b.DriverNameAndSurname}\r\nМаршрут: {b.RouteNumber}\r\nСтатус: На маршруте";
                txt_SearchBuses.AppendText(busInfo + "\r\n\r\n");
            }
        }
        private void btn_Close1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btn_Close2_Click(object sender, EventArgs e)
        {
            btn_Close1_Click(sender, e);
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_BusNumber.Clear();
            txt_DriverNameAndSurname.Clear();
            txt_RouteNumber.Clear();
            txt_SearchBuses.Clear();
            buses_TextBox.Clear();
            bus.Clear();
        }
        private void btn_AddBus_Click(object sender, EventArgs e)
        {
            AddBus();
        }
        private void btn_AddBus2_Click(object sender, EventArgs e)
        {
            btn_AddBus_Click(sender, e);
        }

        private void aboutTheProgram_Click(object sender, EventArgs e)
        {
            Form2 newF = new Form2();
            newF.Show();
        }
    }
}