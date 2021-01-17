using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple follow player script, that matches the camera
/// position to the players movement.
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
