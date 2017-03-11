using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStats {

    private static int survToSave = 15;
    private static int survSaved = 0;
    private static int floors = 20;
    private static int currFloor = 1;
    private static int score = 0;
    private static bool goingUp = false;
    private static float hp = 100;
    private static float maxHp = 100;


    public static int SurvToSave
    {
        get
        {
            return survToSave;
        }
        set
        {
            survToSave = value;
        }
    }

    public static int SurvSaved
    {
        get
        {
            return survSaved;
        }
        set
        {
            survSaved = value;
        }
    }

    public static int Floors
    {
        get
        {
            return floors;
        }
        set
        {
            floors = value;
        }
    }

    public static int CurrFloor
    {
        get
        {
            return currFloor;
        }
        set
        {
            currFloor = value;
        }
    }

    public static bool GoingUp
    {
        get
        {
            return goingUp;
        }
        set
        {
            goingUp = value;
        }
    }

    public static float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    public static float MaxHp
    {
        get
        {
            return maxHp;
        }
        set
        {
            maxHp = value;
        }
    }


}
