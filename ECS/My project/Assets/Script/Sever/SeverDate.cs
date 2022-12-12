using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class Task
{
    public string name;
    public string des;
    public bool propress;
}
public class SeverDate : SingleTon<SeverDate>
{
    public List<Task> tasks=new List<Task>();
    public List<Task> Init()
    {
        tasks = JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText("Assets/Script/Date/Task.json"));
        return tasks;
    }
}
