using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

	void Start ()
	{
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}
	
    //On Equipment changed Callback
	void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
	{
        if (newItem != null)
        {
            //Apply defense & attack gear modifiers
            defense.AddModifier(newItem.defenseModifier);
            attack.AddModifier(newItem.attackModifier);
        }

        if (oldItem != null)
        {
            //Remove defense & attack gear modifiers
            defense.RemoveModifier(oldItem.defenseModifier);
            attack.RemoveModifier(oldItem.attackModifier);
        }
        
	}

    //Player Dies
    public override void Die()
    {
        base.Die();

        //Kill the player
        PlayerManager.instance.KillPlayer();    //Restarts the scene
            //Add UI popup to restart, go to menu, etc.

    }

}
