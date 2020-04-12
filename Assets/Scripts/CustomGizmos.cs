using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class CustomGizmos
{
    public static void DrawWireSquare(Vector3 position, Vector3 size, Color lineColour, Color fillColour)
    {
        if (fillColour != null)
        {
            Gizmos.color = fillColour;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
        }

        Gizmos.color = lineColour;
        // Left line
        Gizmos.DrawLine(position - Vector3.right * size.x * 0.5f - Vector3.up * size.y * 0.5f, position - Vector3.right * size.x * 0.5f + Vector3.up * size.y * 0.5f);
        // Right line
        Gizmos.DrawLine(position + Vector3.right * size.x * 0.5f - Vector3.up * size.y * 0.5f, position + Vector3.right * size.x * 0.5f + Vector3.up * size.y * 0.5f);
        // Top line
        Gizmos.DrawLine(position - Vector3.right * size.x * 0.5f + Vector3.up * size.y * 0.5f, position + Vector3.right * size.x * 0.5f + Vector3.up * size.y * 0.5f);
        // Bottom line
        Gizmos.DrawLine(position - Vector3.right * size.x * 0.5f - Vector3.up * size.y * 0.5f, position + Vector3.right * size.x * 0.5f - Vector3.up * size.y * 0.5f);

        DrawString("0", position, Color.white);

        
    }

    public static void DrawString(string text, Vector3 position, Color colour)
    {
        float zoom = SceneView.currentDrawingSceneView.camera.orthographicSize;

        // the style object allows you to control font size, among many other settings
        var style = new GUIStyle();

        // this value depends on your scene, tweak it to match the other objects
        int fontSize = 70;

        // as you zoom out, the ortho size actually increases, 
        // so dividing by it makes the font smaller which is exactly what we need
        style.fontSize = Mathf.FloorToInt(fontSize / zoom);
        style.alignment = TextAnchor.MiddleCenter;
        style.normal.textColor = colour;

        Handles.Label(position, text, style);
    }
}
