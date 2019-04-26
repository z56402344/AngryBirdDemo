using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    private Button mButton;
    public GameObject mMenuBg;
    public GameObject mMenu;

    public void Awake()
    {
        mButton = GetComponent<Button>();
        mButton.onClick.AddListener(delegate () { ClickButon(); });
    }

   
    // Update is called once per frame
    void Update()
    {

    }


    private void ClickButon()
    {
        mMenuBg.SetActive(false);
        //mMenu.SetActive(true);
        print("点击事件 >>>");
    }

}
