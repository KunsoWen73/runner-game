using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StopButton : MonoBehaviour
{
    public Canvas StopMenu;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        // 添加按钮点击事件监听
        button.onClick.AddListener(Stop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Stop()
    {
        Time.timeScale = 0; //暂停游戏
        StopMenu.enabled = true;
    }
}
