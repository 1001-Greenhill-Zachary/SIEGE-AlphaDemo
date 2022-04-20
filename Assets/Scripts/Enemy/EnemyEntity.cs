/* -----------------------------------------------------------------------------
FILE NAME:      EnemyEntity.cs
AUTHOR:         FrogMaze
DESCRIPTION:    A collection of variables for an enemy
NOTES:          
---------------------------------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    public Vector3 position = Vector3.zero;
    public Vector3 velocity = Vector3.zero;

    // Variables
    [Header("Variables")]
    public float speed;
    public float heading; // Degrees
    public float health;

//-------------------------------
    // Constants
    [Header("Enemy Constants")]
    public float acceleration;
    public float desiredSpeed;
    public float desiredHeading;
    public float turnRate;
    public float maxSpeed;
    public float minSpeed;
}
