/* -----------------------------------------------------------------------------
FILE NAME:      UIMgr.cs
AUTHOR:         FrogMaze
DESCRIPTION:    Manages and updates UI Interface
NOTES:          
---------------------------------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMgr : MonoBehaviour
{
    public static UIMgr inst;
    private void Awake()
    {
        inst = this;
    }

    // Clock components
    /* Old Clock
    public Text minute1;
    public Text minute2;
    public Text second1;
    public Text second2;
    */
    public TextMeshProUGUI minuteTMP0;
    public TextMeshProUGUI minuteTMP1;
    public TextMeshProUGUI secondTMP0;
    public TextMeshProUGUI secondTMP1;


    // Castle Health bar
    public Slider castleHealthBar;

    // Player Stats
    /* Old Counters
    public Text lifeCounter;
    public Text currencyCounter;
    */
    public TextMeshProUGUI lifeCounterTMP;
    public TextMeshProUGUI currencyCounterTMP;

    // New Tower Selection Elements
    public Image towerPanel1;
    public Image towerPanel2;
    public Image towerPanel3;

    public  Color selectionColor;
    private Color defaultColor;

    // Screen Elements
    public GameObject pauseScreen;
    public GameObject defeatScreen;
    public GameObject victoryScreen;

    // Win / Lose Elements
    public TextMeshProUGUI victoryTime;
    public TextMeshProUGUI defeatTime;

    //Tower Selection UI Components
    /*
    public Transform towerPanel1;
    public Transform towerPanel2;
    public Transform towerPanel3;
    RectTransform panel1Transform;
    RectTransform panel2Transform;
    RectTransform panel3Transform;
    public Vector2 towerPanelDefaultSize;
    public Vector2 towerPanelSelectedSize;
    public bool tower1UIActive = false;
    public bool tower2UIActive = false;
    public bool tower3UIActive = false;
    */

    private void Start()
    {
        defaultColor = towerPanel1.color;
        /*
        panel1Transform = towerPanel1.GetComponent<RectTransform>();
        panel2Transform = towerPanel2.GetComponent<RectTransform>();
        panel3Transform = towerPanel3.GetComponent<RectTransform>();
        towerPanelDefaultSize = panel1Transform.rect.size;
        towerPanelSelectedSize.x = towerPanelDefaultSize.x;
        towerPanelSelectedSize.y = towerPanelDefaultSize.y + 30;
        */
    }
    // Update is called once per frame
    void Update()
    {
        // Update clock text labels
        /* Old Text variables
        minute1.text = (GameClock.inst.minutes / 10).ToString();
        minute2.text = (GameClock.inst.minutes % 10).ToString();
        second1.text = (GameClock.inst.seconds / 10).ToString();
        second2.text = (GameClock.inst.seconds % 10).ToString();
        */
        minuteTMP0.text = (GameClock.inst.minutes / 10).ToString();
        minuteTMP1.text = (GameClock.inst.minutes % 10).ToString();
        secondTMP0.text = (GameClock.inst.seconds / 10).ToString();
        secondTMP1.text = (GameClock.inst.seconds % 10).ToString();

        // Update castle health
        castleHealthBar.value = GameMgr.inst.castleHealth;

        // Update player stats
        /* Old Text variables
        lifeCounter.text = GameMgr.inst.lives.ToString();
        currencyCounter.text = GameMgr.inst.currency.ToString();
         */
        lifeCounterTMP.text = GameMgr.inst.lives.ToString();
        currencyCounterTMP.text = GameMgr.inst.currency.ToString();

        // Check if tower is selected
        if (!TowerSelectionMgr.inst.isTowerSelected)
        {
            DeselectTowers();
        }
    }

    public void UpdateTower1UI()
    {
        DeselectTowers();
        towerPanel1.color = selectionColor;
        /*
        if (tower1UIActive)
        {
            DeselectTowers();
        }
        else
        {
            if (tower2UIActive || tower3UIActive)
            {
                DeselectTowers();
            }
            panel1Transform.sizeDelta = towerPanelSelectedSize;
            tower1UIActive = !tower1UIActive;
        }
        */
    }

    public void UpdateTower2UI()
    {
        DeselectTowers();
        towerPanel2.color = selectionColor;
        /*
        if (tower2UIActive)
        {
            DeselectTowers();
        }
        else
        {
            if (tower1UIActive || tower3UIActive)
            {
                DeselectTowers();
            }
            panel2Transform.sizeDelta = towerPanelSelectedSize;
            tower2UIActive = !tower2UIActive;
        }
        */
    }

    public void UpdateTower3UI()
    {
        DeselectTowers();
        towerPanel3.color = selectionColor;
        /*
        if (tower3UIActive)
        {
            DeselectTowers();
        }
        else
        {
            if (tower1UIActive || tower2UIActive)
            {
                DeselectTowers();
            }
            panel3Transform.sizeDelta = towerPanelSelectedSize;
            tower3UIActive = !tower3UIActive;
        }
        */
    }

    public void DeselectTowers()
    {
        towerPanel1.color = defaultColor;
        towerPanel2.color = defaultColor;
        towerPanel3.color = defaultColor;
        /*
        panel1Transform.sizeDelta = towerPanelDefaultSize;
        tower1UIActive = false;
        panel2Transform.sizeDelta = towerPanelDefaultSize;
        tower2UIActive = false;
        panel3Transform.sizeDelta = towerPanelDefaultSize;
        tower3UIActive = false;
        */
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("SplashScreen");
    }

    public void Victory()
    {
        victoryTime.text = FormatTime();
        victoryScreen.SetActive(true);
    }

    public void Defeat()
    {
        defeatTime.text = FormatTime();
        defeatScreen.SetActive(true);
    }

    private string FormatTime()
    {
        string temp = GameClock.inst.minutes.ToString() + ":";
        if (GameClock.inst.seconds < 10)
            temp += "0";

        temp += GameClock.inst.seconds.ToString();

        return temp;
    }
}
