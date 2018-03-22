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
        LootSafe lootsafe = new LootSafe(apiUrl, apiKey);

        bool testingBalance = true;
        bool testingCrafter = true;
        bool testingGlobal = true;
        bool testingLootBox = true;

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
            string eightTimesScopeAddress = "0x3ab412b1ebac03791789763fba17fc1f4e368662";

            StartCoroutine(lootsafe.balance.itemBalance_GET(eightTimesScopeAddress, ethAcc, (status) => {
                Debug.Log("lootsafe.balance.itemBalance_GET: " + eightTimesScopeAddress + " " + ethAcc + "\n" + status.ToString());
            }));

            Issue
            Error Cannot create instance of Item; no code at address 0x3ab412b1ebac03791789763fba17fc1f4e368662
            */
        }

        /* Testing Crafter */

        if (testingCrafter) {

            StartCoroutine(lootsafe.crafter.getCraftables_GET((status) => {
                Debug.Log("lootsafe.crafter.getCraftables_GET\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getDeconstructables_GET((status) => {
                Debug.Log("lootsafe.crafter.getDeconstructables_GET\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getDeconstructionRecipe_GET(item, (status) => {
                Debug.Log("lootsafe.crafter.getDeconstructionRecipe_GET: " + item + "\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getRecipe_GET(item, (status) => {
                Debug.Log("lootsafe.crafter.getRecipe_GET: " + item + "\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.newRecipe_POST(apiKey, "otpkey", "123456" , new List<string> { "1212", "3434" }, new List<string> { "1", "2" }, (status) => {
                Debug.Log("lootsafe.crafter.newRecipe_POST: " + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.removeRecipe_POST(apiKey, "otpkey", "0xae3ec0d604256429625ba044142e0aa872c75f9c", (status) => {
                Debug.Log("lootsafe.crafter.removeRecipe_POST: "  + status.ToString());
            }));
        }

        /* Testing Global */

        if (testingGlobal)
        {
            StartCoroutine(lootsafe.global.newItem_POST("FNX45", "fnx45", 120000, "metadata", (status) => {
                Debug.Log("lootsafe.global.newItem_POST " + status.ToString());
            }));
        }

        /* Testing LootBox*/

        if (testingLootBox)
        {
            StartCoroutine(lootsafe.lootbox.getChances_GET((status) => {
                Debug.Log("lootsafe.lootbox.getChances_GET\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.getCost_GET((status) => {
                Debug.Log("lootsafe.lootbox.getCost_GET\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.getItems_GET(rarity, (status) => {
                Debug.Log("lootsafe.lootbox.getItems_GET: " + rarity + "\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.addItem_POST(apiKey, "otpkey", "", "", (status) => {
                Debug.Log("lootsafe.lootbox.addItem_POST:\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.updateChance_GET(apiKey, "otpkey", "1", "2", "3", (status) => {
                Debug.Log("lootsafe.lootbox.updateChance_GET:\n" + status.ToString());
            })); 

            StartCoroutine(lootsafe.lootbox.updateLootBoxCost_GET(apiKey, "otpkey", "1", (status) => {
                Debug.Log("lootsafe.lootbox.updateLootBoxCost_GET:\n" + status.ToString());
            }));

        }
    }
}
