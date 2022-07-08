using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : ObjectBase
{
    public GameObject ExplosionPrefab;
    public Route route;
    public float distanceThreshold;

    public float movementSpeed;
    public float rotationSpeed;
    private Rigidbody rb;

    private int currentIndex = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SetFirstIndex();
    }
    private void Update()
    {
        Movement();
    }

    void SetFirstIndex()
    {
        float minDis = float.MaxValue;
        
        for (int i = 0; i < route.transform.childCount; i++)
        {
            Transform child = route.transform.GetChild(i);
            float dis = Vector2.Distance(transform.position, child.transform.position);
            if (dis <= minDis)
            {
                minDis = dis;
                currentIndex = i;
            }
            
        }   
        
        transform.LookAt(route.transform.GetChild(currentIndex));
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
        transform.position += transform.forward* increment;

        //if(passedDistance)
    }

    private void OnCollisionEnter(Collision collision)
    {
        ObjectBase ob = collision.transform.GetComponent<ObjectBase>();
        if (ob is PuckBase)
        {
            GameObject Explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            rb.velocity *= 1.2f;
            //Coins.transform.SetParent(transform);
        }
    }
}
