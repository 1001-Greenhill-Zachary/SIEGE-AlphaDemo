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

    public void QuitGame()
    {
        Application.Quit();
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

    public void Link1()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/3d/environments/landscapes/rpg-poly-pack-lite-148410");
    }

    public void Link2()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/3d/environments/dungeons/medieval-castle-pack-lite-51230");
    }

    public void Link3()
    {
        Application.OpenURL("https://www.bensound.com/royalty-free-music/track/epic");
    }

    public void Link4()
    {
        Application.OpenURL("https://mixkit.co/free-sound-effects/click/");
    }

    public void Link5()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/3d/characters/creatures/rpg-monster-duo-pbr-polyart-157762");
    }

    public void Link6()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/3d/props/weapons/low-poly-weapons-71680");
    }

    public void Link7()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/3d/environments/fantasy/canon-tower-50215");
    }

    public void Link8()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/3d/props/exterior/tower-defence-cannon-74837");
    }

    public void Link9()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/3d/environments/fantasy/awesome-stylized-mage-tower-53793");
    }

    public void Link10()
    {
        Application.OpenURL("https://www.1001fonts.com/blackwood-castle-font.html");
    }

    public void Link11()
    {
        Application.OpenURL("https://www.1001fonts.com/english-towne-font.html");
    }

    public void Link12()
    {
        Application.OpenURL("https://ecsl.cse.unr.edu/");
    }

    public void Link13()
    {
        Application.OpenURL("https://store.steampowered.com/app/1843760/Rogue_Tower/");
    }

    public void Link14()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA");
    }
}
