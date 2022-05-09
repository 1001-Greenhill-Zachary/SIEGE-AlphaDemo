using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route1 : Commands
{
    public Route1()
    {
        /*
        cmds.Enqueue(new Vector3(-38, 0, -21));
        cmds.Enqueue(new Vector3(-76, 0, -31));
        cmds.Enqueue(new Vector3(-86, 0, -34));
        cmds.Enqueue(new Vector3(-93, 0, -42));
        cmds.Enqueue(new Vector3(-94, 0, -54));
        cmds.Enqueue(new Vector3(-87, 0, -66.5f));
        cmds.Enqueue(new Vector3(-78, 0, -70));
        cmds.Enqueue(new Vector3(-37, 0, -71));
        cmds.Enqueue(new Vector3(11, 0, -65));
        cmds.Enqueue(new Vector3(45, 0, -55));
        cmds.Enqueue(new Vector3(49, 0, -45));
        cmds.Enqueue(new Vector3(51, 0, -33));
        */
        //cmds.Enqueue(new Vector3(9, 0, 17));
        //cmds.Enqueue(new Vector3(15, 0, 13));
        //cmds.Enqueue(new Vector3(33, 0, 0));
        /*
        cmds.Enqueue(new Vector3(2, 0, 6));
        cmds.Enqueue(new Vector3(7, 0, 9));
        cmds.Enqueue(new Vector3(12, 0, 12));
        cmds.Enqueue(new Vector3(15, 0, 12));
        cmds.Enqueue(new Vector3(20, 0, 10));
        */
        cmds.Enqueue(new Vector3(2, 0, 14));
        cmds.Enqueue(new Vector3(24, 0, 14));
        cmds.Enqueue(new Vector3(29, 0, 6));
        cmds.Enqueue(new Vector3(38, 0, -2));
        cmds.Enqueue(new Vector3(48, 0, -8));
        cmds.Enqueue(new Vector3(58, 0, -14));
        cmds.Enqueue(new Vector3(68, 0, -19));

        cmds.Enqueue(new Vector3(80, 0, -23));
        cmds.Enqueue(new Vector3(90, 0, -29));
        cmds.Enqueue(new Vector3(95, 0, -40));
        cmds.Enqueue(new Vector3(94.7f, 0, -83.9f));
        cmds.Enqueue(new Vector3(94, 0, -112));
        cmds.Enqueue(new Vector3(85, 0, -121));
        cmds.Enqueue(new Vector3(40, 0, -122));
        cmds.Enqueue(new Vector3(34, 0, -119.5f));
        cmds.Enqueue(new Vector3(29, 0, -114.5f));
        cmds.Enqueue(new Vector3(22, 0, -108));
        cmds.Enqueue(new Vector3(14, 0, -103));
        cmds.Enqueue(new Vector3(6, 0, -101));
        cmds.Enqueue(new Vector3(-1, 0, -101));
        cmds.Enqueue(new Vector3(-11, 0, -102));
        cmds.Enqueue(new Vector3(-20, 0, -106));
        cmds.Enqueue(new Vector3(-25, 0, -111));
        cmds.Enqueue(new Vector3(-31, 0, -118));
        cmds.Enqueue(new Vector3(-40, 0, -122));
        cmds.Enqueue(new Vector3(-57.6f, 0, -122.2f));
        cmds.Enqueue(new Vector3(-80, 0, -122.2f));
        cmds.Enqueue(new Vector3(-89, 0, -130));
        cmds.Enqueue(new Vector3(-89.5f, 0, -163));
    }
}