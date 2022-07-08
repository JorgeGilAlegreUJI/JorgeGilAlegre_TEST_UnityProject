using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : ObjectBase
{
    public GameObject CoinsPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        ObjectBase ob = collision.transform.GetComponent<ObjectBase>();
        if (ob is PuckBase)
        {
            GameObject Coins = Instantiate(CoinsPrefab, transform.position, Quaternion.identity);
            Coins.transform.SetParent(transform);
        }
    }
}
