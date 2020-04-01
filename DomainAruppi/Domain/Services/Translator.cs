using Domain.Domain.Entities;
using DomainAruppi.Domain.Entities;
using GoogleTranslateFreeApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAruppi.Domain.Services
{
    public class TranslatorText
    {       


        public static async System.Threading.Tasks.Task<MoreInfo> Translate (MoreInfo moreInfo)
        {
            try
            {
                if (moreInfo.synopsis != null)
                    moreInfo.synopsis = await TranslateText(moreInfo.synopsis);

                if (moreInfo.background != null)
                    moreInfo.background = await TranslateText(moreInfo.background);

                if (moreInfo.broadcast != null && !moreInfo.broadcast.Contains("Unknown"))
                {
                    string[] broadCas = moreInfo.broadcast.Split(new string[] { " " }, StringSplitOptions.None);
                    moreInfo.broadcast = await (TranslateText(broadCas[0])) + " " + broadCas[broadCas.Length - 2] + " " + broadCas[broadCas.Length - 1];
                }
                else if (moreInfo.broadcast != null && moreInfo.broadcast.Contains("Unknown"))
                {
                    string[] broadCas = moreInfo.broadcast.Split(new string[] { " " }, StringSplitOptions.None);
                    moreInfo.broadcast = await (TranslateText(broadCas[0]));
                }

                if (moreInfo.genres != null)
                    moreInfo.genres = await TranslateGenres(moreInfo.genres);

                return moreInfo;
            }catch (Exception ex)
            {
                throw ex;
            }
        }


        public async static System.Threading.Tasks.Task<string> TranslateText(string text)
        {
            if (text.ToLower().Contains("mondays"))
                text = "monday";
            if (text.ToLower().Contains("tuesdays"))
                text = "tuesday";
            if (text.ToLower().Contains("wednesdays"))
                text = "wednesday";
            if (text.ToLower().Contains("thursdays"))
                text = "thursday";
            if (text.ToLower().Contains("fridays"))
                text = "monday";
            if (text.ToLower().Contains("saturdays"))
                text = "saturday";
            if (text.ToLower().Contains("sundays"))
                text = "sunday";

            var translator = new GoogleTranslator();

            Language from = Language.English;
            Language to = GoogleTranslator.GetLanguageByName("Spanish");

            TranslationResult result = await translator.TranslateLiteAsync(text, from, to);

            text = result.MergedTranslation;


            return text;

        }

        public async static System.Threading.Tasks.Task<List<Genre>> TranslateGenres(List<Genre> genres)
        {
            List<Genre> genresNew = new List<Genre>();

            foreach(var item in genres)
            {
                var translator = new GoogleTranslator();

                Language from = Language.English;
                Language to = GoogleTranslator.GetLanguageByName("Spanish");

                TranslationResult result = await translator.TranslateLiteAsync(item.name, from, to);

                item.name = result.MergedTranslation;

                genresNew.Add(item);
            } 

            return genresNew;

        }
        public async static System.Threading.Tasks.Task<List<Anime>> TranslateAnime(List<Anime> anime)
        {
            List<Anime> animeNew = new List<Anime>();

            foreach (var item in anime)
            {
                var translator = new GoogleTranslator();

                Language from = Language.English;
                Language to = GoogleTranslator.GetLanguageByName("Spanish");

                TranslationResult result = await translator.TranslateLiteAsync(item.synopsis, from, to);

                item.synopsis = result.MergedTranslation;

                animeNew.Add(item);
            }

            return animeNew;

        }
    }
}
