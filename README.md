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

 Endpoint  | Type | Auth | Status |
|---|---|---|---|
| **Balance**   |   |   |   |
| balanceOf(string address)  | **GET**  | OPEN  | Available |
| itemBalances(string address)  | **GET**  | OPEN  | Available |
| itemBalance(string itemAddress,string address)  | **GET**  | OPEN   | Available |
| **Crafter**   |   |   |   |
| getCraftables()  | **GET**  | OPEN   | Available |
| getDeconstructables()  | **GET**  | OPEN   | Available |
| getDeconstructionRecipe(string item)  | **GET**  | OPEN   | Available |
| getRecipe(string item) | **GET**  | OPEN   | Available |
| newRecipe(string apiKey, string otp, string result, List<string> materials, List<string> counts)  | **POST**  | AUTH   | Available |
| removeRecipe(string apiKey,string otp,string item)  | **POST**  | AUTH   | Available |
| ~~newDeconstructionRecipe(apiKey, otp)~~ | **POST**  | AUTH   | Unavailable |
| **Events**  |   |   |   |
| fetchEvents()  | **GET**  | OPEN   | Available |
| **Globals**  |   |   |   |
| getMeta()  | **GET**  | OPEN   | Available |
| getTokenAddress()  | **GET**  | OPEN   | Available |
| newItem(string apiKey,string otp,string name,string id,string totalSupply,string metadata) | **POST**  | AUTH   | Available |
| ~~spawnItem(string apiKey,string otp)~~  | **POST**   | AUTH   | Unavailable |
| ~~clearAvailability(string apiKey,string otp)~~  | **POST**   | AUTH   | Unavailable |
| **Items**  |   |   |   |
| getItems()  | **GET**  | OPEN   | Available |
| getItemAddresses()  | **GET**  | OPEN   | Available |
| ledger()  | **GET**  | OPEN   | Available |
| getItem(string item)  | **GET**  | OPEN   | Available |
| getItemByAddress(string item) | **GET**  | OPEN   | Available |
| **LootBox** |   |   |   |
| getChances()  | **GET**  | OPEN   | Available |
| getCost()  | **GET**  | OPEN   | Available |
| getItems(string rarity)  | **GET**  | OPEN   | Available |
| addItem(string apikey,string opt,string item,string rarity)  | **POST**  | AUTH  | Available |
| updateChance(string apikey, string opt, string epic, string rare, string uncommon) | **GET**  | AUTH  | Available |
| updateLootBoxCost(string apikey, string opt, string cost)  | **GET**  | AUTH  | Available |

### Issues & Future Development

* **[Server Issue]** crafter.newDeconstructionRecipe
* **[Server Issue]** global.spawnItem
* **[Server Issue]** global.clearAvailability
