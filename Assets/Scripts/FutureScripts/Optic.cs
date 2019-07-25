using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Optic : MonoBehaviour
{
    public string allowing;
    public GameObject col;
    public bool activate = false;
    private float timer;
    public float onTime = 5f;
    public GameObject controlling;

    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    void onAwake()
    {
        onActivate = new UnityEvent();
        onDeactivate = new UnityEvent();

    }

    private void Start()
    {
        onActivate.AddListener(doThing);
        onDeactivate.AddListener(undoThing);
    }
    private void Update()
    {
        if (activate == true)
        {
            onActivate.Invoke();
            timer += Time.deltaTime;
            if (timer >= onTime)
            {
                activate = false;
                onDeactivate.Invoke();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == allowing)
        {
            col = collision.gameObject;
            collision.gameObject.tag = null;
            activate = true;
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
        if (name.Equals("Bridge"))
        {
            controlling.GetComponent<Collider>().isTrigger = true;
        }
        else
        {
            controlling.GetComponent<Collider>().isTrigger = false;
        }
    }
}
