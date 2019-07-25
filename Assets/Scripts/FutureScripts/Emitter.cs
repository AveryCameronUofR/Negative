using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    SphereCollider collider;
    private float radius = 0.5f;
    public float maxRadius = 50f;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("Active"))
        {
            collider.radius += 0.25f;
            
        } else
        {
            collider.radius = radius;
        }
    }
}
