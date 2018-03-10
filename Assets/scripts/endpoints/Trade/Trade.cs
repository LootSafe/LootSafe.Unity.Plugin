using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade {

    private string apiUrl;
    private string apiKey;
    private string ethAcc;

    /* Private Constructor */

    private Trade(){}

    /* Public Constructor */

    public Trade(string apiUrl, string apiKey, string ethAcc)
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.ethAcc = ethAcc;
    }

    /* Methods */

    public string getMerchantTrade()
    {
        return "";
    }

    public string getTrade()
    {
        return "";
    }

    public string getTrades()
    {
        return "";
    }
}
