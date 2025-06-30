using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject ludopathy;
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToTutorial()
    {
        menu.SetActive(false);
        tutorial.SetActive(true);
    }
    
    public void GoBackToMenu()
    {
        menu.SetActive(true);
        tutorial.SetActive(false);
        ludopathy.SetActive(false);
    }
    
    public void GoToLudopathy()
    {
        menu.SetActive(false);
        ludopathy.SetActive(true);
    }
    
    
    
}
