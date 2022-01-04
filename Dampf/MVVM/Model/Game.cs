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
        private string _imageSource;

        public Game(string title, OSPlatform[] platform, string[] genre, bool isDiscounted, double price)
        {
            _id = _count;
            _title = title;
            _platform = platform;
            _genre = genre;
            _isDiscounted = isDiscounted;
            _price = price;
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

        public string ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; }
        }

    }
}
