/* -----------------------------------------------------------------------------
FILE NAME:      EnemyPhysics.cs
AUTHOR:         FrogMaze
DESCRIPTION:    Calculates an enemies position each frame
                Applies new position to scene
NOTES:          
---------------------------------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        entity.position = transform.localPosition;
    }

    public EnemyEntity entity;

    // Update is called once per frame
    void Update()
    {
        // Check for no speed
        if (Utils.ApproximatelyEqual(entity.speed, entity.desiredSpeed))
        {

        }
        // Adjust speed each frame
        else if (entity.speed < entity.desiredSpeed)
        {
            entity.speed = entity.speed + entity.acceleration * Time.deltaTime;
        }
        else if (entity.speed > entity.desiredSpeed)
        {
            entity.speed = entity.speed - entity.acceleration * Time.deltaTime;
        }

        // Clamp the speeds
        entity.speed = Utils.Clamp(entity.speed, entity.minSpeed, entity.maxSpeed);

        // Adjust heading each frame / based on calculated speed
        if (Utils.ApproximatelyEqual(entity.heading, entity.desiredHeading))
        {}
        else if (Utils.AngleDiffPosNeg(entity.desiredHeading, entity.heading) > 0)
        {
            entity.heading += entity.turnRate * Time.deltaTime;
        }
        else if (Utils.AngleDiffPosNeg(entity.desiredHeading, entity.heading) < 0)
        {
            entity.heading -= entity.turnRate * Time.deltaTime;
        }

        entity.heading = (Utils.Degrees360(entity.heading));

        entity.velocity.x = Mathf.Sin(entity.heading * Mathf.Deg2Rad) * entity.speed;
        entity.velocity.y = 0;
        entity.velocity.z = Mathf.Cos(entity.heading * Mathf.Deg2Rad) * entity.speed;

        // Set enemies position vector
        entity.position = entity.position + entity.velocity * Time.deltaTime;
        // Apply position vector to the scene node
        transform.localPosition = entity.position;

        // Adjust rotation
        eulerRotaion.y = entity.heading;
        transform.localEulerAngles = eulerRotaion;
    }

    public Vector3 eulerRotaion = Vector3.zero;
}
