using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class Asset : MonoBehaviour {
    
    private string url_getAssetOwner = "asset/owner/";
    private string url_getAssetList = "asset/list";
    private string url_getAsset = "asset/get/";
    private string url_getMint = "asset/mint/";
    private string url_getMeta = "";
    private string url_postSetMetadataFile = "asset/metadata/set/";
    private string url_postSetMetaData = "asset/metadata/file/set/";

    private Asset() { }

    public Asset Initialize(string apiUrl)
    {
        url_getAssetOwner = apiUrl + url_getAssetOwner;
        url_getAssetList = apiUrl + url_getAssetList;
        url_getAsset = apiUrl + url_getAsset;
        url_getMint = apiUrl + url_getMint;
        url_postSetMetadataFile = apiUrl + url_postSetMetadataFile;
        url_postSetMetaData = apiUrl + url_postSetMetaData;

        return this;
    }

    /* Endpoint Wrappers */

    public IEnumerator assetOwner(string itemAddress, Action<string> callback)
    {
        string url = (url_getAssetOwner + itemAddress);

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

    public IEnumerator listAsset(Action<string> callback)
    {
        string url = url_getAssetList;

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

    public IEnumerator asset(string itemAddress, Action<string> callback)
    {
        string url = url_getAsset;

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

    public IEnumerator mint(string itemAddress, string walletAddress, string quantity, Action<string> callback)
    {
        string url = (url_getMint + itemAddress + "/" + walletAddress + "/" + quantity);

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

    public IEnumerator meta(Action<string> callback)
    {
        string url = url_getMeta;

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

    /* Authenticated Wrappers */

    public IEnumerator setMetaData(string apiKey, string otp, string metadata, Action<string> callback)
    {
        string url = url_postSetMetaData;

        using (UnityWebRequest www = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST))
        {
            string result = "";

            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            d.Add("metadata", new List<string> { metadata });

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

    public IEnumerator setMetadataFile(string apiKey, string otp, string asset, string file, Action<string> callback)
    {
        string url = url_postSetMetadataFile;

        using (UnityWebRequest www = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST))
        {
            string result = "";

            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            d.Add("asset", new List<string> { asset });
            d.Add("file", new List<string> { file });

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
