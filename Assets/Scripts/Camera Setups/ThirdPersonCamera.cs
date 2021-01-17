using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple 3rd person camera 
/// You can get better results if you use Unity CineMachine. 
/// 
/// </summary>
public class ThirdPersonCamera : MonoBehaviour
{
    public const float Y_ANGLE_MIN = 0.0f;
    public const float Y_ANGLE_MAX = 85.0f;

    public Transform lookAt;
    public Transform cameraTransform;
    private Camera cam;

    Vector3 direction;
    Quaternion rotation;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 20.0f;
    float sensitivityX= 4.0f;
    float sensitivityY = 1.0f;
    public bool InvertYAxis = true;
    
    void Start()
    {
        cameraTransform = transform;
        cam = Camera.main;
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        if (InvertYAxis)
        {
            currentY += Input.GetAxis("Mouse Y") *(-1);
        } else
        {
            currentY += Input.GetAxis("Mouse Y");
        }
        

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    void LateUpdate()
    {
        direction = new Vector3(0, 0, -distance);
        rotation = Quaternion.Euler(currentY, currentX, 0);
        cameraTransform.position = lookAt.position + rotation * direction;
        cameraTransform.LookAt(lookAt.position);
    }
}
