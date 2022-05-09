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

    public List<Vector3> castlePositions;
    public int castlePositionIndex = 0;

    public List<GameObject> AOEs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int j=0;j<AOEs.Count;j++)
        {
            if (AOEs[j].GetComponent<AOE>().delete)
            {
                Destroy(AOEs[j]);
                AOEs.RemoveAt(j);
                j--;
            }
        }
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
            float range = projectilesList2[i].GetComponent<Projectile2>().AOErange;
            float AOEDamageTemp = projectilesList2[i].GetComponent<Projectile2>().AOEdamage;
            if (projectilesList2[i].GetComponent<Projectile2>().isTraveling == false)
            {
                AOELocation = projectilesList2[i].GetComponent<Projectile2>().transform.position;
                AOELocation.y = 1;
                if (projectilesList2[i].GetComponent<Projectile2>().target == null)
                {
                    Destroy(projectilesList2[i]);
                    projectilesList2.RemoveAt(i);
                }
                else
                {

                    int damage = projectilesList2[i].GetComponent<Projectile2>().tower.damage;
                    projectilesList2[i].GetComponent<Projectile2>().target.GetComponent<EnemyEntity>().health =
                        projectilesList2[i].GetComponent<Projectile2>().target.GetComponent<EnemyEntity>().health - damage;
                    Destroy(projectilesList2[i]);
                    projectilesList2.RemoveAt(i);
                }
                GameObject temp = Instantiate(AOEModel, AOELocation, transform.rotation, transform);
                temp.GetComponent<AOE>().AOERange = range;
                temp.GetComponent<AOE>().AOEDamage = AOEDamageTemp;
                AOEs.Add(temp);
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
            temp.GetComponent<Projectile2>().AOEdamage = tower.AOEDamage;
            temp.GetComponent<Projectile2>().AOErange = tower.AOERange;
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
}
