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
    [Header ("Computational")]
    public Vector3 position;
    [Header("Set Up")]
    //The type of tower it is, corresponding to TowerSelectionMgr
    public int towerTypeID;
    //The ID the tower will be given when placed in the world, for TowerMgr
    public int placedTowerID;

    //-----Thinking way to far ahead, but possibly a projectile interface, that has 1-2 types of 
    //-----projectiles/ammunition/damage types for the towers
    //public Projectile projectile;
    //--------------------------------------------------------------------------------------------------

    private void Awake()
    {
        //When the tower is created, set the position variable equal to the transform position
        position = transform.position;
    }
    //--------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        
    }
}
