using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingblocks : MonoBehaviour
{
    public float rotationrate=100f;
    void Start()
    {
        Debug.Log(" ");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down, rotationrate*Time.deltaTime);
    }
}
