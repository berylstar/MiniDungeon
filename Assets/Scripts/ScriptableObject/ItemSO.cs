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
    public string explaination;
    public string effect;
    public int price;

    [Header("Item Status")]
    public bool isAcquired;
    public bool isEquipped;
}
