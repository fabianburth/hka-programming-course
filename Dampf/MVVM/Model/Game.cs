using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Dampf.MVVM.Model
{
    public class Game : INotifyPropertyChanged
    {
        public enum OSPlatform { Windows, Mac, Linux };

        private static long _count = 0;

        private readonly long _id;
        private string _title;
        private OSPlatform[] _platform;
        private string[] _genre;
        private bool _isDiscounted;
        private double _price;
        private double _actualPrice;
        private int _playTime;
        private string _imageSource;

        private string _playTimeValue;

        public Game(string title, OSPlatform[] platform, string[] genre, bool isDiscounted, double price)
        {
            _id = _count;
            _title = title;
            _platform = platform;
            _genre = genre;
            _isDiscounted = isDiscounted;
            _price = price;
            _actualPrice = 0.0;
            _playTime = Games.random.Next(0, 36000000);
            _playTimeValue = _playTime.ToString();

            _count++;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public long Id
        {
            get { return _id; }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public OSPlatform[] Platform
        {
            get { return _platform; }
            set
            {
                _platform = value;
                OnPropertyChanged("Platform");
            }
        }

       public string OSPlatformValue { get => string.Join(", ", _platform); }

        public string[] Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
                OnPropertyChanged("Genre");
            }
        }

        public string GenreValue { get => string.Join(", ", _genre); }

        public bool IsDiscounted
        {
            get { return _isDiscounted; }
            set
            {
                _isDiscounted = value;
                OnPropertyChanged("IsDiscounted");
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public string PriceValue { get => Price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " €"; }

        public double ActualPrice
        {
            get { return _actualPrice; }
            set
            {
                _actualPrice = value;
                OnPropertyChanged("ActualPrice");
            }
        }

        public string ActualPriceValue { get => ActualPrice.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " €"; }

        public int PlayTime
        {
            get { return _playTime; }
            set
            {
                _playTime = value;
                _playTimeValue = _playTime.ToString();
                OnPropertyChanged("PlayTime");
                OnPropertyChanged("PlayTimeValue");
            }
        }

        public string PlayTimeValue
        {
            // could add a playTimeFormatted and if this is initialized, we return the formatted time, this one otherwise
            // probably shouldnt use a random number for comparability and checkability 
            get { return _playTimeValue; }
        }

        public string ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; }
        }

    }
}
