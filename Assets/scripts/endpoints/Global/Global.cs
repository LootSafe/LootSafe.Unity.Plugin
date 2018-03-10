using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    private string apiUrl;
    private string apiKey;
    private string ethAcc;

    /* Private Constructor */

    private Global(){}

    /* Public Constructor */

    public Global(string apiUrl, string apiKey, string ethAcc)
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.ethAcc = ethAcc;
    }

    /* Methods */

    string newItem()
    {
        return "";
    }
}
