using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;  
    public Vector3 offset;

    public void LateUpdate()
    {
        var newPos = target.position + offset;
        transform.position =  newPos;
    }
}
