using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMgr : MonoBehaviour
{
    //Singleton creation of Tower Mgr
    public static TowerMgr inst;
    private void Awake()
    {
        inst = this;
    }
    //--------------------------------------------------------------------------------------------------
    //List of towers placed in the world
    public List<GameObject> placedTowers;

    //Objects to hold the different tower prefabs, that we use to create. Easily add more
    public GameObject tower1Prefab;
    public GameObject tower2Prefab;
    public GameObject tower3Prefab;

    public int currentTowerPlacingID =0;
    //--------------------------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //--------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        
    }
    //--------------------------------------------------------------------------------------------------

    public bool PlaceTower(int towerID, Vector3 position)
    {
        //Based off of towerTypeID, create that type of tower. Copy and past to add more types
        if (towerID == 1)
        {
            //Create tower at mouse position and add it to the list of placed towers
            GameObject temp = Instantiate(tower1Prefab, position, transform.rotation, transform);
            //Play PlacementSound
            SoundMgr.inst.PlayTowerPlacementSound();

            temp.GetComponent<TowerEntity>().placedTowerID = currentTowerPlacingID;
            placedTowers.Add(temp);
            currentTowerPlacingID++;
            return true;
        }
        else if (towerID == 2)
        {
            //Create tower at mouse position and add it to the list of placed towers
            GameObject temp = Instantiate(tower2Prefab, position, transform.rotation, transform);
            //Play PlacementSound
            SoundMgr.inst.PlayTowerPlacementSound();

            temp.GetComponent<TowerEntity>().placedTowerID = currentTowerPlacingID;
            placedTowers.Add(temp);
            currentTowerPlacingID++;
            return true;
        }
        else if (towerID == 3)
        {
            //Create tower at mouse position and add it to the list of placed towers
            GameObject temp = Instantiate(tower3Prefab, position, transform.rotation, transform);
            //Play PlacementSound
            SoundMgr.inst.PlayTowerPlacementSound();

            temp.GetComponent<TowerEntity>().placedTowerID = currentTowerPlacingID;
            placedTowers.Add(temp);
            currentTowerPlacingID++;
            return true;
        }
        return false;
    }
}
