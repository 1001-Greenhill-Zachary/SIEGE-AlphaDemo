using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile3 : MonoBehaviour
{
    public float speed = 20;

    public bool isTraveling = true;



    public TowerEntity tower;

    public Vector3 targetPosition;
    public Vector3 adjustedPosition;
    public float height;
    public float distance;
    public float initialDistance;
    public float change = 3;

    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(transform.position, targetPosition);
        height = distance/2;
        initialDistance = distance;

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(targetPosition, transform.position);
        height = distance - change;
        //print("HEIGHT " + height);
        adjustedPosition = targetPosition;
        adjustedPosition.y = height;
        //print("Target Position: " + targetPosition + "Adjusted Position: " + adjustedPosition);
        if (distance < initialDistance/2)
        {
            height = distance/2;
            height = height - change;
        }
        if (isTraveling)
        {
            Vector3 targetDirection = targetPosition - transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 360f, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, adjustedPosition, step);
        }
        if (distance < 3f)
        {
            isTraveling = false;
        }
    }
}
