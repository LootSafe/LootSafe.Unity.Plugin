using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LootBox : MonoBehaviour
{
    private string url_getChances = "/lootbox/chances";
    private string url_getCost = "/lootbox/cost";
    private string url_getItems = "/lootbox/items/";
    private string url_addItem = "/lootbox/item/add";
    private string url_updateChance = "/lootbox/chances/update/";
    private string url_updateLootBoxCost = "/lootbox/cost/";

    private LootBox(){}

    public LootBox Initialize (string apiUrl)
    {
        url_getChances = apiUrl + url_getChances;
        url_getCost = apiUrl + url_getCost;
        url_getItems = apiUrl + url_getItems;
        url_addItem = apiUrl + url_addItem;
        url_updateChance = apiUrl + url_updateChance;
        url_updateLootBoxCost = apiUrl + url_updateLootBoxCost;

        return this;
    }

    /* Endpoint Wrappers */

    public IEnumerator getChances_GET(Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url_getChances))
        {
            string result = "";

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

    public IEnumerator getCost_GET(Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url_getCost))
        {
            string result = "";

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

    public IEnumerator getItems_GET(string rarity, Action<string> callback)
    {
        string url = (url_getItems + rarity);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            string result = "";

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

    /* Authenticated Endpoint Wrappers */

    public IEnumerator addItem_POST(string apiKey, string otp, string item, string rarity, Action<string> callback)
    {
        using (UnityWebRequest www = new UnityWebRequest(url_addItem, UnityWebRequest.kHttpVerbPOST))
        {
            string result = "";

            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>
            {
                { "item", new List<string> { item } },
                { "rarity", new List<string> { rarity } }
            };

            string jsonBody = JsonStrBuild.Instance.buildStr(d);

            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            www.SetRequestHeader("key", apiKey);
            www.SetRequestHeader("otp", otp);

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

    public IEnumerator updateChance_GET(string apiKey, string otp, string epic, string rare, string uncommon, Action<string> callback)
    {
        string url = (url_updateChance + epic + "/" + rare + "/" + uncommon);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            string result = "";

            www.SetRequestHeader("key", apiKey);
            www.SetRequestHeader("otp", otp);

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

    public IEnumerator updateLootBoxCost_GET(string apiKey, string otp, string cost, Action<string> callback)
    {
        string url = (url_updateLootBoxCost + cost);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            string result = "";

            www.SetRequestHeader("key", apiKey);
            www.SetRequestHeader("otp", otp);

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }
}