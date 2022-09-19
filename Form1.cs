using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Counter.Properties;

namespace Counter
{
    public partial class Form1 : Form
    {
        private Timer mClock;
        private DateTime mGoal;
        private DateTime mStartMinor;

        private TimeSpan mMinorDuration;
        private bool isFirstPhase = true;
        private bool isFullScreen = false;
        private FormBorderStyle defaultFormBorderStyle;

        public Form1()
        {
            mClock = new Timer();
            mClock.Interval = 100;
            mClock.Tick += new EventHandler(TickDown);

            InitializeComponent();

            mMinorDuration = new TimeSpan(0, (int)Settings.Default.MinorTime, 1);

            lblTime.Font = new Font("Times New Roman", 200);
            if (Settings.Default.MajorTime < 10)
                lblTime.Text = "0" + Settings.Default.MajorTime.ToString() + ":00";
            else
                lblTime.Text = Settings.Default.MajorTime.ToString() + ":00";
            PositionLabel();

            this.MaximizeBox = false;
            BackColor = System.Drawing.Color.LimeGreen;

            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
        }

        // Position label in the center of a window
        private void PositionLabel()
        {
            var x = Width / 2 - lblTime.Width / 2;
            var y = Height / 2 - lblTime.Height / 2;
            lblTime.Location = new System.Drawing.Point(x, y);
        }

        private void TickDown(object sender, EventArgs eArgs)
        {
            if (sender != mClock)
                return;
            
            TimeSpan remainingTime;
            if (isFirstPhase)
            {
                remainingTime = mGoal - DateTime.UtcNow;
            }
            else
            {
                remainingTime = DateTime.UtcNow - mGoal;
            }
            
            if (remainingTime < TimeSpan.Zero)
            {
                mClock.Stop();
                mGoal = DateTime.UtcNow;

                isFirstPhase = false;
                BackColor = System.Drawing.Color.OrangeRed;
                mClock.Start();
            }
            else
            {
                lblTime.Text = GetTime(remainingTime);
                if (!isFirstPhase)
                {
                    if (remainingTime >= mMinorDuration)
                    {
                        ResetTimer();
                    }
                }
            }
        }

        public string GetTime(TimeSpan time)
        {
            var timeInString = "";
            var hour = time.Hours;
            var min = time.Minutes;
            var sec = time.Seconds;

            //timeInString = (hour < 10) ? "0" + hour.ToString() : hour.ToString() + ":";
            timeInString += ((min < 10) ? "0" + min.ToString() : min.ToString());
            timeInString += ":" + ((sec < 10) ? "0" + sec.ToString() : sec.ToString());
            return timeInString;  
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (mClock.Enabled)
            {
                ResetTimer();
            }
            else
            {
                mGoal = DateTime.UtcNow;
                mGoal = mGoal.AddMinutes((int)Settings.Default.MajorTime);
                //mGoal = mGoal.AddSeconds(5);
                isFirstPhase = true;

                mClock.Start();
                btnStart.Text = "Stop";
            }
        }

        private void ResetTimer()
        {
            mClock.Stop();
            btnStart.Text = "Start";

            if (Settings.Default.MajorTime < 10)
                lblTime.Text = "0" + Settings.Default.MajorTime.ToString() + ":00";
            else
                lblTime.Text = Settings.Default.MajorTime.ToString() + ":00";
            isFirstPhase = true;
            BackColor = System.Drawing.Color.LimeGreen;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                btnStart_Click(sender, e);
            } else if (e.KeyCode == Keys.F)
            {
                ToggleFullScreen();
            }
            else if (e.KeyCode == Keys.H)
            {
                MessageBox.Show("F - toggle fullscreen mode\n"
                    + "H - show help dialog\n"
                    + "S - start or stop countdown\n"
                    + "Ctrl+P - show preferences dialog",
                    "Keyboard shortcuts",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                if (mClock.Enabled)
                    return;

                decimal majTime = Settings.Default.MajorTime;
                decimal minTime = Settings.Default.MinorTime;

                FormSettings frmSettings = new FormSettings();
                frmSettings.ShowDialog();

                if (frmSettings.IsSaved)
                {
                    ResetTimer();
                    mMinorDuration = new TimeSpan(0, (int)Settings.Default.MinorTime, 1);
                }
                else
                {
                    Settings.Default.MajorTime = majTime;
                    Settings.Default.MinorTime = minTime;
                }

            }
        }

        private void ToggleFullScreen()
        {
            if (isFullScreen)
            {
                FormBorderStyle = defaultFormBorderStyle;
                WindowState = FormWindowState.Normal;
                lblTime.Font = new Font("Times New Roman", 200);
            }
            else
            {
                defaultFormBorderStyle = FormBorderStyle;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                lblTime.Font = new Font("Times New Roman", 300);
            }
            isFullScreen = !isFullScreen;
            PositionLabel();
        }
    }
}
