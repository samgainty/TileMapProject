using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private Rigidbody2D rb;

    public Tilemap map;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get XY input
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        // Apply to player rigidbody2D
        rb.velocity = Vector3.right * inputX * moveSpeed + Vector3.up * inputY * moveSpeed;     
    }
}
