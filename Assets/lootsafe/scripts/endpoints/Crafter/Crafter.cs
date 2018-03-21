using System;
using System.Collections;
using UnityEngine.Networking;

public class Crafter {

    private string apiUrl;

    private String url_getCraftables = "/craftables";
    private String url_getDeconstructables = "/deconstructables";
    private String url_getDeconstructablesRecipe = "/recipe/deconstruction/get/";
    private String url_getRecipe = "/recipe/get/";

    /* Constructors */

    private Crafter(){}

    public Crafter (string apiUrl)
    {
        this.apiUrl = apiUrl;

        this.url_getCraftables = this.apiUrl + this.url_getCraftables;
        this.url_getDeconstructables = this.apiUrl + this.url_getDeconstructables;
        this.url_getDeconstructablesRecipe = this.apiUrl + this.url_getDeconstructablesRecipe;
        this.url_getRecipe = this.apiUrl + this.url_getRecipe;
    }

    /* Endpoint Wrappers */

    public IEnumerator getCraftables_GET(Action<string> callback)
    {
        string result = "";
        
        using (UnityWebRequest www = UnityWebRequest.Get(url_getCraftables))
        {
            www.chunkedTransfer = false;

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }

    public IEnumerator getDeconstructables_GET(Action<string> callback)
    {
        string result = "";

        using (UnityWebRequest www = UnityWebRequest.Get(url_getDeconstructables))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }

    public IEnumerator getDeconstructionRecipe_GET(string item, Action<string> callback)
    {
        string result = "";
        string url = (url_getDeconstructablesRecipe + item);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }

    public IEnumerator getRecipe_GET(string item, Action<string> callback)
    {
        string result = "";
        string url = (url_getRecipe + item);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }
}
