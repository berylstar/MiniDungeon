using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    public List<GameObject> inventory = new List<GameObject>();

    public List<ItemSO> acquiredItems = new List<ItemSO>();

    [Header("Pop Up")]
    [SerializeField] private GameObject panelPopup;
    [SerializeField] private Image imagePopup;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textExplanation;
    [SerializeField] private TextMeshProUGUI textEffect;
    private int popupIndex = -1;

    private void Start()
    {
        for (int i = 0; i < acquiredItems.Count; i++)
        {
            inventory[i].GetComponent<Image>().sprite = acquiredItems[i].image;
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

        if (flag == true)   // 장착
        {
            if (player.items[(int)nowItem.type] != null)    // 장착 하기전에 먼저 해제
            {
                UnEffectItem();
            }

            player.items[(int)nowItem.type] = nowItem;
            EffectItem();

            // 장비 효과 적용
        }
        else if (flag == false && player.items[(int)nowItem.type] != null) //해제
        {
            // 장비 효과 해제
            player.items[(int)nowItem.type] = null;
            UnEffectItem();
        }

        inventory[popupIndex].transform.GetChild(0).gameObject.SetActive(flag);
        popupIndex = -1;
    }

    private void EffectItem()
    {

    }

    private void UnEffectItem()
    {

    }
}