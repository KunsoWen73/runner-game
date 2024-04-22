using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreView : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetComponent<TextMeshProUGUI>();
        string gt = "PLAYER HP:" + GameControl.PlayerHP.ToString() + "\n" + "SCORE:" + GameControl.Score.ToString();
        text.text = gt;
    }

    // Update is called once per frame
    void Update()
    {
        string gt = "PLAYER HP:" + GameControl.PlayerHP.ToString() + "\n" + "SCORE:" + GameControl.Score.ToString();
        text.text = gt;
    }
}
