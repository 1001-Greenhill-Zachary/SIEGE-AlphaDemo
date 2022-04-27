using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;

    public int lives;
    public int currency;
    public int castleHealth;

    private bool gameOver;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        gameOver = false;
    }

    private void Update()
    {

        if (gameOver) { }// Do not check Victory / Defeat screens
        // Check for victory
        else if (castleHealth <= 0)
        {
            Victory();
        }
        // Check for defeat
        else if (lives <= 0)
        {
            Defeat();
        }
    }

    private void Victory()
    {
        Time.timeScale = 0f;
        gameOver = true;
        UIMgr.inst.victoryScreen.SetActive(true);
    }

    private void Defeat()
    {
        Time.timeScale = 0;
        gameOver = true;
        UIMgr.inst.defeatScreen.SetActive(true);
    }
}
