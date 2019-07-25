using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    
    public void Update()
    {
            if (Input.anyKey)
            {
            SceneManager.LoadScene("Environment");
            }
    }
    
}
