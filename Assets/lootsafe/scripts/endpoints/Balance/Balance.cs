using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Balance : MonoBehaviour
{
    private string url_balanceOf = "/balance/token/";
    private string url_itemBalance = "/balance/item/";
    private string url_itemBalances = "/balance/items/";
    
    private Balance(){}

    public Balance Initialize (string apiUrl)
    {
        url_balanceOf = apiUrl + url_balanceOf;
        url_itemBalance = apiUrl + url_itemBalance;
        url_itemBalances = apiUrl + url_itemBalances;

        return this;
    }

    /* Endpoint Wrappers */

    public IEnumerator balanceOf(string address, Action<string> callback)
    {
        string url = (url_balanceOf + address);

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

    public IEnumerator itemBalance(string itemAddress, string address, Action<string> callback)
    {
        string url = (url_itemBalance + itemAddress + "/" + address);
         
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

    public IEnumerator itemBalances(string address, Action<string> callback)
    {
        string url = (url_itemBalances + address);

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
}
