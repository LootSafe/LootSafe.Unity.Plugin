using System;
using System.Collections;
using UnityEngine.Networking;

public class Balance
{
    private string apiUrl;

    private string url_balanceOf = "/balance/token/";
    private string url_itemBalance = "/balance/item/";
    private string url_itemBalances = "/balance/items/";

    /* Constructors */

    private Balance(){}

    public Balance(string apiUrl)
    {
        this.apiUrl = apiUrl;

        this.url_balanceOf = this.apiUrl + this.url_balanceOf;
        this.url_itemBalance = this.apiUrl + this.url_itemBalance;
        this.url_itemBalances = this.apiUrl + this.url_itemBalances;
    }

    /* Endpoint Wrappers */

    public IEnumerator balanceOf_GET(string address, Action<string> callback)
    {
        string result = "";
        string url = (url_balanceOf + address);
                
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

    public IEnumerator itemBalance_GET(string itemAddress, string address, Action<string> callback)
    {
        string result = "";
        string url = (url_itemBalance + "/" + address);
         
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

    public IEnumerator itemBalances_GET(string address, Action<string> callback)
    {
        string result = "";
        string url = (url_itemBalances + address);

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
