/* -----------------------------------------------------------------------------
FILE NAME:      EnemySpawner.cs
AUTHOR:         FrogMaze
DESCRIPTION:    Creates an enemy at specified intervals
                Keeps track of each enemy spawned
                Destroys enemies if they reach zero health

NOTES:          Requires an EnemyEntity class to work
---------------------------------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // The type of enemy to spawn
    [Header("Prefrab")]
    public GameObject enemyToSpawn;

    [Header("Is Active?")]
    public bool active;

    [Header("Spawn Variables")]
    public float spawnRate;
    public float delay;

    // Internal variables for managment
    private float counter;

    void Start()
    {
        counter = 0;// delay / spawnRate;
    }

    void Update()
    {
        // Old method of delay
        /*
        if (delay > 0)
        {
            delay = delay - Time.deltaTime;
        }
        */

        // Checks cooldown and spaws enemies
        if (((GameClock.inst.runTime - delay) / spawnRate) > counter)
        {
            if (active)
            {
                // Create Object and add to EnemyEntityMgr
                EnemyMgr.inst.spawnedEnemies.Add(Instantiate(enemyToSpawn, transform.position, transform.rotation, transform));
            }
            // increment counter
            counter++;
        }
    }
}
