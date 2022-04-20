﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public List<AudioSource> audioSources;
    public static SoundMgr inst;
    private void Awake()
    {
        inst = this;
        audioSources[0].Play();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBackgroundMusic()
    {
        audioSources[0].Play();
    }

    public void StopBackgroundMusic()
    {
        audioSources[0].Stop();
    }

    public void PlaySelectionSound()
    {
        audioSources[1].Play();
    }

    public void PlayTowerPlacementSound()
    {
        audioSources[2].Play();
    }

}

//Backgournd Music "Epic" credited to Royalty Free Music from Bensound www.bensound.com
//Tower Placement and Selection sounds from Mixkit.co
