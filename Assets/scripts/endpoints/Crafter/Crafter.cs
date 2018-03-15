using System;
using System.Collections;
using UnityEngine.Networking;

public class Crafter {

    private string apiUrl;
    
    /* Private Constructor */

    private Crafter(){}

    /* Public Constructor */

    public Crafter (string apiUrl)
    {
        this.apiUrl = apiUrl;
    }

    /* Methods */

    public IEnumerator getCraftables(Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/craftables");
        
        using (UnityWebRequest www = UnityWebRequest.Get(url))
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

    public IEnumerator getDeconstructables(Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/deconstructables");

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

    public IEnumerator getDeconstructionRecipe(string item, Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/recipe/deconstruction/get/" + item);

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

    public IEnumerator getRecipe(string item, Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/recipe/get/" + item);

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
