using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotationVector;
    public float rotationSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVector * (rotationSpeed * Time.deltaTime));
    }
}
