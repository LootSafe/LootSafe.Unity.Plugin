using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour {

    private string apiUrl;
    private string apiKey;
    private string ethAcc;

    /* Private Constructor */

    private LootBox(){}

    /* Public Constructor */

    public LootBox(string apiUrl, string apiKey, string ethAcc)
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.ethAcc = ethAcc;
    }

    /* Methods */

    public string getChances()
    {
        return "";
    }

    public string getCost()
    {
        return "";
    }

    public string getItems()
    {
        return "";
    }
}
