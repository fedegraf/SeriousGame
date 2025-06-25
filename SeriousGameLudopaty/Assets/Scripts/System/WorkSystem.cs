using UnityEngine;

public class WorkSystem : MonoBehaviour
{
    [SerializeField] private int workDuration = 6; // In-game time units
    [SerializeField] private float moneyPerWork = 100f;
    [SerializeField] private float wellnessPenalty = 10f; // Wellness decrease from working
    
    public void StartWork()
    {
        // Deduct time from day
        GameManager.Instance.HoursRemaining -= workDuration;
        // DayNightCycle.Instance.SpendTime(workDuration);
        
        // Add money
        GameManager.Instance.AddMoney(moneyPerWork);
        
        // Decrease wellness from stress

        GameManager.Instance.FamilyWellness -= wellnessPenalty;

        /*
        foreach (var member in GameManager.Instance.familyMembers)
        {
            member.UpdateWellness(-wellnessPenalty);
        }*/
    }
}
