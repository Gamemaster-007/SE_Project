using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour
{
    public float rotaterate=100f;
    void Start()
    {
        Debug.Log(" ");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down, rotaterate*Time.deltaTime);
    }
}
