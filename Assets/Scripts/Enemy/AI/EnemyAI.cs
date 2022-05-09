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
    public Route1 route;

    // Controls how colse each entity needs to get to target location
    public float distanceVariance;

    // Start is called before the first frame update
    void Start()
    {
        route = new Route1();
        // Set enemies initial heading
        ent.desiredHeading = getHeading();
    }

    // Update is called once per frame
    void Update()
    {
        if (route.cmds.Count > 1)
        {
            if (Vector3.Distance(ent.position, route.cmds.Peek()) < distanceVariance)
                route.cmds.Dequeue();
        }
        ent.desiredHeading = getHeading();
    }

    // Get the heading from the top of the queue and current position
    private float getHeading()
    {
        Vector3 temp = route.cmds.Peek() - ent.position;
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
            /*
        }
        ent.desiredHeading = getHeading();
    }

    // Populates the AI with a series of coordinates
    private void populate()
    {
        coords.Enqueue(new Vector3(-38, 0, -21));
        coords.Enqueue(new Vector3(-76, 0, -31));
        coords.Enqueue(new Vector3(-86, 0, -34));
        coords.Enqueue(new Vector3(-93, 0, -42));
        coords.Enqueue(new Vector3(-94, 0, -54));
        coords.Enqueue(new Vector3(-87, 0, -66.5f));
        coords.Enqueue(new Vector3(-78, 0, -70));
        coords.Enqueue(new Vector3(-37, 0, -71));
        coords.Enqueue(new Vector3(11, 0, -65));
        coords.Enqueue(new Vector3(45, 0, -55));
        coords.Enqueue(new Vector3(49, 0, -45));
        coords.Enqueue(new Vector3(51, 0, -33));
        coords.Enqueue(new Vector3(59, 0, -24));
        coords.Enqueue(new Vector3(69, 0, -21));
        coords.Enqueue(new Vector3(80, 0, -23));
        coords.Enqueue(new Vector3(90, 0, -29));
        coords.Enqueue(new Vector3(95, 0, -40));
        coords.Enqueue(new Vector3(94.7f, 0, -83.9f));
        coords.Enqueue(new Vector3(94, 0, -112));
        coords.Enqueue(new Vector3(85, 0, -121));
        coords.Enqueue(new Vector3(40, 0, -122));
        coords.Enqueue(new Vector3(34, 0, -119.5f));
        coords.Enqueue(new Vector3(29, 0, -114.5f));
        coords.Enqueue(new Vector3(22, 0, -108));
        coords.Enqueue(new Vector3(14, 0, -103));
        coords.Enqueue(new Vector3(6, 0, -101));
        coords.Enqueue(new Vector3(-1, 0, -101));
        coords.Enqueue(new Vector3(-11, 0, -102));
        coords.Enqueue(new Vector3(-20, 0, -106));
        coords.Enqueue(new Vector3(-25, 0, -111));
        coords.Enqueue(new Vector3(-31, 0, -118));
        coords.Enqueue(new Vector3(-40, 0, -122));
        coords.Enqueue(new Vector3(-57.6f, 0, -122.2f));
        coords.Enqueue(new Vector3(-80, 0, -122.2f));
        coords.Enqueue(new Vector3(-89, 0, -130));
        coords.Enqueue(new Vector3(-89.5f, 0, -163));

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
