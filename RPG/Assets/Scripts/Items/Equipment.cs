using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    [Header("Slot")]
    public EquipmentSlot equipSlot;

    [Header("Item Mesh")]
    public SkinnedMeshRenderer mesh;    //Item's mesh
    public EquipmentMeshRegion[] coveredMeshRegions;    //Region's the gear covers

    [Header("Stat Modifiers")]
    public int attackModifier;
    public int defenseModifier;

    public override void Use()
    {
        base.Use();

        //Equip the item
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Offhand, Feet }

public enum EquipmentMeshRegion { Legs, Arms, Torso };   //Corresponds to body blendshapes