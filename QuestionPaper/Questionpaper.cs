using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuestionPaper
{
    public partial class Questionpaper : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Record.mdf;Integrated Security=True;User Instance=True");
                
        public Questionpaper()
       
        {
            InitializeComponent();
        }

        private void buttonsearch_Click(object sender, EventArgs e)
        {
            searchfunction();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            if (textBoxdate.Text == "")
            {
                MessageBox.Show("Please Enter a Date of Question Paper.", "Enter Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxdate.Focus();
                textBoxdate.BackColor = Color.Red;
                return;

            }
            
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int width = 420;
            int inc = 50;
            e.Graphics.DrawImage(Properties.Resources.wall, 12, 12, 800, 1125);
            e.Graphics.DrawString("Subject. " + textBoxSubject.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(12, 230));
            e.Graphics.DrawString("Class. " + textBoxclass.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(500, 230));

            e.Graphics.DrawString("Time." + textBoxtime.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(12, 280));
            e.Graphics.DrawString("Marks. " + textBoxmarks.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(500, 280));
            ///e.Graphics.DrawImage(
            e.Graphics.DrawString("Semester. " + textBoxsemester.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(12, 338));
            e.Graphics.DrawString("Date. " + textBoxdate.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(500, 338));

            e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, 350));
            e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, 355));
            if (index == "6")
            {
                width = 420;
                e.Graphics.DrawString("Q No.1: " + textBoxQno1.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.2: " + textBoxQno2.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.3: " + textBoxQno3.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.4: " + textBoxQno4.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.5: " + textBoxQno5.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.6: " + textBoxQno6.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, width));
                e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, ++width));
                width = width + inc;
                e.Graphics.DrawString("Best of Luck for Paper!", new Font("Arial (Body CS)", 16, FontStyle.Underline), Brushes.Black, new Point(270, width));
            }
            else if (index == "7")
            {
                width = 420;
                e.Graphics.DrawString("Q No.1: " + textBoxQno1.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.2: " + textBoxQno2.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.3: " + textBoxQno3.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.4: " + textBoxQno4.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.5: " + textBoxQno5.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.6: " + textBoxQno6.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.7: " + textBoxQno7.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;

                e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, width));
                e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, ++width));
                width = width + inc;
                e.Graphics.DrawString("Best of Luck for Paper!", new Font("Arial (Body CS)", 16, FontStyle.Underline), Brushes.Black, new Point(270, width));




            }

            else if (index == "8")
            {
                width = 420;

                e.Graphics.DrawString("Q No.1: " + textBoxQno1.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.2: " + textBoxQno2.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.3: " + textBoxQno3.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.4: " + textBoxQno4.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.5: " + textBoxQno5.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.6: " + textBoxQno6.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.7: " + textBoxQno7.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.8: " + textBoxQno8.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;




                e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, width));
                e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, ++width));
                width = width + inc;
                e.Graphics.DrawString("Best of Luck for Paper!", new Font("Arial (Body CS)", 16, FontStyle.Underline), Brushes.Black, new Point(270, width));







            }
            else if (index == "9")
            {
                width = 420;
                e.Graphics.DrawString("Q No.1: " + textBoxQno1.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;

                e.Graphics.DrawString("Q No.2: " + textBoxQno2.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.3: " + textBoxQno3.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.4: " + textBoxQno4.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.5: " + textBoxQno5.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.6: " + textBoxQno6.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.7: " + textBoxQno7.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.8: " + textBoxQno8.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.9: " + textBoxQno9.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;




                e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, width++));
                e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, ++width));
                width = width + inc;
                e.Graphics.DrawString("Best of Luck for Paper!", new Font("Arial (Body CS)", 16, FontStyle.Underline), Brushes.Black, new Point(270, 900));



            }


            else if (index == "10")
            {

                width = 420;

                e.Graphics.DrawString("Q No.1: " + textBoxQno1.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;

                e.Graphics.DrawString("Q No.2: " + textBoxQno2.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.3: " + textBoxQno3.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.4: " + textBoxQno4.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.5: " + textBoxQno5.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.6: " + textBoxQno6.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.7: " + textBoxQno7.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.8: " + textBoxQno8.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.9: " + textBoxQno9.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));
                width = width + inc;
                e.Graphics.DrawString("Q No.10: " + textBoxQno10.Text, new Font("Arial (Body CS)", 16, FontStyle.Bold), Brushes.Black, new Point(20, width));

                width = width + inc;


                e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, width++));
                e.Graphics.DrawString("__________________________________________________________________________________________________________________________________________", new Font("Arial (Body CS)", 20, FontStyle.Bold), Brushes.Black, new Point(-4, ++width));
                width = width + inc;
                e.Graphics.DrawString("Best of Luck for Paper!", new Font("Arial (Body CS)", 16, FontStyle.Underline), Brushes.Black, new Point(270, width));







            }



            else
            {

              
            }

        }

        private void textBoxdate_TextChanged(object sender, EventArgs e)
        {
            textBoxdate.BackColor = Color.Black;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want to Update This Question Paper", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                try {

                    String sql = "update Questions set subject='" + textBoxSubject.Text + "',class='" + textBoxclass.Text + "',time='" + textBoxtime.Text + "',marks='" + textBoxmarks.Text + "', part='" + textBoxsemester.Text + "',qno1='" + textBoxQno1.Text + "',qno2='" + textBoxQno2.Text + "',qno3='" + textBoxQno3.Text + "',qno4='" + textBoxQno4.Text + "',qno5='" + textBoxQno5.Text + "',qno6='" + textBoxQno6.Text + "' ,qno7='" + textBoxQno7.Text + "',qno8='" + textBoxQno8.Text + "',qno9='" + textBoxQno9.Text + "',qno10='" + textBoxQno10.Text + "' where id='" + textBoxID.Text + "'";
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();

                    da.Fill(DS);
                    conn.Close();
                    MessageBox.Show("Data is Update Successful", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
                    catch (Exception ee) {
                    MessageBox.Show(ee.Message);
                    return;
                }
            
            
            }
        }
        String index = "";
        private void textBoxID_TextChanged(object sender, EventArgs e)
        {

            try
            {
                String sql = "Select subject,class,time,marks,part,qno1,qno2,qno3,qno4,qno5,qno6,qno7,qno8,qno9,qno10,no from Questions where id='" + textBoxID.Text + "'";

                // String sql = "insert into Questions(ID,subject,class,time,marks,part,qno1,qno2,qno3,qno4,qno5,qno6) values('" + textBoxID.Text + "','" + textBoxSubject.Text + "','" + textBoxclass.Text + "','" + textBoxtime.Text + "','" + textBoxmarks.Text + "','" + textBoxsemester.Text + "','" + textBoxQno1.Text + "','" + textBoxQno2.Text + "','" + textBoxQno3.Text + "','" + textBoxQno4.Text + "','" + textBoxQno5.Text + "','" + textBoxQno6.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();

                da.Fill(DS);
                textBoxSubject.Text = DS.Tables[0].Rows[0][0] + "";
                textBoxclass.Text = DS.Tables[0].Rows[0][1] + "";
                textBoxtime.Text = DS.Tables[0].Rows[0][2] + "";
                textBoxmarks.Text = DS.Tables[0].Rows[0][3] + "";
                textBoxsemester.Text = DS.Tables[0].Rows[0][4] + "";
                textBoxQno1.Text = DS.Tables[0].Rows[0][5] + "";
                textBoxQno2.Text = DS.Tables[0].Rows[0][6] + "";
                textBoxQno3.Text = DS.Tables[0].Rows[0][7] + "";
                textBoxQno4.Text = DS.Tables[0].Rows[0][8] + "";
                textBoxQno5.Text = DS.Tables[0].Rows[0][9] + "";
                textBoxQno6.Text = DS.Tables[0].Rows[0][10] + "";

                textBoxQno7.Text = DS.Tables[0].Rows[0][11] + "";
                textBoxQno8.Text = DS.Tables[0].Rows[0][12] + "";
                textBoxQno9.Text = DS.Tables[0].Rows[0][13] + "";
                textBoxQno10.Text = DS.Tables[0].Rows[0][14] + "";
                index = DS.Tables[0].Rows[0][15] + "";
                conn.Close();
            }
            catch (Exception ex)
            {
                return;
            }

        }

        public void searchfunction() {
            try
            {

                String sql = "Select subject,class,time,marks,part,qno1,qno2,qno3,qno4,qno5,qno6,qno7,qno8,qno9,qno10,no from Questions where id='" + textBoxID.Text + "'";

                // String sql = "insert into Questions(ID,subject,class,time,marks,part,qno1,qno2,qno3,qno4,qno5,qno6) values('" + textBoxID.Text + "','" + textBoxSubject.Text + "','" + textBoxclass.Text + "','" + textBoxtime.Text + "','" + textBoxmarks.Text + "','" + textBoxsemester.Text + "','" + textBoxQno1.Text + "','" + textBoxQno2.Text + "','" + textBoxQno3.Text + "','" + textBoxQno4.Text + "','" + textBoxQno5.Text + "','" + textBoxQno6.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();

                da.Fill(DS);
                textBoxSubject.Text = DS.Tables[0].Rows[0][0] + "";
                textBoxclass.Text = DS.Tables[0].Rows[0][1] + "";
                textBoxtime.Text = DS.Tables[0].Rows[0][2] + "";
                textBoxmarks.Text = DS.Tables[0].Rows[0][3] + "";
                textBoxsemester.Text = DS.Tables[0].Rows[0][4] + "";
                textBoxQno1.Text = DS.Tables[0].Rows[0][5] + "";
                textBoxQno2.Text = DS.Tables[0].Rows[0][6] + "";
                textBoxQno3.Text = DS.Tables[0].Rows[0][7] + "";
                textBoxQno4.Text = DS.Tables[0].Rows[0][8] + "";
                textBoxQno5.Text = DS.Tables[0].Rows[0][9] + "";
                textBoxQno6.Text = DS.Tables[0].Rows[0][10] + "";

                textBoxQno7.Text = DS.Tables[0].Rows[0][11] + "";
                textBoxQno8.Text = DS.Tables[0].Rows[0][12] + "";
                textBoxQno9.Text = DS.Tables[0].Rows[0][13] + "";
                textBoxQno10.Text = DS.Tables[0].Rows[0][14] + "";
                index = DS.Tables[0].Rows[0][15] + "";
                conn.Close(); //conn.Close();
                //MessageBox.Show("Data is Inserted in Database Successfully", "Succeessful", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
                textBoxID.Focus();
                MessageBox.Show("This Question Paper is not in Database ", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBoxID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {

                searchfunction();
            }
        }
    }
}
