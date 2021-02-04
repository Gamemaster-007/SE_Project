using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnField : MonoBehaviour
{
    public float cur_field_no = 0f;
    public bool[] field_isEmpty = {true,true,true,true};
    public string[] field_cropname = {"","","",""};
    public GameObject[] crops_menu = new GameObject[3];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Touch touch = Input.touches[0];
        // Ray touchRay = Camera.mainCamera..ScreenPointToRay(touch.position);
        // RaycastHit[] hits = Physics.RaycastAll(touchRay);
        // foreach( RaycastHit hit in hits ) {
  
        //     print("touching object name="+hit.gameObject.name);
        //     Debug.Log("touching object name="+hit.gameObject.name);
  
        // }
    //     if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
    // {
    //     // Debug.Log("touched the screen");
    //     Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //     RaycastHit raycastHit;
    //     if (Physics.Raycast(raycast, out raycastHit))
    //     {
    //         Debug.Log("Something Hit");
    //         // if (raycastHit.collider.name == "Soccer")
    //         // {
    //         //     Debug.Log("Soccer Ball clicked");
    //         // }

    //         // //OR with Tag

    //         // if (raycastHit.collider.CompareTag("SoccerTag"))
    //         // {
    //         //     Debug.Log("Soccer Ball clicked");
    //         // }
    //     }
    // }
        // foreach (Touch touch in Input.touches)
        // {
        //     if (touch.phase == TouchPhase.Began)
        //     {
        //         Ray ray = Camera.main.ScreenPointToRay (touch.position);
        //         RaycastHit hit = new RaycastHit();
        //         if (Physics.Raycast (ray,out hit,1000.0f))
        //         {
        //             if(hit.collider.gameObject == this.gameObject)
        //             {
        //                 Debug.LogWarning(hit.transform.name);
        //                 // _blFound = true;
        //             }
        //         }
        //     }
        // }
        if (Input.touchCount >= 1)
        {
            // Debug.Log(Input.GetTouch(0).phase);
            if (Input.GetTouch(0).phase != TouchPhase.Moved)
            {
                // Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                // RaycastHit hit;
                // if (Physics.Raycast(ray, out hit))
                // {
                //     // Debug.Log(hit.transform.name);
                // }
            }
            
        }
        
    }
}
