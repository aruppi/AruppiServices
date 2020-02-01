using DomainAruppi.Domain.Entities;
using DomainAruppi.Domain.Entities.episodes;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Domain.Domain.Services
{
    public class ClientAnime
    {
        IConfiguration _iconfiguration;

        public ClientAnime(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public ListEpisodesAnime GetAllEpisodes(ref string name, int numPag)
        {
            ListEpisodesAnime listEpisodesAnime = new ListEpisodesAnime();
            using (HttpClient AruppiClient = new HttpClient())
            {
                string urlSearch = _iconfiguration.GetSection("Keys").GetSection("UrlBase").Value + string.Format("search/anime?q={0}", name);
                AruppiClient.BaseAddress = new Uri(urlSearch);

                StringBuilder path = new StringBuilder(urlSearch);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {
                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(urlSearch).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            name = (JsonConvert.DeserializeObject<Search>(jsonString)).results[0].mal_id.ToString();
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            using (HttpClient AruppiClient = new HttpClient())
            {

                string urlSearch = _iconfiguration.GetSection("Keys").GetSection("UrlBase").Value + string.Format("anime/{0}/episodes/{1}", name, numPag);
                AruppiClient.BaseAddress = new Uri(urlSearch);

                StringBuilder path = new StringBuilder(urlSearch);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {
                    try
                    {

                        HttpResponseMessage response = AruppiClient.GetAsync(urlSearch).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            listEpisodesAnime = JsonConvert.DeserializeObject<ListEpisodesAnime>(jsonString);
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return listEpisodesAnime;
        }

        public VideoAnime GetEpisode(string name, int numCap)
        {
            VideoAnime episode = new VideoAnime();

            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlAnime").Value + string.Format("anime/{0}/{1}", name.Replace(' ', '-'), numCap);

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        episode = JsonConvert.DeserializeObject<VideoAnime>(jsonString);


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return episode;

        }

        public LastEpisodesAdd GetEpisodeFlv()
        {
            LastEpisodesAdd episode = new LastEpisodesAdd();

            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlFlv").Value + string.Format("LatestEpisodesAdded");

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        episode = JsonConvert.DeserializeObject<LastEpisodesAdd>(jsonString);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return episode;
        }
       
        public SearchAnimeFlv SearchAnimeFlv(string anime)
        {

            SearchAnimeFlv episode = new SearchAnimeFlv();

            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlFlv").Value + string.Format("Search/{0}", anime);

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        episode = JsonConvert.DeserializeObject<SearchAnimeFlv>(jsonString);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return episode;

        }
        public Movies SearchMoviesFlv(string pag = "1")
        {

            Movies movies = new Movies();

            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlFlv").Value + string.Format("Movies/default/{0}", pag);

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        movies = JsonConvert.DeserializeObject<Movies>(jsonString);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return movies;

        }
        public Ovas SearchOvasFlv(string pag = "1")
        {

            Ovas ovas = new Ovas();

            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlFlv").Value + string.Format("Ova/default/{0}", pag);

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        ovas = JsonConvert.DeserializeObject<Ovas>(jsonString);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return ovas;

        }
        public Specials SearchSpecialsFlv(string pag = "1")
        {

            Specials specials = new Specials();

            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlFlv").Value + string.Format("Special/default/{0}", pag);

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        specials = JsonConvert.DeserializeObject<Specials>(jsonString);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return specials;

        }
        public SerachServer SerachServerFlv(string id)
        {

            SerachServer servers = new SerachServer();

            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlFlv").Value + string.Format("GetAnimeServers/{0}", id);

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        servers = JsonConvert.DeserializeObject<SerachServer>(jsonString);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return servers;

        }
        public Natsuki TakeCorrectUrl(string url)
        {

            Natsuki servers = new Natsuki();

            using (HttpClient AruppiClient = new HttpClient())
            {               
                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        servers = JsonConvert.DeserializeObject<Natsuki>(jsonString);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return servers;

        }
        public object GetLastMovies(int pag = 1)
        {

            object specials = new Specials();

            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlFlv").Value + string.Format("Movies/added/{0}", pag);

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        specials = JsonConvert.DeserializeObject<object>(jsonString);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return specials;

        }
        public object GetLastSpecials(int pag = 1)
        {

            object specials = new Specials();

            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlFlv").Value + string.Format("Special/added/{0}", pag);

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        specials = JsonConvert.DeserializeObject<object>(jsonString);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return specials;

        }
        public object GetLastOvas(int pag = 1)
        {

            object specials = new Specials();

            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlFlv").Value + string.Format("OVA/added/{0}", pag);

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        specials = JsonConvert.DeserializeObject<object>(jsonString);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return specials;

        }
    }
}
