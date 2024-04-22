using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BTSButton : MonoBehaviour
{
    public string targetSceneName = "StartMenu";
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        // 添加按钮点击事件监听
        button.onClick.AddListener(BackToStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void BackToStart()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
