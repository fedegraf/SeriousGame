using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private int currentDay = 1;
    private float familyWellness = 100f; // escala 0-100 
    private float money = 500f; // Dinero inicial
    
    public int CurrentDay { get => currentDay; }

    public float FamilyWellness { get => familyWellness; set => FamilyWellness = value; }

    public float Money { get => money; }
    
    public List<InventoryItem> inventory = new List<InventoryItem>();
    
    [Header("Daily Costs")]
    [SerializeField] private float dailyFoodCost = 20f;
    [SerializeField] private float dailyRentCost = 50f;
    
    [Header("Family Members")]
    public FamilyMember[] familyMembers;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void StartNewDay()
    {
        // Deduct daily costs
        money -= dailyFoodCost + dailyRentCost;
        
        // Check for game over conditions
        if (money <= 0 || familyWellness <= 0)
        {
            GameOver();
            return;
        }
        
        // Update wellness based on conditions
        UpdateFamilyWellness();
        
        currentDay++;
    }
    
    void UpdateFamilyWellness()
    {
        float wellnessChange = 0f;
        
        // Base wellness decrease
        wellnessChange -= 5f;
        
        // Apply modifiers from items, time spent, etc.
        // ...
        
        familyWellness = Mathf.Clamp(familyWellness + wellnessChange, 0f, 100f);
    }
    
    void GameOver()
    {
        // Show game over screen
        Debug.Log("Game Over! Days survived: " + currentDay);
    }
    
    public void AddMoney(float amount)
    {
        money += amount;
    }
    
    public void SpendMoney(float amount)
    {
        money -= amount;
    }
    
    public void AddItemToInventory(InventoryItem item)
    {
        inventory.Add(item);
    }
    
    public void RemoveItemFromInventory(InventoryItem item)
    {
        inventory.Remove(item);
    }
}