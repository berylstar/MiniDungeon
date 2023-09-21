using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    

    [Header("Inventory")]
    public List<GameObject> inventoryButton = new List<GameObject>();
    public List<ItemSO> acquiredItems = new List<ItemSO>();

    [Header("Shop")]
    public List<ItemSO> forSaleItems = new List<ItemSO>();

    [Header("Panel Pop Up")]
    [SerializeField] private PlayerStatsUI playerStatsUI;
    [SerializeField] private GameObject panelPopup;
    [SerializeField] private Image imagePopup;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textGold;
    [SerializeField] private TextMeshProUGUI textExplanation;
    [SerializeField] private TextMeshProUGUI textEffect;
    private int popupIndex = -1;

    private void Start()
    {
        for (int i = 0; i < acquiredItems.Count; i++)
        {
            inventoryButton[i].GetComponent<Image>().sprite = acquiredItems[i].image;
            acquiredItems[i].inventoryIndex = i;
            acquiredItems[i].isAcquired = true;
            acquiredItems[i].isEquipped = false;
        }

    }

    public void PickItem(int index)
    {
        if (index >= acquiredItems.Count)
            return;

        panelPopup.SetActive(true);
        popupIndex = index;
        ShowPanelPopup(popupIndex);
    }

    private void ShowPanelPopup(int index)
    {
        imagePopup.sprite = acquiredItems[index].image;
        textName.text = acquiredItems[index].itemName;
        textGold.text = $"{acquiredItems[index].price} G";
        textExplanation.text = acquiredItems[index].explaination;
        textEffect.text = acquiredItems[index].effect;
    }

    public void ToggleItem(bool flag)
    {
        if (popupIndex < 0)
            return;

        ItemSO nowItem = acquiredItems[popupIndex];

        if (!nowItem.isAcquired)
            return;

        if (flag == true) // ����
        {
            if (player.items[(int)nowItem.type] != null)    // ���� �ϱ����� ���� ������ ��� �����Ǿ� �ִٸ� ���� ����
            {
                EffectOrUneffectItem(player.items[(int)nowItem.type], false);
            }
            
            EffectOrUneffectItem(nowItem, true);
        }

        else if (flag == false && player.items[(int)nowItem.type] != null) // ����
        {
            EffectOrUneffectItem(nowItem, false);
        }
        
        popupIndex = -1;

        playerStatsUI.ShowDefaultUI();
    }

    private void EffectOrUneffectItem(ItemSO data, bool onoff)
    {
        if (data.statChangers == null)
            return;

        player.items[(int)data.type] = (onoff) ? data : null;

        player.ChangeStats(data.statChangers, onoff);

        inventoryButton[data.inventoryIndex].transform.GetChild(0).gameObject.SetActive(onoff);
    }
}