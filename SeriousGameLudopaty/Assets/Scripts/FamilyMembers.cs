using UnityEngine;

[System.Serializable]
public class FamilyMember
{
    public string name;
    [SerializeField] private float wellness = 100f; // 0-100 scale
    public float happiness = 100f; // 0-100 scale
    
    public void UpdateWellness(float amount)
    {
        wellness = Mathf.Clamp(wellness + amount, 0f, 100f);
    }
    
    public void UpdateHappiness(float amount)
    {
        happiness = Mathf.Clamp(happiness + amount, 0f, 100f);
    }
}