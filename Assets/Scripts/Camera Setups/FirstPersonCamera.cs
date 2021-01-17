using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple 1st person camera
/// </summary>
public class FirstPersonCamera : MonoBehaviour
{
    float y;
    float x;
    Vector3 rotationVal;
    public Camera camera;
    public float mouseSpeed = 1.0f;

    void LateUpdate()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");

        rotationVal = new Vector3(x, y * -1, 0) * mouseSpeed;
        camera.transform.eulerAngles = camera.transform.eulerAngles - rotationVal; ;
    }
}
