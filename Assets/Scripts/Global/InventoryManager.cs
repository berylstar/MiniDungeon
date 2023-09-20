using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Image> items = new List<Image>();

    public List<ItemController> acquiredItems = new List<ItemController>();

    private void Start()
    {
        for (int i = 0; i< acquiredItems.Count; i++)
        {
            items[i].sprite = acquiredItems[i].data.image;
        }
    }
}