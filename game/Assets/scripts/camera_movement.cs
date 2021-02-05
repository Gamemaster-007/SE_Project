using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class camera_movement : MonoBehaviour
{
    public Camera Camera;
    protected Plane Plane;
    public bool istapped;
    public string component_name;
    
    
    public string[] crop_Names = new string[4]; //s

    public int[] isFieldEmpty = {1,1,1,1}; //s
    public int[] isFieldReady = {0,0,0,0}; //s
    public GameObject[] checkMarks = new GameObject[4];
    public int[] ScheckMarks = new int[4]; //s

    public int[] isSecFieldEmpty = {1,1,1,1}; //s
    public int[] isSecFieldReady = {0,0,0,0}; //s
    public GameObject[] secCheckMarks = new GameObject[4];
    public int[] SsecCheckMarks = new int[4]; //s
    
    public int paddy_count = 0; //s
    public int sunflower_count = 0; //s
    public int corn_count = 0; //s
    public int pumpkin_count = 0; //s
    public int carrot_count = 0; //s

    public GameObject[] crop_menu;
    public bool isCropMenuOpen = false;

    public GameObject pumpkin_button;
    public bool isPumpkinButtonOpen = false;

    public GameObject carrot_button;
    public bool isCarrotButtonOpen = false;

    public GameObject[] paddy = new GameObject[4];
    public int[] Spaddy = new int[4]; //s
    public GameObject[] sunflowers = new GameObject[24];
    public int[] Ssunflowers = new int[24]; //s
    public GameObject[] corns = new GameObject[24];
    public int[] Scorns = new int[24]; //s
    public GameObject[] pumpkins = new GameObject[24];
    public int[] Spumpkins = new int[24]; //s
    public GameObject[] carrots = new GameObject[18];
    public int[] Scarrots = new int[18]; //s

    public int total_coins = 100000; //s
    public Text total_coins_display;
    public Text shop_coins_display;

    public int[] display_coin_count = {1000,200}; //s
    public GameObject[] coins = new GameObject[2];
    public GameObject[] display_coin_text = new GameObject[2];

    public GameObject shop;
    public GameObject[] items;
    public int[] items_status; //s
    public GameObject shopIsEmpty;
    public int cur_item = 0; //s
    public int[] item_prices = {7500,10000,500,750,800,930,1500}; //s

    public GameObject[] bakery_logos = new GameObject[2];

    private void Awake()
    {
        if (Camera == null)
            Camera = Camera.main;
    }

    public void OnApplicationQuit(){
        SaveSystem.SaveData(this);
    }

    public void Start(){
        SavingData data = SaveSystem.LoadData();

        if (data != null)
        {        
            crop_Names = data.crop_Names;
            isFieldEmpty = data.isFieldEmpty;
            isFieldReady = data.isFieldReady;
            ScheckMarks = data.ScheckMarks;
            isSecFieldEmpty = data.isSecFieldEmpty;
            isSecFieldReady = data.isSecFieldReady;
            SsecCheckMarks = data.SsecCheckMarks;
            paddy_count = data.paddy_count;
            sunflower_count = data.sunflower_count;
            corn_count = data.corn_count;
            pumpkin_count = data.pumpkin_count;
            carrot_count = data.carrot_count;
            Spaddy = data.Spaddy;
            Ssunflowers = data.Ssunflowers;
            Scorns = data.Scorns;
            Spumpkins = data.Spumpkins;
            Scarrots = data.Scarrots;
            total_coins = data.total_coins;
            items_status = data.items_status;
            cur_item = data.cur_item;
            item_prices = data.item_prices;
            display_coin_count = data.display_coin_count;

            for (int i=0; i<4; i++)
            {
                if(ScheckMarks[i] == 1)
                    checkMarks[i].SetActive(true);
            }
            for (int i=0; i<4; i++)
            {
                if(SsecCheckMarks[i] == 1)
                    secCheckMarks[i].SetActive(true);
            }
            for (int i=0; i<4; i++)
            {
                if(Spaddy[i] == 1)
                    paddy[i].SetActive(true);
            }
            for (int i=0; i<24; i++)
            {
                if(Ssunflowers[i] == 1)
                    sunflowers[i].SetActive(true);
            }
            for (int i=0; i<24; i++)
            {
                if(Scorns[i] == 1)
                    corns[i].SetActive(true);
            }
            for (int i=0; i<24; i++)
            {
                if(Spumpkins[i] == 1)
                    pumpkins[i].SetActive(true);
            }
            for (int i=0; i<18; i++)
            {
                if(Scarrots[i] == 1)
                    carrots[i].SetActive(true);
            }
        }
        total_coins_display.text = total_coins.ToString();
        shop_coins_display.text = total_coins.ToString();
    }

    private void on_field_tap(int field_no, string component_Name)
    {
        if (isFieldEmpty[field_no] == 1 && isCropMenuOpen == false)
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
        else if (isFieldReady[field_no] == 1)
        {
            isFieldEmpty[field_no] = 1;
            isFieldReady[field_no] = 0;
            checkMarks[field_no].SetActive(false);
            ScheckMarks[field_no] = 0;
            if (crop_Names[field_no] == "paddy")
            {
                paddy_count = paddy_count + 1;
                paddy[field_no].SetActive(false);
                Spaddy[field_no] = 0;
            }
            else if (crop_Names[field_no] == "sunflower")
            {
                sunflower_count = sunflower_count + 1;
                for (int i=field_no*6; i<(field_no+1)*6; i++)
                {
                    sunflowers[i].SetActive(false);
                    Ssunflowers[i] = 0;
                }
            }
            else
            {
                corn_count = corn_count + 1;
                for (int i=field_no*6; i<(field_no+1)*6; i++)
                {
                    corns[i].SetActive(false);
                    Scorns[i] = 0;
                }
            }
        }
    }

    private void on_sec_field_tap(int field_no, string component_Name)
    {
        if (field_no == 1 || field_no == 3)
        {
            if (isSecFieldEmpty[field_no] == 1 && isPumpkinButtonOpen == false)
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
            else if (isSecFieldReady[field_no] == 1)
            {
                isSecFieldEmpty[field_no] = 1;
                isSecFieldReady[field_no] = 0;
                secCheckMarks[field_no].SetActive(false);
                SsecCheckMarks[field_no] = 0;
                pumpkin_count = pumpkin_count + 1;
                if (field_no == 1)
                {
                    for (int i=0; i<12; i++)
                    {
                        pumpkins[i].SetActive(false);
                        Spumpkins[i] = 0;
                    }
                }
                else
                {
                    for (int i=12; i<24; i++)
                    {
                        pumpkins[i].SetActive(false);
                        Spumpkins[i] = 0;
                    }
                }
            }
        }
        else if (field_no == 0 || field_no == 2)
        {
            if (isSecFieldEmpty[field_no] == 1 && isPumpkinButtonOpen == false)
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
            else if (isSecFieldReady[field_no] == 1)
            {
                isSecFieldEmpty[field_no] = 1;
                isSecFieldReady[field_no] = 0;
                secCheckMarks[field_no].SetActive(false);
                SsecCheckMarks[field_no] = 0;
                carrot_count = carrot_count + 1;
                if (field_no == 0)
                {
                    for (int i=0; i<9; i++)
                    {
                        carrots[i].SetActive(false);
                        Scarrots[i] = 0;
                    }
                }
                else
                {
                    for (int i=9; i<18; i++)
                    {
                        carrots[i].SetActive(false);
                        Scarrots[i] = 0;
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
        bakery_logos[0].transform.Rotate(0,0,-25*Time.deltaTime);
        bakery_logos[1].transform.Rotate(0,-25*Time.deltaTime,0);


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
                            shop_coins_display.text = total_coins.ToString();
                        }
                        else if (hit.transform.name == "factory_1")
                        {
                            items[cur_item].SetActive(true);
                            shop.SetActive(true);
                            component_name = "factory_1";
                        }
                    }
                }
            }
                
        }

    }

    public void next_item(){
        if (cur_item != -1)
        {
            var temp = 0;
            items[cur_item].SetActive(false);
            for (int i=cur_item+1; i<items.Length; i++)
            {
                if (items_status[i] == 0)
                {
                    items[i].SetActive(true);
                    cur_item = i;
                    temp = 1;
                    break;
                }
            }
            if (temp == 0)
            {
                for (int i=0; i<cur_item+1; i++)
                {
                    if (items_status[i] == 0)
                    {
                        items[i].SetActive(true);
                        cur_item = i;
                        temp = 1;
                        break;
                    }
                }
            }
            if (temp == 0)
            {
                shopIsEmpty.SetActive(true);
                cur_item = -1;
            }
        }
    }

    public void previous_item(){
        if (cur_item != -1)
        {
            var temp = 0;
            items[cur_item].SetActive(false);
            for (int i=cur_item-1; i>-1; i--)
            {
                if (items_status[i] == 0)
                {
                    items[i].SetActive(true);
                    cur_item = i;
                    temp = 1;
                    break;
                }
            }
            if (temp == 0)
            {
                for (int i=items.Length - 1; i>cur_item-1; i--)
                {
                    if (items_status[i] == 0)
                    {
                        items[i].SetActive(true);
                        cur_item = i;
                        temp = 1;
                        break;
                    }
                }
            }
            if (temp == 0)
            {
                shopIsEmpty.SetActive(true);
                cur_item = -1;
            }
        }
    }

    public void purchase_item()
    {
        if (total_coins >= item_prices[cur_item])
        {
            total_coins = total_coins - item_prices[cur_item];
            total_coins_display.text = total_coins.ToString();
            shop_coins_display.text = total_coins.ToString();
            items_status[cur_item] = 1;
            next_item();
        }
    }

    public void close_shop(){
        shop.SetActive(false);
    }

    private void modify_crop(int field_no, string crop_name)
    {
        isFieldEmpty[field_no] = 0;
        isFieldReady[field_no] = 1;
        isCropMenuOpen = false;
        crop_Names[field_no] = crop_name;
        if (crop_name == "paddy")
        {
            paddy[field_no].SetActive(true);
            Spaddy[field_no] = 1;
        }
        else if (crop_name == "sunflower")
        {
            for (int i=field_no*6; i<(field_no+1)*6; i++)
            {
                sunflowers[i].SetActive(true);
                Ssunflowers[i] = 1;
            }
        }
        else
        {
            for (int i=field_no*6; i<(field_no+1)*6; i++)
            {
                corns[i].SetActive(true);
                Scorns[i] = 1;
            }
        }
        foreach (GameObject crop in crop_menu)
        {
            crop.SetActive(false);
        }
        checkMarks[field_no].SetActive(true);
        ScheckMarks[field_no] = 1;
    }

    private void modify_sec_crop(int field_no, string crop_name)
    {
        isSecFieldEmpty[field_no] = 0;
        isSecFieldReady[field_no] = 1;
        if (field_no == 0)
        {
            isCarrotButtonOpen = false;
            for (int i=0; i<9; i++)
            {
                carrots[i].SetActive(true);
                Scarrots[i] = 1;
            }
            carrot_button.SetActive(false);
        }
        else if (field_no == 1)
        {
            isPumpkinButtonOpen = false;
            for (int i=0; i<12; i++)
            {
                pumpkins[i].SetActive(true);
                Spumpkins[i] = 1;
            }
            pumpkin_button.SetActive(false);
        }
        else if (field_no == 2)
        {
            isCarrotButtonOpen = false;
            for (int i=9; i<18; i++)
            {
                carrots[i].SetActive(true);
                Scarrots[i] = 1;
            }
            carrot_button.SetActive(false);
        }
        else if (field_no == 3)
        {
            isPumpkinButtonOpen = false;
            for (int i=12; i<24; i++)
            {
                pumpkins[i].SetActive(true);
                Spumpkins[i] = 1;
            }
            pumpkin_button.SetActive(false);
        }
        secCheckMarks[field_no].SetActive(true);
        SsecCheckMarks[field_no] = 1;
    }

    public void add_crop(string crop_name)
    {
        Debug.Log(crop_name);
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