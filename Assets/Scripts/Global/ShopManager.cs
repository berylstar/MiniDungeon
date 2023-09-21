using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private PlayerStatsUI playerStatsUI;
    [SerializeField] private InventoryManager inven;

    [Header("Shop")]
    [SerializeField] private GameObject panelPopup;
    [SerializeField] private Image imagePopup;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textGold;
    [SerializeField] private TextMeshProUGUI textExplanation;
    [SerializeField] private TextMeshProUGUI textEffect;
    [SerializeField] private Button buttonBuy;

    [SerializeField] private List<GameObject> shopButton = new List<GameObject>();
    public List<ItemSO> forSaleItems = new List<ItemSO>();
    private int si = -1;

    private void Start()
    {
        player = PlayerController.instance;

        for (int i = 0; i < forSaleItems.Count; i++)
        {
            forSaleItems[i] = Instantiate(forSaleItems[i]);
        }

        ShuffleSaleList();
        ShowShop();
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

    public void ShowShop()
    {
        for (int i = 0; i < 5; i++)
        {
            shopButton[i].GetComponent<Image>().sprite = forSaleItems[i].image;
        }
    }

    public void PickItem(int index)
    {
        if (index >= 5)
            return;

        panelPopup.SetActive(true);
        si = index;
        ShowPanelPopup(si);
    }

    private void ShowPanelPopup(int index)
    {
        imagePopup.sprite = forSaleItems[index].image;
        textName.text = forSaleItems[index].itemName;
        textGold.text = $"{forSaleItems[index].price} G";
        textExplanation.text = forSaleItems[index].explaination;
        textEffect.text = forSaleItems[index].effect;
        buttonBuy.interactable = (forSaleItems[index].price <= player.stats.gold || inven.acquiredItems.Count >= 10);
    }

    public void BuyItem()
    {
        player.stats.gold -= forSaleItems[si].price;
        inven.GetBuyItem(forSaleItems[si]);
        forSaleItems.RemoveAt(si);

        playerStatsUI.ShowDefaultUI();
        ShowShop();
    }

    public void GetSoldItem(ItemSO nowItem)
    {
        nowItem.isAcquired = false;
        nowItem.isEquipped = false;

        forSaleItems.Add(nowItem);
    }
}
