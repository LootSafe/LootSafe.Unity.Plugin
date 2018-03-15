using UnityEngine;

public class BootStrap : MonoBehaviour {

    /* Configurables */

    private static string apiUrl = "http://localhost:1337/v1";
    private static string apiKey = "pWpzWuxoKUKAmlHc0wPi7lFS38FTth";
    private static string ethAcc = "0x5dc89fd12c328147119afb8ce6292a2aae0b5171";

    /* LootSafe Object */

    private LootSafe lootsafe;

    void Start()
    {
        /* Creating the object */

        lootsafe = new LootSafe(apiUrl, apiKey, ethAcc);

        /*
        StartCoroutine(lootsafe.crafter.getCraftables((status) => {
            Debug.Log(status.ToString());
        }));
        */
    }
}
