using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Base class for all objects that the player can interact with
 */

public class Interactable : MonoBehaviour {

    public float radius = 1f;               //How close the player needs to be to interact
    public Transform interactionTransform;  //Point to stop at.

    bool isFocus = false;
    bool hasInteracted = false;

    Transform player;

    //Base Interact Method
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        //Interaction
        if (isFocus && !hasInteracted)
        {
            //Move to interaction transform
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                //Interact
                Interact();
                hasInteracted = true;
            }
        }   
    }

    //Player right clicks object (Focuses)
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    //Player loses focus (walks elsewhere or interacts with different object
    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        //If no Interaction object is specified, use the object's transform
        if (interactionTransform == null)
            interactionTransform = transform;

        //Debug display interaction radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
