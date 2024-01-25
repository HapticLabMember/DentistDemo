using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbreakableTeeth : MonoBehaviour
{
    public HapticPlugin hp;
    public float breakingForce = 45.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<FixedJoint>() != null)
        {
            if(hp.GrabObject == this.gameObject)
            {
                this.GetComponent<FixedJoint>().breakForce = breakingForce;
            } else
            {
                this.GetComponent<FixedJoint>().breakForce = Mathf.Infinity;
            }
        }
    }
}
