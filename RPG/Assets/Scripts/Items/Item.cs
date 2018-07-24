using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    //Default Item properties
    new public string name = "New Item";
    [TextArea]
    public string desc = "New Description";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public bool isConsumable = false;   //Destroyed when used

    [Header("Rarity")]
    public ItemRarity rarity;

    [Header("Stat Modifiers")]
    public int lifeModifier;
    public int attackModifier;
    public int defenseModifier;

    //Use the item
    public virtual void Use()
    {
        // Stat Modifying happens in InventorySlot.UseItem()
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}

public enum ItemRarity { Tattered, Common, Uncommon, Rare, Legendary }
