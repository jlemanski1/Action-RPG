using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;

    //Interact with item (pickup)
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);

        //Add to inventory
        bool wasPickedUp = Inventory.instance.Add(item);

        //Destory gameobject if pickup was successful
        if (wasPickedUp)
            Destroy(gameObject);
    }
	
}
