using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : ObjectBase
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float Force = 500f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(StartDeath());

    }

    void Start()
    {
        transform.localScale = Vector3.one * Random.Range(0.05f, 0.2f);

        Vector3 direction = new Vector3(Random.Range(-0.5f,0.5f), Random.value*0.5f, Random.Range(-0.5f,0.5f));
        rb.AddForce(direction*Force);
        
        Vector3 torque = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), Random.Range(-1f,1f));
        rb.AddTorque(torque*Force);
    }

    public override float deathWaitTime
    {
        get { return 3f; }
    }
}
