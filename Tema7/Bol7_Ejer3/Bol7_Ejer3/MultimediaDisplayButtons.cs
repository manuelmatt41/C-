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
                    throw new InvalidEnumArgumentException();
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
                    throw new InvalidEnumArgumentException();
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
                    throw new InvalidEnumArgumentException();
                }

                _timeFormat = value;
                lbTime.Text = new DateTime(600000).ToString(value);
            }
        }

        private int _minutes = 5;
        private int _seconds = 0;

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

