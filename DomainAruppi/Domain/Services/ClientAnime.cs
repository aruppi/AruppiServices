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

        public LastAnimes GetLastAnimes()
        {

            LastAnimes episode = new LastAnimes();

            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlFlv").Value + string.Format("LatestAnimeAdded");

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        episode = JsonConvert.DeserializeObject<LastAnimes>(jsonString);

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
    }
}
