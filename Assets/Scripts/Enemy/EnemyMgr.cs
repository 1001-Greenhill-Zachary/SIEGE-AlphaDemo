using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMgr : MonoBehaviour
{
    // Reference to this object
    public static EnemyMgr inst;

    // List to manage enemies
    public List<GameObject> spawnedEnemies;

    public float despawnRadius;
    public Transform endPoint;

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
        // Checks every enemy per frame
        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
            // For debuging
            //Debug.Log("Health: " + spawnedEnemies[i].GetComponent<EnemyEntity>().health);
            // Remove enmey if it has reached 0 health
            if (spawnedEnemies[i].GetComponent<EnemyEntity>().health <= 0)
            {
                // Add bounty to currency
                GameMgr.inst.currency += spawnedEnemies[i].GetComponent<EnemyEntity>().bounty;

                // Remove enemy from game
                Destroy(spawnedEnemies[i].gameObject);
                // Remove enemy from list
                spawnedEnemies.RemoveAt(i);
            }

            // Remove enemy if it has reached end of map
            if (Vector3.Distance(spawnedEnemies[i].transform.position, endPoint.transform.position) < despawnRadius)
            {
                // Remove enemy from game
                Destroy(spawnedEnemies[i].gameObject);
                // Remove enemy from list
                spawnedEnemies.RemoveAt(i);

                // Decrement remaining lives
                GameMgr.inst.lives--;
            }
        }
    }
}
