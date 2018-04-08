using UnityEngine;

public class Example : MonoBehaviour {

	void Start(){
    
        string apiUrl = "http://localhost:1337/v1";
        string apiKey = "pWpzWuxoKUKAmlHc0wPi7lFS38FTth";

        LootSafe lootsafe = gameObject.AddComponent<LootSafe>().Initialize(apiUrl,apiKey);

        StartCoroutine(lootsafe.crafter.getCraftables((result) => {
            Debug.Log("lootsafe.crafter.getCraftables\n" + result.ToString());
            // Do stuff with status string.
        }));
    }
}