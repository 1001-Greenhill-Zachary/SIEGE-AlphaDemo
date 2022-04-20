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

public class UIMgr : MonoBehaviour
{
    public static UIMgr inst;
    private void Awake()
    {
        inst = this;
    }

    // Clock components
    public Text minute1;
    public Text minute2;
    public Text second1;
    public Text second2;

    //Tower Selection UI Components
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

    private void Start()
    {
        
        panel1Transform = towerPanel1.GetComponent<RectTransform>();
        panel2Transform = towerPanel2.GetComponent<RectTransform>();
        panel3Transform = towerPanel3.GetComponent<RectTransform>();
        towerPanelDefaultSize = panel1Transform.rect.size;
        towerPanelSelectedSize.x = towerPanelDefaultSize.x;
        towerPanelSelectedSize.y = towerPanelDefaultSize.y + 30;

    }
    // Update is called once per frame
    void Update()
    {
        // Update clock text labels
        minute1.text = (GameClock.inst.minutes / 10).ToString();
        minute2.text = (GameClock.inst.minutes % 10).ToString();
        second1.text = (GameClock.inst.seconds / 10).ToString();
        second2.text = (GameClock.inst.seconds % 10).ToString();
    }

    public void UpdateTower1UI()
    {
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
        
    }

    public void UpdateTower2UI()
    {
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
        
    }

    public void UpdateTower3UI()
    {
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
        
    }

    public void DeselectTowers()
    {
        panel1Transform.sizeDelta = towerPanelDefaultSize;
        tower1UIActive = false;
        panel2Transform.sizeDelta = towerPanelDefaultSize;
        tower2UIActive = false;
        panel3Transform.sizeDelta = towerPanelDefaultSize;
        tower3UIActive = false;
    }
}
