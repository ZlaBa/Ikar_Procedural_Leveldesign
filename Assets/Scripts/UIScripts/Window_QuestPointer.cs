using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window_QuestPointer : MonoBehaviour
{
    public Rigidbody2D Parent;
    public Rigidbody2D WaypointCircle;
    public Camera cam;

    public Vector2 shuttle;

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        WaypointCircle.position = Parent.position;
        Vector2 circleDir = shuttle - WaypointCircle.position;
        float angle = Mathf.Atan2(circleDir.y, circleDir.x) * Mathf.Rad2Deg - 90f;
        WaypointCircle.rotation = angle;
    }
}
