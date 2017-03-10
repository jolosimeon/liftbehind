using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStats {

    private static int survToSave = 15;
    private static int survSaved = 0;
    private static int floors = 20;
    private static int currFloor = 0;

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


}
