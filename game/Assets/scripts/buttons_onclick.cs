using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons_onclick : MonoBehaviour
{

    public GameObject paddy;
    public GameObject[] sunflower;
    public GameObject[] corn;

    // void Start() {
    //     sunflower = GameObject.FindGameObjectsWithTag("sunflower_1");
    // }

    void Update()
    {
        
    }

    public void field1_onClick(string crop_name) {
        if (crop_name == "paddy")
        {
            paddy.SetActive(true);
        }
        else if( crop_name == "corn" )
        {
            foreach (GameObject sunfl in sunflower)
            {
                sunfl.SetActive(true);
            }
        }
        else{
            foreach (GameObject cor in corn)
            {
                cor.SetActive(true);
            }
        }
    }
}
