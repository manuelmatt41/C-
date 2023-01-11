using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bol7_Ejer3
{
    public partial class MultimediaDisplayButtons : UserControl
    {
        private readonly string PLAY_TEXT = "Play";
        private readonly string PAUSE_TEXT = "Pause";

        private bool showImages;
        public bool ShowImages { get => showImages; set => showImages = value; }

        private int seconds = 55;
        private int minutes = 0;

        private bool enabled;
        public new bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                btnPlay.Enabled = enabled;
            }
        }

        public bool IsPause { get => btnPlay.Text == PLAY_TEXT; }

        public event EventHandler PlayClick;
        public event EventHandler DesbordaTiempo;


        public MultimediaDisplayButtons()
        {
            InitializeComponent();
        }

        public void AddMinutes()
        {
            minutes++;
        }

        private void ChangeText(object sender, EventArgs e)
        {
            btnPlay.Text = IsPause ? PAUSE_TEXT : PLAY_TEXT;

            PlayClick?.Invoke(this, EventArgs.Empty);
        }

        private void TimeCount(object sender, EventArgs e)
        {
            if (!IsPause)
            {
                lblTime.Text = $"{minutes:00}:{seconds:00}";
                seconds++;
                //TODO No puede ser nunca negativo
                if (seconds > 59)
                {
                    seconds = 0;
                    DesbordaTiempo?.Invoke(this, EventArgs.Empty);
                }
                //Trace.WriteLine($"The time is {lblTime.Text}");
            }
        }
    }
}

