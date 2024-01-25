using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Cavity : MonoBehaviour
{
    //make list of gameObjects so you can store different types of cavities

    private GameObject tool;
    private Vector3 originalSize;

    private void Awake()
    {
        originalSize = transform.localScale;
    }

    /*
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject == tool)
        {
            Vector3 originalSize = cavity.transform.localScale;
            cavity.transform.localScale *= 0.95f;

            if (cavity.transform.localScale.magnitude < originalSize.magnitude * 0.3)
            {
                Destroy(cavity);
            }
        }
    }
    */

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            transform.localScale *= 0.95f;

            if (transform.localScale.magnitude < originalSize.magnitude * 0.3)
            {
                Destroy(this.gameObject);
            }
            Debug.Log(originalSize);
        }

    }
}

