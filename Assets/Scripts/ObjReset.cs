using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjReset : MonoBehaviour
{
    //WorldSelector childReset = new WorldSelector();
    public Camera playerCam;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private string initialWorld;
    private string world1Layer = "world1";
    private string world2Layer = "world2";


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialWorld = LayerMask.LayerToName(transform.gameObject.layer);

    }

    // Update is called once per frame
    private void  OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name.ToLower().Contains("wave"))
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            if (transform.gameObject.name.Equals("Player"))
            {
                if (initialWorld != LayerMask.LayerToName(transform.gameObject.layer))
                {
                    playerCam.cullingMask |= 1 << LayerMask.NameToLayer(world2Layer);
                    playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world1Layer));
                }
            
            }
            transform.gameObject.layer = LayerMask.NameToLayer(initialWorld);



            if (transform.childCount > 0)
            {
                foreach (Transform children in transform)
                {
                   changeChildren(children, initialWorld);
                    

                }
            }


        }


    }

   
    private void changeChildren(Transform child, string world)
    {
        if (child.childCount > 0)
        {
            foreach (Transform children in child)
            {
                changeChildren(children, world);
            }
        }
        child.GetComponent<Rigidbody>().velocity = Vector3.zero;
        child.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        child.gameObject.layer = LayerMask.NameToLayer(world);
        transform.position = initialPosition;
        transform.rotation = initialRotation;

    }
}

