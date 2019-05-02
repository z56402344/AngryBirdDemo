using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string TOTAL = "total";

    public List<Bird> birds;
    public List<Pig> pigs;
    public static GameManager _Instance;
    private Vector3 curPos;

    public GameObject win;
    public GameObject lose;
    public GameObject[] starts;
    private int startNum = 0;
    public int levelNum = 10;

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
                lose.SetActive(true);
            }
        }
        else
        {
            //猪小于0，胜利
            win.SetActive(true);
        }
    }

    //展示星星逻辑
    public void ShowStart()
    {
        StartCoroutine("show");
    }

    //协程
    IEnumerator show()
    {
        for (; startNum < birds.Count+1; startNum++)
        {
            yield return new WaitForSeconds(0.2f);
            starts[startNum].SetActive(true);
        }
         
    }

    //重新开始
    public void Retry()
    {
        print("GameManager ---> Retry()");
        lose.SetActive(false);
        win.SetActive(false);
        SaveData();
        SceneManager.LoadScene(2);
    }

    //回主界面
    public void GoHome()
    {
        SaveData();
        SceneManager.LoadScene(1);
    }


    public void SaveData()
    {
        print("GameManager ---> startNu="+ startNum);
        int startCount = PlayerPrefs.GetInt(LevelSelect.LEVEL + gameObject.name);
        if(startNum > startCount)
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString(LevelSelect.NOW_LEVEL), startNum);

            int sum = 0;
            for (int i = 0; i < levelNum; i++)
            {
                sum += PlayerPrefs.GetInt(LevelSelect.LEVEL + i.ToString());
            }
            PlayerPrefs.SetInt(TOTAL, sum);
            print("GameManager ---> Sum=" + sum);
        }

    }

}
