using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapControl : MonoBehaviour
{
    public Transform player;             // ��ɫ��Transform���
    public float sceneLength = 149f;     // �����ĳ���
    public float destroyDistance = 140f;  // ���ٳ����ľ���
    public float newbuild = -8.09f;         //�½���������   

    public GameObject scenePrefab;
    private Transform scene1;                // ����1��Transform���
    private Transform scene2;                // ����2��Transform���
    // Start is called before the first frame update
    void Start()
    {
        scene1 = scenePrefab.transform;
        scene2 = scenePrefab.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z - scene2.position.z >= destroyDistance)
        {
            Destroy(scene2.gameObject);
        }
        if (player.position.z - scene1.position.z >= newbuild)
        {
            GameObject newScene = Instantiate(scenePrefab, transform.position + new Vector3(0f, 0f, 149f), Quaternion.identity);
            scene2 = scene1;
            scene1 = newScene.transform;
        }
    }


}
