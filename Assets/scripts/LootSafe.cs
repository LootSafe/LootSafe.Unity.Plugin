public class LootSafe
{
    private string apiUrl;
    private string apiKey;
    private string ethAcc;
    private string otpKey;

    /* End Points */

    public Balance balance;
    public Crafter crafter;
    public Global global;
    public LootBox lootbox;
    public Trade trade;

    /* Private Constructor */

    private LootSafe(){}

    /* Public Constructor */

    public LootSafe(string apiUrl, string apiKey, string ethAcc)
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.ethAcc = ethAcc;

        balance = new Balance(apiUrl,apiKey,ethAcc);
        crafter = new Crafter(apiUrl, apiKey, ethAcc);
        global = new Global(apiUrl, apiKey, ethAcc); 
        lootbox = new LootBox(apiUrl, apiKey, ethAcc);
        trade = new Trade(apiUrl, apiKey, ethAcc);
    }

    /* Methods */

    private string otp(string key)
    {
        this.otpKey = key;
        return key;

        // Not functional yet, doesn't do any verification.
        // This will be moved into it's own class
    }
}