using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{
    public string targetSceneName = "Game";
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        // 获取按钮组件
        button = GetComponent<Button>();

        // 添加按钮点击事件监听
        button.onClick.AddListener(LoadTargetScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadTargetScene()
    {
        // 使用场景管理器加载目标场景
        SceneManager.LoadScene(targetSceneName);
    }
}
