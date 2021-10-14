using System;
using System.IO;
using System.Net;
using System.Text;

namespace Films.Model
{
    class OmdbApi
    {
        private string _BaseUrl = "https://www.omdbapi.com/?t=";
        private string _ApiKey = "2d10eac1";
        private string _SearchTitle;
        private Film _FindedFilm;

        public Film GetFilm
        {
            get
            {
                return _FindedFilm;
            }

        }
        public string SearcTtitle
        {
            set
            {
                _SearchTitle = value;
            }
        }

        public void RequestSearch()
        {
            StringBuilder _request = new StringBuilder(_BaseUrl);
            _request.Append(_SearchTitle);
            _request.Append("&apikey=");
            _request.Append(_ApiKey);
            WebRequest request = WebRequest.Create(_request.ToString());
            request.Method = "GET";
            request.Timeout = 10000;
            request.ContentType = "application/json";
            string result = string.Empty;

            try
            {
                using(var response = request.GetResponse())
                {
                    using(var stream = response.GetResponseStream())
                    {
                        using(var reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch(WebException e)
            {
                Console.WriteLine(e);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            if(result != "{\"Response\":\"False\",\"Error\":\"Movie not found!\"}")
            {
                ParseJson(result);
            }
        }

        private void ParseJson(string req)
        {
            string[] separatingStrings = { "\",\"", "\":\"" };
            _FindedFilm = new Film();
            var JsonArr = req.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < JsonArr.Length; i++)
            {
                switch(JsonArr[i])
                {
                    case "{\"Title":
                        _FindedFilm.Title = JsonArr[i + 1];
                        break;
                    case "Runtime":
                        _FindedFilm.Runtime = JsonArr[i + 1];
                        break;
                    case "Genre":
                        _FindedFilm.Genre = JsonArr[i + 1];
                        break;
                    case "Year":
                        _FindedFilm.YearOfFilm = Convert.ToInt32(JsonArr[i + 1]);
                        break;
                    case "Writer":
                        _FindedFilm.Writer = JsonArr[i + 1];
                        break;
                    case "Poster":
                        _FindedFilm.Poster = JsonArr[i + 1];
                        break;
                }
            }
        }
    }
}
