using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public void ShowStart()
    {
        print("播放星星动画 >>>");
        GameManager._Instance.ShowStart();
    }
}
