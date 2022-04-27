using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCircle : MonoBehaviour
{

    public TowerEntity tower;
    public Vector3 circleBaseSize;
    public Vector3 circleNewSize;
    public Vector3 adjustedPosition;
    // Start is called before the first frame update
    void Awake()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        circleBaseSize = Vector3.Scale(transform.localScale, mesh.bounds.size);
        circleBaseSize = circleBaseSize * 2;
        circleNewSize = circleBaseSize * (tower.range);
        transform.localScale = circleNewSize;
        adjustedPosition = transform.position;
        adjustedPosition.y = adjustedPosition.y + 3;
        transform.position = adjustedPosition;
        //print("Circle Size: " + circleNewSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRange()
    {
        circleNewSize = circleBaseSize * tower.range;
        transform.localScale = circleNewSize;
    }
}
