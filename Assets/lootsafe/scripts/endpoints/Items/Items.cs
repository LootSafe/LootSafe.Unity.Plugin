using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Items : MonoBehaviour {

    private String url_getItems = "/item/list/";
    private String url_getItem = "/item/get/";
    private String url_getItemByAddress = "/item/get/address/";
    private String url_getItemAddresses = "/item/addresses/get";
    private String url_ledger = "/item/ledger";

    private Items(){}

    public Items Initialize (string apiUrl)
    {
        url_getItems = apiUrl + url_getItems;
        url_getItem = apiUrl + url_getItem;
        url_getItemByAddress = apiUrl + url_getItemByAddress;
        url_getItemAddresses = apiUrl + url_getItemAddresses;
        url_ledger = apiUrl + url_ledger;

        return this;
    }

    /* Endpoint Wrappers */

    public IEnumerator getItems(Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url_getItems))
        {
            string result = "";

            www.chunkedTransfer = false;

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

    public IEnumerator getItem(string item, Action<string> callback)
    {
        string url = url_getItem + item;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            string result = "";

            www.chunkedTransfer = false;

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

    public IEnumerator getItemByAddress(string address, Action<string> callback)
    {
        string url = url_getItemByAddress + address;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            string result = "";

            www.chunkedTransfer = false;

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

    public IEnumerator getItemAddresses(Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url_getItemAddresses))
        {
            string result = "";

            www.chunkedTransfer = false;

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

    public IEnumerator ledger(Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url_ledger))
        {
            string result = "";

            www.chunkedTransfer = false;

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }
}
