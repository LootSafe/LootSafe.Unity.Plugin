using System;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Text;

public class Global
{
    private CustomYubiKeyClient yubi;

    private string apiKey;
    private string url_newItem = "/item/new";

    /* Constructors */

    private Global(){}    

    public Global (string apiUrl, string apiKey, CustomYubiKeyClient yubi)
    {
        this.apiKey = apiKey;
        this.yubi = yubi;

        url_newItem = apiUrl + url_newItem;
    }

    /* Endpoint Wrappers */

    public IEnumerator newItem_POST(string name, string id, int totalSupply, string metadata, Action<string> callback)
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
            www.SetRequestHeader("otp", yubi.otp);

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }
}