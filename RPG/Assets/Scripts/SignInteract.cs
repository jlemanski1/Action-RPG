using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteract : Interactable
{
    DialogueTrigger dialogueTrigger;
    
	void Start ()
	{
        dialogueTrigger = GetComponent<DialogueTrigger>();
	}

    public override void Interact()
    {
        base.Interact();

        dialogueTrigger.TriggerDialogue();
    }
}
