using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Text Displays")]
    public Text moneyText;
    public Text dayText;
    public Text wellnessText;
    
    [Header("Screens")]
    public GameObject gameOverScreen;
    public GameObject mainGameScreen;
    public GameObject shopScreen;
    
    void Update()
    {
        // Update UI elements
        moneyText.text = "$" + GameManager.Instance.Money.ToString("F2");
        dayText.text = "Day: " + GameManager.Instance.CurrentDay;
        wellnessText.text = "Family Wellness: " + GameManager.Instance.FamilyWellness.ToString("F0") + "%";
    }
    
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        mainGameScreen.SetActive(false);
    }
    
    public void ShowShopScreen()
    {
        shopScreen.SetActive(true);
        mainGameScreen.SetActive(false);
    }
    
    public void ReturnToMainScreen()
    {
        mainGameScreen.SetActive(true);
        shopScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }
}