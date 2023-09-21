using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inven;

    [Header("Shop")]
    [SerializeField] private GameObject panelPopup;
    [SerializeField] private Image imagePopup;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textGold;
    [SerializeField] private TextMeshProUGUI textExplanation;
    [SerializeField] private TextMeshProUGUI textEffect;

    [SerializeField] private List<GameObject> shopButton = new List<GameObject>();
    public List<ItemSO> forSaleItems = new List<ItemSO>();
    private int si = -1;

    private void Start()
    {
        foreach (ItemSO item in forSaleItems)
        {
            item.isAcquired = false;
            item.isEquipped = false;
        }

        ShuffleSaleList();
    }

    private void ShuffleSaleList()
    {
        for (int i = 0; i < forSaleItems.Count; i++)
        {
            int iRand = Random.Range(0, forSaleItems.Count);

            ItemSO temp = forSaleItems[i];
            forSaleItems[i] = forSaleItems[iRand];
            forSaleItems[iRand] = temp;
        }
    }
}
