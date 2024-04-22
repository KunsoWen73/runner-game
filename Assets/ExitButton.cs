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
        // ��ȡ��ť���
        button = GetComponent<Button>();

        // ��Ӱ�ť����¼�����
        button.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Exit()
    {
        //�˳��༭������
        UnityEditor.EditorApplication.isPlaying = false;
        //�˳�����
        Application.Quit();
    }
}
