using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void Update()
    {
        Vector3 playeroffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playeroffsetFromPortal;

        float angularDiffrece = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotDiff = Quaternion.AngleAxis(angularDiffrece, Vector3.up);
        Vector3 newCamDir = portalRotDiff * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);

    }
}
