using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    public float speed = 25;

    public bool isTraveling = true;
    public bool isHalfway = false;

    public GameObject target;
    public TowerEntity tower;

    public Vector3 targetPosition;
    public Vector3 adjustedPosition;
    public float height;
    public float distance;
    public float initialDistance;
    public float change = 4;

    public float AOErange = 20;
    public int AOEdamage = 5;

    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(transform.position, targetPosition);
        height = distance / 2;
        initialDistance = distance;

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            height = 0;
            targetPosition.y = 0;
            adjustedPosition.y = 0;
            distance = Vector3.Distance(targetPosition, transform.position);
        }
        else
        {
            targetPosition = target.GetComponent<EnemyPhysics>().entity.position;
            distance = Vector3.Distance(targetPosition, transform.position);
            height = distance - change;
            //print("HEIGHT " + height);
            adjustedPosition = targetPosition;
            adjustedPosition.y = height;
            //print("Target Position: " + targetPosition + "Adjusted Position: " + adjustedPosition);
            if (distance < initialDistance / 2)
            {
                height = distance / 2;
                height = height - change;
            }
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

    public void AreaDamage()
    {

    }
}
