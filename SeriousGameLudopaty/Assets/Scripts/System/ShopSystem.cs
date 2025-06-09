using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public List<InventoryItem> availableItems = new List<InventoryItem>();

    [SerializeField] private Transform container;
    [SerializeField] private Transform shopItemTemplate;

    private void Start()
    {
        int index = 0;
        foreach (InventoryItem item in availableItems)
        {
            CreateItemButton(item.icon, item.itemName, item.value, index);
            index++;
        }
    }

    private void CreateItemButton(Sprite itemSprite, string itemName, float itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        
        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);
        
        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText("$" + itemCost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
    }

    public void BuyItem(InventoryItem item)
    {
        if (GameManager.Instance.Money >= item.value)
        {
            GameManager.Instance.SpendMoney(item.value);
            GameManager.Instance.AddItemToInventory(item);
        }
    }
    
    public void SellItem(InventoryItem item)
    {
        if (GameManager.Instance.inventory.Contains(item))
        {
            GameManager.Instance.AddMoney(item.value);
            GameManager.Instance.RemoveItemFromInventory(item);
        }
    }
}