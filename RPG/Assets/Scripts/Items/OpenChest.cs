using UnityEngine;

public class OpenChest : Interactable
{
    
    [SerializeField]
    [Header("Chest Inventory")]
    public Item[] items;    //Items in Chest

    Animator chestAnim;
    DialogueTrigger dialogueTrigger;

    private bool hasOpened = false;

    private void Start()
    {
        chestAnim = GetComponent<Animator>();
        chestAnim.enabled = false;

        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public override void Interact()
    {
        base.Interact();
        if (!hasOpened)
        {
            Open();
            dialogueTrigger.TriggerDialogue();
        }
    }

    private void Open()
    {
        //Play Opening animation
        //TODO: Proper animation controller implementation, currently just enabled then plays default anim. make states
        chestAnim.enabled = true;
        //chestAnim.Play("Open");

        //Add chest item(s) to inventory
        for (int i = 0; i < items.Length; i++)
        {
            bool wasPickedUp = Inventory.instance.Add(items[i]);

            //Remove from chest when picked up
            if (wasPickedUp)
                items[i] = null;
        }

        hasOpened = true;      
    }
}
