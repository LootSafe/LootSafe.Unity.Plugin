using UnityEngine;

public class RunnerTest : MonoBehaviour {

    /* Configurables */

    private static string apiUrl = "http://localhost:1337/v1";
    private static string apiKey = "pWpzWuxoKUKAmlHc0wPi7lFS38FTth";
    private static string ethAcc = "0x5dc89fd12c328147119afb8ce6292a2aae0b5171";

    string eightTimesScopeAddress = "0x3ab412b1ebac03791789763fba17fc1f4e368662";
    string item = "0x8a3eb4442f6c512a1c685c8ba320e28909aaa0cb";
    string rarity = "uncommon";

    /* LootSafe Object */

    private LootSafe lootsafe;

    void Start()
    {
        /* Creating the object */

        lootsafe = new LootSafe(apiUrl, apiKey, ethAcc);

        bool testingBalance = true;
        bool testingCrafter = true;
        bool testingGlobal = true;
        bool testingLootBox = true;

        /* Testing Balance */

        if (testingBalance)
        {
            StartCoroutine(lootsafe.balance.balanceOf(ethAcc, (status) =>
            {
                Debug.Log("lootsafe.balance.balanceOf: " + ethAcc + "\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.balance.itemBalances(ethAcc, (status) =>
            {
                Debug.Log("lootsafe.balance.itemBalances: " + ethAcc + "\n" + status.ToString());
            }));

            /*
            StartCoroutine(lootsafe.balance.itemBalance(eightTimesScopeAddress, ethAcc, (status) => {
                Debug.Log("lootsafe.balance.itemBalance: " + eightTimesScopeAddress + " " + ethAcc + "\n" + status.ToString());
            }));

            Issue
            Error Cannot create instance of Item; no code at address 0x3ab412b1ebac03791789763fba17fc1f4e368662
            */
        }

        /* Testing Crafter */

        if (testingCrafter) {

            StartCoroutine(lootsafe.crafter.getCraftables((status) => {
                Debug.Log("lootsafe.crafter.getCraftables\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getDeconstructables((status) => {
                Debug.Log("lootsafe.crafter.getDeconstructables\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getDeconstructionRecipe(item, (status) => {
                Debug.Log("lootsafe.crafter.getDeconstructionRecipe: " + item + "\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.crafter.getRecipe(item, (status) => {
                Debug.Log("lootsafe.crafter.getRecipe: " + item + "\n" + status.ToString());
            }));

        }

        /* Testing Global */

        if (testingGlobal)
        {
            StartCoroutine(lootsafe.global.newItem("FNX45", "fnx45", 120000, "metadata", (status) => {
                Debug.Log("lootsafe.global.newItem " + status.ToString());
            }));
        }

        /* Testing LootBox*/

        if (testingLootBox)
        {
            StartCoroutine(lootsafe.lootbox.getChances((status) => {
                Debug.Log("lootsafe.lootbox.getChances\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.getCost((status) => {
                Debug.Log("lootsafe.lootbox.getCost\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.lootbox.getItems(rarity, (status) => {
                Debug.Log("lootsafe.lootbox.getItems: " + rarity + "\n" + status.ToString());
            }));
        }
        
        /* Testing Trade*/        
        /* Currently not implemented in the API

            StartCoroutine(lootsafe.trade.getMerchantTrade(merchant, (status) => {
                Debug.Log("lootsafe.trade.getMerchantTrade: " + merchant + "\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.trade.getTrade(tradeId, (status) => {
                Debug.Log("lootsafe.trade.getTrade: " + tradeId + "\n" + status.ToString());
            }));

            StartCoroutine(lootsafe.trade.getTrades((status) => {
                Debug.Log("lootsafe.trade.getTrades\n" + status.ToString());
            }));
        */
    }
}
