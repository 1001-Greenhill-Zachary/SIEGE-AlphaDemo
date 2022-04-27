using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleEntity : MonoBehaviour
{
    // Reference to self
    public static CastleEntity inst;
    // Public variables
    public float health;

    private void Awake()
    {
        inst = this;
    }
}
