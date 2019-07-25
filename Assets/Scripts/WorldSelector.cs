using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSelector : MonoBehaviour
{
    public Camera playerCam;
    public GameObject portalTo;
    public string world1Layer = "world1";
    public string world2Layer = "world2";
    public string world3Layer = "world3";
    public string world4Layer = "world4";

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            if (portalTo.name.ToLower().Contains(world1Layer))
            {
                playerCam.cullingMask |= 1 << LayerMask.NameToLayer(world1Layer);

                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world2Layer));
                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world3Layer));
                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world4Layer));

                playerCam.gameObject.layer = LayerMask.NameToLayer(world1Layer);
            }
            else if (portalTo.name.ToLower().Contains(world2Layer))
            {
                playerCam.cullingMask |= 1 << LayerMask.NameToLayer(world2Layer);

                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world1Layer));
                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world3Layer));
                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world4Layer));

                playerCam.gameObject.layer = LayerMask.NameToLayer(world2Layer);
            } else if (portalTo.name.ToLower().Contains(world3Layer))
            {
                playerCam.cullingMask |= 1 << LayerMask.NameToLayer(world3Layer);

                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world1Layer));
                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world2Layer));
                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world4Layer));
                playerCam.gameObject.layer = LayerMask.NameToLayer(world3Layer);
            }
            else if (portalTo.name.ToLower().Contains(world4Layer))
            {
                playerCam.cullingMask |= 1 << LayerMask.NameToLayer(world4Layer);

                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world1Layer));
                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world2Layer));
                playerCam.cullingMask &= ~(1 << LayerMask.NameToLayer(world3Layer));
                playerCam.gameObject.layer = LayerMask.NameToLayer(world4Layer);
            }
        }

        if (portalTo.name.ToLower().Contains(world1Layer))
        {
            collision.gameObject.layer = LayerMask.NameToLayer(world1Layer);
            foreach (Transform child in collision.transform)
            {
                changeChildren(child, world1Layer);
            }
        }
        else if (portalTo.name.ToLower().Contains(world2Layer))
        {
            collision.gameObject.layer = LayerMask.NameToLayer(world2Layer);
            foreach (Transform child in collision.transform)
            {
                changeChildren(child, world2Layer);
            }
        } else if (portalTo.name.ToLower().Contains(world3Layer))
        {
            collision.gameObject.layer = LayerMask.NameToLayer(world3Layer);
            foreach (Transform child in collision.transform)
            {
                changeChildren(child, world3Layer);
            }
        }
        else if (portalTo.name.ToLower().Contains(world4Layer))
        {
            collision.gameObject.layer = LayerMask.NameToLayer(world4Layer);
            foreach (Transform child in collision.transform)
            {
                changeChildren(child, world4Layer);
            }
        }
    }

    private void changeChildren(Transform child, string world)
    {
        if (child.childCount > 0)
        {
            foreach (Transform children in child)
            {
                changeChildren(children, world);
            }
        }

        child.gameObject.layer = LayerMask.NameToLayer(world);
    }
}
