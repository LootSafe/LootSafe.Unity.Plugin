﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LootBox {

    private string apiUrl;
    private string apiKey;
    private string ethAcc;

    /* Private Constructor */

    private LootBox(){}

    /* Public Constructor */

    public LootBox (string apiUrl, string apiKey, string ethAcc)
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.ethAcc = ethAcc;
    }

    /* Methods */

    public IEnumerator getChances(Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/lootbox/chances");

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

    public IEnumerator getCost(Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/lootbox/cost");

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

    public IEnumerator getItems(string rarity, Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/lootbox/items/" + rarity);

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