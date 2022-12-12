using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo 
{
    private static MapInfo _instance;
    public static MapInfo Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = new MapInfo();
                return _instance;
            }
            return null;
        }
    }
    public int[,] map = new int[,]
    {
        {1,1,1,1,1,1,1,1,1,1,1,1 },
        {1,0,0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0,0,1 },
        {1,1,1,1,1,1,1,1,1,1,1,1 }
    };
}
