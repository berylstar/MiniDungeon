using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private PlayerStatsUI playerStatsUI;
    [SerializeField] private ShopManager shop;

    [Header("Inventory")]
    [SerializeField] private Image imagePopup;
    [SerializeField] private TextMeshProUGUI textInventoryLimit;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textGold;
    [SerializeField] private TextMeshProUGUI textExplanation;
    [SerializeField] private TextMeshProUGUI textEffect;

    [SerializeField] private List<GameObject> inventoryButton = new List<GameObject>();
    public List<ItemSO> acquiredItems = new List<ItemSO>();

    private int ii = -1;    // inventory index

    private void Start()
    {
        player = PlayerController.instance;

        for (int i = 0; i < acquiredItems.Count; i++)
        {
            acquiredItems[i] = Instantiate(acquiredItems[i]);
        }
    }

    // 획득한 아이템만 보이게
    public void ShowInventory()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i < acquiredItems.Count)
            {
                inventoryButton[i].SetActive(true);
                inventoryButton[i].GetComponent<Image>().sprite = acquiredItems[i].image;
                acquiredItems[i].inventoryIndex = i;
            }
            else
            {
                inventoryButton[i].SetActive(false);
            }
        }

        textInventoryLimit.text = $"{acquiredItems.Count}/10";
    }

    public void PickItem(int index)
    {
        if (index >= acquiredItems.Count)
            return;

        ii = index;
        ShowPanelPopup(ii);
    }

    private void ShowPanelPopup(int index)
    {
        imagePopup.sprite = acquiredItems[index].image;
        textName.text = acquiredItems[index].itemName;
        textGold.text = $"{acquiredItems[index].price} G";
        textExplanation.text = acquiredItems[index].explaination;
        textEffect.text = acquiredItems[index].effect;
    }

    // 아이템 장착 / 해제 메소드
    public void ToggleItem()
    {
        if (ii < 0)
            return;

        ItemSO nowItem = acquiredItems[ii];

        if (!nowItem.isAcquired)
            return;

        if (nowItem.isEquipped == false) // 장착
        {
            if (player.items[(int)nowItem.type] != null)    // 장착 하기전에 같은 종류의 장비가 장착되어 있다면 먼저 해제
            {
                EffectOrUneffectItem(player.items[(int)nowItem.type], false);
            }
            
            EffectOrUneffectItem(nowItem, true);
        }

        else if (nowItem.isEquipped == true && player.items[(int)nowItem.type] != null) // 해제
        {
            EffectOrUneffectItem(nowItem, false);
        }

        ii = -1;
        playerStatsUI.ShowDefaultUI();
    }

    private void EffectOrUneffectItem(ItemSO nowItem, bool onoff)
    {
        player.items[(int)nowItem.type] = (onoff) ? nowItem : null;

        player.ChangeStats(nowItem, onoff);

        nowItem.isEquipped = !nowItem.isEquipped;

        inventoryButton[nowItem.inventoryIndex].transform.GetChild(0).gameObject.SetActive(onoff);
    }

    public void SellItem()
    {
        ItemSO nowItem = acquiredItems[ii];

        player.stats.gold += nowItem.price / 2;

        if (nowItem.isEquipped)
            EffectOrUneffectItem(nowItem, false);

        shop.GetSoldItem(nowItem);
        acquiredItems.RemoveAt(ii);

        ii = -1;

        playerStatsUI.ShowDefaultUI();
        ShowInventory();
    }

    // ShopManager에서 실행할 메소드
    public void GetBuyItem(ItemSO nowItem)
    {
        nowItem.isAcquired = true;
        nowItem.isEquipped = false;
        acquiredItems.Add(nowItem);
    }
}