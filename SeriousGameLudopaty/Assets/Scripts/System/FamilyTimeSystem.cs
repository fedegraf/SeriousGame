using UnityEngine;

public class FamilyTimeSystem : MonoBehaviour
{
    public int timeCost = 2; // Time units spent
    public float wellnessGain = 15f; // Wellness increase per family member
    
    public void SpendTimeWithFamily()
    {
        // Deduct time from day
        GameManager.Instance.HoursRemaining -= timeCost;
        // DayNightCycle.Instance.SpendTime(timeCost);
        
        // Increase wellness for all family members
        /*foreach (var member in GameManager.Instance.familyMembers)
        {
            member.UpdateWellness(wellnessGain);
        }*/
        
        GameManager.Instance.FamilyWellness += wellnessGain;
    }
}