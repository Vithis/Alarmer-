using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarmer_
{
    public partial class Form1 : Form
    {

        Timer t = new Timer();
        System.Timers.Timer timer;
        System.Timers.Timer shortAlarm;
        SoundPlayer plei = new SoundPlayer();
        TimeSpan untilAlarm = new TimeSpan();
        TimeSpan untilShortAlarm = new TimeSpan();

        DateTime endtime;
        
            
        public Form1()
        {
            InitializeComponent();
                       

            string clock = DateTime.Now.ToString("HH:mm:ss");
            string date = DateTime.Now.ToString("dddd, MMMM d, yyyy");
            label2.Text = clock;
            button4.Text = date;
            label7.Text = "a\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na";
            label11.Text = "a\na\na\na\na\na\na\na\na\na\na";
            label6.BringToFront();
            label7.BringToFront();
            label9.BringToFront();
            button5.BringToFront();
            button6.BringToFront();
            button3.ForeColor = Color.SlateGray;
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            shortAlarm = new System.Timers.Timer();

            t.Interval = 1000;
            timer.Interval = 1000;
            shortAlarm.Interval = 1000;

            timer.Elapsed += Timer_Elapsed;
            shortAlarm.Elapsed += ShortAlarm_Elapsed;

            t.Tick += new EventHandler(this.updateClock);
            t.Start();


        }

        private void ShortAlarm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime timenow = DateTime.Now;
            untilShortAlarm = endtime - timenow;
            timeIsLeft.Text = untilShortAlarm.ToString(@"hh\:mm\:ss");


            if (timenow.Hour == endtime.Hour && timenow.Minute == endtime.Minute && timenow.Second == endtime.Second)
                {
                    shortAlarm.Stop();
                    plei.SoundLocation = @"D:\Music\abcde.wav";
                    plei.PlayLooping();
                    MessageBox.Show("Ya boiiii");
                }
           

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime timenow = DateTime.Now;
            DateTime userTime = dateTimePicker1.Value;
            


            try
            {
                if (dateTimePicker1.Value < DateTime.Now)
                {
                    untilAlarm = dateTimePicker1.Value - DateTime.Now;
                    untilAlarm += TimeSpan.FromDays(1);
                }

                else if (dateTimePicker1.Value > DateTime.Now)
                {
                    untilAlarm = dateTimePicker1.Value - DateTime.Now;
                }

                timeIsLeft.Text = untilAlarm.ToString(@"hh\:mm\:ss");
               
                
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
                       

            if(timenow.Hour == userTime.Hour && timenow.Minute == userTime.Minute && timenow.Second == userTime.Second)
            {
                try
                {
                    timer.Stop();
                    button3.Text = "Alarm!";
                    plei.SoundLocation = @"D:\Music\abcde.wav";
                    plei.PlayLooping();
                    
                    if(WindowState == FormWindowState.Minimized) {
                        WindowState = FormWindowState.Normal;
                    };
                    DialogResult result = MessageBox.Show("Alarm at " + userTime.ToString("HH:mm:ss") + " is ringing!\n Would you like to stop the Alarm now?", "Alarmer+", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if(result == DialogResult.Yes)
                    {
                        button3.ForeColor = Color.Red;
                        button3.Text = "Over!";
                        timeIsLeft.Text = "";
                        plei.Stop();
                        
                        
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateClock(object sender, EventArgs e)
        {
            string clock = DateTime.Now.ToString("HH:mm:ss");
            string date = DateTime.Now.ToString("dddd, MMMM d, yyyy");
            label2.Text = clock;
            button4.Text = date;

            

        
      

        }
              
        private void startButton_Click(object sender, EventArgs e)
        {
           

            

            if (dateTimePicker1.Value < DateTime.Now)
            {
                untilAlarm = dateTimePicker1.Value - DateTime.Now;
                untilAlarm += TimeSpan.FromDays(1);
            }

            else if(dateTimePicker1.Value > DateTime.Now)
            {
                untilAlarm = dateTimePicker1.Value - DateTime.Now;
            }

            timeIsLeft.Text = untilAlarm.ToString(@"hh\:mm\:ss");

            var shit = untilAlarm.TotalSeconds;
   
                 
                    timer.Start();

                    button3.ForeColor = System.Drawing.Color.LimeGreen;
                    button3.Text = "Started";
                }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            button3.ForeColor = System.Drawing.Color.Red;
            button3.Text = "Stopped";
            plei.Stop();
            
            
        }

        private void shortTimer_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.Visible = true;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            button8.Text = ("Selected timer is: " + listBox1.SelectedItem.ToString());
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

                switch (listBox1.SelectedIndex)
                {
                case 0:
                    endtime = DateTime.Now.AddMinutes(5);
                    break;
                case 1:
                    endtime = DateTime.Now.AddMinutes(10);
                    break;
                case 2:
                    endtime = DateTime.Now.AddMinutes(15);
                    break;
                case 3:
                    endtime = DateTime.Now.AddMinutes(20);
                    break;
                case 4:
                    endtime = DateTime.Now.AddMinutes(25);
                    break;
                case 5:
                    endtime = DateTime.Now.AddMinutes(30);
                    break;
                case 6:
                    endtime = DateTime.Now.AddMinutes(35);
                    break;
                case 7:
                    endtime = DateTime.Now.AddMinutes(40);
                    break;
                case 8:
                    endtime = DateTime.Now.AddMinutes(45);
                    break;
                case 9:
                    endtime = DateTime.Now.AddMinutes(50);
                    break;
                case 10:
                    endtime = DateTime.Now.AddMinutes(55);
                    break;
                case 11:
                    endtime = DateTime.Now.AddHours(1);
                    break;
            }

            untilShortAlarm = endtime - DateTime.Now;
            timeIsLeft.Text = untilShortAlarm.ToString(@"hh\:mm\:ss");
            shortAlarm.Start();
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            shortAlarm.Stop();
            plei.Stop();
        }
                
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.START_2));
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.START_1));
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.STOP_2));
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.STOP_1));
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            //button1.Size = new System.Drawing.
        }
    }
}
