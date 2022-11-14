using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherRequest : MonoBehaviour
{
    public int actualWeather = 0;
    
    public DigitalRuby.RainMaker.RainScript2D rainMaker;

    void Start()
    {
        StartCoroutine(GetWeather());
    }

    void WeatherChange()
    {
        if (actualWeather >= 200 && actualWeather < 300)
        {
            //Tormenta
            rainMaker.RainIntensity += 1;
        }
        else if (actualWeather >= 300 && actualWeather < 400)
        {
            //Llovizna
            rainMaker.RainIntensity += 0.2f;
        }
        else if (actualWeather >= 400 && actualWeather < 600)
        {
            //Llovizna
            rainMaker.RainIntensity += 0.4f;
        }
        else if (actualWeather >= 600 && actualWeather < 800)
        {
            //Llovizna
            rainMaker.RainIntensity += 0.6f;
        }
        else if (actualWeather >= 800 && actualWeather < 1000)
        {
            //Llovizna
            rainMaker.RainIntensity += 0.8f;
        }
    }

    IEnumerator GetWeather()
    {
        //https://openweathermap.org/current
        string cityName = "guadalajara";
        string ApiKey = "53c164c99a64741dd863dfa45874f9ff";
        UnityWebRequest www = UnityWebRequest.Get($"https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid={ApiKey}");
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {

            Debug.LogWarning(www.error);
            actualWeather = 800;
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            Root weather = JsonConvert.DeserializeObject<Root>(www.downloadHandler.text);
            actualWeather = weather.weather[0].id;
        }

        WeatherChange();
        StopCoroutine(GetWeather());
    }



    private class Clouds
    {
        public int all { get; set; }
    }

    private class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

    private class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }

    private class Rain
    {
        public double _1h { get; set; }
    }

    private class Root
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    private class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    private class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    private class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }

}