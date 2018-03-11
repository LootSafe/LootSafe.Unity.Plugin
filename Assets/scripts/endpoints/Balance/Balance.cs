﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Balance : MonoBehaviour
{
    private string apiUrl;
    private string apiKey;
    private string ethAcc;

    /* Private Constructor */

    private Balance(){}

    /* Public Constructor */

    public Balance (string apiUrl, string apiKey, string ethAcc)
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.ethAcc = ethAcc;
    }

    /* Methods */

    public IEnumerator balanceOf(string address, Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/balance/token/" + address);
                
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                result = www.error;
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                result = www.downloadHandler.text;
            }

            callback(result);
        }
    }

    public IEnumerator itemBalance(string itemAddress, string address, Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/balance/item/" + itemAddress + "/" + address);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                result = www.error;
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                result = www.downloadHandler.text;
            }

            callback(result);
        }
    }

    public IEnumerator itemBalances(string address, Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/balance/items/" + address);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                result = www.error;
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                result = www.downloadHandler.text;
            }

            callback(result);
        }
    }
}
