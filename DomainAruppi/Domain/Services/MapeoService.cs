using DomainAruppi.Domain.Entities;
using System.Collections.Generic;
using Domain.Domain.Entities;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace DomainAruppi.Domain.Services
{
    public class MapeoService
    {
        public static object MapSchedule(Schedule schedule, string day)
        {           
            Day programacion = new Day();
            programacion.day = new List<Series>();

            if (day.ToLower().Contains("monday"))
                foreach (var item in schedule.calender[0].monday)
                {                    
                    for (int i = 0; i < item.id.Count(); i++)
                    {
                        Series series = new Series();
                        series.image_url = item.poster[i];
                        series.mal_id = Convert.ToInt32(item.id[i]);
                        series.title = item.title[i];
                        programacion.day.Add(series);
                    }
                    
                }
            if (day.ToLower().Contains("tuesday"))
                foreach (var item in schedule.calender[0].tuesday)
                {
                    for (int i = 0; i < item.id.Count(); i++)
                    {
                        Series series = new Series();
                        series.image_url = item.poster[i];
                        series.mal_id = Convert.ToInt32(item.id[i]);
                        series.title = item.title[i];
                        programacion.day.Add(series);
                    }
                }
            if (day.ToLower().Contains("wednesday"))
                foreach (var item in schedule.calender[0].wednesday)
                {
                    for (int i = 0; i < item.id.Count(); i++)
                    {
                        Series series = new Series();
                        series.image_url = item.poster[i];
                        series.mal_id = Convert.ToInt32(item.id[i]);
                        series.title = item.title[i];
                        programacion.day.Add(series);
                    }
                }
            if (day.ToLower().Contains("thursday"))
                foreach (var item in schedule.calender[0].thursday)
                {
                    for (int i = 0; i < item.id.Count(); i++)
                    {
                        Series series = new Series();
                        series.image_url = item.poster[i];
                        series.mal_id = Convert.ToInt32(item.id[i]);
                        series.title = item.title[i];
                        programacion.day.Add(series);
                    }
                }
            if (day.ToLower().Contains("friday"))
                foreach (var item in schedule.calender[0].friday)
                {
                    for (int i = 0; i < item.id.Count(); i++)
                    {
                        Series series = new Series();
                        series.image_url = item.poster[i];
                        series.mal_id = Convert.ToInt32(item.id[i]);
                        series.title = item.title[i];
                        programacion.day.Add(series);
                    }
                }
            if (day.ToLower().Contains("saturday"))
                foreach (var item in schedule.calender[0].saturday)
                {
                    for (int i = 0; i < item.id.Count(); i++)
                    {
                        Series series = new Series();
                        series.image_url = item.poster[i];
                        series.mal_id = Convert.ToInt32(item.id[i]);
                        series.title = item.title[i];
                        programacion.day.Add(series);
                    }
                }
            if (day.ToLower().Contains("sunday"))
                foreach (var item in schedule.calender[0].sunday)
                {
                    for (int i = 0; i < item.id.Count(); i++)
                    {
                        Series series = new Series();
                        series.image_url = item.poster[i];
                        series.mal_id = Convert.ToInt32(item.id[i]);
                        series.title = item.title[i];
                        programacion.day.Add(series);
                    }
                }

            return programacion;
        }

        public static async Task<Day> MapOldSchedule(ProgramacionOld schedule,string day)
        {
            var programacion = new Day();
            programacion.day = new List<Series>();        

            programacion.day = 
            schedule.monday != null ? schedule.monday :
            schedule.tuesday != null ? schedule.tuesday :
            schedule.wednesday != null ? schedule.wednesday :
            schedule.thursday != null ? schedule.thursday :
            schedule.friday != null ?  schedule.friday :
            schedule.saturday != null ?  schedule.saturday :
            schedule.sunday;

          return programacion; 

        }

    }
}
