using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapControl : MonoBehaviour
{
    public Transform player;             // 角色的Transform组件
    public float sceneLength = 149f;     // 场景的长度
    public float destroyDistance = 140f;  // 销毁场景的距离
    public float newbuild = -8.09f;         //新建场景距离   

    public GameObject scenePrefab;
    private Transform scene1;                // 场景1的Transform组件
    private Transform scene2;                // 场景2的Transform组件
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
