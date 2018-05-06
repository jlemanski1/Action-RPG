using UnityEngine;

/*
 * Base Stat class used to inherit from for Characters (ex. player, npcs, enemies)
 * TODO: Add more stats to base and PlayerStats class
 * TODO: Make health a stat so armour can modify it & potions can restore it
 */
public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat attack;     //Damage
    public Stat defense;    //armour

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        //Lessen damage by armour value
        //TODO: * damage & attack, defense modifiers by a level modifier (maybe Enum lvl : modifier %)
        damage -= defense.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);  //Prevent strong armour from causing damage to be negative

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        //Death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die in some way (turn into physics ragdoll for enemy?)
        //Override this method
        Debug.Log(transform.name + " died.");
    }
}
