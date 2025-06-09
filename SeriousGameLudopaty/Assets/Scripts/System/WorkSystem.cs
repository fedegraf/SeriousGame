using UnityEngine;

public class WorkSystem : MonoBehaviour
{
    [SerializeField] private float workDuration = 10f; // In-game time units
    [SerializeField] private float moneyPerWork = 100f;
    [SerializeField] private float wellnessPenalty = 10f; // Wellness decrease from working
    
    public void StartWork()
    {
        // Deduct time from day
        // DayNightCycle.Instance.SpendTime(workDuration);
        
        // Add money
        GameManager.Instance.AddMoney(moneyPerWork);
        
        // Decrease wellness from stress
        foreach (var member in GameManager.Instance.familyMembers)
        {
            member.UpdateWellness(-wellnessPenalty);
        }
    }
}
