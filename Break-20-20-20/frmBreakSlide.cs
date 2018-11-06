using System;
using System.Windows.Forms;

namespace Break_20_20_20
{
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Timers;

    public partial class frmBreakSlide : Form
    {
        private int _sec = 60;
        public frmBreakSlide()
        {
            InitializeComponent();
        }

        private void frmBreakSlide_Load(object sender, EventArgs e)
        {
            Initialise();
        }
        private void Initialise()
        {
            this.Opacity = 0;
            this.Show();
            progressBar1.Value = 540;
            _sec = 60;
            controlPanel.Left = (controlPanel.Parent.Width - controlPanel.Width) / 2;
            controlPanel.Top = (controlPanel.Parent.Height - controlPanel.Height) / 2;
            fadeLblMsg.Text = @"    ";
            FormLoadTimer.Start();
        }

        private void FormLoadTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.025;
            }
            else
            {
                FormLoadTimer.Stop();
                progressBarTimer.Start();
                secondCountTimer.Start();
                fadeLblMsg.Text = @"Take a deep breath";
            }
        }

        private void frmBreakSlide_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Hide();
            }
        }

        private void progressBarTimer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 0)
            {
                progressBar1.Value -= 1;
            }
            else
            {
                progressBarTimer.Stop();
                this.Hide();
            }
        }

        private void secondCountTimer_Tick(object sender, EventArgs e)
        {
            if (_sec != 0)
            {
                _sec -= 1;
                lblCounter.Text = _sec + @"s";

                switch (_sec)
                {
                    case 55:
                        PlaySound();
                        fadeLblMsg.Text = @"Rub your palms and close your eyes with it";
                        break;
                    case 45:
                        PlaySound();
                        fadeLblMsg.Text = @"Focus your eyes on something at least 20 feet away";
                        break;
                    case 25:
                        PlaySound();
                        fadeLblMsg.Text = @"Stretch your arms and legs";
                        break;

                }

                if (_sec == 55)
                    fadeLblMsg.Text = @"Rub your palms and close your eyes with it";
                
            }
            else
            {
                _sec = 60;
                secondCountTimer.Stop();
                fadeLblMsg.Text = @"    ";
                PlaySound();
            }
        }

        private void frmBreakSlide_ResizeEnd(object sender, EventArgs e)
        {
            controlPanel.Left = (controlPanel.Parent.Width - controlPanel.Width) / 2;
            controlPanel.Top = (controlPanel.Parent.Height - controlPanel.Height) / 2;
        }

        private void MainTimeWatcher_Tick(object sender, EventArgs e)
        {
            Initialise();
        }

        private static void PlaySound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\notify.wav");
            player.Play();
        }
    }
}
