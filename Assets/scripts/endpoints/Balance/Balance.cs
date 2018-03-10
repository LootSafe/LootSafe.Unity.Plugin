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

    public string balanceOf()
    {
        return "";
    }

    public string itemBalance()
    {
        return "";
    }

    public string itemBalances()
    {
        return "";
    }
}
