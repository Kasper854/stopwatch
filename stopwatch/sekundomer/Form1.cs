using System;
using System.Drawing;
using System.Windows.Forms;

namespace sekundomer
{
    public partial class Form1 : Form
    {
        DateTime date1 = new DateTime(0, 0);
        Form topMostForm;
        Label textTimer;
        Button resetTimer;
        Button saveTime;
        static int index = 0;
        public Form1()
        {
            InitializeComponent();
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            
           
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            date1 = date1.AddSeconds(1);
            textTimer.Text = date1.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {

                topMostForm = new Form();
                topMostForm.Size = new Size(15,90);//15 90
                topMostForm.StartPosition = FormStartPosition.Manual;
                topMostForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                textTimer = new Label();
                textTimer.Font = new Font("Arial",15, FontStyle.Bold);
                textTimer.Location = new Point(17, 0);
                saveTime = new Button();
                saveTime.Size = new Size(45, 25);
                saveTime.Location = new Point(10, 23);
                saveTime.Text = "Save";
                saveTime.FlatAppearance.BorderSize = 0;
                saveTime.FlatStyle = FlatStyle.Flat;
                saveTime.BackColor = Color.Aquamarine;
                resetTimer = new Button();
                resetTimer.Size = new Size(45, 25);
                resetTimer.Location = new Point(65, 23);
                resetTimer.Text = "Reset";
                resetTimer.FlatAppearance.BorderSize = 0;
                resetTimer.FlatStyle = FlatStyle.Flat;
                resetTimer.BackColor = Color.Red;




            saveTime.Click += SaveTime_Click;
                resetTimer.Click += ResetTimer_Click;

                topMostForm.Controls.Add(textTimer);
              
                topMostForm.Controls.Add(resetTimer);
                topMostForm.Controls.Add(saveTime);
                topMostForm.TopMost = true;
               
                topMostForm.Show();
               

            if(timer1.Enabled==true)
            {
                timer1.Stop();
                timer1.Enabled = false;    
            }
            else
            {
                timer1.Interval = 1000;
                button1.Enabled = false;
                timer1.Enabled = true;
                timer1.Start();
            
            }
            topMostForm.FormClosed += TopMostForm_FormClosed;
        }

        private void ResetTimer_Click(object sender, EventArgs e)
        {
            date1 = new DateTime(0, 0);
            textTimer.Text = "00:00:00";
            
        }

        private void SaveTime_Click(object sender, EventArgs e)
        {
            index++;
            comboBox1.Items.Add(index + " | " + textTimer.Text);
        }

        private void TopMostForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            textTimer.Text = "0";
            timer1.Enabled = false;
            button1.Enabled = true;
            date1 = new DateTime(0, 0);
        }

  
    }
}
