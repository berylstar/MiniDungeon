using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Shop")]
    public List<GameObject> shopButton = new List<GameObject>();
    public List<ItemSO> forSaleItems = new List<ItemSO>();
    private int si = -1;
}
