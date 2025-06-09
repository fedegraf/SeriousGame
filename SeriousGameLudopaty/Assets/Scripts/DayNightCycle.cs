using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private float dayDuration = 60f;
    private float currentTime = 0f;
    
    void Update()
    {
        currentTime += Time.deltaTime;
        
        if (currentTime >= dayDuration)
        {
            currentTime = 0f;
            GameManager.Instance.StartNewDay();
        }
        
        // Update visuals
    }
}