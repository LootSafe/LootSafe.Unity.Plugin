using System;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Text;

public class Global
{
    private string apiUrl;
    private string apiKey;

    private CustomYubiKeyClient yubi;

    /* Private Constructor */

    private Global(){}

    /* Public Constructor */

    public Global (string apiUrl, string apiKey, CustomYubiKeyClient yubi)
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.yubi = yubi;
    }

    /* Methods */

    public IEnumerator newItem(string name, string id, int totalSupply, string metadata, Action<string> callback)
    {
        string url = (apiUrl + "/item/new");

        Dictionary<string, string> d = new Dictionary<string, string>();
        d.Add("name", name);
        d.Add("id", id);
        d.Add("totalSupply", "" + totalSupply);
        d.Add("metadata", "metadata");

        string jsonBody = JsonStrBuild.Instance.buildStr(d);

        using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
        {
            string result = "default";

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