using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar;

public class GlueGunBehavior : MonoBehaviour
{
    OVRGrabbable grabState;

    //The interactive area that would be activated when pressing down the trigger while grabbing the gluegun
    [SerializeField]
    GameObject glueZone;

    private void Awake()
    {
        //Get component of the OVRGrabbable
    }

    private void FixedUpdate()
    {
        //If the gluegun is being grabbed, the gluezone is active while the trigger is pressed
    }
}
