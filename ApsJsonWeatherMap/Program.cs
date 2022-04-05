using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace ApsJsonWeatherMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            Console.WriteLine("Please enter your API key : ");

            var apiKey = Console.ReadLine();

            while( true)
            {
                Console.WriteLine("Please enter the city name that you would like to check weather for : ");

                var city = Console.ReadLine();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;

                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();

               // Console.WriteLine(response);
                Console.WriteLine(formattedResponse);

                Console.WriteLine("Would you like to enter another city?");
                var userinput = Console.ReadLine();

                if (userinput == "no")
                { break; }

            }
        }
    }
}
