using System.Text.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace Films.Model
{
    class OmdbApi
    {
        private const string BASE_URL = "https://www.omdbapi.com/?t=";
        private const string API_KEY = "2d10eac1";
        private Film _findedFilm;

        public Film GetFilm
        {
            get => _findedFilm;
        }

        public void RequestSearch(string title)
        {
            WebRequest request = WebRequest.Create(BASE_URL + title + "&apikey=" + API_KEY);
            request.Method = "GET";
            request.Timeout = 10000;
            request.ContentType = "application/json";
            string result = string.Empty;

            try
            {
                using(var reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _findedFilm = null;

            if(result == "{\"Response\":\"False\",\"Error\":\"Movie not found!\"}")
            {
                MessageBox.Show("Film not founded", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            ParseJson(result);
        }

        private void ParseJson(string req)
        {
            _findedFilm = JsonSerializer.Deserialize<Film>(req);
        }
    }
}
