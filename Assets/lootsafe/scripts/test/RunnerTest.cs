using System.Collections.Generic;
using UnityEngine;

public class RunnerTest : MonoBehaviour
{
    private static string apiUrl = "http://localhost:1337/v1";
    private static string apiKey = "pWpzWuxoKUKAmlHc0wPi7lFS38FTth";

    private static string ethAcc = "0xe41d2828c69b521e5562943c38aed61698f9e7de";
    private static string item = "0x4a908ef51590de02b0f16403dfb49774b11d7847";
    private static string rarity = "uncommon";
    private static string otpkey = "otpkey";

    void Start()
    {
        LootSafe lootsafe = gameObject.AddComponent<LootSafe>().Initialize(apiUrl, apiKey);

        bool testBalance = false;
        bool testCrafter = false;
        bool testEvents = false;
        bool testGlobal = false;    
        bool testItems = true;
        bool testLootBox = false;

        /* Testing Balance */

        if (testBalance)
        {
            StartCoroutine(lootsafe.balance.balanceOf(ethAcc, (result) => {
                Debug.Log("lootsafe.balance.balanceOf: " + ethAcc + "\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.balance.itemBalances(ethAcc, (result) => {
                Debug.Log("lootsafe.balance.itemBalances: " + ethAcc + "\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.balance.itemBalance(item, ethAcc, (result) => {
                Debug.Log("lootsafe.balance.itemBalance: " + item + " " + ethAcc + "\n" + result.ToString());
            }));
        }

        /* Testing Crafter */

        if (testCrafter)
        {
            StartCoroutine(lootsafe.crafter.getCraftables((result) => {
                Debug.Log("lootsafe.crafter.getCraftables\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getDeconstructables((result) => {
                Debug.Log("lootsafe.crafter.getDeconstructables\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getDeconstructionRecipe(item, (result) => {
                Debug.Log("lootsafe.crafter.getDeconstructionRecipe: " + item + "\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getRecipe(item, (result) => {
                Debug.Log("lootsafe.crafter.getRecipe: " + item + "\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.crafter.newRecipe(apiKey, otpkey, "123456", new List<string> { "1212", "3434" }, new List<string> { "1", "2" }, (result) => {
                Debug.Log("lootsafe.crafter.newRecipe:\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.crafter.newDestructionRecipe(apiKey, otpkey, "123456", new List<string> { "1212", "3434" }, new List<string> { "1", "2" }, (result) => {
                Debug.Log("lootsafe.crafter.newDestructionRecipe:\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.crafter.removeRecipe(apiKey, otpkey, item, (result) => {
                Debug.Log("lootsafe.crafter.removeRecipe:\n" + result.ToString());
            }));
        }

        /* Testing Events */

        if (testEvents)
        {
            StartCoroutine(lootsafe.events.fetchEvents((result) => {
                Debug.Log("lootsafe.events.fetchEvents\n" + result.ToString());
            }));
        }

        /* Testing Global */

        if (testGlobal)
        {
            StartCoroutine(lootsafe.globals.getMeta((result) => {
                Debug.Log("lootsafe.globals.getMeta\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.globals.getTokenAddress((result) => {
                Debug.Log("lootsafe.globals.getTokenAddress\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.globals.newItem(apiKey, otpkey, "FNX45", "fnx45", 120000, "metadata", (result) => {
                Debug.Log("lootsafe.globals.newItem\n" + result.ToString());
            }));
        }

        /* Testing Items*/

        if (testItems)
        {
            StartCoroutine(lootsafe.items.getItems((result) => {
                Debug.Log("lootsafe.global.getItems\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.items.getItem(item, (result) => {
                Debug.Log("lootsafe.global.getItem\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.items.getItemByAddress(item, (result) => {
                Debug.Log("lootsafe.global.getItemByAddress\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.items.getItemAddresses((result) => {
                Debug.Log("lootsafe.global.getItemAddresses\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.items.ledger((result) => {
                Debug.Log("lootsafe.global.ledger\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.items.clearAvailability(apiKey, otpkey, item, ethAcc, (result) => {
                Debug.Log("lootsafe.items.clearAvailability\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.items.spawnItem(apiKey, otpkey, item, ethAcc, (result) => {
                Debug.Log("lootsafe.items.spawnItem\n" + result.ToString());
            }));
        }

        /* Testing LootBox*/

        if (testLootBox)
        {
            StartCoroutine(lootsafe.lootbox.getChances((result) => {
                Debug.Log("lootsafe.lootbox.getChances\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.getCost((result) => {
                Debug.Log("lootsafe.lootbox.getCost\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.getItems(rarity, (result) => {
                Debug.Log("lootsafe.lootbox.getItems: " + rarity + "\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.addItem(apiKey, otpkey, "Something", "uncommon", (result) => {
                Debug.Log("lootsafe.lootbox.addItem:\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.updateChance(apiKey, otpkey, "1", "2", "3", (result) => {
                Debug.Log("lootsafe.lootbox.updateChance:\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.updateLootBoxCost(apiKey, otpkey, "1", (result) => {
                Debug.Log("lootsafe.lootbox.updateLootBoxCost:\n" + result.ToString());
            }));
        }
    }
}
