using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public event EventHandler PlayClick;

        private InformationDisplay _informationButton = InformationDisplay.TEXT;
        public InformationDisplay InformationButton
        {
            get { return _informationButton; }
            set
            {
                if (!Enum.IsDefined(typeof(InformationDisplay), value))
                {
                    throw new InvalidEnumArgumentException();
                }

                _informationButton = value;
            }
        }

        private string _firstText = "Play";
        public string FirstText
        {
            get { return _firstText; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                _firstText = value;
            }
        }

        private string _secondText = "Pause";
        public string SecondText
        {
            get { return _secondText; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                _secondText = value;
            }
        }

        private string _timeFormat = "mm:ss";
        public string TimeFormat
        {
            get { return _timeFormat; }
            set
            {
                if (!IsCorrectFormat(value))
                {
                    throw new ArgumentException();
                }

                _timeFormat = value;
            }
        }

        private int _seconds;
        public int Seconds
        {
            get { return _seconds; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                _seconds = value;
            }
        }

        private bool _isPlaying= false;
        public bool IsPlaying { get { return _isPlaying; } }

        public MultimediaDisplayButtons()
        {
            InitializeComponent();
        }

        private void ButtonPlayInformationChange(object sender, EventArgs e)
        {
            switch (InformationButton)
            {
                case InformationDisplay.TEXT:
                    btnPlay.Text = btnPlay.Text == FirstText ? SecondText : FirstText;
                    break;
            }
            PlayClick?.Invoke(this, EventArgs.Empty);
            _isPlaying = !_isPlaying;
        }

        private bool IsCorrectFormat(string format)
        {
            switch (format)
            {
                case "mm:ss":
                    return true;
                case "HH:mm:ss":
                    return true;
                default:
                    return false;
            }
        }
    }

    public enum InformationDisplay
    {
        TEXT, IMAGE
    }
}

