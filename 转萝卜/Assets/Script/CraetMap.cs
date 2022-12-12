/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public enum Type
{
    luobo,one,two,three
}
public class CraetMap : MonoBehaviour
{
    int[,] map = new int[,]
    {
        {1,1,1,1,1,1,1,1,1,1,1,1 },
        {1,0,0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0,0,1 },
        {1,1,1,1,1,1,1,1,1,1,1,1 }
    };
    IPlayer player=new IPlayer();
    List<GameObject> objects = new List<GameObject>();
    int lanfang = -1,hongfang=-1;
    int lanfang1 = -1,hongfang1=-1;
    int ran;
    GameObject flagitem;
    bool flag=false,butflag=true;
    public GameObject jifem;
    public Transform Path;
    public Button Luobo;
    public void SetPlay(IPlayer player)
    {
        this.player = player;
    }
    public void Init()
    {
       *//* player.Creat(Path);
        player.SetList(objects);*//*
    }
    // Start is called before the first frame update
    void Start()
    {
       *//* for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i,j]==1)
                {
                    GameObject item = Instantiate(Resources.Load<GameObject>("Item"), Path);
                    item.transform.localPosition = new Vector3(-585+(j*105), 326-(i*105), 0);
                    objects.Add(item);
                }
            }
        }*/
       /* Init();
        Luobo.onClick.AddListener(() =>
        {
            if (butflag==true)
            {
                int num = Random.Range(0, 4);
                if (num == 0)
                {
                    print("转动萝卜");
                }
                else if (num == 1)
                {
                    print("1");
                }
                else if (num == 2)
                {
                    print("2");
                }
                else if (num == 3)
                {
                    print("3");
                }
                Move(num);
                if (num!=0)
                {
                    butflag = false;
                }
            }
            
        });*//*
    }
    public void Move(int num)
    {
        if (num==0)
        {
            if (flagitem != null)
            {
                flagitem.GetComponent<Image>().color = Color.white;
            }
            ran = Random.Range(0, objects.Count);
            objects[ran].GetComponent<Image>().color = Color.black;
            flagitem = objects[ran];
            if (lanfang==ran)
            {
                SetPlay(new Player1());
                player.Triggertrap();
                lanfang = 0;
                lanfang1 = 0;
            }
            if (hongfang==ran)
            {
                SetPlay(new Player2());
                player.Triggertrap();
                hongfang = 0;
                hongfang1 = 0;
            }
        }
        else
        {
            if (flag)
            {
                lanfang1 += num;
                StartCoroutine(Movecount(lanfang1));
                
            }
            else
            {
                hongfang1 += num;
                StartCoroutine(Movecount(hongfang1));

            }
           
        }
        flag = !flag;
    }
    IEnumerator Movecount(int num)
    {
        yield return new WaitForSeconds(0.5f);
        if (flag==false)
        {
            lanfang++;
            SetPlay(new Player1());
            Init();
            player.Move(lanfang);
                
            if (lanfang == objects.Count-1)
            {
                jifem.SetActive(true);
                jifem.transform.GetChild(0).GetComponent<Text>().text = "蓝方胜利";
                lanfang = num;
            }
            if (lanfang != num)
                {
                    StartCoroutine(Movecount(num));
                }
                
                else
                {
                    if (lanfang == hongfang1)
                    {
                        lanfang1++;
                        StartCoroutine(Movecount(lanfang1));
                    }
                    if (lanfang == ran)
                    {
                        player.Triggertrap();
                        lanfang = 0;
                        lanfang1 = 0;
                    }
                    butflag = true;
                }
            
            
        }
        else
        {
            hongfang++;
            SetPlay(new Player2());
            Init();
            player.Move(hongfang); 
            if (hongfang == objects.Count-1)
            {
                jifem.SetActive(true);
                jifem.transform.GetChild(0).GetComponent<Text>().text = "红方胜利";
                hongfang = num;
            }
            if (hongfang != num)
                {
                    StartCoroutine(Movecount(num));
                }
                else
                {
                    if (lanfang1 == hongfang)
                    {
                        hongfang1++;
                        StartCoroutine(Movecount(hongfang1));
                    }
                    if (hongfang == ran)
                    {
                        player.Triggertrap();
                        hongfang = 0;
                        hongfang1 = 0;
                    }
                    butflag = true;
                }
            }
           

        
       
    }
}
*/