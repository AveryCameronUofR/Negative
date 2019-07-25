using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundReceive : MonoBehaviour
{
    //  ObjReset basicInfo = new ObjReset();
    public bool isPressed = false;
    public string allowing;
    public GameObject target;
    public float onTime = 5f;
    private float timer = 0f;

    // Start is called before the first frame update

    void Update()
    {
        if (isPressed)
        {
            timer += Time.deltaTime;
            target.tag = "Active";
        } 
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals(allowing))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            timer = 0;
            isPressed = true;
        }
       
    }

}
