/* -----------------------------------------------------------------------------
FILE NAME:      EnemyAI.cs
AUTHOR:         FrogMaze
DESCRIPTION:    Keeps a list of movement commands
NOTES:          
---------------------------------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAIv2 : MonoBehaviour
{
    public EnemyEntity ent;
    public Route0 route;

    // Controls how colse each entity needs to get to target location
    public float distanceVariance;

    // Start is called before the first frame update
    void Start()
    {
        route = new Route0();
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
