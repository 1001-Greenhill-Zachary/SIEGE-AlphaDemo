/* -----------------------------------------------------------------------------
FILE NAME:      DamageOverTime.cs
AUTHOR:         FrogMaze
DESCRIPTION:    Applies damage to an enemies health over time
NOTES:          Requires an EnemyEntity class to work
---------------------------------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public EnemyEntity ent;
    public float amount;

    // Update is called once per frame
    void Update()
    {
        ent.health = ent.health - (Time.deltaTime * amount);
    }
}
