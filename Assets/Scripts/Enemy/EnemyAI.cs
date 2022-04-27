/* -----------------------------------------------------------------------------
FILE NAME:      EnemyAI.cs
AUTHOR:         FrogMaze
DESCRIPTION:    Keeps a list of movement commands
NOTES:          
---------------------------------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public EnemyEntity ent;
    public Queue<Vector3> coords;

    // Controls how colse each entity needs to get to target location
    public float distanceVariance;

    // Start is called before the first frame update
    void Start()
    {
        coords = new Queue<Vector3>();

        // Add the list of coordinates to entity
        populate();

        // Set enemies initial heading
        ent.desiredHeading = getHeading();
    }

    // Update is called once per frame
    void Update()
    {
        if (coords.Count > 1)
        {
            if (Vector3.Distance(ent.position, coords.Peek()) < distanceVariance)
                coords.Dequeue();

            /*
            if (coords.Count > 0)
                ent.desiredHeading = getHeading();
            */
        }
        ent.desiredHeading = getHeading();
    }

    // Populates the AI with a series of coordinates
    private void populate()
    {
        coords.Enqueue(new Vector3(-35, 0, -20));
        coords.Enqueue(new Vector3(25, 0, -30));
        coords.Enqueue(new Vector3(0, 0, -50));
        coords.Enqueue(new Vector3(-30, 0, -66));
    }

    // Get the heading from the top of the queue and current position
    private float getHeading()
    {
        Vector3 temp = coords.Peek() - ent.position;
        float ret = Mathf.Atan2(temp.x, temp.z) * Mathf.Rad2Deg;
        return ret;
    }
}
/*
public class EnemyAI : MonoBehaviour
{
    public EnemyEntity ent;
    public Queue<Vector3> coords;

    // Controls how colse each entity needs to get to target location
    public float distanceVariance;

    // Start is called before the first frame update
    void Start()
    {
        coords = new Queue<Vector3>();
        coords.Enqueue(new Vector3(-35, 0, -20));
        coords.Enqueue(new Vector3(25, 0, -30));
        coords.Enqueue(new Vector3(0, 0, -50));
        ent.desiredHeading = getHeading();
    }

    // Update is called once per frame
    void Update()
    {
        if (coords.Count > 0)
        {
            if (Vector3.Distance(ent.position, coords.Peek()) < distanceVariance)
            {
                coords.Dequeue();
            }

            if (coords.Count > 0)
                ent.desiredHeading = getHeading();
        }
    }

    // This works but it needs some fixing
    private float getHeading()
    {
        Vector3 temp = coords.Peek() - ent.position;
        float ret = Mathf.Atan2(temp.x, temp.z) * Mathf.Rad2Deg;
        return ret;
    }
}
*/
