using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class Items : MonoBehaviour {

    private string url_getItems = "item/list/";
    private string url_getItem = "item/get/";
    private string url_getItemByAddress = "item/get/address/";
    private string url_getItemAddresses = "item/addresses/get";
    private string url_ledger = "item/ledger";
    private string url_spawnItem = "item/spawn";
    private string url_clearAvailability = "item/clearAvailability";

    private Items(){}

    public Items Initialize (string apiUrl)
    {
        url_getItems = apiUrl + url_getItems;
        url_getItem = apiUrl + url_getItem;
        url_getItemByAddress = apiUrl + url_getItemByAddress;
        url_getItemAddresses = apiUrl + url_getItemAddresses;
        url_ledger = apiUrl + url_ledger;
        url_spawnItem = apiUrl + url_spawnItem;
        url_clearAvailability = apiUrl + url_clearAvailability;

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

    public IEnumerator getItem(string itemAddress, Action<string> callback)
    {
        string url = url_getItem + itemAddress;

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

    public IEnumerator getItemByAddress(string itemAddress, Action<string> callback)
    {
        string url = url_getItemByAddress + itemAddress;

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

    public IEnumerator spawnItem(string apiKey, string otp, string itemAddress, string to, Action<string> callback)
    {
        using (UnityWebRequest www = new UnityWebRequest(url_spawnItem, UnityWebRequest.kHttpVerbPOST))
        {
            string result = "";

            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            d.Add("itemAddress", new List<string> { itemAddress });
            d.Add("to", new List<string> { to });

            string jsonBody = JsonStrBuild.Instance.buildStr(d);

            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            www.SetRequestHeader("accept", "application/json text/plain, */*; charset=UTF-8");
            www.SetRequestHeader("content-type", "application/json; charset=UTF-8");
            www.SetRequestHeader("dataType", "json");
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

    public IEnumerator clearAvailability(string apiKey, string otp, string itemAddress, Action<string> callback)
    {
        using (UnityWebRequest www = new UnityWebRequest(url_clearAvailability, UnityWebRequest.kHttpVerbPOST))
        {
            string result = "";

            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            d.Add("itemAddress", new List<string> { itemAddress });

            string jsonBody = JsonStrBuild.Instance.buildStr(d);

            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            www.SetRequestHeader("accept", "application/json text/plain, */*; charset=UTF-8");
            www.SetRequestHeader("content-type", "application/json; charset=UTF-8");
            www.SetRequestHeader("dataType", "json");
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
