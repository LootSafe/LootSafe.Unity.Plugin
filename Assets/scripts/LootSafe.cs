public class LootSafe
{
    private string otpKey;

    private CustomYubiKeyClient yubikey;

    /* End Points */

    public Balance balance;
    public Crafter crafter;
    public Global global;
    public LootBox lootbox;

    /* Private Constructor */

    private LootSafe(){}

    /* Public Constructor */

    public LootSafe(string apiUrl, string apiKey)
    {
        yubikey = new CustomYubiKeyClient("");

        balance = new Balance(apiUrl);
        crafter = new Crafter(apiUrl);
        global = new Global(apiUrl, apiKey, yubikey); 
        lootbox = new LootBox(apiUrl);
    }

    /* Methods */

    private string otp(string key)
    {
        yubikey = new CustomYubiKeyClient(1, key, "nounce");
        return yubikey.otp;
    }
}