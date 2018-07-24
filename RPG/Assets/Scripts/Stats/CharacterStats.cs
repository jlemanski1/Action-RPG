using UnityEngine;

/*
 * Base Stat class used to inherit from for Characters (ex. player, npcs, enemies)
 * TODO: Add more stats to base and PlayerStats class
 */
public class CharacterStats : MonoBehaviour
{

    public Stat life;       // Health
    public Stat attack;     //Damage
    public Stat defense;    //armour

    private void Awake()
    {
        //currentHealth = maxHealth;
        
    }

    public void TakeDamage(int damage)
    {
        //Lessen damage by armour value
        //TODO: * damage & attack, defense modifiers by a level modifier (maybe Enum lvl : modifier %)
        damage -= defense.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);  //Prevent strong armour from causing damage to be negative

        life.AddModifier(-damage);
        Debug.Log(transform.name + " takes " + damage + " damage." + "\n\tlife: " + life.GetValue());

        //Death
        if (life.GetValue() <= 0)
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
