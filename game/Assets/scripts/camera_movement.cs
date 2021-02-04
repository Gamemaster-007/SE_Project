using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class camera_movement : MonoBehaviour
{
    public Camera Camera;
    public bool Rotate;
    protected Plane Plane;
    public bool istapped;
    public string component_name;
    
    
    public string[] crop_Names = new string[4];

    public bool[] isFieldEmpty = {true,true,true,true};
    public bool[] isFieldReady = {false,false,false,false};
    public GameObject[] checkMarks = new GameObject[4];

    public bool[] isSecFieldEmpty = {true,true,true,true};
    public bool[] isSecFieldReady = {false,false,false,false};
    public GameObject[] secCheckMarks = new GameObject[4];
    
    public int paddy_count = 0;
    public int sunflower_count = 0;
    public int corn_count = 0;
    public int pumpkin_count = 0;
    public int carrot_count = 0;

    public GameObject[] crop_menu;
    public bool isCropMenuOpen = false;

    public GameObject pumpkin_button;
    public bool isPumpkinButtonOpen = false;

    public GameObject carrot_button;
    public bool isCarrotButtonOpen = false;

    public GameObject[] paddy = new GameObject[4];
    public GameObject[] sunflowers = new GameObject[24];
    public GameObject[] corns = new GameObject[24];
    public GameObject[] pumpkins = new GameObject[24];
    public GameObject[] carrots = new GameObject[18];

    public int total_coins = 0;
    public Text total_coins_display;

    public int[] display_coin_count = {0,10};
    public GameObject[] coins = new GameObject[2];
    public GameObject[] display_coin_text = new GameObject[2];

    public GameObject shop;
    public GameObject[] items;

    private void Awake()
    {
        if (Camera == null)
            Camera = Camera.main;
    }

    private void on_field_tap(int field_no, string component_Name)
    {
        if (isFieldEmpty[field_no] == true && isCropMenuOpen == false)
        {
            pumpkin_button.SetActive(false);
            isPumpkinButtonOpen = false;

            carrot_button.SetActive(false);
            isCarrotButtonOpen = false;

            isCropMenuOpen = true;
            component_name = component_Name;
            foreach (GameObject crop in crop_menu)
            {
                crop.SetActive(true);
            }
        }
        else if (isFieldReady[field_no] == true)
        {
            isFieldEmpty[field_no] = true;
            isFieldReady[field_no] = false;
            checkMarks[field_no].SetActive(false);
            if (crop_Names[field_no] == "paddy")
            {
                paddy_count = paddy_count + 1;
                paddy[field_no].SetActive(false);
            }
            else if (crop_Names[field_no] == "sunflower")
            {
                sunflower_count = sunflower_count + 1;
                for (int i=field_no*6; i<(field_no+1)*6; i++)
                {
                    sunflowers[i].SetActive(false);
                }
            }
            else
            {
                corn_count = corn_count + 1;
                for (int i=field_no*6; i<(field_no+1)*6; i++)
                {
                    corns[i].SetActive(false);
                }
            }
        }
    }

    private void on_sec_field_tap(int field_no, string component_Name)
    {
        if (field_no == 1 || field_no == 3)
        {
            if (isSecFieldEmpty[field_no] == true && isPumpkinButtonOpen == false)
            {
                isCropMenuOpen = false;
                foreach (GameObject crop in crop_menu)
                {
                    crop.SetActive(false);
                }

                isCarrotButtonOpen = false;
                carrot_button.SetActive(false);

                isPumpkinButtonOpen = true;
                pumpkin_button.SetActive(true);
                component_name = component_Name;
            }
            else if (isSecFieldReady[field_no] == true)
            {
                isSecFieldEmpty[field_no] = true;
                isSecFieldReady[field_no] = false;
                secCheckMarks[field_no].SetActive(false);
                pumpkin_count = pumpkin_count + 1;
                if (field_no == 1)
                {
                    for (int i=0; i<12; i++)
                    {
                        pumpkins[i].SetActive(false);
                    }
                }
                else
                {
                    for (int i=12; i<24; i++)
                    {
                        pumpkins[i].SetActive(false);
                    }
                }
            }
        }
        else if (field_no == 0 || field_no == 2)
        {
            if (isSecFieldEmpty[field_no] == true && isPumpkinButtonOpen == false)
            {
                isCropMenuOpen = false;
                foreach (GameObject crop in crop_menu)
                {
                    crop.SetActive(false);
                }

                isPumpkinButtonOpen = false;
                pumpkin_button.SetActive(false);

                isCarrotButtonOpen = true;
                carrot_button.SetActive(true);
                component_name = component_Name;
            }
            else if (isSecFieldReady[field_no] == true)
            {
                isSecFieldEmpty[field_no] = true;
                isSecFieldReady[field_no] = false;
                secCheckMarks[field_no].SetActive(false);
                carrot_count = carrot_count + 1;
                if (field_no == 0)
                {
                    for (int i=0; i<9; i++)
                    {
                        carrots[i].SetActive(false);
                    }
                }
                else
                {
                    for (int i=9; i<18; i++)
                    {
                        carrots[i].SetActive(false);
                    }
                }
            }
        }
    }

    private void Update()
    {

        for (int i=0; i<2; i++)
        {
            if(display_coin_count[i] != 0)
            {
                TextMesh text = display_coin_text[i].GetComponent<TextMesh>();
                text.text = display_coin_count[i].ToString();
                coins[i].SetActive(true);
                coins[i].transform.Rotate(0,-25*Time.deltaTime,0);
            }
            else
            {
                coins[i].SetActive(false);
            }
        }

        if (Input.touchCount >= 1)
            Plane.SetNormalAndPosition(transform.up, transform.position);

        var Delta1 = Vector3.zero;
        var Delta2 = Vector3.zero;

        if (Input.touchCount >= 1)
        {

            Delta1 = PlanePositionDelta(Input.GetTouch(0));
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                istapped = true;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                istapped = false;
                var new_cam_pos = Delta1+Camera.transform.position;
                
                if (new_cam_pos.x > -90 && new_cam_pos.x < 150 && new_cam_pos.z > -70 && new_cam_pos.z < -10)
                    Camera.transform.Translate(Delta1, Space.World);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (istapped == true)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.name == "field_13")
                        {
                            on_field_tap(0,"field_13");
                        }
                        else if (hit.transform.name == "field_14")
                        {
                            on_field_tap(1,"field_14");
                        }
                        else if (hit.transform.name == "field_23")
                        {
                            on_field_tap(2,"field_23");
                        }
                        else if (hit.transform.name == "field_24")
                        {
                            on_field_tap(3,"field_24");
                        }
                        else if (hit.transform.name == "field_11")
                        {
                            on_sec_field_tap(0,"field_11");
                        }
                        else if (hit.transform.name == "field_12")
                        {
                            on_sec_field_tap(1,"field_12");
                        }
                        else if (hit.transform.name == "field_21")
                        {
                            on_sec_field_tap(2,"field_21");
                        }
                        else if (hit.transform.name == "field_22")
                        {
                            on_sec_field_tap(3,"field_22");
                        }
                        else if (hit.transform.name == "coin_collector_1" || hit.transform.name == "coin_collector_2")
                        {
                            int index = hit.transform.name[hit.transform.name.Length - 1] - '0';
                            total_coins = total_coins + display_coin_count[index - 1];
                            display_coin_count[index-1] = 0;
                            total_coins_display.text = total_coins.ToString();
                        }
                        else if (hit.transform.name == "factory_1")
                        {
                            shop.SetActive(true);
                        }
                    }
                }
            }
                
        }

    }

    public void close_shop(){
        shop.SetActive(false);
    }

    private void modify_crop(int field_no, string crop_name)
    {
        isFieldEmpty[field_no] = false;
        isFieldReady[field_no] = true;
        isCropMenuOpen = false;
        crop_Names[field_no] = crop_name;
        if (crop_name == "paddy")
        {
            paddy[field_no].SetActive(true);
        }
        else if (crop_name == "sunflower")
        {
            for (int i=field_no*6; i<(field_no+1)*6; i++)
            {
                sunflowers[i].SetActive(true);
            }
        }
        else
        {
            for (int i=field_no*6; i<(field_no+1)*6; i++)
            {
                corns[i].SetActive(true);
            }
        }
        foreach (GameObject crop in crop_menu)
        {
            crop.SetActive(false);
        }
        checkMarks[field_no].SetActive(true);
    }

    private void modify_sec_crop(int field_no, string crop_name)
    {
        isSecFieldEmpty[field_no] = false;
        isSecFieldReady[field_no] = true;
        if (field_no == 0)
        {
            isCarrotButtonOpen = false;
            for (int i=0; i<9; i++)
            {
                carrots[i].SetActive(true);
            }
            carrot_button.SetActive(false);
        }
        else if (field_no == 1)
        {
            isPumpkinButtonOpen = false;
            for (int i=0; i<12; i++)
            {
                pumpkins[i].SetActive(true);
            }
            pumpkin_button.SetActive(false);
        }
        else if (field_no == 2)
        {
            isCarrotButtonOpen = false;
            for (int i=9; i<18; i++)
            {
                carrots[i].SetActive(true);
            }
            carrot_button.SetActive(false);
        }
        else if (field_no == 3)
        {
            isPumpkinButtonOpen = false;
            for (int i=12; i<24; i++)
            {
                pumpkins[i].SetActive(true);
            }
            pumpkin_button.SetActive(false);
        }
        secCheckMarks[field_no].SetActive(true);
    }

    public void add_crop(string crop_name)
    {
        if (component_name == "field_13")
        {
            modify_crop(0,crop_name);
        }
        else if (component_name == "field_14")
        {
            modify_crop(1,crop_name);
        }
        else if (component_name == "field_23")
        {
            modify_crop(2,crop_name);
        }
        else if (component_name == "field_24")
        {
            modify_crop(3,crop_name);
        }
        else if (component_name == "field_11")
        {
            modify_sec_crop(0,crop_name);
        }
        else if (component_name == "field_12")
        {
            Debug.Log("clicked");
            modify_sec_crop(1,crop_name);
        }
        else if (component_name == "field_21")
        {
            modify_sec_crop(2,crop_name);
        }
        else if (component_name == "field_22")
        {
            modify_sec_crop(3,crop_name);
        }
    }

    protected Vector3 PlanePositionDelta(Touch touch)
    {
        if (touch.phase != TouchPhase.Moved)
            return Vector3.zero;

        var rayBefore = Camera.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = Camera.ScreenPointToRay(touch.position);
        if (Plane.Raycast(rayBefore, out var enterBefore) && Plane.Raycast(rayNow, out var enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);

        return Vector3.zero;
    }

    protected Vector3 PlanePosition(Vector2 screenPos)
    {
        var rayNow = Camera.ScreenPointToRay(screenPos);
        if (Plane.Raycast(rayNow, out var enterNow))
            return rayNow.GetPoint(enterNow);

        return Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }
}