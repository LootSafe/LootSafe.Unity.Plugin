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

        LootSafe lootsafe = gameObject.AddComponent<LootSafe>().Initialize(apiUrl,apiKey);

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

### Endpoints

 Endpoint  | Type | Auth | Status |
|---|---|---|---|
| **Balance**   |   |   |   |
| balanceOf_GET(string address)  | **GET**  | OPEN  | Available |
| itemBalances_GET(string address)  | **GET**  | OPEN  | Available |
| itemBalance_GET(string itemAddress,string address)  | **GET**  | OPEN   | Available |
| **Crafter**   |   |   |   |
| getCraftables_GET()  | **GET**  | OPEN   | Available |
| getDeconstructables_GET()  | **GET**  | OPEN   | Available |
| getDeconstructionRecipe_GET(string item)  | **GET**  | OPEN   | Available |
| getRecipe_GET(string item) | **GET**  | OPEN   | Available |
| newRecipe_POST(string apiKey, string otp, string result, List<string> materials, List<string> counts)  | **POST**  | AUTH   | Available |
| removeRecipe_POST(string apiKey,string otp,string item)  | **POST**  | AUTH   | Available |
| ~~newDeconstructionRecipe_POST(apiKey, otp)~~ | **POST**  | AUTH   | Unavailable |
| **Events**  |   |   |   |
| fetchEvents_GET()  | **GET**  | OPEN   | Available |
| **Globals**  |   |   |   |
| getMeta_GET()  | **GET**  | OPEN   | Available |
| getTokenAddress_GET()  | **GET**  | OPEN   | Available |
| newItem_POST(string apiKey,string otp,string name,string id,string totalSupply,string metadata) | **POST**  | AUTH   | Available |
| ~~spawnItem_POST(string apiKey,string otp)~~  | **POST**   | AUTH   | Unavailable |
| ~~clearAvailability_POST(string apiKey,string otp)~~  | **POST**   | AUTH   | Unavailable |
| **Items**  |   |   |   |
| getItems_GET()  | **GET**  | OPEN   | Available |
| getItemAddresses_GET()  | **GET**  | OPEN   | Available |
| ledger_GET()  | **GET**  | OPEN   | Available |
| getItem_GET(string item)  | **GET**  | OPEN   | Available |
| getItemByAddress_GET(string item) | **GET**  | OPEN   | Available |
| **LootBox** |   |   |   |
| getChances_GET()  | **GET**  | OPEN   | Available |
| getCost_GET()  | **GET**  | OPEN   | Available |
| getItems_GET(string rarity)  | **GET**  | OPEN   | Available |
| addItem_POST(string apikey,string opt,string item,string rarity)  | **POST**  | AUTH  | Available |
| updateChance_GET(string apikey, string opt, string epic, string rare, string uncommon) | **GET**  | AUTH  | Available |
| updateLootBoxCost_GET(string apikey, string opt, string cost)  | **GET**  | AUTH  | Available |

## Issues & Future Development

* **[Server Issue]** crafter.newDeconstructionRecipe_POST
* **[Server Issue]** global.spawnItem_POST
* **[Server Issue]** global.clearAvailability_POST
