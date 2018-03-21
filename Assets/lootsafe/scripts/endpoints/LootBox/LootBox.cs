using System;
using System.Collections;
using UnityEngine.Networking;

public class LootBox {

    private string apiUrl;

    private string url_getChances = "/lootbox/chances";
    private string url_getCost = "/lootbox/cost";
    private string url_getItems = "/lootbox/items/";

    /* Constructors */

    private LootBox(){}

    public LootBox (string apiUrl)
    {
        this.apiUrl = apiUrl;

        this.url_getChances = this.apiUrl + this.url_getChances;
        this.url_getCost = this.apiUrl + this.url_getCost;
        this.url_getItems = this.apiUrl + this.url_getItems;
    }

    /* Endpoint Wrappers */

    public IEnumerator getChances_GET(Action<string> callback)
    {
        string result = "";

        using (UnityWebRequest www = UnityWebRequest.Get(url_getChances))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }

    public IEnumerator getCost_GET(Action<string> callback)
    {
        string result = "";

        using (UnityWebRequest www = UnityWebRequest.Get(url_getCost))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }

    public IEnumerator getItems_GET(string rarity, Action<string> callback)
    {
        string result = "";
        string url = (url_getItems + rarity);

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