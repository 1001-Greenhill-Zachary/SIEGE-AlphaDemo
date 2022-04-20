using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectionMgr : MonoBehaviour
{
    //Singleton creation of Tower Selection Mgr
    public static TowerSelectionMgr inst;
    private void Awake()
    {
        inst = this;
    }

    //List to hold all tower types, each corresponding to a number to pick to create.
    //This will be a lesser version of the tower type, only model and ID, to help save processing power
    //Called skeleton tower in comments for now
    public List<TowerSelectionData> towerTypeList;

    //Booleans for checking states of tower selection
    public bool isTowerSelected = false;
    public bool isPlacing = false;

    //Index for the currently selected tower
    public int selectedTowerIndex = 1;

    //The mouse position, it intersects with the ground to determine position
    public Vector3 intersectionPoint = Vector3.zero;
    //From as6, variables for checking if we clicked on an entity
    public float clickRadius = 100;
    public List<int> IDs = new List<int>();
    public int closestTower = 0;
    public bool towerClickedOn;


    //--------------------------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        //Just make sure no skeleton towers are showing initially
        for (int i = 0; i < towerTypeList.Count; i++)
        {
            towerTypeList[i].towerModel.SetActive(false);
        }
    }
    //--------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        //Select tower to place (1)---Copy this and change key numbers for additional towers
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
        {
            if (selectedTowerIndex == 1 && isTowerSelected == true)
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);

                isTowerSelected = false;
            }
            else
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                //Play SelectionSound
                SoundMgr.inst.PlaySelectionSound();
                

                selectedTowerIndex = 1;
                isTowerSelected = true;
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(true);
            }

            UIMgr.inst.UpdateTower1UI();
        }
        //Select tower to place (2)
        if (Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Keypad2))
        {
            if (selectedTowerIndex == 2 && isTowerSelected == true)
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);

                isTowerSelected = false;
            }
            else
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                //Play SelectionSound
                SoundMgr.inst.PlaySelectionSound();
                

                selectedTowerIndex = 2;
                isTowerSelected = true;
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(true);
            }
            UIMgr.inst.UpdateTower2UI();
        }
        if (Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Keypad3))
        {
            if (selectedTowerIndex == 3 && isTowerSelected == true)
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);

                isTowerSelected = false;
            }
            else
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                //Play SelectionSound
                SoundMgr.inst.PlaySelectionSound();


                selectedTowerIndex = 3;
                isTowerSelected = true;
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(true);
            }

            UIMgr.inst.UpdateTower3UI();
        }
        //If a tower is selected, hover the model at the mouse position
        if (isTowerSelected)
        {
            GetMousePosition();
            ShowTowerOnMouse();
        }
        //When clicking the left mouse button, either place a tower if one is selected, or check info of
        //entity if one is clicked on
        if (Input.GetMouseButtonDown(0))
        {
            if (isTowerSelected)
            {
                bool placed = TowerMgr.inst.PlaceTower(selectedTowerIndex, intersectionPoint);
                if (placed)
                {
                    print("Tower Placed");
                    isTowerSelected = false;
                    towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                }
                else
                {
                    print("TOWER PLACEMENT FAILED");
                }

            }
            else
            {
                towerClickedOn = ClickedOnTower();
                if (towerClickedOn)
                {
                    //Here we will display tower information because it is clicked on
                }
                //Planning on this selecting an entity (Tower or enemy) in the world and 
                //displaying imformation about it like health, damage.
            }


        }
    }
    //--------------------------------------------------------------------------------------------------

    void GetMousePosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        {
            intersectionPoint = hit.point;
        }
    }
    //--------------------------------------------------------------------------------------------------
    //Set current skeleton tower to mouse position
    void ShowTowerOnMouse()
    {
        towerTypeList[selectedTowerIndex - 1].transform.position = intersectionPoint;
    }
    //--------------------------------------------------------------------------------------------------
    //This is from as6, will check all placed towers to see how close they are to click point, and 
    //Return the closest one that is within the predetermined radius
    bool ClickedOnTower()
    {
        GetMousePosition();
        IDs.Clear();
        for (int i = 0; i < TowerMgr.inst.placedTowers.Count; i++)
        {
            GameObject Obj = TowerMgr.inst.placedTowers[i];
            if (Vector3.Distance(intersectionPoint, TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().position) < clickRadius)
            {
                //print(intersectionPoint + " " + Obj.GetComponent<TowerEntity>().position + " " + Vector3.Distance(intersectionPoint, TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().position));
                IDs.Add(TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().placedTowerID);
            }
        }
        if (IDs.Count > 0)
        {
            closestTower = FindClosestTower(intersectionPoint);
            print("Tower Clicked On ID " + closestTower);
            return true;
        }
        return false;
    }
    //--------------------------------------------------------------------------------------------------
    //From as6, will find the closest tower in the predetermined click radius
    public int FindClosestTower(Vector3 intPoint)
    {
        int ID = 0;
        float min = 10000000000;
        for (int i = 0; i < IDs.Count; i++)
        {
            if (Vector3.Distance(intPoint, TowerMgr.inst.placedTowers[IDs[i]].GetComponent<TowerEntity>().position) < min)
            {
                min = Vector3.Distance(intPoint, TowerMgr.inst.placedTowers[IDs[i]].GetComponent<TowerEntity>().position);
                ID = IDs[i];
            }
        }
        return ID;
    }
    //--------------------------------------------------------------------------------------------------
}
