public class LootSafe
{
    private string apiUrl;
    private string apiKey;
    private string ethAcc;
    private string otpKey;

    private CustomYubiKeyClient yubikey;

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

        yubikey = new CustomYubiKeyClient("");

        balance = new Balance(apiUrl,apiKey,ethAcc);
        crafter = new Crafter(apiUrl, apiKey, ethAcc);
        global = new Global(apiUrl, apiKey, ethAcc, yubikey); 
        lootbox = new LootBox(apiUrl, apiKey, ethAcc);
        trade = new Trade(apiUrl, apiKey, ethAcc);
    }

    /* Methods */

    private string otp(string key)
    {
        yubikey = new CustomYubiKeyClient(1, key, "nounce");
        return yubikey.otp;
    }
}