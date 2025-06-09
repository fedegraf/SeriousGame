using UnityEngine;
using UnityEngine.UI;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem Instance;
    
    public GameObject tooltipPanel;
    public Text tooltipText;
    
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
        
        HideTooltip();
    }
    
    public void ShowTooltip(string text, Vector2 position)
    {
        tooltipPanel.SetActive(true);
        tooltipText.text = text;
        tooltipPanel.transform.position = position;
    }
    
    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }
}