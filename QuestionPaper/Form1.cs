using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuestionPaper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //linkLabel1.Links.Add(0, 8, "D:\\Projects\\C- Sharp\\QuestionPaper\\QuizSystem\\Pakistan_history_MCQS.html");
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            login();

        }

        private void UsernametextBox_TextChanged(object sender, EventArgs e)
        {
            UsernametextBox.BackColor = Color.White;
        }

        private void passwordtextBox_TextChanged(object sender, EventArgs e)
        {
            passwordtextBox.BackColor = Color.White;
        }



        private void passwordtextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                login();

            }
            else
            {

                // UsernametextBox.Text = "ghh";
            }

        }

        private void passwordtextBox_Enter(object sender, EventArgs e)
        {
            // UsernametextBox.Text = "ghghyuh";

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Windows.Forms.

            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void changedpasswordbutton_Click(object sender, EventArgs e)
        {
            Forgetpassword o = new Forgetpassword();
            o.ShowDialog();
        }
        //  }
        void login() {



            if (UsernametextBox.Text == "")
            {
                UsernametextBox.BackColor = Color.Red;
                MessageBox.Show("Enter a User Name in Textfield", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                UsernametextBox.Focus();
                return;
            }
            if (passwordtextBox.Text == "")
            {
                passwordtextBox.BackColor = Color.Red;
                MessageBox.Show("Enter a Password in Given Textfield.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordtextBox.Focus();
                return;

            }
            if (UsernametextBox.Text == "Admin" && passwordtextBox.Text == "Password")
            {
                Dashboard obj = new Dashboard();
                this.Hide();
                obj.ShowDialog();

            }
            else
            {
                MessageBox.Show("Invalid User Name or Password", "Information Does Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        
        
        
        
        
        }
    }
    }
//}
