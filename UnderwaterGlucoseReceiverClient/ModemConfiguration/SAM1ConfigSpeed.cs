using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient.ModemConfiguration
{
    public abstract class SAM1ConfigSpeed : INotifyPropertyChanged
    {
        protected int ValueMax = 6;
        protected int ValueMin = 4;
        protected string DisplayLetter = "";

        protected int val;
        public int Value
        {
            get { return val; }

            set
            {
                if (value < ValueMin)
                    val = ValueMin;
                else if (value > ValueMax)
                    val = ValueMax;
                else
                    val = value;

                OnPropertyChanged("Value");
            }
        }
        public string Text
        {
            get
            {
                string str = DisplayLetter;
                return str + Value.ToString();
            }
        }

        public SAM1ConfigSpeed(int i)
        {
        }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
