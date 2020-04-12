using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam;

    public GameObject player;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        // Set camera position to player position with constant z distance
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10.0f);
    }

}
