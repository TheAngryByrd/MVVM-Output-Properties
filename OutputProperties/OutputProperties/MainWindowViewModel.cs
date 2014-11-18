using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OutputProperties.Annotations;

namespace OutputProperties
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _favoriteColor;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value == _firstName) return;
                _firstName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value == _lastName) return;
                _lastName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }

        public string FullName
        {
            get { return string.Format("Full Name: {0} {1}", FirstName, LastName); }
        }

     
    }
}
