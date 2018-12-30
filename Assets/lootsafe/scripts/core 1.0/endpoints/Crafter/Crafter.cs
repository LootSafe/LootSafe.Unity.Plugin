using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Crafter : MonoBehaviour
{
    private String url_getCraftables = "craftables";
    private String url_getDeconstructables = "deconstructables";
    private String url_getDeconstructablesRecipe = "recipe/deconstruction/get/";
    private String url_getRecipe = "recipe/get/";
    private String url_newRecipe = "recipe/new";
    private String url_removeRecipe = "recipe/remove";
    private String url_newDeconstructionRecipe = "recipe/deconstruction/new";

    private Crafter(){}

    public Crafter Initialize (string apiUrl)
    {
        url_getCraftables = apiUrl + url_getCraftables;
        url_getDeconstructables = apiUrl + url_getDeconstructables;
        url_getDeconstructablesRecipe = apiUrl + url_getDeconstructablesRecipe;
        url_getRecipe = apiUrl + url_getRecipe;
        url_newRecipe = apiUrl + url_newRecipe;
        url_removeRecipe = apiUrl + url_removeRecipe;
        url_newDeconstructionRecipe = apiUrl + url_newDeconstructionRecipe;

        return this;
    }

    /* Endpoint Wrappers */

    public IEnumerator getCraftables(Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url_getCraftables))
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

    public IEnumerator getDeconstructables(Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url_getDeconstructables))
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

    public IEnumerator getDeconstructionRecipe(string itemAddress, Action<string> callback)
    {
        string url = (url_getDeconstructablesRecipe + itemAddress);

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

    public IEnumerator getRecipe(string itemAddress, Action<string> callback)
    {
        string url = (url_getRecipe + itemAddress);

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

    public IEnumerator newRecipe(string apiKey, string otp, string result, List<string> materials, List<string> counts, Action<string> callback)
    {
        using (UnityWebRequest www = new UnityWebRequest(url_newRecipe, UnityWebRequest.kHttpVerbPOST))
        {
            string response = "";

            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>
            {
                { "result", new List<string> { result } },
                { "materials", materials },
                { "counts", counts }
            };

            www.SetRequestHeader("accept", "application/json text/plain, */*; charset=UTF-8");
            www.SetRequestHeader("content-type", "application/json; charset=UTF-8");
            www.SetRequestHeader("dataType", "json");
            www.SetRequestHeader("key", apiKey);
            www.SetRequestHeader("otp", otp);

            string jsonBody = JsonStrBuild.Instance.buildStr(d);

            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                response = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                response = www.downloadHandler.text;

            callback(response);
        }
    }

    public IEnumerator newDestructionRecipe(string apiKey, string otp, string result, List<string> materials, List<string> counts, Action<string> callback)
    {
        using (UnityWebRequest www = new UnityWebRequest(url_newDeconstructionRecipe, UnityWebRequest.kHttpVerbPOST))
        {
            string response = "";

            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>
            {
                { "result", new List<string> { result } },
                { "materials", materials },
                { "counts", counts }
            };

            www.SetRequestHeader("accept", "application/json text/plain, */*; charset=UTF-8");
            www.SetRequestHeader("content-type", "application/json; charset=UTF-8");
            www.SetRequestHeader("dataType", "json");
            www.SetRequestHeader("key", apiKey);
            www.SetRequestHeader("otp", otp);

            string jsonBody = JsonStrBuild.Instance.buildStr(d);

            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                response = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                response = www.downloadHandler.text;

            callback(response);
        }
    }

    public IEnumerator removeRecipe(string apiKey, string otp, string itemAddress, Action<string> callback)
    {
        using (UnityWebRequest www = new UnityWebRequest(url_removeRecipe, UnityWebRequest.kHttpVerbPOST))
        {
            string response = "";

            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>
            {
                { "item", new List<string> { itemAddress } }
            };

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
                response = "{\"status\":" + www.responseCode + ",\"message\":\"" + www.error + "\",\"data\":" + "\"null\"}";
            else
                response = www.downloadHandler.text;

            callback(response);
        }
    }
}
