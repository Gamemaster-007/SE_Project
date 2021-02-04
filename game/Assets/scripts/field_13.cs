using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field_13 : MonoBehaviour
{

    public GameObject[] crop_menu = new GameObject[3];
    public bool isEmpty = true;
    public string crop_Name;
    public GameObject paddy;
    public GameObject[] sunflowers = new GameObject[6];
    public GameObject[] corns = new GameObject[6];

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1 && isEmpty == true)
        {
            foreach (GameObject crop in crop_menu)
            {
                crop.SetActive(true);
            }
        }
    }

    public void add_crop(string crop_name)
    {
        isEmpty = false;
        crop_Name = crop_name;
        if (crop_name == "paddy")
        {
            paddy.SetActive(true);
        }
        else if(crop_name == "sunflower")
        {
            foreach (GameObject sunflower in sunflowers)
            {
                sunflower.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject corn in corns)
            {
                corn.SetActive(true);
            }
        }

        foreach (GameObject crop in crop_menu)
        {
            crop.SetActive(false);
        }
    }
}
