using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    public int startNum = 0;
    public GameObject Locks;
    public GameObject Open;
    public bool isSelect;

    public GameObject Map;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        int start = PlayerPrefs.GetInt(GameManager.TOTAL, 0);
        if (start >= startNum)
        {
            isSelect = true;
        }

        if (isSelect)
        {
            Locks.SetActive(false);
            Open.SetActive(true);
        }
    }

    //点击选择Map
    public void Select()
    {
        if (isSelect)
        {
            Map.SetActive(false);
            Panel.SetActive(true);
        }
    }


}
