using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace TargetController
{
    public class SplitTime : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime timeHit;
        private Duration timeDuration;
        private string targetID;
        private string sensorReading;
        private string split
        {
            get
            {
                return timeDuration.TimeSpan.TotalSeconds.ToString();
            }
            set
            {
                split = value.ToString();
            }
        }

        

        public DateTime TimeHit
        {
            get { return timeHit; }
            set
            {
                timeHit = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        public Duration TimeDuration
        {
            get { return timeDuration; }
            set
            {
                timeDuration = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        public string Split
        {
            get { return split; }
            set
            {
                split = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        public string TargetID
        {
            get { return targetID; }
            set
            {
                targetID = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        public string SensorReading
        {
            get { return sensorReading; }
            set
            {
                sensorReading = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
