using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform itemsParent;
    public GameObject itemButtonPrefab;
    
    private List<GameObject> itemButtons = new List<GameObject>();
    
    public void UpdateInventoryUI()
    {
        // Clear existing buttons
        foreach (var button in itemButtons)
        {
            Destroy(button);
        }
        itemButtons.Clear();
        
        // Create new buttons for each inventory item
        foreach (var item in GameManager.Instance.inventory)
        {
            GameObject newButton = Instantiate(itemButtonPrefab, itemsParent);
            newButton.GetComponent<Image>().sprite = item.icon;
            newButton.GetComponentInChildren<Text>().text = item.itemName;
            
            // Add click handler
            newButton.GetComponent<Button>().onClick.AddListener(() => UseItem(item));
            
            itemButtons.Add(newButton);
        }
    }
    
    void UseItem(InventoryItem item)
    {
        // Apply item effects
        GameManager.Instance.FamilyWellness = Mathf.Clamp(
            GameManager.Instance.FamilyWellness + item.wellnessEffect, 0f, 100f);
        
        // Remove from inventory
        GameManager.Instance.RemoveItemFromInventory(item);
        
        // Update UI
        UpdateInventoryUI();
    }
}