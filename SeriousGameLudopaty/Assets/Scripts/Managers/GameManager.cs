using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public event Action<float> OnVariableChange;

    private int currentDay = 1;
    [SerializeField] private int hoursOfTheDay = 10;
    [SerializeField] private float displayTime;
    private int hoursRemaining;
    private float familyWellness = 100f; // escala 0-100 
    private float money = 500f; // Dinero inicial

    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private TextMeshProUGUI familyWellnessText;
    [SerializeField] private TextMeshProUGUI hoursRemainingText;
    [SerializeField] private TextMeshProUGUI daysPlayingText;

    public int CurrentDay { get => currentDay; }
    
    public int HoursRemaining
    {
        get => hoursRemaining;
        set
        {
            hoursRemaining = value;
            UpdateHours();
        }
    }

    public float FamilyWellness
    {
        get => familyWellness;
        set { 
            familyWellness = value;
            OnVariableChange.Invoke(familyWellness);
        }
        
    }

    public float Money { get => money;         
        set { 
        money = value;
        OnVariableChange.Invoke(money);
    }}
    
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
        OnVariableChange  += UpdateUITexts;
        OnVariableChange += CheckForGameOver;

        hoursRemaining = hoursOfTheDay;
        
        hoursRemainingText.text = "Horas disponibles: " + hoursRemaining;
        daysPlayingText.text = "dias jugados: 1";
    }

    private void UpdateUITexts(float obj)
    {
        currencyText.text = "Dinero: $" + money;
        familyWellnessText.text = "Bienestar Familiar: " + familyWellness;
    }

    public void StartNewDay()
    {
        Debug.Log("New Day Started");
        // Deduct daily costs
        money -= dailyFoodCost + dailyRentCost;
        UpdateFamilyWellness();

        CheckForGameOver(0);

        currentDay++;
        daysPlayingText.text = "dias jugados: " + currentDay;
    }

    public void UpdateHours()
    {
        Debug.Log("Hours Remaining: " + hoursRemaining);
        if (hoursRemaining <= 0)
        {
            StartNewDay();
            hoursRemaining += hoursOfTheDay;
        }
        hoursRemainingText.text = "Horas disponibles: " + hoursRemaining;
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
    
    void CheckForGameOver(float obj)
    {
        if (money <= 0 || familyWellness <= 0)
        {
            // Show game over screen
            Debug.Log("Game Over! Days survived: " + currentDay);        }
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