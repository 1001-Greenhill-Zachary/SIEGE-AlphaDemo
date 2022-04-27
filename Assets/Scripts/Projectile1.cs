using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    public float speed =50;

    public bool isTraveling = true;

    public GameObject target;
    public TowerEntity tower;

    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target ==null)
        {

        }
        else
        {
            targetPosition = target.transform.position;
        }
        if (isTraveling)
        {
            //print("Target Position " + target.transform.position);
            Vector3 targetDirection = targetPosition - transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 360f, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);

            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            if (Vector3.Distance(transform.position, targetPosition) < .001f)
            {
                isTraveling = false;
            }
        }

    }
}
