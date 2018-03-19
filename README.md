# LootSafe.Unity.Plugin

### Usage

```
Assets/lootsafe/scripts/test/RunnerTest.cs
```
**RunnerTest.cs is a MonoBehaviour.** Due to the library restrictions of Unity3D where **System.Net.Http** is not included we are restricted to using **UnityEngine.Networking** . 

This requires that the class you call the API from **must inherit MonoBehaviour** this allows the use of CoRoutines to call the API.

The example below is the most minimalist usage case. The script has been attached to an object in the scene and the scripts **void Start()** gets called when the scene loads.

```
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
```

Output from Debug.Log
```
lootsafe.crafter.getCraftables
{"status":200,"message":"Craftables fetched","data":[]}
```

### Source and Importing

Source Directory Location
```
Assets/lootsafe/scripts/
```

Unity Package Location
```
lootsafe-api-currentdate.unitypackage
```

### Endpoints

**Balance**

* balanceOf(string address)
* itemBalances(string address)
* **~~itemBalance(string itemAddress, string address)~~ In Progress**

**Crafter**

* getCraftables()
* getDeconstructables()
* getDeconstructionRecipe(string item)
* getRecipe(string item)

**Global**

* newItem(string name, string id, int totalSupply, string metadata)

**LootBox**

* getChances()
* getCost()
* getItems(string rarity)

### Issues

* OTP added to the project and ready for implementation but it isn't being used yet.
* itemBalance endpoint isn't working. Seems to be a serverside issue currently.
