using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class Global : MonoBehaviour {

    private string url_newItem = "/item/new";
    private string url_spawnItem = "/item/new";
    private string url_clearAvailability = "/item/new";

    /* Constructors */

    private Global(){}

    public Global(string apiUrl)
    {
        url_newItem = apiUrl + url_newItem;
        url_spawnItem = apiUrl + url_spawnItem;
        url_clearAvailability = apiUrl + url_clearAvailability;
    }

    /* Authenticated Wrappers */

    public IEnumerator newItem_POST(string apiKey, string otp, string name, string id, int totalSupply, string metadata, Action<string> callback)
    {
        using (UnityWebRequest www = new UnityWebRequest(url_newItem, "POST"))
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
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }

    /*
    public IEnumerator spawnItem_POST(string apiKey, string otp, Action<string> callback)
    {

    }

    public IEnumerator clearAvailability_POST(string apiKey, string otp, Action<string> callback)
    {

    }
    */
}
