using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckSpawner : SystemsBase
{
    [Header("Launch Settings")]
    public float launchForce;
    public WoodPuck woodPuckPrefab;

    public void LaunchNewPuck(PuckBase puckPrefab,Vector2 direction)
    {
        PuckBase puck = Instantiate(puckPrefab, transform.position, Quaternion.identity,transform);
        Rigidbody rb = puck.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(direction.x*-1f,0,direction.y*-1f).normalized * launchForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,0.1f);
    }
}
