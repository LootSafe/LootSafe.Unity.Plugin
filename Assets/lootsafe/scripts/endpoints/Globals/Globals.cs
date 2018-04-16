using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Globals : MonoBehaviour {

    private string url_newItem = "/item/new";
    private string url_meta = "/";
    private string url_getTokenAddress = "/address/token";

    private Globals(){}

    public Globals Initialize (string apiUrl)
    {
        url_newItem = apiUrl + url_newItem;
        url_meta = apiUrl + url_meta;
        url_getTokenAddress = apiUrl + url_getTokenAddress;

        return this;
    }

    /* Endpoint Wrappers */

    public IEnumerator getMeta(Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url_meta))
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

    public IEnumerator getTokenAddress(Action<string> callback)
    {
        string url = url_getTokenAddress;

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

    public IEnumerator newItem(string apiKey, string otp, string name, string id, int totalSupply, string metadata, Action<string> callback)
    {
        using (UnityWebRequest www = new UnityWebRequest(url_newItem, UnityWebRequest.kHttpVerbPOST))
        {
            string result = "";

            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            d.Add("name", new List<string> { name });
            d.Add("id", new List<string> { id });
            d.Add("totalSupply", new List<string> { "" + totalSupply });
            d.Add("metadata", new List<string> { "metadata" });

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
