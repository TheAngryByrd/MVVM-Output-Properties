using System.ComponentModel;
using System.Runtime.CompilerServices;
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
                OnPropertyChanged("Sentence");
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
                OnPropertyChanged("Sentence");
            }
        }

        public string FullName
        {
            get { return string.Format("Full Name: {0} {1}", FirstName, LastName); }
        }

        public string FavoriteColor
        {
            get { return _favoriteColor; }
            set
            {
                if (value == _favoriteColor) return;
                _favoriteColor = value;
                OnPropertyChanged();
                OnPropertyChanged("Sentence");
            }
        }

        public string Sentence
        {
            get { return string.Format("{0}'s favorite color is: {1}", FullName, FavoriteColor); }
        }
     
    }
}
