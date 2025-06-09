using UnityEngine;

public class FamilyTimeSystem : MonoBehaviour
{
    public float timeCost = 5f; // Time units spent
    public float wellnessGain = 15f; // Wellness increase per family member
    
    public void SpendTimeWithFamily()
    {
        // Deduct time from day
        // DayNightCycle.Instance.SpendTime(timeCost);
        
        // Increase wellness for all family members
        foreach (var member in GameManager.Instance.familyMembers)
        {
            member.UpdateWellness(wellnessGain);
        }
    }
}