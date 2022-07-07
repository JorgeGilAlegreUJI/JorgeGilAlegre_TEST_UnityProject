using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckSpawner : SystemsBase
{
    [Header("Launch Settings")]
    public float launchForce;
    public PuckBase PuckPrefab;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        ClearLine();
    }

    public void LaunchNewPuck(PuckBase puckPrefab,Vector2 direction)
    {
        if (direction.magnitude < 0.1f) return;
        float vectorMagnitude = direction.magnitude;
        vectorMagnitude = Mathf.Clamp(vectorMagnitude, 0.1f, 2.5f);
        PuckBase puck = Instantiate(puckPrefab, transform.position, Quaternion.identity);
        puck.transform.SetParent(transform);
        Rigidbody rb = puck.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(direction.x*-1f,0,direction.y*-1f).normalized * (launchForce * vectorMagnitude));
    }

    public void visualizeDirection(Vector2 direction)
    {
        if (direction.magnitude >= 2.5f) direction = direction.normalized * 2.5f;
        
        Vector3 origin = transform.position;
        origin.y = 0.2f;

        Vector3 endPoint = new Vector3(direction.x * -1f, 0, direction.y * -1f);
        endPoint += origin;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0,origin);
        lineRenderer.SetPosition(1,endPoint);
    }

    public void ClearLine()
    {
        lineRenderer.positionCount = 0;
    }


}
