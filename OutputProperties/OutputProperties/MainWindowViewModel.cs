using System.Reactive.Linq;
using ReactiveUI;

namespace OutputProperties
{
    public class MainWindowViewModel : ReactiveObject
    {
        private string _firstName;
        private string _lastName;
        private string _favoriteColor;


        ObservableAsPropertyHelper<string> _fullName;
        public string FullName
        {
            get { return _fullName.Value; }
        }


        ObservableAsPropertyHelper<string> _sentence;
        public string Sentence
        {
            get { return _sentence.Value; }
        }
        public MainWindowViewModel()
        {
            this.WhenAnyValue(x => x.FirstName, x => x.LastName, (first, last) => new {first,last})
                .Select(name => string.Format("Full Name: {0} {1}", name.first, name.last))
                .ToProperty(this, x => x.FullName, out _fullName);

            this.WhenAnyValue(x => x.FullName, x => x.FavoriteColor, (full,color) => new {full,color})
                .Select(x => string.Format("{0}'s favorite color is: {1}", x.full, x.color))
                .ToProperty(this, x => x.Sentence, out _sentence);
        }

        public string FirstName
        {
            get { return _firstName; }
            set { this.RaiseAndSetIfChanged(ref _firstName, value); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { this.RaiseAndSetIfChanged(ref _lastName, value); }
        }

        public string FavoriteColor
        {
            get { return _favoriteColor; }
            set { this.RaiseAndSetIfChanged(ref _favoriteColor, value); }
        }

     
    }
}
