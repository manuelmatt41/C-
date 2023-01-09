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
        private readonly string playText = "Play";
        private readonly string pauseText = "Pause";

        private bool showImages = false;
        public bool ShowImages { get => showImages; set => showImages = value; }

        private int seconds = 0;
        private int minutes = 0;

        public bool IsPause { get => btnPlay.Text == pauseText; }

        public event EventHandler PlayClick;
        public event EventHandler DesbordaTiempo;

        public MultimediaDisplayButtons()
        {
            InitializeComponent();
        }

        private void ChangeText(object sender, EventArgs e)
        {
            btnPlay.Text = IsPause ? playText : pauseText;

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

