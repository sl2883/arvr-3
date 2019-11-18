using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar;

public class LightsaberBehavior : MonoBehaviour
{
    //Accessing the script that take care of lightsaber's grabbing state
    OVRGrabbable grabState;

    //The Quillon that already installed on the handle. Should be inactive at the begginning of the game
    [SerializeField]
    GameObject lightsaberQuillonInstalled;
    //The Quillon module that has not been installed yet.
    [SerializeField]
    GameObject lightsaberQuillonModule;
    //The active area to snap the quillon module to the handle
    [SerializeField]
    GameObject quillonConnectZone;
    bool quillonIsInstalled;

    //The Power that already installed on the handle. Should be inactive at the beginning of the game
    [SerializeField]
    GameObject lightsaberPowerInstalled;
    //The Power module that has not been installed yet
    [SerializeField]
    GameObject lightsaberPowerModule;
    //The active area to snap the power module to the handle
    [SerializeField]
    GameObject powerConnectZone;
    bool powerIsInstalled;

    //bool to signal if the lightsaber is done assembling
    bool lightsaberIsAssembled;

    //The blade that already installed on the handle
    [SerializeField]
    GameObject lightsaberBlade;
    [SerializeField]
    float lightsaberLength = 1f;
    [SerializeField]
    float bladeSmooth = 1f;
    bool bladeIsActivated;

    private void Awake()
    {
        //[TODO]Getting the info of OVRGrabbable
        grabState = GetComponent<OVRGrabbable>();
        bladeIsActivated = false;
        quillonIsInstalled = false;
        powerIsInstalled = false;
    }

    private void FixedUpdate()
    {
        //[TODO]Step one: check if the power is connected.
        ConnectingPower();

        //[TODO]Step two: check in the Quillon is connected.
        ConnectingQuillon();

        //[TODO]Once the lightsaber is done assembling, set the blade GameObject active.

        //[TODO]If the lightsaber is done assembled, change bladeIsActivated after pressing the A button on the R-Controller while the player is grabbing it
        SetBladeStatus(bladeIsActivated);
        
        
    }

    void ConnectingPower()
    {
        //get the connector state of power
        if (gameObject.GetComponentInChildren<LightsaberModuleConnector>().IsConnected) {
            //if it is connected:
            
            //activate the pre-installed power part on the handle
            lightsaberPowerInstalled.SetActive(true);

            //simply make the power module "invisible" by switching off its mesh renderer
            (lightsaberPowerModule.GetComponent<MeshRenderer>()).enabled = false;

            //we dont need the connect area anymore so switch it off
            gameObject.GetComponentInChildren<LightsaberModuleConnector>().enabled = false;

            powerIsInstalled = true;
        }

    }

    void ConnectingQuillon()
    {
        if (!quillonIsInstalled && lightsaberPowerInstalled.GetComponentInChildren<LightsaberModuleConnector>().IsConnected)
        {
            Debug.Log("SUNNY --- In LightSaber, inside quillion");
            //if it is connected:

            //activate the pre-installed power part on the handle
            lightsaberQuillonInstalled.SetActive(true);

            Debug.Log("SUNNY --- In LightSaber, quillion installed");

            //simply make the power module "invisible" by switching off its mesh renderer
            (lightsaberQuillonModule.GetComponent<MeshRenderer>()).enabled = false;

            Debug.Log("SUNNY --- In LightSaber, quillion mesh off");

            //we dont need the connect area anymore so switch it off
            lightsaberPowerInstalled.GetComponentInChildren<LightsaberModuleConnector>().enabled = false;

            Debug.Log("SUNNY --- In LightSaber, module off");

            quillonIsInstalled = true;
        }

        //same process as in power connection        
        
    }

    void SetBladeStatus(bool bladeStatus)
    {
        if (quillonIsInstalled)
        {
            if (!bladeStatus && OVRInput.Get(OVRInput.Button.One))
            {
                Debug.Log("SUNNY -- in blade active");
                //Lightsaber goes back
                lightsaberBlade.gameObject.SetActive(true);
                bladeIsActivated = true;

                lightsaberBlade.gameObject.transform.localScale = new Vector3(0.6f, 1.3f, 1.3f);
            }

            if (bladeStatus && !OVRInput.Get(OVRInput.Button.One))
            {
                //Lightsaber pulls out
                Debug.Log("SUNNY -- in blade deactivated");
                bladeIsActivated = false;

                lightsaberBlade.gameObject.transform.localScale = new Vector3(0.001f, 1.3f, 1.3f);
            }
        }
    }
}
