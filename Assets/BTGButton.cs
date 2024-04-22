using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BTGButton : MonoBehaviour
{
    public Canvas StopMenu;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        // 添加按钮点击事件监听
        button.onClick.AddListener(BackToGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BackToGame()
    {
        StopMenu.enabled = false;
        Time.timeScale = 1; //开始游戏
    }
}
