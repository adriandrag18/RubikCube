using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{ 
    [SerializeField] private float sensitivity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float rotateHorizontal = Input.GetAxis("Mouse X");
            float rotateVertical = Input.GetAxis("Mouse Y");
            transform.RotateAround(Vector3.zero, Vector3.up, rotateHorizontal * sensitivity);
            transform.RotateAround(Vector3.zero, -transform.right, rotateVertical * sensitivity);
        }
    }
}
