﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace марафон
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("8.04.2020 6:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            time.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString() + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int login = 0;
            string role = "";
            using (SqlConnection con = new
                SqlConnection(марафон.Properties.Settings.Default.MaraphonConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Count (*)FROM [User] Where Email=" + textBox1.Text + "AND Password=" + textBox2.Text + "";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    login = Convert.ToInt32(reader[0]);
                }
                con.Close();
                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandText = "SELECT Roleld FROM [User] WHERE Email=" + textBox1.Text + "AND password=" + textBox2.Text + "";
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    role = reader1[0].ToString();
                }
                con.Close();
            }
                    if(login == 1)
                    {
                File.WriteAllText("Resources/login.txt", textBox1.Text);
                if (role == "R")
                {
                    runner r = new runner();
                    r.Show();
                    this.Hide();
                }
                else
                {
                    if (role == "A")
                    {
                        admin a = new admin();
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        if(role == "c")
                        {
                            Coordinator coor = new Coordinator();
                            coor.Show();
                            this.Hide();
                        }
                    }
                }
                    }
                    else
                    {
                MessageBox.Show("Не правильный логин/пароль.");
                    }

        }
    }

}

