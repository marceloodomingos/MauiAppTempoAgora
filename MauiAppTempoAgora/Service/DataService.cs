using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using MauiAppTempoAgora.Models;
using Newtonsoft.Json.Linq;

namespace MauiAppTempoAgora.Service
{
    public class DataService
    {
        public static async Task<Tempo?> GetPrevisaoDoTEmpo(String cidade)
        {
            String appApi = "c28187113392ad236dc6cb580dee0325";
            String url = $"https://api.openweathermap.org/data/2.5/"+$"weather?q={cidade}&units=metrics&appid={appApi}";

            Tempo tempo = null;

            using (HttpClient client = new HttpClient()) {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine("---------------------------------------");
                    Debug.WriteLine(json);
                    Debug.WriteLine("---------------------------------------");

                    var rascunho = JObject.Parse(json);
                    Debug.WriteLine("---------------------------------------");
                    Debug.WriteLine(rascunho);
                    Debug.WriteLine("---------------------------------------");

                    DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    DateTime sunrise = time.AddSeconds((double)rascunho["sys"]["sunrise"]).ToLocalTime();
                    DateTime sunset = time.AddSeconds((double)rascunho["sys"]["sunset"]).ToLocalTime();


                    tempo = new Tempo()
                    {
                        Humidity = (string)rascunho["main"]["humidity"],
                        Temperatura = (string)rascunho["main"]["temp"],
                        Title = (string)rascunho["main"]["name"],
                        Visibility = (string)rascunho["main"]["visibility"],
                        Wind = (string)rascunho["main"]["speed"],
                        Sunrise = sunset.ToString(),
                        Sunset = sunset.ToString(),
                        Weather = (string)rascunho["weather"][0]["main"],
                        WeatherDescrition = (string)rascunho["weather"][0]["descrition"],
                    };

                    
                }
            
            }
            return tempo;
        }
    }
}
