using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameControl : MonoBehaviour
{
    public Canvas StopMenu;
    public Canvas OverMenu;
    public static List<GameObject> coins = new List<GameObject>();    //����б�
    public static int PlayerHP;     //�������ֵ
    public static int Score;        //�Ʒְ�
    // Start is called before the first frame update
    void Start()
    {
        StopMenu.enabled = false;
        OverMenu.enabled = false;
        PlayerHP = 3;
        Score = 0;
        // ���Ӳ���б�  
        coins.Clear();
        Time.timeScale = 1; //��ʼ��Ϸ
    }

    // Update is called once per frame
    void Update()
    {
        //��ײ������Ϸ����
        if(PlayerHP == 0)
        {
            Time.timeScale = 0;
            OverMenu.enabled = true;
        }
    }
}
