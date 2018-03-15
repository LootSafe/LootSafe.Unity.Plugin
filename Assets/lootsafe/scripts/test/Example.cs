using UnityEngine;

public class Example : MonoBehaviour {

	void Start(){
    
        string apiUrl = "http://localhost:1337/v1";
        string apiKey = "pWpzWuxoKUKAmlHc0wPi7lFS38FTth";

        LootSafe lootsafe = new LootSafe(apiUrl, apiKey);

        StartCoroutine(lootsafe.crafter.getCraftables((status) => {
            Debug.Log("lootsafe.crafter.getCraftables\n" + status.ToString());
            // Do stuff with status string.
        }));
    }
}