using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Cavity : MonoBehaviour
{
    //make list of gameObjects so you can store different types of cavities

    private GameObject cavity;
    private Vector3 originalSize;
    public GameObject tool;

    private void Awake()
    {
        cavity = this.gameObject;
        originalSize = transform.localScale;
        GameObject[] tools = GameObject.FindGameObjectsWithTag("Player");
        if(tools.Length > 0)
        {
            tool = tools[0];
        }
    }

    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == tool)
        {
            cavity.transform.localScale *= 0.97f;

            if (cavity.transform.localScale.magnitude < originalSize.magnitude * 3)
            {
                Destroy(cavity);
            }
        }
    }
    
    
    /*
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
    */
}

