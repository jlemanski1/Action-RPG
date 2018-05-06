using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject inventoryUI;

    //Tooltip
    [Header("Tooltip/Item Description")]
    public GameObject tooltip;
    public Text nameText;
    public Text descText;

    InventorySlot[] slots;  //Array of inventory slots
    Inventory inventory;    //Inventory instance


    void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;    //Trigger UpdateUI when an item is added or removed

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();   //Move to UpdateUI or check callback if I add the ability to unlock slots
    }


    void Update () {
		if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

	}

    void UpdateUI()
    {
        //Loop through slots
        for (int i = 0; i < slots.Length; i++)
        { 
            //Check for free space
            if (i < inventory.items.Count)
            {
                //Add item
                slots[i].AddItem(inventory.items[i]);
                //nameText.text = inventory.items[i].rarity + " " + inventory.items[i].name;    //Set tooltip name to item's name
            }
            else
            {
                //Clear Item
                slots[i].ClearSlot();
            }
        }

    }
}
