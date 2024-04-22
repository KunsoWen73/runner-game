using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameControl : MonoBehaviour
{
    public Canvas StopMenu;
    public Canvas OverMenu;
    public static List<GameObject> coins = new List<GameObject>();    //金币列表
    public static int PlayerHP;     //玩家生命值
    public static int Score;        //计分板
    // Start is called before the first frame update
    void Start()
    {
        StopMenu.enabled = false;
        OverMenu.enabled = false;
        PlayerHP = 3;
        Score = 0;
        // 清空硬币列表  
        coins.Clear();
        Time.timeScale = 1; //开始游戏
    }

    // Update is called once per frame
    void Update()
    {
        //碰撞三次游戏结束
        if(PlayerHP == 0)
        {
            Time.timeScale = 0;
            OverMenu.enabled = true;
        }
    }
}
