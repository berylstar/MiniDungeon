using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    private PlayerController player;
    
    [Header("Inventory")]
    [SerializeField] private PlayerStatsUI playerStatsUI;

    [SerializeField] private GameObject panelPopup;
    [SerializeField] private Image imagePopup;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textGold;
    [SerializeField] private TextMeshProUGUI textExplanation;
    [SerializeField] private TextMeshProUGUI textEffect;

    public List<GameObject> inventoryButton = new List<GameObject>();
    public List<ItemSO> acquiredItems = new List<ItemSO>();
    private int ii = -1;

    private void Start()
    {
        player = PlayerController.instance;

        for (int i = 0; i < acquiredItems.Count; i++)
        {
            inventoryButton[i].GetComponent<Image>().sprite = acquiredItems[i].image;
            acquiredItems[i].inventoryIndex = i;
            acquiredItems[i].isAcquired = true;
            acquiredItems[i].isEquipped = false;
        }

        // 상점 새로고침
    }

    public void PickItem(int index)
    {
        if (index >= acquiredItems.Count)
            return;

        panelPopup.SetActive(true);
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

    public void ToggleItem(bool flag)
    {
        if (ii < 0)
            return;

        ItemSO nowItem = acquiredItems[ii];

        if (!nowItem.isAcquired)
            return;

        if (flag == true) // 장착
        {
            if (player.items[(int)nowItem.type] != null)    // 장착 하기전에 같은 종류의 장비가 장착되어 있다면 먼저 해제
            {
                EffectOrUneffectItem(player.items[(int)nowItem.type], false);
            }
            
            EffectOrUneffectItem(nowItem, true);
        }

        else if (flag == false && player.items[(int)nowItem.type] != null) // 해제
        {
            EffectOrUneffectItem(nowItem, false);
        }

        ii = -1;

        playerStatsUI.ShowDefaultUI();
    }

    private void EffectOrUneffectItem(ItemSO data, bool onoff)
    {
        player.items[(int)data.type] = (onoff) ? data : null;

        player.ChangeStats(data, onoff);

        inventoryButton[data.inventoryIndex].transform.GetChild(0).gameObject.SetActive(onoff);
    }
}