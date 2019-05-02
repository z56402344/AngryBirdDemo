using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public static string LEVEL = "level";
    public static string NOW_LEVEL = "nowLevel";

    public bool isSelect = false;
    public Sprite levelBG;
    private Image image;


    public GameObject Map;
    public GameObject Panel;
    public GameObject[] starts;

    public void Awake()
    {
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent.GetChild(0).name == gameObject.name)
        {
            isSelect = true;

        }
        else
        {
            int preLevel = int.Parse(gameObject.name)-1;
            if (PlayerPrefs.GetInt(LEVEL + preLevel) > 0)
            {
                isSelect = true;
            }
        }

        if (isSelect)
        {
            image.overrideSprite = levelBG;
            transform.Find("Text").gameObject.SetActive(true);
        }
        int startCount = PlayerPrefs.GetInt(LEVEL + gameObject.name);
        for (int i =0; i < startCount; i++)
        {
            starts[i].SetActive(true);
        }
    }

    public void Select()
    {
        if (isSelect)
        {
            //设置当前关卡名，用于关卡结束时存储数据时的key值
            PlayerPrefs.SetString(NOW_LEVEL, LEVEL + gameObject.name);
            SceneManager.LoadScene(2);
        }
    }

    public void Return()
    {
        Map.SetActive(true);
        Panel.SetActive(false);
    }

}
