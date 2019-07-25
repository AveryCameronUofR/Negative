using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitCommand : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            {
            SceneManager.LoadScene("Environment");
            }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Application.Quit();
        }
    }
    
}
