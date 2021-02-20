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
    
    public int[] items_count = {0,0,0,0,0,0,0,0,0,0,0,0,0,0}; //s  0-paddy 1-sunflower 2-corn 3-pumpkin 4-carrot 5-bread 6-cake 7-carrotjuice 8-baverage 9-halwa 10-pizza 11-popcorn 12-pimpkinpie 13-soup
    public Text[] items_Total_Count_text = new Text[28];

    public int[] items_display_count = {0,0,0,0,0,0,0,0,0}; //s
    public Text[] items_Count_text = new Text[9];

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

    public int total_coins = 0; //s
    public Text total_coins_display;
    public Text shop_coins_display;
    public Text market_coins_display;

    public int[] display_coin_count = {0,0}; //s
    public GameObject[] coins = new GameObject[2];
    public GameObject[] display_coin_text = new GameObject[2];

    public GameObject shop;
    public GameObject[] items;
    public int[] items_status; //s
    public GameObject shopIsEmpty;
    public int cur_item = 0; //s
    public int[] item_prices = {7500,10000}; //s

    public GameObject[] bakery_logos = new GameObject[2];
    public GameObject Bakery_HOT;
    public GameObject Bakery_Sweet;

    public float total_waste = 0f; //s
    public Text waste_display;

    public Material water_clean;
    public Material water_avg_clean;
    public Material water_dirty;
    public GameObject water;

    public GameObject Waste_Management;

    public GameObject Crop_Shop;
    public GameObject[] market_items = new GameObject[5];
    public int cur_crop_item = 0;
    public int[] market_prices = {70,190,100,210,260};

    public GameObject quit_menu;

    public GameObject user_quide;
    public GameObject[] pages;
    public int cur_page = 0;

    public bool[] isFieldTimerOn = {false,false,false,false};
    public float[] field_times = {0,0,0,0};
    public GameObject[] field_timer_count = new GameObject[4];

    public bool[] isSecFieldTimerOn = {false,false,false,false};
    public float[] secfield_times = {0,0,0,0};
    public GameObject[] secfield_timer_count = new GameObject[4];

    public float time_forCoins_1 = 0;
    public float time_forCoins_2 = 0;
    public float time_forBuildings = 0;
    public float time_forWaste = 0;

    public GameObject[] building_1 = new GameObject[9];
    public GameObject[] building_2 = new GameObject[9];
    public GameObject[] building_3 = new GameObject[9];
    public GameObject[] building_4 = new GameObject[9];
    public int[] no_on_building = {-1,-1,-1,-1};

    public GameObject[] waste_display_blocks;
    public float[] waste_values = {0.5f,1f};
    public bool[] is_waste_open;

    public int[] build_prices = {400,90,120,70,120,160,210,540,60};
    public int[] items_indexes = {10,5,6,7,8,9,11,12,13}; 

    public GameObject rain;
    public bool isSomethingOpen = false;

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

        user_quide.SetActive(true);
        pages[cur_page].SetActive(true);
        isSomethingOpen = true;

        if (data != null)
        {        
            crop_Names = data.crop_Names;
            isFieldEmpty = data.isFieldEmpty;
            isFieldReady = data.isFieldReady;
            ScheckMarks = data.ScheckMarks;
            isSecFieldEmpty = data.isSecFieldEmpty;
            isSecFieldReady = data.isSecFieldReady;
            SsecCheckMarks = data.SsecCheckMarks;
            items_count = data.items_count;
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
            total_waste = data.total_waste;

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
        market_coins_display.text = total_coins.ToString();
        waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
        for (int i=0; i<28; i++)
        {
            items_Total_Count_text[i].text = "x" + items_count[i%13].ToString();
        }
    }

    public void next_page(){
        pages[cur_page].SetActive(false);
        cur_page = cur_page + 1;
        pages[cur_page].SetActive(true);
    }

    public void close_user_guide(){
        pages[cur_page].SetActive(false);
        user_quide.SetActive(false);
        isSomethingOpen = false;
    }

    public void open_quit_menu(){
        quit_menu.SetActive(true);
        isSomethingOpen = true;
    }

    public void close_quit_menu(){
        quit_menu.SetActive(false);
        isSomethingOpen = false;
    }

    public void quit_game(){
        for(int i=0; i<4; i++)
        {
            if(isFieldTimerOn[i] == true)
            {
                
                field_times[i] = 0;
                isFieldTimerOn[i] = false;
                field_timer_count[i].SetActive(false);
                modify_crop(i,crop_Names[i]);
            }
        }

        for(int i=0; i<4; i++)
        {
            if(isSecFieldTimerOn[i] == true)
            {
                secfield_times[i] = 0;
                isSecFieldTimerOn[i] = false;
                secfield_timer_count[i].SetActive(false);
                modify_sec_crop(i);
            }
        }
        Application.Quit();
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
                items_count[0] = items_count[0] + 1;
                items_Total_Count_text[0].text = "x" + items_count[0].ToString();
                items_Total_Count_text[14].text = "x" + items_count[0].ToString();
                paddy[field_no].SetActive(false);
                Spaddy[field_no] = 0;
            }
            else if (crop_Names[field_no] == "sunflower")
            {
                items_count[1] = items_count[1] + 1;
                items_Total_Count_text[1].text = "x" + items_count[1].ToString();
                items_Total_Count_text[15].text = "x" + items_count[1].ToString();
                for (int i=field_no*6; i<(field_no+1)*6; i++)
                {
                    sunflowers[i].SetActive(false);
                    Ssunflowers[i] = 0;
                }
            }
            else
            {
                items_count[2] = items_count[2] + 1;
                items_Total_Count_text[2].text = "x" + items_count[2].ToString();
                items_Total_Count_text[16].text = "x" + items_count[2].ToString();
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
                items_count[3] = items_count[3] + 1;
                items_Total_Count_text[3].text = "x" + items_count[3].ToString();
                items_Total_Count_text[17].text = "x" + items_count[3].ToString();
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
                items_count[4] = items_count[4] + 1;
                items_Total_Count_text[4].text = "x" + items_count[4].ToString();
                items_Total_Count_text[18].text = "x" + items_count[4].ToString();
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

        time_forCoins_1 += Time.deltaTime;
        time_forCoins_2 += Time.deltaTime;

        if(time_forCoins_1 > 50)
        {
            display_coin_count[0] += 10;
            time_forCoins_1 = 0;
        }
        if(time_forCoins_2 > 180)
        {
            display_coin_count[1] += 100;
            time_forCoins_2 = 0;
        }

        time_forBuildings += Time.deltaTime;

        if(time_forBuildings > 60)
        {
            var temp = Random.Range(1,4);
            var temp1 = Random.Range(1,9);
            if(no_on_building[temp-1] == -1)
            {
                if(temp == 1)
                {
                    building_1[temp1-1].SetActive(true);
                    no_on_building[0] = temp1;
                }
                else if(temp == 2)
                {
                    building_2[temp1-1].SetActive(true);
                    no_on_building[1] = temp1;
                }
                else if(temp == 3)
                {
                    building_3[temp1-1].SetActive(true);
                    no_on_building[2] = temp1;
                }
                else if(temp == 4)
                {
                    building_4[temp1-1].SetActive(true);
                    no_on_building[3] = temp1;
                }
            }
            time_forBuildings = 0;
        }

        time_forWaste += Time.deltaTime;

        if(time_forWaste > 50)
        {
            time_forWaste = 0;
            var temp = Random.Range(1,2);
            if(is_waste_open[temp-1] == false)
            {
                waste_display_blocks[temp-1].SetActive(true);
                is_waste_open[temp-1] = true;
            }
        }

        for(int i=0; i<4; i++)
        {
            if(isFieldTimerOn[i] == true)
            {
                if(field_times[i] > 0)
                {
                    field_times[i] -= Time.deltaTime;
                    field_timer_count[i].SetActive(true);
                    TextMesh timer_count = field_timer_count[i].GetComponent<TextMesh>();
                    timer_count.text = ((int)field_times[i]).ToString() + "S";
                }
                else{
                    field_times[i] = 0;
                    isFieldTimerOn[i] = false;
                    field_timer_count[i].SetActive(false);
                    modify_crop(i,crop_Names[i]);
                }
            }
        }

        for(int i=0; i<4; i++)
        {
            if(isSecFieldTimerOn[i] == true)
            {
                if(secfield_times[i] > 0)
                {
                    secfield_times[i] -= Time.deltaTime;
                    secfield_timer_count[i].SetActive(true);
                    TextMesh timer_count = secfield_timer_count[i].GetComponent<TextMesh>();
                    timer_count.text = ((int)secfield_times[i]).ToString() + "S";
                }
                else{
                    secfield_times[i] = 0;
                    isSecFieldTimerOn[i] = false;
                    secfield_timer_count[i].SetActive(false);
                    modify_sec_crop(i);
                }
            }
        }

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

        if (total_waste > 8)
        {
            rain.SetActive(true);
            water.GetComponent<MeshRenderer> ().material = water_dirty;
        }
        else if(total_waste > 6)
        {
            rain.SetActive(false);
            water.GetComponent<MeshRenderer> ().material = water_avg_clean;
        }
        else
        {
            rain.SetActive(false);
            water.GetComponent<MeshRenderer> ().material = water_clean;
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
                
                if (new_cam_pos.x > -90 && new_cam_pos.x < 150 && new_cam_pos.z > -70 && new_cam_pos.z < -10 && isSomethingOpen == false)
                    Camera.transform.Translate(Delta1, Space.World);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (istapped == true && isSomethingOpen == false)
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
                            market_coins_display.text = total_coins.ToString();
                        }
                        else if (hit.transform.name == "factory_1")
                        {
                            if(cur_item != -1)
                            {
                                items[cur_item].SetActive(true);
                            }
                            else
                            {
                                shopIsEmpty.SetActive(true);
                            }
                            shop.SetActive(true);
                            isSomethingOpen = true;
                            component_name = "factory_1";
                        }
                        else if (hit.transform.name == "crop_shop")
                        {
                            market_items[cur_crop_item].SetActive(true);
                            Crop_Shop.SetActive(true);
                            isSomethingOpen = true;
                        }
                        else if (hit.transform.name == "Bakery_HOT")
                        {
                            Bakery_HOT.SetActive(true);
                            isSomethingOpen = true;
                        }
                        else if (hit.transform.name == "Bakery_Sweet")
                        {
                            Bakery_Sweet.SetActive(true);
                            isSomethingOpen = true;
                        }
                        else if (hit.transform.name == "Factory")
                        {
                            Waste_Management.SetActive(true);
                            isSomethingOpen = true;
                        }
                        else if (hit.transform.name == "building_1" || hit.transform.name == "building_2" || hit.transform.name == "building_3" || hit.transform.name == "building_4")
                        {
                            var temp = int.Parse(hit.transform.name.Substring(9,1));
                            if(no_on_building[temp - 1] != -1 && items_count[items_indexes[no_on_building[temp - 1] - 1]] > 0)
                            {
                                if(temp == 1)
                                {
                                    building_1[no_on_building[temp - 1] - 1].SetActive(false);
                                }
                                else if(temp == 2)
                                {
                                    building_2[no_on_building[temp - 1] - 1].SetActive(false);
                                }
                                else if(temp == 3)
                                {
                                    building_3[no_on_building[temp - 1] - 1].SetActive(false);
                                }
                                else
                                {
                                    building_4[no_on_building[temp - 1] - 1].SetActive(false);
                                }
                                items_count[items_indexes[no_on_building[temp - 1] - 1]] = items_count[items_indexes[no_on_building[temp - 1] - 1]] - 1;
                                items_Total_Count_text[items_indexes[no_on_building[temp - 1] - 1]].text = "x" + items_count[items_indexes[no_on_building[temp - 1] - 1]].ToString();
                                items_Total_Count_text[items_indexes[no_on_building[temp - 1] - 1] + 14].text = "x" + items_count[items_indexes[no_on_building[temp - 1] - 1]].ToString();
                                total_coins = total_coins + build_prices[no_on_building[temp - 1] - 1];
                                no_on_building[temp - 1] = -1;
                                total_coins_display.text = total_coins.ToString();
                                shop_coins_display.text = total_coins.ToString();
                                market_coins_display.text = total_coins.ToString();
                            }
                        }
                        else if (hit.transform.name == "waste_1" || hit.transform.name == "waste_2")
                        {
                            var temp = int.Parse(hit.transform.name.Substring(6,1)) - 1;
                            if(is_waste_open[temp] == true)
                            {
                                total_waste += (float)waste_values[temp];
                                waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
                                waste_display_blocks[temp].SetActive(false);
                                is_waste_open[temp] = false;
                            }
                        }
                    }
                }
            }
                
        }

    }

    public void close_Bakery_Hot(){
        Bakery_HOT.SetActive(false);
        isSomethingOpen = false;
    }

    public void close_Bakery_Sweet(){
        Bakery_Sweet.SetActive(false);
        isSomethingOpen = false;
    }

    public void manage_waste(string waste_amount)
    {
        float waste_value = float.Parse(waste_amount.Substring(0,2));
        int price = int.Parse(waste_amount.Substring(2,4));
        if (total_coins >= price)
        {
            total_coins = total_coins - price;
            total_coins_display.text = total_coins.ToString();
            shop_coins_display.text = total_coins.ToString();
            market_coins_display.text = total_coins.ToString();

            total_waste = total_waste - waste_value;
            if(total_waste < 0)
            {
                total_waste = 0f;
            }
            waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
        }
    }

    public void close_waste_management(){
        Waste_Management.SetActive(false);
        isSomethingOpen = false;
    }

    public void add_display_count(string item_name)
    {
        if (item_name == "bread")
        {
            if(items_count[0] >= (items_display_count[0] + 1)*10)
            {
                items_display_count[0] = items_display_count[0] + 1;
                items_Count_text[0].text = items_display_count[0].ToString();
            }
        }
        else if (item_name == "cake")
        {
            if(items_count[0] >= (items_display_count[1] + 1)*3 && items_count[4] >= (items_display_count[1] + 1)*2)
            {
                items_display_count[1] = items_display_count[1] + 1;
                items_Count_text[1].text = items_display_count[1].ToString();
            }
        }
        else if (item_name == "carrotJuice")
        {
            if(items_count[4] >= (items_display_count[2] + 1)*5)
            {
                items_display_count[2] = items_display_count[2] + 1;
                items_Count_text[2].text = items_display_count[2].ToString();
            }
        }
        else if (item_name == "baverage")
        {
            if(items_count[4] >= (items_display_count[3] + 1)*2 && items_count[3] >= (items_display_count[3] + 1)*3)
            {
                items_display_count[3] = items_display_count[3] + 1;
                items_Count_text[3].text = items_display_count[3].ToString();
            }
        }
        else if (item_name == "halwa")
        {
            if(items_count[4] >= (items_display_count[4] + 1)*6 && items_count[1] >= (items_display_count[4] + 1))
            {
                items_display_count[4] = items_display_count[4] + 1;
                items_Count_text[4].text = items_display_count[4].ToString();
            }
        }
        else if (item_name == "pizza")
        {
            if(items_count[0] >= (items_display_count[5] + 1)*4 && items_count[1] >= (items_display_count[5] + 1)*2 && items_count[2] >= (items_display_count[5] + 1)*2 && items_count[4] >= (items_display_count[5] + 1)*4)
            {
                items_display_count[5] = items_display_count[5] + 1;
                items_Count_text[5].text = items_display_count[5].ToString();
            }
        }
        else if (item_name == "popcorn")
        {
            if(items_count[1] >= (items_display_count[6] + 1) && items_count[2] >= (items_display_count[6] + 1)*3)
            {
                items_display_count[6] = items_display_count[6] + 1;
                items_Count_text[6].text = items_display_count[6].ToString();
            }
        }
        else if (item_name == "pumpkinpie")
        {
            if(items_count[0] >= (items_display_count[7] + 1)*2 && items_count[1] >= (items_display_count[7] + 1) && items_count[3] >= (items_display_count[7] + 1)*3)
            {
                items_display_count[7] = items_display_count[7] + 1;
                items_Count_text[7].text = items_display_count[7].ToString();
            }
        }
        else if (item_name == "soup")
        {
            if(items_count[2] >= (items_display_count[8] + 1)*2 && items_count[4] >= (items_display_count[8] + 1)*3)
            {
                items_display_count[8] = items_display_count[8] + 1;
                items_Count_text[8].text = items_display_count[8].ToString();
            }
        }
    }

    public void decrease_display_count(int item_index)
    {
        if(items_display_count[item_index] > 0)
        {
            items_display_count[item_index] = items_display_count[item_index] - 1;
            items_Count_text[item_index].text = items_display_count[item_index].ToString();
        }
    }

    public void bake_item(string item_name)
    {
        if (item_name == "bread")
        {
            if(items_count[0] >= (items_display_count[0])*10 && (total_waste + (float)(0.3)*items_display_count[0]) < 10)
            {
                items_count[0] = items_count[0] - (items_display_count[0])*10;
                items_Total_Count_text[0].text = "x" + items_count[0].ToString();
                items_Total_Count_text[14].text = "x" + items_count[0].ToString();
                items_count[5] = items_count[5] + items_display_count[0];
                items_Total_Count_text[5].text = "x" + items_count[5].ToString();
                items_Total_Count_text[19].text = "x" + items_count[5].ToString();
                total_waste = total_waste + (float)(0.3)*items_display_count[0];
                waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
                items_display_count[0] = 0;
                items_Count_text[0].text = items_display_count[0].ToString();
            }
        }
        else if (item_name == "cake")
        {
            if(items_count[0] >= (items_display_count[1])*3 && items_count[4] >= (items_display_count[1])*2 && (total_waste + (float)(0.8)*items_display_count[1]) < 10)
            {
                items_count[0] = items_count[0] - (items_display_count[1])*3;
                items_Total_Count_text[0].text = "x" + items_count[0].ToString();
                items_Total_Count_text[14].text = "x" + items_count[0].ToString();
                items_count[4] = items_count[4] - (items_display_count[1])*2;
                items_Total_Count_text[4].text = "x" + items_count[4].ToString();
                items_Total_Count_text[18].text = "x" + items_count[4].ToString();
                items_count[6] = items_count[6] + items_display_count[1];
                items_Total_Count_text[6].text = "x" + items_count[6].ToString();
                items_Total_Count_text[20].text = "x" + items_count[6].ToString();
                total_waste = total_waste + (float)(0.8)*items_display_count[1];
                waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
                items_display_count[1] = 0;
                items_Count_text[1].text = items_display_count[1].ToString();
            }
        }
        else if (item_name == "carrotJuice")
        {
            if(items_count[4] >= (items_display_count[2])*5 && (total_waste + (float)(0.12)*items_display_count[2]) < 10)
            {
                items_count[4] = items_count[4] - (items_display_count[2])*5;
                items_Total_Count_text[4].text = "x" + items_count[4].ToString();
                items_Total_Count_text[18].text = "x" + items_count[4].ToString();
                items_count[7] = items_count[7] + items_display_count[2];
                items_Total_Count_text[7].text = "x" + items_count[7].ToString();
                items_Total_Count_text[21].text = "x" + items_count[7].ToString();
                total_waste = total_waste + (float)(0.12)*items_display_count[2];
                waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
                items_display_count[2] = 0;
                items_Count_text[2].text = items_display_count[2].ToString();
                
            }
        }
        else if (item_name == "baverage")
        {
            if(items_count[4] >= (items_display_count[3])*2 && items_count[3] >= (items_display_count[3])*3 && (total_waste + (float)(0.21)*items_display_count[3]) < 10)
            {
                items_count[4] = items_count[4] - (items_display_count[3])*2;
                items_Total_Count_text[4].text = "x" + items_count[4].ToString();
                items_Total_Count_text[18].text = "x" + items_count[4].ToString();
                items_count[3] = items_count[3] - (items_display_count[3])*3;
                items_Total_Count_text[3].text = "x" + items_count[3].ToString();
                items_Total_Count_text[17].text = "x" + items_count[3].ToString();
                items_count[8] = items_count[8] + items_display_count[3];
                items_Total_Count_text[8].text = "x" + items_count[8].ToString();
                items_Total_Count_text[22].text = "x" + items_count[8].ToString();
                total_waste = total_waste + (float)(0.21)*items_display_count[3];
                waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
                items_display_count[3] = 0;
                items_Count_text[3].text = items_display_count[3].ToString();
                
            }
        }
        else if (item_name == "halwa")
        {
            if(items_count[4] >= (items_display_count[4])*6 && items_count[1] >= (items_display_count[4]) && (total_waste + (float)(0.6)*items_display_count[4]) < 10)
            {
                items_count[4] = items_count[4] - (items_display_count[4])*6;
                items_Total_Count_text[4].text = "x" + items_count[4].ToString();
                items_Total_Count_text[18].text = "x" + items_count[4].ToString();
                items_count[1] = items_count[1] - (items_display_count[4]);
                items_Total_Count_text[1].text = "x" + items_count[1].ToString();
                items_Total_Count_text[15].text = "x" + items_count[1].ToString();
                items_count[9] = items_count[9] + items_display_count[4];
                items_Total_Count_text[9].text = "x" + items_count[9].ToString();
                items_Total_Count_text[23].text = "x" + items_count[9].ToString();
                total_waste = total_waste + (float)(0.6)*items_display_count[4];
                waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
                items_display_count[4] = 0;
                items_Count_text[4].text = items_display_count[4].ToString();
                
            }
        }
        else if (item_name == "pizza")
        {
            if(items_count[0] >= (items_display_count[5])*4 && items_count[1] >= (items_display_count[5])*2 && items_count[2] >= (items_display_count[5])*2 && items_count[4] >= (items_display_count[5])*4 && (total_waste + (float)items_display_count[5]) < 10)
            {
                items_count[0] = items_count[0] - (items_display_count[5])*4;
                items_Total_Count_text[0].text = "x" + items_count[0].ToString();
                items_Total_Count_text[14].text = "x" + items_count[0].ToString();
                items_count[1] = items_count[1] - (items_display_count[5])*2;
                items_Total_Count_text[1].text = "x" + items_count[1].ToString();
                items_Total_Count_text[15].text = "x" + items_count[1].ToString();
                items_count[2] = items_count[2] - (items_display_count[5])*2;
                items_Total_Count_text[2].text = "x" + items_count[2].ToString();
                items_Total_Count_text[16].text = "x" + items_count[2].ToString();
                items_count[4] = items_count[4] - (items_display_count[5])*4;
                items_Total_Count_text[4].text = "x" + items_count[4].ToString();
                items_Total_Count_text[18].text = "x" + items_count[4].ToString();
                items_count[10] = items_count[10] + items_display_count[5];
                items_Total_Count_text[10].text = "x" + items_count[10].ToString();
                items_Total_Count_text[24].text = "x" + items_count[10].ToString();
                total_waste = total_waste + (float)items_display_count[5];
                waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
                items_display_count[5] = 0;
                items_Count_text[5].text = items_display_count[5].ToString();
                
            }
        }
        else if (item_name == "popcorn")
        {
            if(items_count[1] >= (items_display_count[6]) && items_count[2] >= (items_display_count[6])*3 && (total_waste + (float)(0.02)*items_display_count[6]) < 10)
            {
                items_count[1] = items_count[1] - (items_display_count[6]);
                items_Total_Count_text[1].text = "x" + items_count[1].ToString();
                items_Total_Count_text[15].text = "x" + items_count[1].ToString();
                items_count[2] = items_count[2] - (items_display_count[6])*3;
                items_Total_Count_text[2].text = "x" + items_count[2].ToString();
                items_Total_Count_text[16].text = "x" + items_count[2].ToString();
                items_count[11] = items_count[11] + items_display_count[6];
                items_Total_Count_text[11].text = "x" + items_count[11].ToString();
                items_Total_Count_text[25].text = "x" + items_count[11].ToString();
                total_waste = total_waste + (float)(0.02)*items_display_count[6];
                waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
                items_display_count[6] = 0;
                items_Count_text[6].text = items_display_count[6].ToString();
                
            }
        }
        else if (item_name == "pumpkinpie")
        {
            if(items_count[0] >= (items_display_count[7])*2 && items_count[1] >= (items_display_count[7]) && items_count[3] >= (items_display_count[7])*3 && (total_waste + (float)(1.2)*items_display_count[7]) < 10)
            {
                items_count[0] = items_count[0] - (items_display_count[7])*2;
                items_Total_Count_text[0].text = "x" + items_count[0].ToString();
                items_Total_Count_text[14].text = "x" + items_count[0].ToString();
                items_count[1] = items_count[1] - (items_display_count[7]);
                items_Total_Count_text[1].text = "x" + items_count[1].ToString();
                items_Total_Count_text[15].text = "x" + items_count[1].ToString();
                items_count[3] = items_count[3] - (items_display_count[7])*3;
                items_Total_Count_text[3].text = "x" + items_count[3].ToString();
                items_Total_Count_text[17].text = "x" + items_count[3].ToString();
                items_count[12] = items_count[12] + items_display_count[7];
                items_Total_Count_text[12].text = "x" + items_count[12].ToString();
                items_Total_Count_text[26].text = "x" + items_count[12].ToString();
                total_waste = total_waste + (float)(1.2)*items_display_count[7];
                waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
                items_display_count[7] = 0;
                items_Count_text[7].text = items_display_count[7].ToString();
                
            }
        }
        else if (item_name == "soup")
        {
            if(items_count[2] >= (items_display_count[8])*2 && items_count[4] >= (items_display_count[8])*3 && (total_waste + (float)(0.15)*items_display_count[8]) < 10)
            {
                items_count[2] = items_count[2] - (items_display_count[8])*2;
                items_Total_Count_text[2].text = "x" + items_count[2].ToString();
                items_Total_Count_text[16].text = "x" + items_count[2].ToString();
                items_count[4] = items_count[4] - (items_display_count[8])*3;
                items_Total_Count_text[4].text = "x" + items_count[4].ToString();
                items_Total_Count_text[18].text = "x" + items_count[4].ToString();
                items_count[13] = items_count[13] + items_display_count[8];
                items_Total_Count_text[13].text = "x" + items_count[13].ToString();
                items_Total_Count_text[27].text = "x" + items_count[13].ToString();
                total_waste = total_waste + (float)(0.15)*items_display_count[8];
                waste_display.text = ((int)(((float)total_waste/10)*100)).ToString() + "%";
                items_display_count[8] = 0;
                items_Count_text[8].text = items_display_count[8].ToString();
                
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

    public void market_next_item(){
        market_items[cur_crop_item].SetActive(false);
        if(cur_crop_item == 4)
        {
            cur_crop_item = -1;
        }
        cur_crop_item = cur_crop_item + 1;
        market_items[cur_crop_item].SetActive(true);
    }

    public void market_previous_item(){
        market_items[cur_crop_item].SetActive(false);
        if(cur_crop_item == 0)
        {
            cur_crop_item = 5;
        }
        cur_crop_item = cur_crop_item - 1;
        market_items[cur_crop_item].SetActive(true);
    }

    public void purchase_market_item(){
        if(total_coins >= market_prices[cur_crop_item])
        {
            total_coins = total_coins - market_prices[cur_crop_item];
            total_coins_display.text = total_coins.ToString();
            shop_coins_display.text = total_coins.ToString();
            market_coins_display.text = total_coins.ToString();
            items_count[cur_crop_item] = items_count[cur_crop_item] + 1;
            items_Total_Count_text[cur_crop_item].text = "x" + items_count[cur_crop_item].ToString();
            items_Total_Count_text[cur_crop_item+14].text = "x" + items_count[cur_crop_item].ToString();
        }
    }

    public void close_market(){
        Crop_Shop.SetActive(false);
        isSomethingOpen = false;
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
            market_coins_display.text = total_coins.ToString();
            items_status[cur_item] = 1;
            next_item();
        }
    }

    public void close_shop(){
        shop.SetActive(false);
        isSomethingOpen = false;
    }

    public void start_timer(int field_no, string crop_name){
        if(crop_name == "paddy")
        {
            isFieldTimerOn[field_no] = true;
            field_times[field_no] = 11;
            isFieldEmpty[field_no] = 0;
        }
        else if(crop_name == "sunflower")
        {
            isFieldTimerOn[field_no] = true;
            field_times[field_no] = 21;
            isFieldEmpty[field_no] = 0;
        }
        else if(crop_name == "corn"){
            isFieldTimerOn[field_no] = true;
            field_times[field_no] = 16;
            isFieldEmpty[field_no] = 0;
        }
        else if(crop_name == "pumpkin"){
            isSecFieldTimerOn[field_no] = true;
            secfield_times[field_no] = 21;
            isSecFieldEmpty[field_no] = 0;
        }
        else if(crop_name == "carrot"){
            isSecFieldTimerOn[field_no] = true;
            secfield_times[field_no] = 26;
            isSecFieldEmpty[field_no] = 0;
        }
    }

    private void modify_crop(int field_no, string crop_name)
    {
        isFieldReady[field_no] = 1;
        
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
        checkMarks[field_no].SetActive(true);
        ScheckMarks[field_no] = 1;
    }

    private void modify_sec_crop(int field_no)
    {
        isSecFieldReady[field_no] = 1;
        if (field_no == 0)
        {
            for (int i=0; i<9; i++)
            {
                carrots[i].SetActive(true);
                Scarrots[i] = 1;
            }
        }
        else if (field_no == 1)
        {
            for (int i=0; i<12; i++)
            {
                pumpkins[i].SetActive(true);
                Spumpkins[i] = 1;
            }
        }
        else if (field_no == 2)
        {
            for (int i=9; i<18; i++)
            {
                carrots[i].SetActive(true);
                Scarrots[i] = 1;
            }
        }
        else if (field_no == 3)
        {
            for (int i=12; i<24; i++)
            {
                pumpkins[i].SetActive(true);
                Spumpkins[i] = 1;
            }
        }
        secCheckMarks[field_no].SetActive(true);
        SsecCheckMarks[field_no] = 1;
    }

    public void add_crop(string crop_name)
    {
        if (component_name == "field_13")
        {
            crop_Names[0] = crop_name;
            isCropMenuOpen = false;
            foreach (GameObject crop in crop_menu)
            {
                crop.SetActive(false);
            }
            start_timer(0,crop_name);
        }
        else if (component_name == "field_14")
        {
            crop_Names[1] = crop_name;
            isCropMenuOpen = false;
            foreach (GameObject crop in crop_menu)
            {
                crop.SetActive(false);
            }
            start_timer(1,crop_name);
        }
        else if (component_name == "field_23")
        {
            crop_Names[2] = crop_name;
            isCropMenuOpen = false;
            foreach (GameObject crop in crop_menu)
            {
                crop.SetActive(false);
            }
            start_timer(2,crop_name);
        }
        else if (component_name == "field_24")
        {
            crop_Names[3] = crop_name;
            isCropMenuOpen = false;
            foreach (GameObject crop in crop_menu)
            {
                crop.SetActive(false);
            }
            start_timer(3,crop_name);
        }
        else if (component_name == "field_11")
        {
            isCarrotButtonOpen = false;
            carrot_button.SetActive(false);
            start_timer(0,crop_name);
        }
        else if (component_name == "field_12")
        {
            isPumpkinButtonOpen = false;
            pumpkin_button.SetActive(false);
            start_timer(1,crop_name);
        }
        else if (component_name == "field_21")
        {
            isCarrotButtonOpen = false;
            carrot_button.SetActive(false);
            start_timer(2,crop_name);
        }
        else if (component_name == "field_22")
        {
            isPumpkinButtonOpen = false;
            pumpkin_button.SetActive(false);
            start_timer(3,crop_name);
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