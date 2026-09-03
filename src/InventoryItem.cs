using Godot;
using Godot.Collections;

public struct InventoryItem
{
    public enum TYPE: byte {
        HEALING,
        INFO,
        UNIQUE
    }
    public string name;
    public string description;
    public TYPE itemType;

    public InventoryItem(string name, string description, TYPE itemType)
    {
        this.name = name;
        this.description = description;
        this.itemType = itemType;
    }

    public static InventoryItem[] LoadInventoryItems()
    {
        var f = FileAccess.GetFileAsString("res://data/item.json");

        Dictionary j = (Dictionary) Json.ParseString(f);

        Array items = (Array) j["items"];

        InventoryItem[] inventoryItems = new InventoryItem[items.Count];

        for (int i = 0; i < items.Count; i++)
        {
            Dictionary item = (Dictionary) items[i];

            InventoryItem _item = new InventoryItem((string) item["name"], (string) item["desc"], 0);
        }

        return inventoryItems; 
    }
}