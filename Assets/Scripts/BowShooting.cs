using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShooting : MonoBehaviour
{
    public Camera Cam;
    public GameObject arrow;
    public Transform arrowSpawn;
    public float projectileSpeed;
    private bool timerStart = false;
    private float reloadTime = 0.1f;
    private float timer;
    
    void Update()
    {
        if (timerStart)
        {
            timer += Time.deltaTime;
        }
        if (timer >= reloadTime)
        {
            timer = 0;
            timerStart = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !timerStart)
        {
            timerStart = true;
            arrow.layer = Cam.gameObject.layer;
            GameObject arrowObject = Instantiate(arrow, arrowSpawn.position, Quaternion.identity);
            Rigidbody rb = arrowObject.GetComponent<Rigidbody>();
            rb.velocity = Cam.transform.forward * projectileSpeed;
        }
    }
}
