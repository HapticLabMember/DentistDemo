using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringTrigger : MonoBehaviour
{
    public HapticPlugin HP;
    public GameObject trg;
    public float springMag = 0.008f;
    private bool exists = false;
    private bool broken = false;

    // Start is called before the first frame update
    void Start()
    {
        HP.SpringAnchorObj = null;
        HP.SpringGMag = 0.0f;
        HP.enable_GloablSpring = false;
        if(trg == null)
        {
            trg = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if there isn't the HP.GrabObject != null condition
        //it checks HP.GrabObject.GetComponent even if grabobject is null, which breaks the code
        if (HP.GrabObject == trg && trg.GetComponent<FixedJoint>() != null && HP.bIsGrabbing == true)
        {

            //checks if the spring anchor is already set
            //if anchor is not set, it changes HP.SpringGDir to the current position of stylus
            //"exists" changes to true so it doesnt repeat this code every frame
            if (!exists)
            {
                HP.SpringGDir = HP.CurrentPosition;
                exists = true;
            }
            HP.SpringGMag = springMag;
            HP.enable_GloablSpring = true;
        }
        //if there are no objects being grabbed or the fixed joint has broken, spring is disabled
        else if(HP.bIsGrabbingActive == false || (trg.GetComponent<FixedJoint>() == null && broken == false))
        {
            //if the spring anchor was set, it changes the position to zero (might not be necessary)
            //also changes "exists" to false so the next time we grab an object, it sets the anchor
            //to the current stylus position
            if (exists)
            {
                HP.SpringGDir = Vector3.zero;
                exists = false;
            }

            //setting spring magnitude to 0 and disabling spring force
            HP.SpringGMag = 0.0f;
            HP.enable_GloablSpring = false;
            if(trg.GetComponent<FixedJoint>() == null)
            {
                broken = true;
            }
        }
    }
}
