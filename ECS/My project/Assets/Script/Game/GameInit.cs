using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public enum MonsterType
{
    Player,
    NPC,
    Enemy,
    gather
}
public class GameInit : MonoBehaviour
{
    static PlayUse use = new PlayUse();
    public GameObject[] m_buttonlist;
    List<Dateinfo> m_date=new List<Dateinfo>();
    List<object_info> lm_ist = new List<object_info>();
    public static List<ObjectBase> m_objects = new List<ObjectBase>();
    // Start is called before the first frame update
    private void Awake()
    {
        /*m_datelist.Add(new Dateinfo("1", 0, 0, 0, "222", MonsterType.Player));
        File.WriteAllText("2.json", JsonConvert.SerializeObject(m_datelist));*/
        string str = File.ReadAllText("Assets/Script/Date/Date.json");
        m_date= JsonConvert.DeserializeObject<List<Dateinfo>>(str);
        if (File.Exists("Assets/Script/Date/play.json"))
        {
            use = JsonConvert.DeserializeObject<PlayUse>(File.ReadAllText("Assets/Script/Date/play.json"));
        }

    }
    public static void SetDate()
    {
        if (File.Exists("Assets/Script/Date/play.json"))
        {
            use = JsonConvert.DeserializeObject<PlayUse>(File.ReadAllText("Assets/Script/Date/play.json"));
        }
    }
    void Start()
    {

        
        for (int i = 0; i < m_date.Count; i++)
        {
            object_info info = new object_info();
            info.ID = i;
            info.name = m_date[i].name;
            info.Path = m_date[i].path;
            info.vector3 = new Vector3(m_date[i].x, m_date[i].y, m_date[i].z);
            info.m_type = m_date[i].type;
            lm_ist.Add(info);
        }
        for (int i = 0; i < m_buttonlist.Length; i++)
        {
            int j = i;
            m_buttonlist[j].GetComponent<Button>().onClick.AddListener(() =>
            {
                Gameobj(lm_ist[j]);
            });
        }

        Gatherinfo enemyinfo = new Gatherinfo();
        enemyinfo.name = m_date[3].name;
        enemyinfo.vector3 = new Vector3(0, 0.5f, 10);
        enemyinfo.Path = "Assets/Resources/gather.prefab";
        enemyinfo.ID = 1001;
        GatherObj gather = new GatherObj(enemyinfo);
        gather.CreatObj();
        m_objects.Add(gather);
    }
    private void Gameobj(object_info info)
    {
        ObjectBase obj = null;
        if (info.m_type == MonsterType.Player)
        {
            
            Playerinfo playerinfo = new Playerinfo();
            playerinfo.name = use.m_name;
            playerinfo.m_HP = 100;
            playerinfo.vector3=info.vector3;
            playerinfo.m_type = info.m_type;
            playerinfo.Path = use.m_path;
            playerinfo.ID=info.ID;
            playerinfo.m_hpMax = 500;
            playerinfo.m_MP = 100;
            playerinfo.m_mpMax = 300;

            obj = new MyPlayer(playerinfo);
        }
        else if (info.m_type == MonsterType.NPC)
        {
            NPCinfo npcinfo = new NPCinfo();
            npcinfo.name = info.name;
            npcinfo.vector3 = info.vector3;
            npcinfo.m_type = info.m_type;
            npcinfo.Path = info.Path;
            npcinfo.ID = info.ID;
            npcinfo.m_plotId= info.ID;
            obj = new NPCObj(npcinfo);
        }
        else if (info.m_type == MonsterType.Enemy)
        {
            Enemyinfo enemyinfo = new Enemyinfo();
            enemyinfo.name = info.name;
            enemyinfo.m_HP = 100;
            enemyinfo.vector3 = info.vector3;
            enemyinfo.m_type = info.m_type;
            enemyinfo.Path = info.Path;
            enemyinfo.ID = info.ID;
            enemyinfo.m_MP = 100;
            obj = new EnemyObj(enemyinfo);
        }
        
        obj.CreatObj();
        m_objects.Add(obj);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
