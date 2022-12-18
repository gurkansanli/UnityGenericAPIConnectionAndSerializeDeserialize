using System;
using System.Collections.Generic;

public class WeatherForecast
{
    public int? id;
    public DateTime? date;
    public int? temperatureC;
    public string summary;
}

public class WeatherForecastFilter
{
    public string Search { get; set; }
    public string Date { get; set; }
    public string Summary { get; set; }
}
