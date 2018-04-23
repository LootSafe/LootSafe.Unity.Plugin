using UnityEngine;

public class LootSafe : MonoBehaviour
{
    public Balance balance;
    public Crafter crafter;
    public Events events;
    public General general;
    public Items items;
    public LootBox lootbox;

    private LootSafe(){}

    public LootSafe Initialize (string apiUrl, string apiKey)
    {
        balance = gameObject.AddComponent<Balance>().Initialize(apiUrl);
        crafter = gameObject.AddComponent<Crafter>().Initialize(apiUrl);
        events = gameObject.AddComponent<Events>().Initialize(apiUrl);
        general = gameObject.AddComponent<General>().Initialize(apiUrl);
        items = gameObject.AddComponent<Items>().Initialize(apiUrl);
        lootbox = gameObject.AddComponent<LootBox>().Initialize(apiUrl);

        return this;
    }
}