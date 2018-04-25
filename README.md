# LootSafe.Unity.Plugin

LootSafe API abstraction written in C# for Unity3D to aid developers with integrating LootSafe's services with their games.

Check out [our website](http://lootsafe.io/) for more information.

## Index

* [Requirements and Installation](#requirements-and-installation)
* [Running the example](#running-the-example)
* [Endpoints](#endpoints)
* [Future Development](#future-development)

## Requirements and Installation

Currently working on **Unity3D version 2017.3.1f1** running on Windows 10.

**Step 1** 

Clone/Download this repository

**Step 2** 

Make sure your player settings are configured

**Player Settings**

* **Scripting Runtime** - Version Experimental (.NET 4.6 Equivalent)
* **Scripting Backend** - Mono
* **API Compatibility** - .NET 4.6

**Step 3** 

Once downloaded by clicking on the unitypackage named

```
lootsafe-api-date.unitypackage
```

you'll be prompted by Unity to import the asset to your current project.

Once done you'll notice a folder named **lootsafe** has been imported.

**Step 4**

To use LootSafe's API wrapper in your Unity3D scene do the following

* Create an empty GameObject named "LootSafe"
* Add the ```lootsafe/scripts/test/Example.cs``` to our new GameObject

### Running the example

**RunnerTest.cs is a MonoBehaviour.** Due to the library restrictions of Unity3D where **System.Net.Http** is not used we are restricted to using **UnityEngine.Networking** without having to use a 3rd party solution. 

This requires that the class you call the API from **must inherit MonoBehaviour** because this allows the use of CoRoutines to call the API.

The example below is the most minimalist usage case.

```
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
```

Output from Debug.Log
```
lootsafe.crafter.getCraftables
{"status":200,"message":"Craftables fetched","data":[]}
```

### Endpoints

 Endpoint  | Type | Auth | Status |
|---|---|---|---|
| **Balance**   |   |   |   |
| balance.balanceOf(string address)  | **GET**  | OPEN  | Available |
| balance.itemBalances(string address)  | **GET**  | OPEN  | Available |
| balance.itemBalance(string itemAddress,string address)  | **GET**  | OPEN   | Available |
| **Crafter**   |   |   |   |
| crafter.getCraftables()  | **GET**  | OPEN   | Available |
| crafter.getDeconstructables()  | **GET**  | OPEN   | Available |
| crafter.getDeconstructionRecipe(string itemAddress)  | **GET**  | OPEN   | Available |
| crafter.getRecipe(string itemAddress) | **GET**  | OPEN   | Available |
| crafter.newRecipe(string apiKey, string otp, string result, List<string> materials, List<string> counts)  | **POST**  | AUTH   | Available |
| crafter.newDestructionRecipe(string apiKey, string otp, string result, List<string> materials, List<string> counts)  | **POST**  | AUTH   | Available |
| crafter.removeRecipe(string apiKey,string otp,string itemAddress)  | **POST**  | AUTH   | Available 
| **Events**  |   |   |   |
| events.fetchEvents()  | **GET**  | OPEN   | Available |
| **General**  |   |   |   |
| general.meta()  | **GET**  | OPEN   | Available |
| general.getTokenAddress()  | **GET**  | OPEN   | Available |
| general.newItem(string apiKey,string otp,string name,string id,string totalSupply,string metadata) | **POST**  | AUTH   | Available |
| **Items**  |   |   |   |
| items.getItems()  | **GET**  | OPEN   | Available |
| items.getItemAddresses()  | **GET**  | OPEN   | Available |
| items.ledger()  | **GET**  | OPEN   | Available |
| items.getItem(string item)  | **GET**  | OPEN   | Available |
| items.getItemByAddress(string item) | **GET**  | OPEN   | Available |
| items.spawnItem(string apiKey, string otpkey, string itemAddress, string address)  | **POST**  | AUTH  | Available |
| items.clearAvailability(string apiKey, string otpkey, string itemAddress)  | **POST**  | AUTH  | Available |
| **LootBox** |   |   |   |
| lootbox.getChances()  | **GET**  | OPEN   | Available |
| lootbox.getCost()  | **GET**  | OPEN   | Available |
| lootbox.getItems(string rarity)  | **GET**  | OPEN   | Available |
| lootbox.addItem(string apiKey,string opt,string itemAddress,string rarity)  | **POST**  | AUTH  | Available |
| lootbox.updateChance(string apiKey, string opt, string epic, string rare, string uncommon) | **GET**  | AUTH  | Available |
| lootbox.updateLootBoxCost(string apiKey, string opt, string cost)  | **GET**  | AUTH  | Available |

### Future Development
* Authentication on some routes
* API key setup better documented
* Less hardcoding
