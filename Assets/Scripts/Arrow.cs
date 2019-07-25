using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody arrow;
    private float aliveTime = 2f;
    private float destroyTimer;
    private int hitSomething = 0;
    public GameObject bow;
    void Start()
    {
        arrow = GetComponent<Rigidbody>();
        //arrow.gameObject.layer = bow.layer;
        transform.rotation = Quaternion.LookRotation(arrow.velocity);//cam.transform.rotation;// 

    }
    void Update()
    {

        transform.rotation = Quaternion.LookRotation(arrow.velocity);
        if (hitSomething >= 2)
        {
            destroyTimer += Time.deltaTime;
            if (destroyTimer >= aliveTime)
            {
                Destroy(gameObject);
            }
        }
            
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitSomething += 1;
        //arrow.constraints = RigidbodyConstraints.FreezeAll;
    }
}

