using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class Networking
{
    private readonly ISerializationOption _serializationOption;

    public Networking(ISerializationOption serializationOption)
    {
        _serializationOption = serializationOption;
    }

    public async Task<ResponseBase<TResultType>> Get<TResultType>(string url)
    {
        try
        {
            using var unityWebRequest = UnityWebRequest.Get("https://localhost:44365" + url);

            //unityWebRequest.SetRequestHeader("Content-Type", _serializationOption.ContentType);
            unityWebRequest.SetRequestHeader("Authorization", _serializationOption.Authorization);

            var operation = unityWebRequest.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            var result = _serializationOption.Deserialize<TResultType>(unityWebRequest.downloadHandler.text);

            return result;
        }
        catch (Exception ex)
        {
            Debug.LogError($"{nameof(Get)} failed: {ex.Message}");
            return default;
        }
    }

    public async Task<ResponseBase<TResultType>> Post<TResultType>(string url, WWWForm form)
    {
        try
        {
            using var unityWebRequest = UnityWebRequest.Post("https://localhost:44365" + url, form);

            //unityWebRequest.SetRequestHeader("Content-Type", _serializationOption.ContentType);
            unityWebRequest.SetRequestHeader("Authorization", _serializationOption.Authorization);

            var operation = unityWebRequest.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            var result = _serializationOption.Deserialize<TResultType>(unityWebRequest.downloadHandler.text);

            if (unityWebRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Failed: {unityWebRequest.error}");
            }
            
            return result;
        }
        catch (Exception ex)
        {
            Debug.LogError($"{nameof(Get)} failed: {ex.Message}");
            return default;
        }
    }
}
