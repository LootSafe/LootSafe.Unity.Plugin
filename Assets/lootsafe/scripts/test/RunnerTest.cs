using System.Collections.Generic;
using UnityEngine;

public class RunnerTest : MonoBehaviour
{
    private static string apiUrl = "http://localhost:1337/v1";
    private static string apiKey = "pWpzWuxoKUKAmlHc0wPi7lFS38FTth";
    private static string ethAcc = "0x5dc89fd12c328147119afb8ce6292a2aae0b5171";

    private static string item = "0x8a3eb4442f6c512a1c685c8ba320e28909aaa0cb";
    private static string rarity = "uncommon";
    private static string otpkey = "otpkey";

    void Start()
    {
        LootSafe lootsafe = gameObject.AddComponent<LootSafe>().Initialize(apiUrl, apiKey);

        bool testBalance = true;
        bool testCrafter = true;
        bool testEvents = true;
        bool testGlobal = true;
        bool testItems = true;
        bool testLootBox = true;

        /* Testing Balance */

        if (testBalance)
        {
            StartCoroutine(lootsafe.balance.balanceOf_GET(ethAcc, (result) => {
                Debug.Log("lootsafe.balance.balanceOf_GET: " + ethAcc + "\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.balance.itemBalances_GET(ethAcc, (result) => {
                Debug.Log("lootsafe.balance.itemBalances_GET: " + ethAcc + "\n" + result.ToString());
            }));

            /*
            StartCoroutine(lootsafe.balance.itemBalance_GET("0x3ab412b1ebac03791789763fba17fc1f4e368662", ethAcc, (result) => {
                Debug.Log("lootsafe.balance.itemBalance_GET: " + "0x3ab412b1ebac03791789763fba17fc1f4e368662" + " " + ethAcc + "\n" + result.ToString());
            }));
            */
        }

        /* Testing Crafter */

        if (testCrafter)
        {
            StartCoroutine(lootsafe.crafter.getCraftables_GET((result) => {
                Debug.Log("lootsafe.crafter.getCraftables_GET\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getDeconstructables_GET((result) => {
                Debug.Log("lootsafe.crafter.getDeconstructables_GET\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getDeconstructionRecipe_GET(item, (result) => {
                Debug.Log("lootsafe.crafter.getDeconstructionRecipe_GET: " + item + "\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getRecipe_GET(item, (result) => {
                Debug.Log("lootsafe.crafter.getRecipe_GET: " + item + "\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.crafter.newRecipe_POST(apiKey, otpkey, "123456", new List<string> { "1212", "3434" }, new List<string> { "1", "2" }, (result) => {
                Debug.Log("lootsafe.crafter.newRecipe_POST:\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.crafter.removeRecipe_POST(apiKey, otpkey, item, (result) => {
                Debug.Log("lootsafe.crafter.removeRecipe_POST:\n" + result.ToString());
            }));
        }

        /* Testing Events */

        if (testEvents)
        {
            StartCoroutine(lootsafe.events.fetchEvents_GET(apiKey, otpkey, (result) => {
                Debug.Log("lootsafe.events.fetchEvents\n" + result.ToString());
            }));
        }

        /* Testing Global */

        if (testGlobal)
        {
            StartCoroutine(lootsafe.globals.getMeta_GET((result) => {
                Debug.Log("lootsafe.globals.getMeta_GET\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.globals.getTokenAddress_GET(item, (result) => {
                Debug.Log("lootsafe.globals.getTokenAddress_GET\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.globals.newItem_POST(apiKey, otpkey, "FNX45", "fnx45", 120000, "metadata", (result) => {
                Debug.Log("lootsafe.globals.newItem_POST\n" + result.ToString());
            }));

            /*            
            StartCoroutine(lootsafe.globals.spawnItem_POST(apiKey, otpkey, (result) => {
                Debug.Log("lootsafe.globals.spawnItem_POST " + result.ToString());
            }));

            StartCoroutine(lootsafe.globals.clearAvailability_POST(apiKey, otpkey, (result) => {
                Debug.Log("lootsafe.globals.clearAvailability_POST " + result.ToString());
            }));
            */
        }

        /* Testing Items*/

        if (testItems)
        {
            StartCoroutine(lootsafe.items.getItems_GET((result) => {
                Debug.Log("lootsafe.global.getItems_GET\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.items.getItem_GET(item, (result) => {
                Debug.Log("lootsafe.global.getItem_GET\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.items.getItemByAddress_GET(item, (result) => {
                Debug.Log("lootsafe.global.getItemByAddress_GET\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.items.getItemAddresses_GET((result) => {
                Debug.Log("lootsafe.global.getItemAddresses_GET\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.items.ledger_GET((result) => {
                Debug.Log("lootsafe.global.ledger_GET\n" + result.ToString());
            }));
        }

        /* Testing LootBox*/

        if (testLootBox)
        {
            StartCoroutine(lootsafe.lootbox.getChances_GET((result) => {
                Debug.Log("lootsafe.lootbox.getChances_GET\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.getCost_GET((result) => {
                Debug.Log("lootsafe.lootbox.getCost_GET\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.getItems_GET(rarity, (result) => {
                Debug.Log("lootsafe.lootbox.getItems_GET: " + rarity + "\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.addItem_POST(apiKey, otpkey, "", "", (result) => {
                Debug.Log("lootsafe.lootbox.addItem_POST:\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.updateChance_GET(apiKey, otpkey, "1", "2", "3", (result) => {
                Debug.Log("lootsafe.lootbox.updateChance_GET:\n" + result.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.updateLootBoxCost_GET(apiKey, otpkey, "1", (result) => {
                Debug.Log("lootsafe.lootbox.updateLootBoxCost_GET:\n" + result.ToString());
            }));
        }
    }
}
