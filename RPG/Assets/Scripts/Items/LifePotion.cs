using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LifePotion is a generic name as this same script can be used with a negative
/// value to work as a poison type potion that damages the character's health.
/// </summary>
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/LifePotion")]
public class LifePotion : Item {

    [Header("Player Stats")]
    PlayerStats playerStats;

    [Header("Stat Modifiers")]
    public int lifeModifier;

    private void Awake() {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    /// <summary>
    /// Interact with the potion/food item (whatever item modifies the life)
    /// </summary>
    public override void Use() {
        // Apply the effects
        playerStats.life.AddModifier(lifeModifier);

        base.Use();
    }
}
