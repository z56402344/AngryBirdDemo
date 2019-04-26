using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausepanel : MonoBehaviour
{
    private Animator animator;
    public GameObject mPuaseButton;
    public int mType = 0;//0=继续，1=重新开始

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Pause()
    {
        //1.播放动画
        animator.SetBool("isPause",true);
        //2.隐藏按钮
        mPuaseButton.SetActive(false);
    }

    public void Resum()
    {
        mType = 0;
        Time.timeScale = 1;
        animator.SetBool("isPause", false);

    }

    public void Retry()
    {
        mType = 1;
        Time.timeScale = 1;
        animator.SetBool("isPause", false);


    }

    public void Home()
    {

    }

    public void PauseAnimEnd()
    {
        Time.timeScale = 0;
    }

    public void ResumAnimEnd()
    {
        print("ResumAnimEnd >>> ");
        mPuaseButton.SetActive(true);
        if (mType == 1)
        {
            SceneManager.LoadScene(2);
        }
       
    }

}
