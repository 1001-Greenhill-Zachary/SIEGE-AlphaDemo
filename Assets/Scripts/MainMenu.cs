using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject instructionScreen;
    public GameObject creditScreen;

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void deselectAllMenus()
    {
        menuScreen.SetActive(false);
        instructionScreen.SetActive(false);
        creditScreen.SetActive(false);
    }

    public void mainMenu()
    {
        deselectAllMenus();
        menuScreen.SetActive(true);
    }

    public void instructionMenu()
    {
        deselectAllMenus();
        instructionScreen.SetActive(true);
    }

    public void creditMenu()
    {
        deselectAllMenus();
        creditScreen.SetActive(true);
    }
}
