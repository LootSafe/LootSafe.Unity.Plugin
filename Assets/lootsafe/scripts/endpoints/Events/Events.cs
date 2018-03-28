using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Events : MonoBehaviour {

    private string url_fetchevents= "/events";

    private Events(){}

    public Events Initialize(string apiUrl)
    {
        url_fetchevents = apiUrl + url_fetchevents;
        return this;
    }

    /* Authenticated Wrappers */

    public IEnumerator fetchEvents_GET(Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url_fetchevents))
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
}
