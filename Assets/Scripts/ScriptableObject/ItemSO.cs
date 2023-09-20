using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Armor,
    Weapon,
    Accessory,
    Food,
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
}
