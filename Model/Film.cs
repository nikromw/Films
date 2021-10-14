using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Model
{
    class Film : INotifyPropertyChanged
    {
        public int? Id { get; set; }
        private string _Title, _Genre, _Writer, _Poster, _Runtime;
        private int _Year;
        private bool _IsFavorit = false;
        private Film item;

        public int? GetId
        {
            get
            {
                return Id;
            }
            set
            {
                value = value;
            }
        }

        public Film()
        { }
        public Film(Film item)
        {
            this.item = item;
        }
        
        public bool isFavorit
        {
            get
            {
                return _IsFavorit;
            }
            set
            {
                _IsFavorit = value;
            }
        }

        public string Runtime
        {
            get
            { return _Runtime; }
            set
            { _Runtime = value; }
        }
        public string Poster
        {
            get
            { return _Poster; }
            set
            { _Poster = value; }
        }

        public string Genre
        {
            get
            { return _Genre; }
            set
            { _Genre = value; }
        }
        public string Writer
        {
            get
            { return _Writer; }
            set
            { _Writer = value; }
        }
        public int YearOfFilm
        {
            get
            { return _Year; }
            set
            { _Year = value; }
        }
        public string Title
        {
            get
            { return _Title; }
            set
            { _Title = value; }
        }
        private bool IsFavorit
        {
            set
            {
                IsFavorit = value;
                OnPropertyChanged("IsFavorite");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
