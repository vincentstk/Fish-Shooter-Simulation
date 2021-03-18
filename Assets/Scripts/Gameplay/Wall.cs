using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private Vector3 NormalVector;

    public Vector3 GetNormal
    {
        get => NormalVector;
    }
}
