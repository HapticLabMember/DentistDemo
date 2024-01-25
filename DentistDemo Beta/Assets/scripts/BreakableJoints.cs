using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableJoints : MonoBehaviour
{
    public float springConstant = 10f;
    private Vector3 originalPosition;
    private bool isPulled = false;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (!isPulled)
        {
            // Calculate displacement from the original position.
            Vector3 displacement = transform.position - originalPosition;

            // Calculate the spring force.
            Vector3 springForce = -springConstant * displacement;

            // Apply the spring force to the tooth.
            GetComponent<Rigidbody>().AddForce(springForce);
        }
    }

    public void PullTooth()
    {
        isPulled = true;
        // Apply any additional forces to simulate the tooth being pulled from the gum.
    }
}


