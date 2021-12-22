using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVEL_DATA_STORE : MonoBehaviour 
{
    public static List<string> inventoryItems = new List<string>();

    public static int coinBalance = 0;
    public static int lives = 5;

    //---Level1_1

    public static int Level1_1CoinBalance = 0;

    //---

    //---Level1_2

    public static int Level1_2CoinBalance = 0;

    //---

    //---Level1_3

    public static bool Level1_3Reload = false;

    public static bool Level1_3Coin1Taken = false;
    public static bool Level1_3Coin2Taken = false;
    public static bool Level1_3Coin3Taken = false;
    public static bool Level1_3Coin4Taken = false;

    public static int Level1_3CoinBalance = 0;

    public static Vector2 Level1_3CheckPointCoordinates = new Vector2();

    public static Vector3 Level1_3Crate1Pos = new Vector3(-6f, -3.5f, 0);

    public static Vector3 Level1_3PlayerPos = new Vector3(-2f, -3.5f, 0);

    public static Sprite Level1_3Barrel1Sprite = Resources.Load<Sprite>("Barrel1");
    public static Sprite Level1_3Barrel2Sprite = Resources.Load<Sprite>("Barrel1");

    public static Sprite Level1_3Chest1Sprite = Resources.Load<Sprite>("Chest_Closed");

    //---

    //---Level1_3_Cave
    
    public static bool Level1_3_CaveCoin1Taken = false;
    public static bool Level1_3_CaveKey1Taken = false;

    //---
}
