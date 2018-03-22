public class LootSafe
{
    /* End Points */

    public Balance balance;
    public Crafter crafter;
    public Global global;
    public Items items;
    public LootBox lootbox;

    /* Private Constructor */

    private LootSafe(){}

    /* Public Constructor */

    public LootSafe(string apiUrl, string apiKey)
    {
        balance = new Balance(apiUrl);
        crafter = new Crafter(apiUrl);
        global = new Global(apiUrl);
        items = new Items(apiUrl);
        lootbox = new LootBox(apiUrl);
    }
}