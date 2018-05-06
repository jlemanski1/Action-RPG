using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    Item item;  //Current item in the slot

    public Image icon;
    public Button removeButton;

    public InventoryUI inventoryUI;

    //Add Item to slot
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        removeButton.interactable = true;
    }

    //Clear Item from slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    //Click the remove button
    public void OnRemoveButton()
    {
        //Remove item from slot
        Inventory.instance.Remove(item);
        /* Currently items are destroyed when removed, either add a warning or drop item on ground */
    }

    //Click on the Item (icon)
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();

            //If item's consumable
            if (item.isConsumable)
            {
                //Remove from slot after use
                Inventory.instance.Remove(item);

                //Modify stats
            }
        }
    }

    //Shows item name & description on mouse over
    public void ShowTooltip()
    {
        if (item != null)
        {
            //Change nameText colour to represent rarity
            switch (item.rarity)
            {
                case ItemRarity.Tattered:
                    inventoryUI.nameText.color = Color.white;
                    break;
                case ItemRarity.Common:
                    inventoryUI.nameText.color = Color.green;
                    break;
                case ItemRarity.Uncommon:
                    inventoryUI.nameText.color = Color.cyan;
                    break;
                case ItemRarity.Rare:
                    inventoryUI.nameText.color = Color.magenta;
                    break;
                case ItemRarity.Legendary:
                    inventoryUI.nameText.color = Color.yellow;
                    break;
                default:
                    break;
            }

            //Set tooltip nameText to item's name
            inventoryUI.nameText.text = item.rarity + " " + item.name;

            //Set tooltip description to item's description
            inventoryUI.descText.text = item.desc;

            //Set tooltip to active
            inventoryUI.tooltip.SetActive(true);
        }
        
    }

    //Hide the tooltip
    public void HideTooltip()
    {
        inventoryUI.tooltip.SetActive(false);
    }


}
