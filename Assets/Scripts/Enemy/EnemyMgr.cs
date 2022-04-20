using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMgr : MonoBehaviour
{
    // Reference to this object
    public static EnemyMgr inst;

    // List to manage enemies
    public List<GameObject> spawnedEnemies;

    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnedEnemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks every enemies health and despawns if below zero
        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
            // For debuging
            //Debug.Log("Health: " + spawnedEnemies[i].GetComponent<EnemyEntity>().health);
            if (spawnedEnemies[i].GetComponent<EnemyEntity>().health <= 0)
            {
                // Remove enemy from game
                Destroy(spawnedEnemies[i].gameObject);
                // Remove enemy from list
                spawnedEnemies.RemoveAt(i);
            }
        }
    }
}
