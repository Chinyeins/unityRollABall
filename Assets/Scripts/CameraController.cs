using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Position camera
*/
public class CameraController : MonoBehaviour
{
    public Camera camera;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if(camera == null)
        {
            Debug.LogWarning("There is no camera attached to the PlayerController. Please select a camera to use for your player.");
        } else
        {
            offset = camera.transform.position - transform.position;
        } 

    }

    // Is run after all other objects, scripts has been processed.
    //This guarantees the player really has moved before setting cam pos.
    void LateUpdate()
    {
        if(camera)
        {
            camera.transform.position = offset + transform.position;
        }
    }
}
