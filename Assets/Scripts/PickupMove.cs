using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMove : MonoBehaviour
{
    // Start is called before the first frame update
   
    RaycastHit hit;
    GameObject held;

    public bool holding = false;
    public bool canDrop = true;
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        bool keystroke = false;

        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit[] hits;
            ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            hits = Physics.RaycastAll(ray, 7);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.CompareTag("Pickup"))
                {
                    hit = hits[i];
                    held = hit.transform.gameObject;
                    if(hit.collider.gameObject.CompareTag("Pickup") && !holding)
                    {
                        pickupBox();
                        keystroke = true;
                        

                    }
                    break;
                }  
            }
            if (holding && canDrop && !keystroke)
            {
                dropBox();

            }
            keystroke = false;

        }
        if(holding)
        {
            moveBox();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canDrop = false;
    }


    private void OnCollisionExit(Collision collision)
    {
        canDrop = true;
    }

    public void dropBox()
    {
        if (holding)
        {
            held.transform.parent.rotation = Quaternion.Euler(0,0,0);
            hit.rigidbody.angularVelocity = Vector3.zero;
            hit.rigidbody.velocity = Vector3.zero;
            hit.transform.parent.parent = null;
            //hit.rigidbody.isKinematic = false;
            hit.rigidbody.useGravity = true;
            holding = false;
            held.transform.position = GameObject.Find("Player").transform.position;
        }
    }

    private void pickupBox()
    {
        
        held.GetComponent<Rigidbody>().useGravity = false;
        held.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        held.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //hit.rigidbody.isKinematic = true;
        held.transform.position = gameObject.transform.position;
        held.transform.rotation = gameObject.transform.rotation;
        held.transform.parent.parent = gameObject.transform;
        

        holding = true;
    }
    private void moveBox()
    {
        GameObject player = GameObject.Find("Player");
        transform.LookAt(player.transform);
        //hit.transform.position = gameObject.transform.position;
       
    }

}
