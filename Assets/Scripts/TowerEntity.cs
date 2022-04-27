using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEntity : MonoBehaviour
{
    //Each tower will have these variables, changed individually in the editor like Entity381 in as6
    [Header ("Tower Settings")]
    public int cost;
    public int damage;
    public float fireRate;
    public float range;
    public string projectileTypeString;
    public string targetingMode;
    public bool isSIEGE;
    
    [Header ("Computational")]
    public Vector3 position;
    public GameObject targetedEnemy;
    public float timer = 1;
    public GameObject selectionCircle;
    public GameObject selectedModeText;
    public int targetingModeIndex=0;
    public float adjustedRange;
    [Header("Set Up")]
    //The type of tower it is, corresponding to TowerSelectionMgr
    //public int towerTypeID;
    //The ID the tower will be given when placed in the world, for TowerMgr
    public int placedTowerID;
    

    //-----Thinking way to far ahead, but possibly a projectile interface, that has 1-2 types of 
    //-----projectiles/ammunition/damage types for the towers
    //public Projectile projectile;
    //--------------------------------------------------------------------------------------------------

    private void Awake()
    {

        if (projectileTypeString == "projectile3")
        {
            //When the tower is created, set the position variable equal to the transform position
            position = transform.position;
            selectionCircle.SetActive(false);
            selectedModeText.SetActive(false);
            targetingMode = "SIEGE";
            this.selectedModeText.GetComponent<TextMesh>().text = targetingMode;
            isSIEGE = true;
        }
        else
        {
            //When the tower is created, set the position variable equal to the transform position
            position = transform.position;
            selectionCircle.SetActive(false);
            selectedModeText.SetActive(false);
            targetingMode = TowerMgr.inst.targetingModes[targetingModeIndex];
            this.selectedModeText.GetComponent<TextMesh>().text = targetingMode;
            isSIEGE = false;
        }
    }
    //--------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (isSIEGE)
        {
            if (timer > fireRate)
            {
                ProjectileMgr.inst.FireProjectile(projectileTypeString, this, targetedEnemy);
                timer = 0;
            }
        }
        else
        {
            targetedEnemy = Utils.GetTarget(targetingMode, this);
            
            if (targetedEnemy == null)
            {

            }
            else
            {
                if (timer > fireRate)
                {
                    ProjectileMgr.inst.FireProjectile(projectileTypeString, this, targetedEnemy);
                    timer = 0;
                }
            }
        }
    }
}
