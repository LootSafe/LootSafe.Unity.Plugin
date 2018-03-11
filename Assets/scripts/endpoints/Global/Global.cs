using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Global : MonoBehaviour
{

    private string apiUrl;
    private string apiKey;
    private string ethAcc;

    /* Private Constructor */

    private Global() { }

    /* Public Constructor */

    public Global(string apiUrl, string apiKey, string ethAcc)
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.ethAcc = ethAcc;
    }

    /* Methods */

    public IEnumerator newItem(string name, string id, int totalSupply, string metadata, Action<string> callback)
    {
        string url = (apiUrl + "/item/new");

        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("id", id);
        form.AddField("totalSupply", totalSupply);
        form.AddField("metadata", metadata);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            string result = "";

            www.SetRequestHeader("Accept", "application/json, text/plain, */*");
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("key", apiKey);

            //www.SetRequestHeader("otp", otp);
            //Add authentication here

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error;
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }
}