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
        public int Id { get; set; }

        public bool isFavorite { get; set; }

        public string Runtime { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public string Writer { get; set; }
        public int YearOfFilm { get; set; }
        public string Title { get; set; }
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
