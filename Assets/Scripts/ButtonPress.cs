using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPress : MonoBehaviour
{
  //  ObjReset basicInfo = new ObjReset();
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialColliderPosition;
    private Quaternion initialColliderRotation;
    public bool isPressed = false;
    public string ObjName;
    private GameObject GObject;
    private bool reached = false;
    public string allowing;
    public GameObject controlling;

    // Start is called before the first frame update

    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    void onAwake()
    {
        onActivate = new UnityEvent();
        onDeactivate = new UnityEvent();
        
    }

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        onActivate.AddListener(doThing);
        onDeactivate.AddListener(undoThing);
    }

    void Update()
    {
        if(isPressed && !reached)
        {
            GObject.transform.position = Vector3.Lerp(GObject.transform.position, initialPosition, 0.25f);
            if (Vector3.Distance(GObject.transform.position, initialPosition) <= 0.25f)
            {
                reached = true;
            }
        }
       
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collision)
    {
        //if ((collision.gameObject.name.Equals("Player")|| collision.gameObject.name.Equals("Sphere")) && !isPressed)
        //{
            if (collision.gameObject.name.Equals(allowing))
            {

                initialColliderPosition = transform.position;
                initialColliderPosition.z += 20;
                initialColliderRotation = transform.rotation;

                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                GObject = collision.gameObject;
                isPressed = true;
                ObjName = collision.gameObject.name;
            Debug.Log("done1");
           
            onActivate.Invoke();

            }
            //else if (collision.gameObject.name.Equals("Player"))
            //{
            //    isPressed = true;
            //}
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Equals(ObjName))
        {
            isPressed = false;
            reached = false;
            
            onDeactivate.Invoke();
        }
    }
    void doThing()
    {
        if (controlling.name.Equals("Bridge"))
        {
            controlling.GetComponent<Collider>().isTrigger = false;
        }
        else
        {
            controlling.GetComponent<Collider>().isTrigger = true;
        }
    }
   void undoThing()
    {
        if (controlling.name.Equals("Bridge"))
        {
            controlling.GetComponent<Collider>().isTrigger = true;
        }
        else
        {
            controlling.GetComponent<Collider>().isTrigger = false;
        }
    }


}
