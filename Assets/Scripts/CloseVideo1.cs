using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseVideo1 : MonoBehaviour
{public float timer = 0.0f;
    public GameObject lights;
    public GameObject lights2;
 
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        

   
        if (lights.GetComponent<Light>().intensity < 3 && timer > 3.75f) 
        {
            lights.GetComponent<Light>().intensity += 0.1f;
           
        }  
           timer += Time.deltaTime;
           if(timer > 15.10f)
           {
            
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<QuitCommand>().enabled = true;

           }

        lights2.GetComponent<Light>().color = Color.Lerp(Color.white, Color.black, 10f);

    }
}
