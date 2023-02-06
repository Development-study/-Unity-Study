using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
    public float rotatespeed = 100;

    void Update()
    {
        transform.Rotate(Vector3.up * rotatespeed * Time.deltaTime, Space.World);
    }

}
