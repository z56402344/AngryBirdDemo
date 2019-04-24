using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Bird> birds;
    public List<Pig> pigs;
    public static GameManager _Instance;
    private Vector3 curPos;

    public void Awake()
    {
        _Instance = this;
        if (birds.Count > 0)
        {
            curPos = birds[0].transform.position;
        }
    }

    public void Init()
    {
        birds[0].transform.position = curPos;
        for (int i = 0; i < birds.Count;i++)
        {

            if (i == 0)
            {
                //第一只鸟
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                //其他鸟
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }

    public void NextBird()
    {
        //1.先判断猪的数量，大于0情况中，；
        if (pigs.Count > 0)
        {
            if (birds.Count > 0)
            {
                //鸟大于0，继续下一只鸟；
                Init();
            }
            else
            {
               //鸟小于0，输

            }
        }
        else
        {
            //猪小于0，胜利

        }
    }

   
}
