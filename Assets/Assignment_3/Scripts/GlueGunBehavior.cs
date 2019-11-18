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

    public OVRInput.Button shootingButton;

    private void Awake()
    {
        //Get component of the OVRGrabbable
        grabState = GetComponent<OVRGrabbable>();
    }

    private void FixedUpdate()
    {
        //If the gluegun is being grabbed, the gluezone is active while the trigger is pressed
        
        if(grabState.isGrabbed && OVRInput.Get(OVRInput.RawButton.LIndexTrigger)) //OVRInput.Get(OVRInput.Button.One)
        {
            glueZone.gameObject.SetActive(true);
            Debug.Log("Sunny -- Here in gluegun down state");
        }
        else
        {
            glueZone.gameObject.SetActive(false);
        }
    }
}
