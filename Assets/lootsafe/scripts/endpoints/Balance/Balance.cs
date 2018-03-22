using System;
using System.Collections;
using UnityEngine.Networking;

public class Balance
{
    private string url_balanceOf = "/balance/token/";
    private string url_itemBalance = "/balance/item/";
    private string url_itemBalances = "/balance/items/";

    /* Constructors */

    private Balance(){}

    public Balance(string apiUrl)
    {
        url_balanceOf = apiUrl + url_balanceOf;
        url_itemBalance = apiUrl + url_itemBalance;
        url_itemBalances = apiUrl + url_itemBalances;
    }

    /* Endpoint Wrappers */

    public IEnumerator balanceOf_GET(string address, Action<string> callback)
    {
        string url = (url_balanceOf + address);
                
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            string result = "";

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }

    public IEnumerator itemBalance_GET(string itemAddress, string address, Action<string> callback)
    {
        string url = (url_itemBalance + address);
         
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            string result = "";

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }

    public IEnumerator itemBalances_GET(string address, Action<string> callback)
    {
        string url = (url_itemBalances + address);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            string result = "";

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error + "\nStatus Code: " + www.responseCode;
            else
                result = www.downloadHandler.text + "\nStatus Code: " + www.responseCode;

            callback(result);
        }
    }
}
