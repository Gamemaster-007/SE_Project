using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavingData
{
    public string[] crop_Names; //s
    public int[] isFieldEmpty; //s
    public int[] isFieldReady; //s
    public int[] ScheckMarks; //s
    public int[] isSecFieldEmpty; //s
    public int[] isSecFieldReady; //s
    public int[] SsecCheckMarks; //s
    public int paddy_count; //s
    public int sunflower_count; //s
    public int corn_count; //s
    public int pumpkin_count; //s
    public int carrot_count; //s
    public int[] Spaddy; //s
    public int[] Ssunflowers; //s
    public int[] Scorns; //s
    public int[] Spumpkins; //s
    public int[] Scarrots; //s
    public int total_coins; //s
    public int[] items_status; //s
    public int cur_item; //s
    public int[] item_prices; //s
    public int[] display_coin_count;
    public int[] items_count;

    public SavingData (camera_movement info)
    {
        crop_Names = info.crop_Names;
        isFieldEmpty = info.isFieldEmpty;
        isFieldReady = info.isFieldReady;
        ScheckMarks = info.ScheckMarks;
        isSecFieldEmpty = info.isSecFieldEmpty;
        isSecFieldReady = info.isSecFieldReady;
        SsecCheckMarks = info.SsecCheckMarks;
        Spaddy = info.Spaddy;
        Ssunflowers = info.Ssunflowers;
        Scorns = info.Scorns;
        Spumpkins = info.Spumpkins;
        Scarrots = info.Scarrots;
        total_coins = info.total_coins;
        items_status = info.items_status;
        cur_item = info.cur_item;
        item_prices = info.item_prices;
        display_coin_count = info.display_coin_count;
        items_count = info.items_count;
    }
}
