using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr : MonoBehaviour
{
    //Singleton creation of Control Mgr
    public static ControlMgr inst;
    private void Awake()
    {
        inst = this;
    }

    public bool backgroundMusicOn = true;

    //--------------------------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //--------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SoundMgr.inst.StopBackgroundMusic();
            //Probably turn this into pause menu later on, just imported form as6
            Application.Quit();
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (backgroundMusicOn)
            {
                SoundMgr.inst.StopBackgroundMusic();
            }
            else
            {
                SoundMgr.inst.PlayBackgroundMusic();
            }
            backgroundMusicOn = !backgroundMusicOn;
        }

    }
    //--------------------------------------------------------------------------------------------------
}
