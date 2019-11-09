using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Entities;
using Domain.Domain.Services;
using DomainAruppi.Domain.Entities;
using DomainAruppi.Domain.Entities.episodes;
using DomainAruppi.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AruppiApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AruppiController : ControllerBase
    {
        IConfiguration _iconfiguration;
        private Client _client;
        private ClientAnime _clientAnime;

        public AruppiController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
            _client = new Client(_iconfiguration);
            _clientAnime = new ClientAnime(_iconfiguration);
        }
        
        [HttpGet]
        public object Schedule(string day)
        {           
            Schedule programacion = _client.Programacion();

            return MapeoService.MapSchedule(programacion,day);           
        }

        [HttpGet]
        public MoreInfo MoreInfo(string id)
        {            
            if (id != null)
            {
                MoreInfo moreInfo = _client.MoreInfo(ref id);

                moreInfo.characters = _client.Characters(id);

                moreInfo.pictures = _client.Pictures(id);

                moreInfo = (TranslatorText.Translate(moreInfo)).Result;

                return moreInfo;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public object News()
        {            

            var news =  _client.NewsAnime();

            return news;
        }
          [HttpGet]
        public Wallpapers Wallpapers(string tag = "samurai", int pag = 0)
        {
            Wallpapers images = _client.Wallpapers(tag,pag);

            return images;
        }
        
        [HttpGet]
        public Seasons Season(string year,string seasons)
        {
            Seasons animes = _client.Seasons(seasons,year);

            return animes;
        } 
        [HttpGet]
        public Ivoox Ivoox()
        {
            Ivoox ivox = _client.IvooxClient();

            return ivox;
        }
        [HttpGet]
        public ListEpisodesAnime GetAnime(string name,int numPag = 1)
        {

            ListEpisodesAnime episodes = _clientAnime.GetAllEpisodes(ref name,numPag);


            return episodes;
        }
        [HttpGet]
        public VideoAnime GetEpisode(string name, int numCap)
        {

            VideoAnime episodes = _clientAnime.GetEpisode( name, numCap);


            return episodes;
        }
        [HttpGet]
        public LastEpisodesAdd GetLastEpisodes()
        {
            return _clientAnime.GetEpisodeFlv();
          
        }
        [HttpGet]
        public LastEpisodesAdd GetLastAnimes()
        {
            return _clientAnime.GetLastAnimes();

        }
    }
}