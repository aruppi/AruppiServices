using Domain.Domain.Entities;
using DomainAruppi.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Domain.Domain.Services
{
    public class Client
    {
        IConfiguration _iconfiguration;

        public Client(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public async Task<ProgramacionOld> Programacion(string day)
        {
            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlBase").Value + $"schedule/{day}";

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                ProgramacionOld respuesta = new ProgramacionOld();


                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        HttpResponseMessage response = await AruppiClient.GetAsync(url);

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            respuesta = JsonConvert.DeserializeObject<ProgramacionOld>(jsonString);
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return respuesta;
                }
            }
        }

        public MoreInfo MoreInfo(ref string id)
        {

            using (HttpClient AruppiClient = new HttpClient())
            {
                string urlSearch = _iconfiguration.GetSection("Keys").GetSection("UrlBase").Value + string.Format("search/anime?q={0}", id);
                AruppiClient.BaseAddress = new Uri(urlSearch);

                StringBuilder path = new StringBuilder(urlSearch);



                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        HttpResponseMessage response = AruppiClient.GetAsync(urlSearch).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            id = (JsonConvert.DeserializeObject<Search>(jsonString)).results[0].mal_id.ToString();
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
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlBase").Value + string.Format("anime/{0}", id);


                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                MoreInfo respuesta = new MoreInfo();


                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            respuesta = JsonConvert.DeserializeObject<MoreInfo>(jsonString);
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return respuesta;
                }
            }
        }
        public object Rank(int num)
        {

            using (HttpClient AruppiClient = new HttpClient())
            {
                string urlSearch = _iconfiguration.GetSection("Keys").GetSection("UrlBase").Value + $"top/anime/{num}/upcoming";
                AruppiClient.BaseAddress = new Uri(urlSearch);

                StringBuilder path = new StringBuilder(urlSearch);



                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {


                        HttpResponseMessage response = AruppiClient.GetAsync(urlSearch).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            return JsonConvert.DeserializeObject<object>(jsonString);
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

        }
        public FutureSeasons FutureSeasons()
        {

            using (HttpClient AruppiClient = new HttpClient())
            {
                string urlSearch = _iconfiguration.GetSection("Keys").GetSection("UrlBase").Value + $"season/later";
                AruppiClient.BaseAddress = new Uri(urlSearch);

                StringBuilder path = new StringBuilder(urlSearch);



                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {


                        HttpResponseMessage response = AruppiClient.GetAsync(urlSearch).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            return JsonConvert.DeserializeObject<FutureSeasons>(jsonString);
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
        }
        public List<Character> Characters(string id)
        {
            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlBase").Value + string.Format("anime/{0}/characters_staff", id);

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                MoreInfo respuesta = new MoreInfo();

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            respuesta = JsonConvert.DeserializeObject<MoreInfo>(jsonString);
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return respuesta.characters;
                }
            }
        }
        public List<Picture> Pictures(string id)
        {
            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlBase").Value + string.Format("anime/{0}/pictures", id);

                AruppiClient.BaseAddress = new Uri(url);



                StringBuilder path = new StringBuilder(url);

                MoreInfo respuesta = new MoreInfo();


                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            respuesta = JsonConvert.DeserializeObject<MoreInfo>(jsonString);
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return respuesta.pictures;
                }
            }
        }
        public object NewsAnime()
        {
            using (HttpClient AruppiClient = new HttpClient())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Rss));

                string url = "https://somoskudasai.com/feed/";

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                Rss respuesta = new Rss();


                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            using (TextReader reader = new StringReader(jsonString))
                            {
                                respuesta = (Rss)serializer.Deserialize(reader);
                            }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return respuesta;
                }
            }
        }

        public Seasons Seasons(string seasons, string year)
        {
            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlBase").Value + string.Format("season/{0}/{1}", year, seasons);

                AruppiClient.BaseAddress = new Uri(url);


                StringBuilder path = new StringBuilder(url);

                Seasons respuesta = new Seasons();


                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            respuesta = JsonConvert.DeserializeObject<Seasons>(jsonString);
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return respuesta;
                }
            }
        }
        public Wallpapers Wallpapers(string tag, int pag)
        {
            using (HttpClient AruppiClient = new HttpClient())
            {
                string url = _iconfiguration.GetSection("Keys").GetSection("UrlBaseImages").Value + string.Format("{0}?type=json&search_tag={1}", pag, tag);

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                Wallpapers respuesta = new Wallpapers();


                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            respuesta = JsonConvert.DeserializeObject<Wallpapers>(jsonString);
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return respuesta;
                }
            }
        }

        public Ivoox IvooxClient()
        {
            using (HttpClient AruppiClient = new HttpClient())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Ivoox));

                string url = "https://www.ivoox.com/podcast-anitakume_fg_f1660716_filtro_1.xml";

                AruppiClient.BaseAddress = new Uri(url);

                StringBuilder path = new StringBuilder(url);

                Ivoox respuesta = new Ivoox();


                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(path.ToString())))
                {

                    try
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        HttpResponseMessage response = AruppiClient.GetAsync(url).Result;

                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode && response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                            using (TextReader reader = new StringReader(jsonString))
                            {
                                respuesta = (Ivoox)serializer.Deserialize(reader);
                            }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return respuesta;
                }
            }
        }

    }
}
