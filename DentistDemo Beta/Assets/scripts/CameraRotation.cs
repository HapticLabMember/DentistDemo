using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    //can rotate entire menu set or just rotate the teeth
    //public GameObject teeth;
    
    [SerializeField] private GameObject menuSet;
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private Sprite leftButtonSymbol;
    [SerializeField] private Sprite rightButtonSymbol;
    public Transform rotatePoint;
    public float rotationSpeed = 1.0f;

    // Start is called before the first frame update
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject == leftButton)
        {
            menuSet.transform.RotateAround(rotatePoint.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if(collision.gameObject == rightButton)
        {
            menuSet.transform.RotateAround(rotatePoint.position, Vector3.down, rotationSpeed * Time.deltaTime);
        }
    }
}
