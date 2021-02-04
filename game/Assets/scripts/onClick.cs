using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour
{
    public GameObject crops;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            crops.SetActive(true);
        }
    }

    void OnMouseDown() {
        crops.SetActive(false);
        Debug.Log("clicked");
    }
}
