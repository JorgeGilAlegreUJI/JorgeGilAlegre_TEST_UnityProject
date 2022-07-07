using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.GetChild(0).position,0.05f);
        for (int i = 1; i < transform.childCount; i++)
        {
            Gizmos.DrawWireSphere(transform.GetChild(i).position,0.05f);
            Gizmos.DrawLine(transform.GetChild(i).position,transform.GetChild(i-1).position);
        }
    }
}


