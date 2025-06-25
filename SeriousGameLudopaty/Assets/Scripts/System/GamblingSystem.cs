using UnityEngine;

public class GamblingSystem : MonoBehaviour
{
    [SerializeField] private float minGambleAmount = 20f;
    [SerializeField] private float maxGambleAmount = 100f;
    [SerializeField] private float winProbability = 0.50f; // 25% chance to win
    [SerializeField] private float winMultiplier = 2f; // 2x return on win
    [SerializeField] private float wellnessPenalty = 10f; // Wellness decrease
    [SerializeField] private int timeSpent = 2;
    
    public void Gamble()
    {
        if (minGambleAmount > GameManager.Instance.Money) return;
        Debug.Log("Bet: $" + minGambleAmount);
        
        bool win = Random.value <= winProbability;

        if (win)
        {
            float winnings = minGambleAmount * winMultiplier;
            GameManager.Instance.AddMoney(winnings);
            Debug.Log("Bet winned, winnings: $" + winnings);
            // Show win UI
        }
        else
        {
            GameManager.Instance.SpendMoney(minGambleAmount);
            Debug.Log("Bet Lost");
            // Show loss UI
        }
        
        // Gambling affects wellness negatively
        /*
        foreach (var member in GameManager.Instance.familyMembers)
        {
            member.UpdateWellness(-5f);
        }
        */
        GameManager.Instance.FamilyWellness -= wellnessPenalty;
        GameManager.Instance.HoursRemaining -= timeSpent;

        
        winProbability -= 0.05f;
        winProbability = Mathf.Clamp(winProbability, 0f, 100f);
        Debug.Log("Winning Probability: " + winProbability);

        minGambleAmount += 20f;
        minGambleAmount = Mathf.Clamp(minGambleAmount, 0f, 150f);

        timeSpent++;
    }
}