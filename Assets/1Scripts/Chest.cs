using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Chest : ObjectBase
{
    public GameObject CoinsPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        ObjectBase ob = collision.transform.GetComponent<ObjectBase>();
        if (ob is PuckBase)
        {
            GameObject Coins = Instantiate(CoinsPrefab, transform.position, quaternion.identity);
            //Coins.transform.SetParent(transform);
        }
    }
}
