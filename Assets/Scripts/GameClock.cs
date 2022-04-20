/* -----------------------------------------------------------------------------
FILE NAME:      GameClock.cs
AUTHOR:         FrogMaze
DESCRIPTION:    A Clock to keep track of game time
NOTES:          
---------------------------------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClock : MonoBehaviour
{
    public int minutes;
    public int seconds;
    public float runTime;

    public static GameClock inst;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        minutes = 0;
        seconds = 0;
        runTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        runTime = runTime + Time.deltaTime;
        seconds = (int)runTime % 60;
        minutes = (int)(runTime / 60);
    }
}
