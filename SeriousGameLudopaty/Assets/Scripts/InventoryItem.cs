using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public float wellnessEffect; // How much this affects family wellness when used
    public float value; // Monetary value
    public Sprite icon;
    
    public InventoryItem(string name, float effect, float val)
    {
        itemName = name;
        wellnessEffect = effect;
        value = val;
    }
}