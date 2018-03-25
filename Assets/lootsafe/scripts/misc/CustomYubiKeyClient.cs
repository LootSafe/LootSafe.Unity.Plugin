using System;
using System.Collections;
using UnityEngine.Networking;

public class CustomYubiKeyClient {

    public string id { get; set; }
    public string otp { get; set; }
    public string nounce { get; set; }

    private CustomYubiKeyClient(){}

    public CustomYubiKeyClient(string otp)
    {
        this.id = "" + 1;
        this.otp = otp;
        this.nounce = "";
    }

    public CustomYubiKeyClient(int id, string otp, string nounce)
    {
        this.id = "" + id;
        this.otp = otp;
        this.nounce = nounce;
    }

    public IEnumerator validKey(Action<string> callback)
    {
        string result = "";
        string url = "http://api2.yubico.com/wsapi/2.0/verify?";
        url += "id=" + id;
        url += "&otp=" + otp;
        url += "&nounce=" + nounce;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
                result = www.error;
            else
                result = www.downloadHandler.text;

            callback(result);
        }
    }

}
