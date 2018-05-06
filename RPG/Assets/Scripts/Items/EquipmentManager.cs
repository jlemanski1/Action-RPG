using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    [Header("Equiped Items")]
    Equipment[] currentEquipment;

    public Equipment[] defaultItems;

    public SkinnedMeshRenderer targetMesh;
    SkinnedMeshRenderer[] currentMeshes;    //Meshes of equiped gear

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        //Initialize currentEquipment based on number of equipment slots
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];

        //Initialize current Mesh array
        currentMeshes = new SkinnedMeshRenderer[numSlots];

        //Equip default equipment
        EquipDefaultItems();
    }

    //Equip Item
    public void Equip(Equipment newItem)
    {
        //Get the slot index of the item to equip
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = UnEquip(slotIndex);

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        //Set blendshape so body doesn't intersect with the armour
        SetEquipmentBlendShapes(newItem, 100);

        //Set slotIndex to newItem
        currentEquipment[slotIndex] = newItem;

        //Instantiate the new mesh
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);

        //Set the mesh's parent object (target: player body mesh)
        newMesh.transform.parent = targetMesh.transform;

        //Set newMesh to deform with the target mesh's bones
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

        //Add new mesh to currentMeshes
        currentMeshes[slotIndex] = newMesh;

    }

    //Unequip Item
    public Equipment UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            //Add back to inventory
            Equipment oldItem = currentEquipment[slotIndex];
            SetEquipmentBlendShapes(oldItem, 0);
            inventory.Add(oldItem);

            //Remove from Equipment slots
            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            return oldItem;
        }
        return null;
    }

    //UnEquip all items
    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }

        //Equip default items so as to not be naked
        EquipDefaultItems();
    }

    //Set blend shapes for equipment to correspond with the proper region
    void SetEquipmentBlendShapes(Equipment item, int weight)
    {
        foreach (EquipmentMeshRegion blendShape in item.coveredMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
        }
    }

    //Equip items marked default
    void EquipDefaultItems()
    {
        foreach (Equipment item in defaultItems)
        {
            Equip(item);
        }
    }

    void Update()
    {
        //U: UnEquipAll
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnEquipAll();
        }
    }
}
