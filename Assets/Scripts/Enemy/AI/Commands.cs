using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Commands
{
    public Queue<Vector3> cmds;

    public Commands()
    {
        cmds = new Queue<Vector3>();
    }

}
