using System.Collections.Generic;
using CitySecuritySmart.Web.Models;

namespace CitySecuritySmart.Web.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
