using Newtonsoft.Json;
using System;
using UnityEngine;

public class JsonSerializationOption : ISerializationOption
{
    public string ContentType => "application/json";

    public string Authorization => "";

    public ResponseBase<T> Deserialize<T>(string json)
    {
        try
        {
            var result2 = JsonConvert.DeserializeObject(json);
            var result = JsonConvert.DeserializeObject<ResponseBase<T>>(json);
            Debug.Log($"Success: {json}");
            return result;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Could not parse response {json}. {ex.Message}");
            return default;
        }
    }
}
