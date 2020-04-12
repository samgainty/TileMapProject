using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleMouseFollow : MonoBehaviour
{
    private void Update()
    {
        // Track cursor on screen coordinates
        transform.position = Input.mousePosition;
    }
}
