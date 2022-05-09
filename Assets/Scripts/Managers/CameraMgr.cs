using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
    public static CameraMgr inst;
    private void Awake()
    {
        inst = this;
    }
    //--------------------------------------------------------------------------------------------------
    public GameObject cameraRig;

    public bool isOverheadViewMode = true;
    public Vector3 cameraDefaultYaw = Vector3.zero;

    //public GameObject yawNode;
    public GameObject pitchNode;
    //public GameObject rollNode;

    public float cameraMoveSpeed = 25;
    public float cameraTurnRate = 85;
    //Only imported as6 pitch node, as I figured the player only needs to pitch
    public Vector3 currentPitchEulerAngles = Vector3.zero;
    //--------------------------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        cameraDefaultYaw = pitchNode.transform.localEulerAngles;
    }
    //--------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            cameraMoveSpeed = 75;
            cameraTurnRate = 170;
            if (Input.GetKey(KeyCode.A))
            {
                cameraRig.transform.Translate(Vector3.left * Time.deltaTime * cameraMoveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                cameraRig.transform.Translate(Vector3.right * Time.deltaTime * cameraMoveSpeed);
            }

            currentPitchEulerAngles = pitchNode.transform.localEulerAngles;

            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    currentPitchEulerAngles.x -= cameraTurnRate * Time.deltaTime;
                }
                else
                {
                    cameraRig.transform.Translate(Vector3.forward * Time.deltaTime * cameraMoveSpeed);
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    currentPitchEulerAngles.x += cameraTurnRate * Time.deltaTime;
                }
                else
                {
                    cameraRig.transform.Translate(Vector3.back * Time.deltaTime * cameraMoveSpeed);
                }
            }

            pitchNode.transform.localEulerAngles = currentPitchEulerAngles;

            if (Input.GetKey(KeyCode.R))
            {
                cameraRig.transform.Translate(Vector3.up * Time.deltaTime * cameraMoveSpeed);

            }
            if (Input.GetKey(KeyCode.F))
            {
                cameraRig.transform.Translate(Vector3.down * Time.deltaTime * cameraMoveSpeed);

            }
        }
        else
        {
            cameraMoveSpeed = 25;
            cameraTurnRate = 85;
            if (Input.GetKey(KeyCode.A))
            {
                cameraRig.transform.Translate(Vector3.left * Time.deltaTime * cameraMoveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                cameraRig.transform.Translate(Vector3.right * Time.deltaTime * cameraMoveSpeed);
            }

            currentPitchEulerAngles = pitchNode.transform.localEulerAngles;

            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    currentPitchEulerAngles.x -= cameraTurnRate * Time.deltaTime;
                }
                else
                {
                    cameraRig.transform.Translate(Vector3.forward * Time.deltaTime * cameraMoveSpeed);
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    currentPitchEulerAngles.x += cameraTurnRate * Time.deltaTime;
                }
                else
                {
                    cameraRig.transform.Translate(Vector3.back * Time.deltaTime * cameraMoveSpeed);
                }
            }

            pitchNode.transform.localEulerAngles = currentPitchEulerAngles;

            if (Input.GetKey(KeyCode.R))
            {
                cameraRig.transform.Translate(Vector3.up * Time.deltaTime * cameraMoveSpeed);

            }
            if (Input.GetKey(KeyCode.F))
            {
                cameraRig.transform.Translate(Vector3.down * Time.deltaTime * cameraMoveSpeed);

            }
        }
        
    }
}
