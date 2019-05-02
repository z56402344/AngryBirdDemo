using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//加载对应场景的对应关卡地图
public class LoadLevel : MonoBehaviour
{
    public void Awake()
    {
        Instantiate(Resources.Load(PlayerPrefs.GetString(LevelSelect.NOW_LEVEL)));
    }
}
