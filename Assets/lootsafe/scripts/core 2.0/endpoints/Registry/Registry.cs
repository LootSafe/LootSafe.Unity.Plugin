using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Registry : MonoBehaviour
{
    private string url_getRegAssets = "registry/assets";
    private string url_getRegOwner = "registry/owner";
    private string url_getFindAddress = "registry/find/";
    private string url_postAsset = "registry/create";

    private Registry(){}

    public Registry Initialize (string apiUrl)
    {
        url_getRegAssets = apiUrl + url_getRegAssets;
        url_getRegOwner = apiUrl + url_getRegOwner;
        url_postAsset = apiUrl + url_postAsset;
        url_getFindAddress = apiUrl + url_getFindAddress;

        return this;
    }

    /* Endpoint Wrappers */

    public IEnumerator assets(Action<string> callback)
    {
        string url = url_getRegAssets;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            string result = "";

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

    public IEnumerator owner(Action<string> callback)
    {
        string url = url_getRegOwner;
         
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            string result = "";

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

    public IEnumerator findAddress(string itemAddress, Action<string> callback)
    {
        string url = (url_getFindAddress + itemAddress);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            string result = "";

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }


    /* Authenticated Wrappers */

    public IEnumerator create(string apiKey, string otp, string symbol, string name, string identifier, Action<string> callback)
    {
        string url = url_postAsset;

        using (UnityWebRequest www = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST))
        {
            string result = "";

            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            d.Add("symbol", new List<string> { symbol });
            d.Add("name", new List<string> { name });
            d.Add("identifier", new List<string> { identifier });

            string jsonBody = JsonStrBuild.Instance.buildStr(d);

            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            www.SetRequestHeader("accept", "application/json text/plain, */*; charset=UTF-8");
            www.SetRequestHeader("content-type", "application/json; charset=UTF-8");
            www.SetRequestHeader("dataType", "json");
            www.SetRequestHeader("key", apiKey);
            www.SetRequestHeader("otp", otp);

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }
}
