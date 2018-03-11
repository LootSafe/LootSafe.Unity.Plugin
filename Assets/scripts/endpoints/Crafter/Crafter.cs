using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Crafter {

    private string apiUrl;
    private string apiKey;
    private string ethAcc;
    
    /* Private Constructor */

    private Crafter(){}

    /* Public Constructor */

    public Crafter(string apiUrl, string apiKey, string ethAcc)
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.ethAcc = ethAcc;
    }

    /* Methods */

    public IEnumerator getCraftables(Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/craftables");
        
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                result = www.error;
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                result = www.downloadHandler.text;
            }

            callback(result);
        }
    }

    public IEnumerator getDeconstructables(Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/deconstructables");

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                result = www.error;
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                result = www.downloadHandler.text;
            }

            callback(result);
        }
    }

    public IEnumerator getDeconstructionRecipe(string item, Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/recipe/deconstruction/get/" + item);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                result = www.error;
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                result = www.downloadHandler.text;
            }

            callback(result);
        }
    }

    public IEnumerator getRecipe(string item, Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/recipe/get/" + item);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                result = www.error;
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                result = www.downloadHandler.text;
            }

            callback(result);
        }
    }
}
