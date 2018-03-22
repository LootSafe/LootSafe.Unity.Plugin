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

    public IEnumerator fetchEvents_GET(string apiKey, string otp, Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url_fetchevents))
        {
            string result = "";

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }
}
