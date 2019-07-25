using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveCycle : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 10;
    private int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        



        if (Vector3.Distance(waypoints[current].transform.position, transform.position) <= WPradius)
        {
            while(current == number)
            {
             number = Random.Range(1, 8);
            
            }
            current = number;
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
}
