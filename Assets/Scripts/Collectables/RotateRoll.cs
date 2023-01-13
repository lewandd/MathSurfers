using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoll : MonoBehaviour
{
    public float rotateSpeed = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeed, 0, 0, Space.World);
    }
}