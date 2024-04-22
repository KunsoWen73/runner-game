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
        // ��ȡ��ť���
        button = GetComponent<Button>();

        // ��Ӱ�ť����¼�����
        button.onClick.AddListener(LoadTargetScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadTargetScene()
    {
        // ʹ�ó�������������Ŀ�곡��
        SceneManager.LoadScene(targetSceneName);
    }
}
