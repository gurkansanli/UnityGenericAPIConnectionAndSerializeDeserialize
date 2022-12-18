using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeatherForecastController : MonoBehaviour
{
    public WeatherForecastController Instance;

    [SerializeField] TextMeshProUGUI txtSearch;
    [SerializeField] TextMeshProUGUI txtSummary;
    [SerializeField] GameObject WeatherForecastPrefab;
    [SerializeField] GameObject WeatherForecastScrollView;
    List<GameObject> weatherForecasts = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        MultipleGet();
    }

    void Update()
    {

    }

    public async void Get(string id)
    {
        var result = await new Networking(new JsonSerializationOption()).Get<ResponseBase<WeatherForecast>>("/WeatherForecast/" + id);
        if (result != null)
            if (result.status == 200)
            {
                
            }
    }

    public async void MultipleGet()
    {
        WWWForm formData = new WWWForm();
        //formData.AddField("Search", txtSearch.text);
        //formData.AddField("Summary", txtSummary.text);

        var result = await new Networking(new JsonSerializationOption()).Post<WeatherForecast>("/WeatherForecast/MultipleGetWeatherForecast", formData);
        if (result != null)
            if (result.status == 200)
            {
                GameObject weatherForecast = Instantiate(WeatherForecastPrefab, WeatherForecastScrollView.transform);
                weatherForecasts.Add(weatherForecast);
            }
    }

    public async void Add()
    {
        WWWForm formData = new WWWForm();
        formData.AddField("DeviceId", SystemInfo.deviceUniqueIdentifier);

        var result = await new Networking(new JsonSerializationOption()).Post<ResponseBase<WeatherForecast>>("/WeatherForecast/AddWeatherForecast", formData);
        if (result != null)
            if (result.status == 200)
            {

            }
    }

    public async void UpdateW()
    {
        WWWForm formData = new WWWForm();
        formData.AddField("DeviceId", SystemInfo.deviceUniqueIdentifier);

        var result = await new Networking(new JsonSerializationOption()).Post<ResponseBase<WeatherForecast>>("/WeatherForecast/UpdateWeatherForecast", formData);
        if (result != null)
            if (result.status == 200)
            {

            }
    }
}
