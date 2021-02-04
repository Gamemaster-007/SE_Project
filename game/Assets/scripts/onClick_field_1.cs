using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick_field_1 : MonoBehaviour
{
    public GameObject crops_menu;
    public bool isEmpty = true;
    public string crop_name = "";
    public Time remaining_time;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            crops_menu.SetActive(true);
        }
    }
}