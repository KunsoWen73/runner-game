using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        // 获取按钮组件
        button = GetComponent<Button>();

        // 添加按钮点击事件监听
        button.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Exit()
    {
        //退出编辑器运行
        UnityEditor.EditorApplication.isPlaying = false;
        //退出程序
        Application.Quit();
    }
}
