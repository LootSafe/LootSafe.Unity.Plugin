using System.Collections;
using System;
using UnityEngine.Networking;

public class Trade {

    private string apiUrl;
    private string apiKey;
    private string ethAcc;

    /* Private Constructor */

    private Trade(){}

    /* Public Constructor */

    public Trade (string apiUrl, string apiKey, string ethAcc)
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.ethAcc = ethAcc;
    }

    /* Methods */

    public IEnumerator getMerchantTrade(string merchant, Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/trades/" + merchant);

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

    public IEnumerator getTrade(string tradeId, Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/trade/" + tradeId);

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

    public IEnumerator getTrades(Action<string> callback)
    {
        string result = "";
        string url = (apiUrl + "/trades");

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
