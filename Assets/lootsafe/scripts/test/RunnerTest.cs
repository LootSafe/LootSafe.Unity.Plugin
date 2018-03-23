using System.Collections.Generic;
using UnityEngine;

public class RunnerTest : MonoBehaviour {

    private static string apiUrl = "http://localhost:1337/v1";
    private static string apiKey = "pWpzWuxoKUKAmlHc0wPi7lFS38FTth";
    private static string ethAcc = "0x5dc89fd12c328147119afb8ce6292a2aae0b5171";

    private static string item = "0x8a3eb4442f6c512a1c685c8ba320e28909aaa0cb";
    private static string rarity = "uncommon";

    void Start()
    {
        LootSafe lootsafe = gameObject.AddComponent<LootSafe>().Initialize(apiUrl, apiKey);

        bool testingBalance = true;
        bool testingCrafter = true;
        bool testingGlobal = true;
        bool testingItems = true;
        bool testingLootBox = true;
        bool testingEvents = true;

        /* Testing Balance */

        if (testingBalance)
        {
            StartCoroutine(lootsafe.balance.balanceOf_GET(ethAcc, (status) =>
            {
                Debug.Log("lootsafe.balance.balanceOf_GET: " + ethAcc + "\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.balance.itemBalances_GET(ethAcc, (status) =>
            {
                Debug.Log("lootsafe.balance.itemBalances_GET: " + ethAcc + "\n" + status.ToString());
            }));

            /*
            StartCoroutine(lootsafe.balance.itemBalance_GET("0x3ab412b1ebac03791789763fba17fc1f4e368662", ethAcc, (status) => {
                Debug.Log("lootsafe.balance.itemBalance_GET: " + "0x3ab412b1ebac03791789763fba17fc1f4e368662" + " " + ethAcc + "\n" + status.ToString());
            }));
            */
        }

        /* Testing Crafter */

        if (testingCrafter)
        {
            StartCoroutine(lootsafe.crafter.getCraftables_GET((status) =>
            {
                Debug.Log("lootsafe.crafter.getCraftables_GET\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getDeconstructables_GET((status) =>
            {
                Debug.Log("lootsafe.crafter.getDeconstructables_GET\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getDeconstructionRecipe_GET(item, (status) =>
            {
                Debug.Log("lootsafe.crafter.getDeconstructionRecipe_GET: " + item + "\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getRecipe_GET(item, (status) =>
            {
                Debug.Log("lootsafe.crafter.getRecipe_GET: " + item + "\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.newRecipe_POST(apiKey, "otpkey", "123456", new List<string> { "1212", "3434" }, new List<string> { "1", "2" }, (status) =>
            {
                Debug.Log("lootsafe.crafter.newRecipe_POST: " + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.removeRecipe_POST(apiKey, "otpkey", "0xae3ec0d604256429625ba044142e0aa872c75f9c", (status) =>
            {
                Debug.Log("lootsafe.crafter.removeRecipe_POST: " + status.ToString());
            }));
        }

        /* Testing Global */

        if (testingGlobal)
        {
            StartCoroutine(lootsafe.globals.getMeta_GET((status) =>
            {
                Debug.Log("lootsafe.globals.getMeta_GET " + status.ToString());
            }));

            StartCoroutine(lootsafe.globals.getTokenAddress_GET("0x0", (status) =>
            {
                Debug.Log("lootsafe.globals.getTokenAddress_GET " + status.ToString());
            }));

            StartCoroutine(lootsafe.globals.newItem_POST(apiKey, "otpkey", "FNX45", "fnx45", 120000, "metadata", (status) =>
            {
                Debug.Log("lootsafe.globals.newItem_POST " + status.ToString());
            }));

            /*            
            StartCoroutine(lootsafe.globals.spawnItem_POST(apiKey, "otpkey", (status) => {
                Debug.Log("lootsafe.globals.spawnItem_POST " + status.ToString());
            }));

            StartCoroutine(lootsafe.globals.clearAvailability_POST(apiKey, "otpkey", (status) => {
                Debug.Log("lootsafe.globals.clearAvailability_POST " + status.ToString());
            }));
            */
        }

        /* Testing Items*/

        if (testingItems)
        {
            StartCoroutine(lootsafe.items.getItems_GET((status) =>
            {
                Debug.Log("lootsafe.global.getItems_GET " + status.ToString());
            }));

            StartCoroutine(lootsafe.items.getItem_GET(item, (status) =>
            {
                Debug.Log("lootsafe.global.getItem_GET " + status.ToString());
            }));

            StartCoroutine(lootsafe.items.getItemByAddress_GET(item, (status) =>
            {
                Debug.Log("lootsafe.global.getItemByAddress_GET " + status.ToString());
            }));

            StartCoroutine(lootsafe.items.getItemAddresses_GET((status) =>
            {
                Debug.Log("lootsafe.global.getItemAddresses_GET " + status.ToString());
            }));

            StartCoroutine(lootsafe.items.ledger_GET((status) =>
            {
                Debug.Log("lootsafe.global.ledger_GET " + status.ToString());
            }));
        }

        /* Testing LootBox*/

        if (testingLootBox)
        {
            StartCoroutine(lootsafe.lootbox.getChances_GET((status) =>
            {
                Debug.Log("lootsafe.lootbox.getChances_GET\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.getCost_GET((status) =>
            {
                Debug.Log("lootsafe.lootbox.getCost_GET\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.getItems_GET(rarity, (status) =>
            {
                Debug.Log("lootsafe.lootbox.getItems_GET: " + rarity + "\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.addItem_POST(apiKey, "otpkey", "", "", (status) =>
            {
                Debug.Log("lootsafe.lootbox.addItem_POST:\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.updateChance_GET(apiKey, "otpkey", "1", "2", "3", (status) =>
            {
                Debug.Log("lootsafe.lootbox.updateChance_GET:\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.updateLootBoxCost_GET(apiKey, "otpkey", "1", (status) =>
            {
                Debug.Log("lootsafe.lootbox.updateLootBoxCost_GET:\n" + status.ToString());
            }));
        }

        /* Testing Events */

        if (testingEvents)
        {
            StartCoroutine(lootsafe.events.fetchEvents_GET(apiKey, "otpkey", (status) =>
            {
                Debug.Log("lootsafe.events.fetchEvents\n" + status.ToString());
            }));
        }
    }
}
