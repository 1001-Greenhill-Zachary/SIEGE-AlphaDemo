using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMgr : MonoBehaviour
{
    public static ProjectileMgr inst;
    private void Awake()
    {
        inst = this;
    }

    public List<GameObject> projectileTypes;

    public List<GameObject> projectilesList1;
    public List<GameObject> projectilesList2;
    public List<GameObject> projectilesList3;

    public GameObject AOEModel;
    public Vector3 AOELocation;
    public List<GameObject> AOEList;
    public int AOEIndex=-1;

    public List<Vector3> castlePositions;
    public int castlePositionIndex = 0;

    public float timer = 0;
    public float waitTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i<projectilesList1.Count;i++)
        {
            if (projectilesList1[i].GetComponent<Projectile1>().isTraveling == false)
            {
                if (projectilesList1[i].GetComponent<Projectile1>().target == null)
                {
                    Destroy(projectilesList1[i]);
                    projectilesList1.RemoveAt(i);
                }
                else
                {
                    int damage = projectilesList1[i].GetComponent<Projectile1>().tower.damage;
                    projectilesList1[i].GetComponent<Projectile1>().target.GetComponent<EnemyEntity>().health =
                        projectilesList1[i].GetComponent<Projectile1>().target.GetComponent<EnemyEntity>().health - damage;
                    Destroy(projectilesList1[i]);
                    projectilesList1.RemoveAt(i);
                }

            }
        }
        for (int i = 0; i < projectilesList2.Count; i++)
        {
            if (projectilesList2[i].GetComponent<Projectile2>().target != null)
            {
                AOELocation = projectilesList2[i].GetComponent<Projectile2>().target.GetComponent<EnemyEntity>().position;
                AOELocation.y = 1;
            }
            if (projectilesList2[i].GetComponent<Projectile2>().isTraveling == false)
            {
                if (timer < waitTime)
                {
                    timer = timer + Time.deltaTime;
                }
                else
                {
                    timer = 0;
                }
                if (projectilesList2[i].GetComponent<Projectile2>().target == null)
                {
                    GameObject temp = Instantiate(AOEModel, AOELocation, transform.rotation, transform);
                    Destroy(projectilesList2[i]);
                    projectilesList2.RemoveAt(i);
                    //AOEList.Add(temp);
                    //AOEIndex++;
                    ////print("HERE");
                    //ExecuteAfterTime(3, AOEIndex);
                }
                else
                {
                    //GameObject temp = Instantiate(AOEModel, AOELocation, transform.rotation, transform);
                    int damage = projectilesList2[i].GetComponent<Projectile2>().tower.damage;
                    projectilesList2[i].GetComponent<Projectile2>().target.GetComponent<EnemyEntity>().health =
                        projectilesList2[i].GetComponent<Projectile2>().target.GetComponent<EnemyEntity>().health - damage;
                    //Vector3 currentPosition = projectilesList2[i].GetComponent<Projectile2>().target.GetComponent<EnemyEntity>().position;
                    //for (int x = 0; x < EnemyMgr.inst.spawnedEnemies.Count; x++)
                    //{
                    //    Vector3 direction = EnemyMgr.inst.spawnedEnemies[x].GetComponent<EnemyEntity>().position - currentPosition;
                    //    float distanceSquaredToTarget = direction.sqrMagnitude;
                    //    if (distanceSquaredToTarget < projectilesList2[i].GetComponent<Projectile2>().AOErange * projectilesList2[i].GetComponent<Projectile2>().AOErange)
                    //    {
                    //        EnemyMgr.inst.spawnedEnemies[x].GetComponent<EnemyEntity>().health =
                    //            EnemyMgr.inst.spawnedEnemies[x].GetComponent<EnemyEntity>().health - projectilesList2[i].GetComponent<Projectile2>().AOEdamage;
                    //    }
                    //}
                    //AOEList.Add(temp);
                    //AOEIndex++;
                    //print("HERE");
                    //ExecuteAfterTime(3, AOEIndex);
                    Destroy(projectilesList2[i]);
                    projectilesList2.RemoveAt(i);
                }
                

            }
        }
        for (int i = 0; i < projectilesList3.Count; i++)
        {
            if (projectilesList3[i].GetComponent<Projectile3>().isTraveling == false)
            {
                int damage = projectilesList3[i].GetComponent<Projectile3>().tower.damage;
                GameMgr.inst.castleHealth = GameMgr.inst.castleHealth - damage;
                //print("HERE");
                Destroy(projectilesList3[i]);
                projectilesList3.RemoveAt(i);
            }
        }
    }

    public void FireProjectile(string projectileType, TowerEntity tower, GameObject targetedEnemy)
    {
        
        if (projectileType == "projectile1")
        {
            SoundMgr.inst.PlayArrowProjectileFireSound();
            GameObject temp = Instantiate(projectileTypes[0], tower.position, transform.rotation, transform);
            temp.GetComponent<Projectile1>().tower = tower;
            temp.GetComponent<Projectile1>().target = targetedEnemy;
            projectilesList1.Add(temp);
        }
        else if (projectileType == "projectile2")
        {
            SoundMgr.inst.PlayTower2Sound();
            GameObject temp = Instantiate(projectileTypes[1], tower.position, transform.rotation, transform);
            temp.GetComponent<Projectile2>().tower = tower;
            temp.GetComponent<Projectile2>().target = targetedEnemy;
            projectilesList2.Add(temp);
        }
        else if (projectileType == "projectile3")
        {
            SoundMgr.inst.PlaySIEGETowerSound();
            GameObject temp = Instantiate(projectileTypes[2], tower.position, transform.rotation, transform);
            temp.GetComponent<Projectile3>().tower = tower;
            temp.GetComponent<Projectile3>().targetPosition = castlePositions[castlePositionIndex];
            projectilesList3.Add(temp);
            castlePositionIndex++;
            if (castlePositionIndex > castlePositions.Count -1)
            {
                castlePositionIndex = 0;
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time, int index)
    {
        print("HERE");
        yield return new WaitForSeconds(time);

        Destroy(AOEList[index]);
        AOEList.RemoveAt(index);
        AOEIndex--;
    }
}
