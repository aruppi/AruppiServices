﻿using System;
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
        public async Task<object> Schedule(string day)
        {
            var programacion = await _client.Programacion(day);

            var day1 = await MapeoService.MapOldSchedule(programacion, day);

            try
            {
                foreach (var item in day1.day)
                    item.genres = await TranslatorText.TranslateGenres(item.genres);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return day1;
        }

        [HttpGet]
        public MoreInfo MoreInfo(string id)
        {
            if (id != null)
            {
                MoreInfo moreInfo = _client.MoreInfo(ref id);

                moreInfo.characters = _client.Characters(id);

                moreInfo.pictures = _client.Pictures(id);
                try
                {
                    moreInfo = (TranslatorText.Translate(moreInfo)).Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return moreInfo;
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        public MoreInfo MovieInfo(string id)
        {
            if (id != null)
            {
                try
                {
                    MoreInfo moreInfo = _client.MovieInfo(id);

                    moreInfo.characters = _client.Characters(id);

                    moreInfo.pictures = _client.Pictures(id);
                    try
                    {
                        moreInfo = (TranslatorText.Translate(moreInfo)).Result;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return moreInfo;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public object News()
        {

            var news = _client.NewsAnime();

            return news;
        }
        [HttpGet]
        public Wallpapers Wallpapers(string tag = "samurai", int pag = 0)
        {
            Wallpapers images = _client.Wallpapers(tag, pag);

            return images;
        }

        [HttpGet]
        public Seasons Season(string year, string seasons)
        {
            Seasons animes = _client.Seasons(seasons, year);

            return animes;
        }
        [HttpGet]
        public Ivoox Ivoox()
        {
            Ivoox ivox = _client.IvooxClient();

            return ivox;
        }
        [HttpGet]
        public ListEpisodesAnime GetAnime(string name, int numPag = 1)
        {

            ListEpisodesAnime episodes = _clientAnime.GetAllEpisodes(ref name, numPag);


            return episodes;
        }
        [HttpGet]
        public VideoAnime GetEpisode(string name, int numCap)
        {

            VideoAnime episodes = _clientAnime.GetEpisode(name, numCap);


            return episodes;
        }
        [HttpGet]
        public LastEpisodesAdd GetLastEpisodes()
        {
            return _clientAnime.GetEpisodeFlv();

        }

        [HttpGet]
        public SearchAnimeFlv SearchAnimeFlv(string anime)
        {
            return _clientAnime.SearchAnimeFlv(anime);

        }

        [HttpGet]
        public SearchBuscadorAnime SearchBuscadorAnime(string anime)
        {
            return _clientAnime.SearchBuscadorAnime(anime);
        }

        [HttpGet]
        public SerachServer SearchServersFlv(string id)
        {
            SerachServer server = new SerachServer();
            server.servers = new List<ServerFlv>();
            var servers = _clientAnime.SerachServerFlv(id);

            foreach (var item in servers.servers)
            {

                //if (item.server.Equals("natsuki"))
                //    item.url = _clientAnime.TakeCorrectUrl(item.code.Replace("embed", "check")).file;

                if (item.server.Equals("mega"))
                {

                    server.servers.Add(item);

                }

            }

            return server;

        }
        [HttpGet]
        public Movies SearchMoviesFlv(string pag)
        {
            return _clientAnime.SearchMoviesFlv(pag);

        }
        [HttpGet]
        public Ovas SearchOvasFlv(string pag)
        {
            return _clientAnime.SearchOvasFlv(pag);

        }
        [HttpGet]
        public Specials SearchSpecialsFlv()
        {
            return _clientAnime.SearchSpecialsFlv();

        }
        [HttpGet]
        public object GetLastMovies(int pag = 1)
        {
            return _clientAnime.GetLastMovies(pag);

        }
        [HttpGet]
        public object GetLastSpecials(int pag = 1)
        {
            return _clientAnime.GetLastSpecials(pag);

        }
        [HttpGet]
        public object GetLastOvas()
        {
            return _clientAnime.GetLastOvas();

        }
        [HttpGet]
        public object Rank(int num = 1)
        {
            return _client.Rank(num);

        }
        [HttpGet]
        public FutureSeasons FutureSeasons()
        {
            var response = _client.FutureSeasons();

            //foreach (var item in response.anime)
            //    item.genres = await TranslatorText.TranslateGenres(item.genres);


            return response;

        }
    }
}