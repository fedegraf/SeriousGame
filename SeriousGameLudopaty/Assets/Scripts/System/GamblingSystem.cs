using UnityEngine;

public class GamblingSystem : MonoBehaviour
{
    [SerializeField] private float minGambleAmount = 20f;
    [SerializeField] private float maxGambleAmount = 100f;
    [SerializeField] private float winProbability = 0.25f; // 25% chance to win
    [SerializeField] private float winMultiplier = 2f; // 2x return on win
    
    public void Gamble(float amount)
    {
        if (amount > GameManager.Instance.Money) return;
        
        bool win = Random.value <= winProbability;
        
        if (win)
        {
            float winnings = amount * winMultiplier;
            GameManager.Instance.AddMoney(winnings);
            // Show win UI
        }
        else
        {
            GameManager.Instance.SpendMoney(amount);
            // Show loss UI
        }
        
        // Gambling affects wellness negatively
        foreach (var member in GameManager.Instance.familyMembers)
        {
            member.UpdateWellness(-5f);
        }
    }
}