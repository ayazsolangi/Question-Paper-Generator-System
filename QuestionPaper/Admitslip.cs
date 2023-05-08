using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace QuestionPaper
{
    public partial class Admitslip : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Record.mdf;Integrated Security=True;User Instance=True");
        public Admitslip()
        {
            InitializeComponent();
        }
        String ID = "";
        private void buttonSearch_Click(object sender, EventArgs e){
            try
            {
               // photo = textBoxID.Text.ToString();
                String sql = "select Name, Class, Age, Image from Student where id='" + textBoxID.Text + "'";
                //String sql = "SELECT name, department, photo from studentrecord2 WHERE ID='" + textBoxID.Text + "'";
                byte[] img = null;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                      //  Namelabel.Text = "Name: " + ds.Tables[0].Rows[0][0] + "";
                        ////       Classlabel.Text="Class: "+ds.Tables[0].Rows[0][1] + "";
                        ////       DOBlabel.Text="Age: "+ds.Tables[0].Rows[0][2] + "";

                        Namelabel.Text = "Name: " + reader[0];
                        Classlabel.Text = "Class: " + reader[1];
                        DOBlabel.Text = "Age: " + reader[2];
                       // labelname.Text = reader[0] + "";
                        //labeldepartment.Text = reader[1] + "";
                       // labelrollno.Text = textBoxID.Text;
                       // labelissuecard.Text = dateTimePicker1.Text;
                        img = (byte[])reader[3];
                    }
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);

                    conn.Close();
                }
            }
            catch (Exception o)
            {
                conn.Close();
                MessageBox.Show(o.Message);

            }


        ////{
        ////    String sql="select Name, Class, Age, Image from Student where id='"+textBoxID.Text+"'";
        ////    SqlCommand cmd = new SqlCommand(sql, conn);
        ////    SqlDataAdapter da=new SqlDataAdapter(cmd);
        ////    try
        ////    {
        ////        ID = textBoxID.Text;
        ////        DataSet ds = new DataSet();
        ////        da.Fill(ds);
               
        ////        Namelabel.Text="Name: "+ds.Tables[0].Rows[0][0] + "";
        ////       Classlabel.Text="Class: "+ds.Tables[0].Rows[0][1] + "";
        ////       DOBlabel.Text="Age: "+ds.Tables[0].Rows[0][2] + "";


        ////    }
        ////    catch (Exception er) {
        ////        MessageBox.Show("This Student is not in Table...", "Could not Find", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        ////    }

            
        }
        private void buttonView_Click(object sender, EventArgs e)
        {
         printPreviewDialog1.Document = printDocument1;
         printPreviewDialog1.ShowDialog();
        
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
            }

       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            e.Graphics.DrawImage(Properties.Resources.frame, 30, 59, 624, 312);
            //            e.Graphics.DrawImage(Properties.Resources.frame, 30, 100, 501, 287);
            e.Graphics.DrawString(Namelabel.Text, new Font("Tahoma", 14, FontStyle.Bold), Brushes.Black, new Point(44, 190));

            e.Graphics.DrawString("Roll No: "+ID, new Font("Tahoma", 14, FontStyle.Bold), Brushes.Black, new Point(43, 234));

            e.Graphics.DrawString(Classlabel.Text, new Font("Tahoma", 14, FontStyle.Bold), Brushes.Black, new Point(43, 272));

            e.Graphics.DrawString(DOBlabel.Text, new Font("Tahoma", 14, FontStyle.Bold), Brushes.Black, new Point(43, 312));

            //e.Graphics.DrawImage(pictureBox2.Image, 142, 180, 507, 180);
            e.Graphics.DrawImage(pictureBox1.Image, 507, 180, 142, 180);
        
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
