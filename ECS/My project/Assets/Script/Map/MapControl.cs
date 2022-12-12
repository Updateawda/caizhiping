using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapControl : MonoBehaviour
{
    List<ObjectBase> list = new List<ObjectBase>();
    public static List<GameObject> maplist = new List<GameObject>();
    Vector3 vector3;
    float width;
    float height;
    float x;
    float y;
    float xratio;
    float yratio;
    public GameObject plane;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        width = plane.GetComponent<MeshFilter>().mesh.bounds.size.x*plane.transform.lossyScale.x;
        height = plane.GetComponent<MeshFilter>().mesh.bounds.size.z * plane.transform.lossyScale.z;
        x=GetComponent<RectTransform>().sizeDelta.x;
        y=GetComponent<RectTransform>().sizeDelta.y;
        xratio= x/width; 
        yratio= y/height;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (list.Count!= GameInit.m_objects.Count)
        {
            list.Clear();
            for (int i = 0; i < maplist.Count; i++)
            {
                Destroy(maplist[i].gameObject);
            }
            maplist.Clear();
            foreach (var item in GameInit.m_objects)
            {
                list.Add(item);
                GameObject map = Instantiate(Resources.Load<GameObject>("maoflag"), transform);
                if (item is MyPlayer)
                {
                    map.GetComponent<Image>().color = Color.green;

                }
                else if (item is NPCObj)
                {
                    map.GetComponent<Image>().color = Color.yellow;
                }
                else if (item is EnemyObj)
                {
                    map.GetComponent<Image>().color = Color.red;
                }
                else if (item is GatherObj)
                {
                    map.GetComponent<Image>().color = Color.blue;
                }
                maplist.Add(map);
            }
        }
        for (int i = 0; i < maplist.Count; i++)
        {
            maplist[i].transform.localPosition = new Vector3(GameInit.m_objects[i].m_go.transform.position.x * xratio, GameInit.m_objects[i].m_go.transform.position.z * yratio,0);
            maplist[i].transform.eulerAngles = new Vector3(0, 0, -GameInit.m_objects[i].m_go.transform.eulerAngles.y);
        }
    }
}
