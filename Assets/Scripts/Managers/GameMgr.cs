using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;

    [Header("Game Variables")]
    public int lives;
    public int currency;
    public int castleHealth;

    [Header("Difficulty Scalars")]
    public GameObject CastleFullHP;
    public GameObject CastleDamaged;
    public EnemySpawner damageSpawner0;

    // Private variables for checks
    private bool gameOver;
    private bool castleHasBeenDamaged;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        gameOver = false;
        castleHasBeenDamaged = false;
    }

    private void Update()
    {
        // Check for damage and increment difficulty
        if (castleHealth < 100 && !castleHasBeenDamaged)
        {
            CastleFullHP.SetActive(false);
            CastleDamaged.SetActive(true);
            damageSpawner0.active = true;
            castleHasBeenDamaged = true;
        }

        if (gameOver) { }// Do not check Victory / Defeat screens
        // Check for victory
        else if (castleHealth <= 0)
            Victory();
        // Check for defeat
        else if (lives <= 0)
            Defeat();
    }

    private void Victory()
    {
        SoundMgr.inst.PlayWinGameSound();
        Time.timeScale = 0f;
        gameOver = true;
        //UIMgr.inst.victoryScreen.SetActive(true);
        UIMgr.inst.Victory();
    }

    private void Defeat()
    {
        SoundMgr.inst.PlayLoseGameSound();
        Time.timeScale = 0;
        gameOver = true;
        //UIMgr.inst.defeatScreen.SetActive(true);
        UIMgr.inst.Defeat();
    }
}
