# LootSafe.Unity.Plugin

### Environment

Currently working on Unity3D version 2017.3.1f1 running on Windows 10.

Player Settings

* **Scripting Runtime** - Version Experimental (.NET 4.6 Equivalent)
* **Scripting Backend** - Mono
* **API Compatibility** - .NET 4.6

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

        StartCoroutine(lootsafe.crafter.getCraftables_GET((status) => {
            Debug.Log("lootsafe.crafter.getCraftables_GET\n" + status.ToString());
            // Do stuff with status string.
        }));
    }
}
```

Output from Debug.Log
```
lootsafe.crafter.getCraftables_GET
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

## Endpoints

### Balance

**Open**

* balanceOf_GET(string address)
* itemBalances_GET(string address)
* **~~itemBalance_GET(string itemAddress, string address)~~**

### Crafter

**Open**

* getCraftables_GET()
* getDeconstructables_GET()
* getDeconstructionRecipe_GET(string item)
* getRecipe_GET(string item)

**Authenticated**

* newRecipe_POST(string apiKey, string otp, string result, List<string> materials, List<string> counts)
* removeRecipe_POST(string apiKey, string otp, string item)
* **~~newDeconstructionRecipe_POST()~~**

### Global

**Authenticated**

* newItem_POST(string name, string id, int totalSupply, string metadata)
* **~~spawnItem_POST()~~**
* **~~clearAvailability_POST()~~**

### Items

**Open**

* getItems_GET()
* getItemAddresses_GET()
* ledger_GET()
* **~~getItem_GET(item)~~**
* **~~getItemByAddress_GET(item)~~**

### LootBox

**Open**

* getChances_GET()
* getCost_GET()
* getItems_GET(string rarity)

**Authenticated**

* addItem_POST(string apikey, string opt, string item, string rarity)
* updateChance_GET(string apikey, string opt, string epic, string rare, string uncommon)
* updateLootBoxCost_GET(string apikey, string opt, string cost)

## Issues & Future Development


* **[Server Issue]** balance.itemBalance_GET
* **[Server Issue]** crafter.newDeconstructionRecipe_POST
* **[Server Issue]** global.spawnItem_POST
* **[Server Issue]** global.clearAvailability_POST
* **[Server Issue]** items.getItem_GET
* **[Server Issue]** items.getItemByAddress_GET

* **[Implement]** Authentication is in place for later implementation