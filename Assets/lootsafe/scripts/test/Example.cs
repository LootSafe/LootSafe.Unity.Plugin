using UnityEngine;

public class Example : MonoBehaviour {

    private string apiUrl = "http://localhost:1337/v1/";
    private string apiKey = "pWpzWuxoKUKAmlHc0wPi7lFS38FTth";

    private LootSafe lootsafe;

    void Start(){

        lootsafe = gameObject.AddComponent<LootSafe>().Initialize(apiUrl,apiKey);

        StartCoroutine(lootsafe.crafter.getCraftables((result) => {
            Debug.Log("lootsafe.crafter.getCraftables\n" + result.ToString());
            // Do stuff with status string.
        }));
    }
}