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
    public bool isType1;
    public bool isType2;
    public int upgradeCost;
    public float AOEDamage;
    public float AOERange;
    
    [Header ("Computational")]
    public Vector3 position;
    public GameObject targetedEnemy;
    public float timer = 1;
    public GameObject selectionCircle;
    public GameObject selectedModeText;
    public GameObject upgradeText;
    public GameObject statsText;
    public int targetingModeIndex=0;
    public float adjustedRange;
    public Transform target;
    public Vector3 targetPosition;
    public Vector3 lookPosition;
    public int step=2;
    public bool upgraded;
    public int upgradeTimes = 0;
    public int cashBack;
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
            upgradeText.SetActive(false);
            statsText.SetActive(false);
            targetingMode = "SIEGE";
            selectedModeText.GetComponent<TextMesh>().text = targetingMode;
            upgradeText.GetComponent<TextMesh>().text = "Upgrade Cost: " + upgradeCost;
            statsText.GetComponent<TextMesh>().text = "Damage: " + damage + "\nRange: SIGE (Unlimeted)" + "\nFire Rate: " + fireRate;
            isSIEGE = true;
        }
        else
        {
            isSIEGE = false;
            if (projectileTypeString == "projectile1")
            {
                isType1 = true;
            }
            if (projectileTypeString == "projectile2")
            {
                isType2 = true;
            }
            //When the tower is created, set the position variable equal to the transform position
            position = transform.position;
            selectionCircle.SetActive(false);
            selectedModeText.SetActive(false);
            upgradeText.SetActive(false);
            statsText.SetActive(false);
            targetingMode = TowerMgr.inst.targetingModes[targetingModeIndex];
            selectedModeText.GetComponent<TextMesh>().text = targetingMode;
            upgradeText.GetComponent<TextMesh>().text = "Upgrade Cost: " + upgradeCost;
            if (isType2)
            {
                statsText.GetComponent<TextMesh>().text = "Damage: " + damage + "\nRange: " + range + "\nFire Rate: " + fireRate + "\nAOE Damage: " + AOEDamage + "\nAOE Range: " + AOERange;
            }
            else
            {
                statsText.GetComponent<TextMesh>().text = "Damage: " + damage + "\nRange: " + range + "\nFire Rate: " + fireRate;
            }
                
        }
        cashBack = cost;
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
                targetPosition = ProjectileMgr.inst.castlePositions[ProjectileMgr.inst.castlePositionIndex];
                lookPosition = targetPosition - transform.position;
                var rotation = Quaternion.LookRotation(lookPosition);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * step);
                ProjectileMgr.inst.FireProjectile(projectileTypeString, this, targetedEnemy);
                timer = 0;
            }
        }
        else if (isType1)
        {
            targetedEnemy = Utils.GetTarget(targetingMode, this);
            if (targetedEnemy == null)
            {

            }
            else
            {
                //Uncomment this for tower 1 to rotate towards enemies
                //target = targetedEnemy.transform;
                //lookPosition = target.position - transform.position;
                //var rotation = Quaternion.LookRotation(lookPosition);
                //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * step);
            }
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

    public void Upgrade()
    {
        cashBack = cashBack + upgradeCost;
        fireRate = (fireRate / 2) + (fireRate/4);
        damage = damage + 10;
        range = range + 20;
        selectionCircle.GetComponent<RangeCircle>().UpdateRange();
        cost = cost * 2;
        upgradeCost = upgradeCost * 2;
        upgradeCost = upgradeCost + 10;
        upgradeTimes++;
        upgradeText.GetComponent<TextMesh>().text = "(" + upgradeTimes + ")-Upgrade Cost: " + upgradeCost;
        if (isSIEGE==false && isType1==false)
        {
            print("HERE");
            AOEDamage = AOEDamage + 10;
            statsText.GetComponent<TextMesh>().text = "Damage: " + damage + "\nRange: " + range + "\nFire Rate: " + fireRate + "\nAOE Damage: " + AOEDamage + "\nAOE Range: " + AOERange;
        }
        else
        {
            statsText.GetComponent<TextMesh>().text = "Damage: " + damage + "\nRange: " + range + "\nFire Rate: " + fireRate;
        }
    }
}
