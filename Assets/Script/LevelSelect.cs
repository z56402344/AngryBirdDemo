using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public bool isSelect = false;
    public Sprite levelBG;
    private Image image;


    public GameObject Map;
    public GameObject Panel;

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
        if (isSelect)
        {
            image.overrideSprite = levelBG;
            transform.Find("Text").gameObject.SetActive(true);
        }
    }

    public void Select()
    {
        if (isSelect)
        {
            PlayerPrefs.SetString("nowLevel", "level" + gameObject.name);
            SceneManager.LoadScene(2);
        }
    }

    public void Return()
    {
        Map.SetActive(true);
        Panel.SetActive(false);
    }

}
