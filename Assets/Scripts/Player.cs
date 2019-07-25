using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public Transform cam;
    public Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float deltaSpeed = speed * Time.deltaTime;

        Quaternion rot = cam.transform.rotation;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.position += rot * Vector3.right * deltaSpeed;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.position += rot * Vector3.left * deltaSpeed;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            transform.position += rot * Vector3.forward * deltaSpeed;

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            transform.position += rot * Vector3.back * deltaSpeed;
    }

    // neutralizes forces on the player to avoid movement without player input from collisions
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        rb.angularVelocity = new Vector3(0, rb.angularVelocity.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Finish"))
        {
            other.enabled = false;
        }
    }
}
