using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one isntance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();     //Inventory: List of items
    public int space = 20;      //Space in inventory

    public bool Add(Item item)
    {
        //Check if it's a default item
        if (!item.isDefaultItem)
        {
            //Check for full inventory
            if (items.Count >= space)
            {
                Debug.Log("Not enough inventory space.");
                return false;
            }
            //Add Item to Inventory
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true; 
    }

    public void Remove(Item item)
    {
        //Remove item from inventory
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
