﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Antivirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int viruses = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            string[] search = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.*");
            progressBar1.Maximum = search.Length;
            foreach (string item in search)
            {
                try
                {
                    StreamReader stream = new StreamReader(item);
                    string read = stream.ReadToEnd();
                    string[] virus = new string[] { "antivirus", "anti virus", "security", "secu", "avast antivirus", "antivirus gratuit", "free antivirus", "antivirus free", "firewall", "norton antivirus", "kaspersky internet ", "avg antivirus", "virus scan", "best free antivirus", "panda antivirus", "virus protection","VIRUSES", "INFECTED", "HACKED" };
                    foreach (string st in virus)
                    {
                        if (Regex.IsMatch(read, st))
                        {
                            MessageBox.Show("ALERT...!!! VIRUS DETECTED");
                            viruses += 1;
                            listBox1.Items.Add(item);
                            button3.Show();
                            label2.Text = "Virus Detected : " + viruses.ToString();
                        }
                        progressBar1.Increment(1);
                    }
                }
                catch
                {
                    string read = item;
                    string[] virus = new string[] { "antivirus", "anti virus", "security", "secu", "avast antivirus", "antivirus gratuit", "free antivirus", "antivirus free", "firewall", "norton antivirus", "kaspersky internet ", "avg antivirus", "virus scan", "best free antivirus", "panda antivirus", "virus protection", "VIRUSES", "INFECTED", "HACKED" };
                    foreach (string st in virus)
                    {
                        if (Regex.IsMatch(read, st))
                        {
                            viruses += 1;
                            listBox1.Items.Add(item);
                            button3.Show();
                            label2.Text = "Virus Detected : " + viruses.ToString();

                        }
                        progressBar1.Increment(1);
                    }
                }
            }
            if (viruses < 1)
                MessageBox.Show("NO VIRUS FOUND, YOU ARE SAFE....");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label1.Text = "Selected Location : " + folderBrowserDialog1.SelectedPath;
            viruses = 0;
            progressBar1.Value = 0;
            listBox1.Items.Clear();
            button2.Show();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            string removex = listBox1.Text;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Delete(this.listBox1.Text);
            viruses -= 1;
            label2.Text = "Virus Detected : " + viruses.ToString();
            listBox1.Items.Clear();
            MessageBox.Show("Selected Malware Successfully Removed!!!....NOW YOU ARE SAFE ^_^");
            progressBar1.Value = 0;
            button2.Hide();
            button3.Hide();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}