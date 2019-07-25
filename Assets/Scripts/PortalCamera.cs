using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    private void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angleDifference = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalDifference = Quaternion.AngleAxis(angleDifference, Vector3.up);
        Vector3 newCamDirection = portalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCamDirection, Vector3.up);
    }
}
