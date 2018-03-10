using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class BootStrap : MonoBehaviour {

    /* Configurables */

    private static string apiUrl = "http://localhost:1337/v1";
    private static string apiKey = "pWpzWuxoKUKAmlHc0wPi7lFS38FTth";
    private static string ethAcc = "0x616604227072883aabfc3ee09eae350be9c0912d";

    /* LootSafe Object */

    private LootSafe lootsafe;

    void Start()
    {
        /* Creating the object */

        lootsafe = new LootSafe(apiUrl, apiKey, ethAcc);
    }
}
