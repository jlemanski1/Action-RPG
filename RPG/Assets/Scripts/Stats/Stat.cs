using System.Collections.Generic;
using UnityEngine;

/*
 * Stat Object,
 * Base stat value -> Modifier -> Final Stat Value
 * Modify stat value with modifiers
 */

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;   //Starting value for the given stat

    private List<int> modifiers = new List<int>();

    //Return the final value (after modifiers have been applied)
    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(modifier => finalValue += modifier);

        return finalValue;
    }

    //Add modifier to list
    public void AddModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }
	
    //Remove modifier from list
    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }
}
