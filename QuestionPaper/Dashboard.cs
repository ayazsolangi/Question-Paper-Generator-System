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
    public partial class Dashboard : Form
    {
        String index = "";
        public Dashboard()
        {
            InitializeComponent();
           // linkLabel1.Links.Add(0, 8, "D:\\Projects\\C- Sharp\\QuestionPaper\\QuizSystem\\Pakistan_history_MCQS.html");




            HideAll();







        }

        private void onlineQuizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addstudent obj = new addstudent();
            obj.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj = new Form1();
            obj.ShowDialog();
            //Application.Exit();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("Pakistan_history_MCQS.html");
            System.Diagnostics.Process.Start("D:\\Projects\\C- Sharp\\QuestionPaper\\QuizSystem\\Pakistan_history_MCQS.html");
            
        }

        private void admitSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admitslip obj = new Admitslip();
            obj.ShowDialog();

        }

        private void papersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Questionpaper obj = new Questionpaper();
            obj.ShowDialog();
        }


        
        private void buttonView_Click(object sender, EventArgs e)
        {
            if (index == "")
            {

                comboBox1.BackColor = Color.Red;
                return;

            }
            if (check() == 0)
            {

              return;
            }
            
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        int check() {

            if (textBoxclass.Text == "" || textBoxdate.Text == "" || textBoxmarks.Text == "" || textBoxQno1.Text == "" || textBoxQno2.Text == "" || textBoxQno3.Text == "" || textBoxQno4.Text == "" || textBoxQno5.Text == "" || textBoxQno6.Text == "" || textBoxsemester.Text == "" || textBoxSubject.Text == "" || textBoxtime.Text == "")
            {
                MessageBox.Show("Please Make sure All Textboxes are Filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;


            }
            else {
                return 1;
            
            }
        
        
        
        
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (check() == 0) {

                return;
            }
            printDocument1.Print();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (check() == 0)
            {

                return;
            }
            try {

                int nu = Convert.ToInt32(textBoxID.Text);
            
            }
            catch (Exception ee) {
                MessageBox.Show("Enter ID of Question Paper in Number only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxID.Focus();
                return;

            
            }
            
            DialogResult result = MessageBox.Show("Do You Want to Save Data in Database?", "Saved Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                try
                {
                    //SqlConnection conn = new SqlConnection("");
                    SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Record.mdf;Integrated Security=True;User Instance=True");
                    String sql = "insert into Questions(ID,subject,class,time,marks,part,qno1,qno2,qno3,qno4,qno5,qno6,qno7,qno8,qno9,qno10,no) values('" + textBoxID.Text + "','" + textBoxSubject.Text + "','" + textBoxclass.Text + "','" + textBoxtime.Text + "','" + textBoxmarks.Text + "','" + textBoxsemester.Text + "','" + textBoxQno1.Text + "','" + textBoxQno2.Text + "','" + textBoxQno3.Text + "','" + textBoxQno4.Text + "','" + textBoxQno5.Text + "','" + textBoxQno6.Text + "','" + textBoxQno7.Text + "','" + textBoxQno8.Text + "','" + textBoxQno9.Text + "','" + textBoxQno10.Text + "','" + index + "')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    MessageBox.Show("Data is Inserted in Database Successfully", "Succeessful", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
                catch (Exception ex) {
                    MessageBox.Show("Something Went Wrong"+ex.Message, "Run Time Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }

            
            }
            else
            {
                return;
            }
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

            else if(index=="8")
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


            else if (index == "10") {

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



            else {

                MessageBox.Show("This seems that there are no Questions entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.BackColor = Color.Red;
                return;
            
            }





        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void buttonsearch_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
         

        }





        void HideAll() {




            textBoxQno1.Hide();
            textBoxQno2.Hide();
            textBoxQno3.Hide();
            textBoxQno4.Hide();
            textBoxQno6.Hide();
            textBoxQno5.Hide();
            textBoxQno7.Hide();
            textBoxQno8.Hide();
            textBoxQno9.Hide();
            textBoxQno10.Hide();
            labelq1.Hide();
            labelq2.Hide();
            labelq3.Hide();
            labelq4.Hide();
            labelq5.Hide();
            labelq6.Hide();
            labelq7.Hide();
            labelq8.Hide();
            labelq9.Hide();
            labelq10.Hide();





        
        
        }



        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.BackColor = Color.White;
            index = comboBox1.Text;
            if (comboBox1.Text == "6") {
                HideAll();

                textBoxQno1.Visible = true;
                labelq1.Visible = true;

                textBoxQno2.Visible = true;
                labelq2.Visible = true;

                textBoxQno3.Visible = true;
                labelq3.Visible = true;

                textBoxQno4.Visible = true;
                labelq4.Visible = true;

                textBoxQno5.Visible = true;
                labelq5.Visible = true;

                textBoxQno6.Visible = true;
                labelq6.Visible = true;

            
            
            }


        else    if (comboBox1.Text == "7")
            {

                HideAll();
                textBoxQno1.Visible = true;
                labelq1.Visible = true;

                textBoxQno2.Visible = true;
                labelq2.Visible = true;

                textBoxQno3.Visible = true;
                labelq3.Visible = true;

                textBoxQno4.Visible = true;
                labelq4.Visible = true;

                textBoxQno5.Visible = true;
                labelq5.Visible = true;

                textBoxQno6.Visible = true;
                labelq6.Visible = true;

                textBoxQno7.Visible = true;
                labelq7.Visible = true;


            }

            else if (comboBox1.Text == "8")
            {
                HideAll();
                textBoxQno1.Visible = true;
                labelq1.Visible = true;

                textBoxQno2.Visible = true;
                labelq2.Visible = true;

                textBoxQno3.Visible = true;
                labelq3.Visible = true;

                textBoxQno4.Visible = true;
                labelq4.Visible = true;

                textBoxQno5.Visible = true;
                labelq5.Visible = true;

                textBoxQno6.Visible = true;
                labelq6.Visible = true;

                textBoxQno7.Visible = true;
                labelq7.Visible = true;

                textBoxQno8.Visible = true;
                labelq8.Visible = true;



            }


            else if (comboBox1.Text == "9")
            {
                HideAll();
                textBoxQno1.Visible = true;
                labelq1.Visible = true;

                textBoxQno2.Visible = true;
                labelq2.Visible = true;

                textBoxQno3.Visible = true;
                labelq3.Visible = true;

                textBoxQno4.Visible = true;
                labelq4.Visible = true;

                textBoxQno5.Visible = true;
                labelq5.Visible = true;

                textBoxQno6.Visible = true;
                labelq6.Visible = true;

                textBoxQno7.Visible = true;
                labelq7.Visible = true;

                textBoxQno8.Visible = true;
                labelq8.Visible = true;

                textBoxQno9.Visible = true;
                labelq9.Visible = true;

            }
            else if (comboBox1.Text == "10")
            {
                HideAll();
                textBoxQno1.Visible = true;
                labelq1.Visible = true;

                textBoxQno2.Visible = true;
                labelq2.Visible = true;

                textBoxQno3.Visible = true;
                labelq3.Visible = true;

                textBoxQno4.Visible = true;
                labelq4.Visible = true;

                textBoxQno5.Visible = true;
                labelq5.Visible = true;

                textBoxQno6.Visible = true;
                labelq6.Visible = true;

                textBoxQno7.Visible = true;
                labelq7.Visible = true;

                textBoxQno8.Visible = true;
                labelq8.Visible = true;

                textBoxQno9.Visible = true;
                labelq9.Visible = true;

                textBoxQno10.Visible = true;
                labelq10.Visible = true;







            }
            else {
                HideAll();
            }





        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

       
       


       
    }
}
