using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dateinfo 
{
    public string name;
    public float x;
    public float y;
    public float z;
    public string path;
    public MonsterType type;

    public Dateinfo(string name, float x, float y, float z, string path, MonsterType type)
    {
        this.name = name;
        this.x = x;
        this.y = y;
        this.z = z;
        this.path = path;
        this.type = type;
    }
}
