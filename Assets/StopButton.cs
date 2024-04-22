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

        // ��Ӱ�ť����¼�����
        button.onClick.AddListener(Stop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Stop()
    {
        Time.timeScale = 0; //��ͣ��Ϸ
        StopMenu.enabled = true;
    }
}
