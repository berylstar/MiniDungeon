using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Armor = 0,
    Weapon = 1,
    Accessory = 2,
    Food = 3,
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/Item")]
public class ItemSO : ScriptableObject
{
    [Header("Item Info")]
    public string itemName;
    public ItemType type;
    public Sprite image;
    [Multiline(2)]
    public string explaination;
    [Multiline(2)]
    public string effect;
    public UnitStatsSO statChangers;
    public int price;

    [Header("Item Status")]
    public bool isAcquired = false;
    public int inventoryIndex = -1;
    public bool isEquipped = false;
}
