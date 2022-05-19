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
    public bool toggleRanges = false;

    //Box colliders for checking placement
    public List<Collider> colliderZones;

    //Index for the currently selected tower
    public int selectedTowerIndex = 1;

    //The mouse position, it intersects with the ground to determine position
    public Vector3 intersectionPoint = Vector3.zero;
    //From as6, variables for checking if we clicked on an entity
    public float clickRadius = 10;
    public List<int> IDs = new List<int>();
    public int closestTower = 0;
    public bool isTowerClickedOn;
    public TowerEntity towerSelectedByClick;
    public bool isTowerCurrentlySelectedByClick = false;


    //--------------------------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        //Just make sure no skeleton towers are showing initially
        for (int i = 0; i < towerTypeList.Count; i++)
        {
            towerTypeList[i].towerModel.SetActive(false);
            towerTypeList[i].selectionCircle.SetActive(false);
        }
    }
    //--------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        //Select tower to place (1)---Copy this and change key numbers for additional towers
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
        {
            SelectTower1();
            /*
            if (TowerMgr.inst.tower1Prefab.GetComponent<TowerEntity>().cost > GameMgr.inst.currency)
            {
                Debug.Log("Unaviable Funds");
            }
            else
            {

                if (towerSelectedByClick != null)
                {
                    isTowerCurrentlySelectedByClick = false;
                    towerSelectedByClick.selectionCircle.SetActive(false);
                    towerSelectedByClick.selectedModeText.SetActive(false);
                }
                if (selectedTowerIndex == 1 && isTowerSelected == true)
                {
                    //Unselect Current tower
                    towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                    towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);

                    isTowerSelected = false;
                }
                else
                {
                    //Unselect Current tower
                    towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                    towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);
                    //Play SelectionSound
                    SoundMgr.inst.PlaySelectionSound();


                    selectedTowerIndex = 1;
                    isTowerSelected = true;
                    towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(true);
                    towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(true);

                }
                UIMgr.inst.UpdateTower1UI();
            }
            */
        }

        //Select tower to place (2)
        if (Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Keypad2))
        {
            SelectTower2();
            /*
            if (TowerMgr.inst.tower2Prefab.GetComponent<TowerEntity>().cost > GameMgr.inst.currency)
            {
                Debug.Log("Unaviable Funds");
            }
            else
            {
                if (towerSelectedByClick != null)
                {
                    isTowerCurrentlySelectedByClick = false;
                    towerSelectedByClick.selectionCircle.SetActive(false);
                    towerSelectedByClick.selectedModeText.SetActive(false);
                }
                if (selectedTowerIndex == 2 && isTowerSelected == true)
                {
                    //Unselect Current tower
                    towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                    towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);

                    isTowerSelected = false;
                }
                else
                {
                    //Unselect Current tower
                    towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                    towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);
                    //Play SelectionSound
                    SoundMgr.inst.PlaySelectionSound();


                    selectedTowerIndex = 2;
                    isTowerSelected = true;
                    towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(true);
                    towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(true);
                }
                UIMgr.inst.UpdateTower2UI();
            }
            */
        }


        if (Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Keypad3))
        {
            SelectTower3();
            /*
            if (TowerMgr.inst.tower3Prefab.GetComponent<TowerEntity>().cost > GameMgr.inst.currency)
            {
                Debug.Log("Unaviable Funds");
            }
            else
            {
                if (towerSelectedByClick != null)
                {
                    isTowerCurrentlySelectedByClick = false;
                    towerSelectedByClick.selectionCircle.SetActive(false);
                    towerSelectedByClick.selectedModeText.SetActive(false);
                }
                if (selectedTowerIndex == 3 && isTowerSelected == true)
                {
                    //Unselect Current tower
                    towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                    towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);

                    isTowerSelected = false;
                }
                else
                {
                    //Unselect Current tower
                    towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                    towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);
                    //Play SelectionSound
                    SoundMgr.inst.PlaySelectionSound();


                    selectedTowerIndex = 3;
                    isTowerSelected = true;
                    towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(true);
                    towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(true);
                }
                UIMgr.inst.UpdateTower3UI();
            }
            */
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
                    towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);
                }
                else
                {
                    print("TOWER PLACEMENT FAILED");
                }

            }
            else
            {
                if (towerSelectedByClick != null)
                {
                    isTowerCurrentlySelectedByClick = false;
                    towerSelectedByClick.selectionCircle.SetActive(false);
                    towerSelectedByClick.selectedModeText.SetActive(false);
                    towerSelectedByClick.upgradeText.SetActive(false);
                    towerSelectedByClick.statsText.SetActive(false);
                }
                isTowerClickedOn = ClickedOnTower();
                if (isTowerClickedOn)
                {
                    if (towerSelectedByClick != null)
                    {
                        isTowerCurrentlySelectedByClick = true;
                        towerSelectedByClick.selectionCircle.SetActive(true);
                        towerSelectedByClick.selectedModeText.SetActive(true);
                        towerSelectedByClick.upgradeText.SetActive(true);
                        towerSelectedByClick.statsText.SetActive(true);
                    }
                }
                else
                {
                    if (towerSelectedByClick != null)
                    {
                        isTowerCurrentlySelectedByClick = false;
                        towerSelectedByClick.selectionCircle.SetActive(false);
                        towerSelectedByClick.selectedModeText.SetActive(false);
                        towerSelectedByClick.upgradeText.SetActive(false);
                        towerSelectedByClick.statsText.SetActive(false);
                    }
                }
                //Planning on this selecting an entity (Tower or enemy) in the world and 
                //displaying imformation about it like health, damage.
            }


        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            toggleRanges = !toggleRanges;
            for (int i=0;i<TowerMgr.inst.placedTowers.Count;i++)
            {
                TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().selectionCircle.SetActive(toggleRanges);
                TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().selectedModeText.SetActive(toggleRanges);
            }
        }

        if (isTowerCurrentlySelectedByClick)
        {
            if (!towerSelectedByClick.isSIEGE)
            {
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    towerSelectedByClick.targetingModeIndex++;
                    if (towerSelectedByClick.targetingModeIndex > TowerMgr.inst.targetingModes.Count - 1)
                    {
                        towerSelectedByClick.targetingModeIndex = 0;
                    }
                    towerSelectedByClick.targetingMode = TowerMgr.inst.targetingModes[towerSelectedByClick.targetingModeIndex];
                    towerSelectedByClick.selectedModeText.GetComponent<TextMesh>().text = towerSelectedByClick.targetingMode;
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    towerSelectedByClick.targetingModeIndex--;
                    if (towerSelectedByClick.targetingModeIndex < 0)
                    {
                        towerSelectedByClick.targetingModeIndex = TowerMgr.inst.targetingModes.Count - 1;
                    }
                    towerSelectedByClick.targetingMode = TowerMgr.inst.targetingModes[towerSelectedByClick.targetingModeIndex];
                    towerSelectedByClick.selectedModeText.GetComponent<TextMesh>().text = towerSelectedByClick.targetingMode;
                }
            }
            if (Input.GetKeyUp(KeyCode.Delete))
            {
                bool deleted = false;
                for (int i=0;i<TowerMgr.inst.placedTowers.Count;i++)
                {
                    if (TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().placedTowerID == closestTower)
                    {
                        GameMgr.inst.currency = GameMgr.inst.currency + TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().cashBack;
                        Destroy(TowerMgr.inst.placedTowers[i]);
                        TowerMgr.inst.placedTowers.RemoveAt(i);
                        TowerMgr.inst.currentTowerPlacingID--;
                        deleted = true;

                    }
                    if (deleted)
                    {
                        TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().placedTowerID--;
                    }
                }
                deleted = false;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                bool upgraded = false;
                for (int i = 0; i < TowerMgr.inst.placedTowers.Count; i++)
                {
                    if (TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().placedTowerID == closestTower)
                    {
                        if (GameMgr.inst.currency > TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().upgradeCost)
                        {
                            GameMgr.inst.currency = GameMgr.inst.currency - TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().upgradeCost;
                            TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().Upgrade();
                        }
                    }
                }
                if (upgraded)
                {
                    print("Upgrade Successfull");
                }
                else
                {
                    print("Upgrade FAILED");
                }
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
            //for (int i=0;i<TowerMgr.inst.placedTowers.Count;i++)
            //{
            //    if (closestTower == TowerMgr.inst.placedTowers[i].GetComponent<TowerEntity>().placedTowerID)
            //    {
            //        towerSelectedByClick = TowerMgr.inst.placedTowers[closestTower].GetComponent<TowerEntity>();
            //    }
            //}
            print("Tower Clicked On ID " + closestTower);
            return true;
        }
        return false;
    }
    //--------------------------------------------------------------------------------------------------
    //From as6, will find the closest tower in the predetermined click radius
    public int FindClosestTower(Vector3 intPoint)
    {

        if (towerSelectedByClick != null)
        {
            towerSelectedByClick.selectionCircle.SetActive(false);
        }
        int ID = 0;
        float min = 10000000000;
        for (int i = 0; i < IDs.Count; i++)
        {
            if (Vector3.Distance(intPoint, TowerMgr.inst.placedTowers[IDs[i]].GetComponent<TowerEntity>().position) < min)
            {
                min = Vector3.Distance(intPoint, TowerMgr.inst.placedTowers[IDs[i]].GetComponent<TowerEntity>().position);
                towerSelectedByClick = TowerMgr.inst.placedTowers[IDs[i]].GetComponent<TowerEntity>();
                ID = IDs[i];
            }
        }
        return ID;
    }
    //--------------------------------------------------------------------------------------------------
    // For Mouse selection / placement
    //--------------------------------------------------------------------------------------------------

    public void SelectTower1()
    {
        if (TowerMgr.inst.tower1Prefab.GetComponent<TowerEntity>().cost > GameMgr.inst.currency)
        {
            Debug.Log("Unaviable Funds");
        }
        else
        {

            if (towerSelectedByClick != null)
            {
                isTowerCurrentlySelectedByClick = false;
                towerSelectedByClick.selectionCircle.SetActive(false);
                towerSelectedByClick.selectedModeText.SetActive(false);
            }
            if (selectedTowerIndex == 1 && isTowerSelected == true)
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);

                isTowerSelected = false;
            }
            else
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);
                //Play SelectionSound
                SoundMgr.inst.PlaySelectionSound();


                selectedTowerIndex = 1;
                isTowerSelected = true;
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(true);
                towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(true);

            }
            UIMgr.inst.UpdateTower1UI();
        }
    }

    public void SelectTower2()
    {
        if (TowerMgr.inst.tower2Prefab.GetComponent<TowerEntity>().cost > GameMgr.inst.currency)
        {
            Debug.Log("Unaviable Funds");
        }
        else
        {
            if (towerSelectedByClick != null)
            {
                isTowerCurrentlySelectedByClick = false;
                towerSelectedByClick.selectionCircle.SetActive(false);
                towerSelectedByClick.selectedModeText.SetActive(false);
            }
            if (selectedTowerIndex == 2 && isTowerSelected == true)
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);

                isTowerSelected = false;
            }
            else
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);
                //Play SelectionSound
                SoundMgr.inst.PlaySelectionSound();


                selectedTowerIndex = 2;
                isTowerSelected = true;
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(true);
                towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(true);
            }
            UIMgr.inst.UpdateTower2UI();
        }
    }

    public void SelectTower3()
    {
        if (TowerMgr.inst.tower3Prefab.GetComponent<TowerEntity>().cost > GameMgr.inst.currency)
        {
            Debug.Log("Unaviable Funds");
        }
        else
        {
            if (towerSelectedByClick != null)
            {
                isTowerCurrentlySelectedByClick = false;
                towerSelectedByClick.selectionCircle.SetActive(false);
                towerSelectedByClick.selectedModeText.SetActive(false);
            }
            if (selectedTowerIndex == 3 && isTowerSelected == true)
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);

                isTowerSelected = false;
            }
            else
            {
                //Unselect Current tower
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(false);
                towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(false);
                //Play SelectionSound
                SoundMgr.inst.PlaySelectionSound();


                selectedTowerIndex = 3;
                isTowerSelected = true;
                towerTypeList[selectedTowerIndex - 1].towerModel.SetActive(true);
                towerTypeList[selectedTowerIndex - 1].selectionCircle.SetActive(true);
            }
            UIMgr.inst.UpdateTower3UI();
        }
    }
}
