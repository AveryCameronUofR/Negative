using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSelectorOld : MonoBehaviour
{
    public Camera playerCam;
    public GameObject sphere;
    public GameObject cube;
    /*
     * WorldSelector:
     * Takes camera and/or object1 and/or object2
     * changes layer to proper world based on collision
     * 
     * ***For Boxes with sphere and cube component, both need to be reference in the script in unity****
     */
    public void Start()
    {
        if (playerCam != null){
            //adds the layer to the camera render
            playerCam.cullingMask |= 1 << LayerMask.NameToLayer("world1");
            //removes the layer from the camera render
            playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer("world2"));
        }
        if (sphere != null)
            sphere.layer = LayerMask.NameToLayer("world1");

        if(cube!= null)
            cube.layer = LayerMask.NameToLayer("world1");
    }

    private void  OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.ToLower().Contains("world2"))
        {
            if (playerCam != null)
            {
                playerCam.cullingMask |= 1 << LayerMask.NameToLayer("world2");
                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer("world1"));
            }
            if (sphere != null)
                sphere.layer = LayerMask.NameToLayer("world2");

            if (cube != null)
                cube.layer = LayerMask.NameToLayer("world2");
        }

        if (collision.gameObject.name.ToLower().Contains("world1"))
        {
            if (playerCam != null)
            {
                playerCam.cullingMask |= 1 << LayerMask.NameToLayer("world1");
                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer("world2"));
            }
            if (sphere != null)
                sphere.layer = LayerMask.NameToLayer("world1");

            if (cube != null)
                cube.layer = LayerMask.NameToLayer("world1");
        }
    }
}
