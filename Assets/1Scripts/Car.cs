using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : ObjectBase
{
    public Route route;
    public float distanceThreshold;

    public float movementSpeed;
    public float rotationSpeed;
    private Rigidbody rb;

    private int currentIndex = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        Waypoint nextPoint = route.transform.GetChild(currentIndex).GetComponent<Waypoint>();
        float dis = Vector3.Distance(transform.position, nextPoint.transform.position);
        if (dis <= distanceThreshold)
        {
            currentIndex++;
            if (currentIndex >= route.transform.childCount) currentIndex = 0;
            nextPoint = route.transform.GetChild(currentIndex).GetComponent<Waypoint>();
        }

        Vector3 dir = nextPoint.transform.position - transform.position;
        Quaternion newRot = Quaternion.LookRotation(dir, nextPoint.upVector);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotationSpeed * Time.deltaTime);
        float increment = (movementSpeed * Time.deltaTime);
        transform.position += dir.normalized* increment;

        //if(passedDistance)
    }
}
