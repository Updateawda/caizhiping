using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    GameObject prefab;
    public string Name;
    public float HP;
    public float MP;
    float hpflag;
    float mpflag;
    // Start is called before the first frame update
    void Start()
    {
        hpflag = HP;
        mpflag = MP;
        prefab = Instantiate(Resources.Load<GameObject>("HP"), GameObject.Find("Canvas").transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (prefab!=null)
        {
            prefab.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position + Vector3.up*2);
            prefab.transform.GetChild(1).GetComponent<Text>().text=HP+"/"+hpflag;
            prefab.transform.GetChild(2).GetComponent<Text>().text=Name;

        }
        
    }
    public void SetDate(string name, float hP, float mP)
    {
        Name = name;
        HP = hP;
        MP = mP;
    }
}
