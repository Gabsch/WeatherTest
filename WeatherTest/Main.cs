using System;
using System.Threading;
using GTANetworkAPI;

namespace WeatherTest
{
    public class Main : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            NAPI.Util.ConsoleOutput("WeatherTest resource loaded!");
        }

        [Command("weather")]
        public void SetWeather(Client sender, string weatherId = "")
        {
            if (!String.IsNullOrEmpty(weatherId) && Enum.TryParse(typeof(Weather), weatherId, ignoreCase: true, out var weather))
            {
                NAPI.World.SetWeather((Weather)weather);
                return;
            }

            NAPI.Chat.SendChatMessageToPlayer(sender, $"'{weatherId}' is not a valid value. Valid values are: {String.Join(", ", Enum.GetNames(typeof(Weather)))}");
        }
    }
}
