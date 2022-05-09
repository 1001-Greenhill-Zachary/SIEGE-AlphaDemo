using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    public List<EnemyEntity> IDs;
    public float AOERange;
    public float AOEDamage;
    public float timer;
    public bool delete = false;
    // Start is called before the first frame update
    void Start()
    {
        SoundMgr.inst.PlayExplosionSound();
        for (int i = 0; i < EnemyMgr.inst.spawnedEnemies.Count; i++)
        {
            if (Vector3.Distance(transform.position, EnemyMgr.inst.spawnedEnemies[i].transform.position) < AOERange)
            {
                //print(transform.position + " " + EnemyMgr.inst.spawnedEnemies[i].transform.position + " " + Vector3.Distance(transform.position, EnemyMgr.inst.spawnedEnemies[i].transform.position));
                //print(AOERange);
                IDs.Add(EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>());
            }
        }
        for (int i = 0; i < IDs.Count; i++)
        {
            IDs[i].health = IDs[i].health - AOEDamage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > .5)
        {
            delete = true;
        }
        else
        {
            timer = timer + Time.deltaTime;
        }
    }
}
