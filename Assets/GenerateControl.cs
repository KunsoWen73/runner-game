using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateControl : MonoBehaviour
{
    //公共部分
    public Transform player; // 玩家的 Transform 组件
    public float triggerDistance = -50f; // 生成触发距离
    public float destroyDistance = 5f; //销毁距离
    private float[] spawnPositionsX = { -2.5f, 0f, 2.5f }; //固定x坐标

    //障碍物部分
    public GameObject obstaclePrefab; // 障碍物预制体
    public int obstacleCount = 12; // 障碍物数量
    private float lastGeneratedZ = 0f; // 上一个生成的障碍物的 Z 坐标
    private List<GameObject> obstacles = new List<GameObject>();    //障碍物列表
    public float minZInterval = 10f; // 最小的 Z 轴间隔值

    //金币部分
    public GameObject cornPrefab;   //金币预制体
    public int cornCount = 15;      //金币数量
    private float lastZ = 0f; // 上一个生成的金币的 Z 坐标
    public float minZ = 2f; // 最小的 Z 轴间隔值
    // Start is called before the first frame update
    void Start()
    {
        if(player.position.z == -8.09f)
        {
            SpawnObstacles();
            SpawnCorn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 角色超过销毁触发距离后销毁障碍物
        if (obstacles.Count > 0 && player.position.z - obstacles[0].transform.position.z > destroyDistance)
        {
            Destroy(obstacles[0]);
            obstacles.RemoveAt(0);
        }

        // 当角色距离上一个生成位置超过触发距离时生成障碍物
        if (player.position.z - lastGeneratedZ > triggerDistance - 20f)
        {
            SpawnObstacles();
        }

        // 角色超过销毁触发距离后销毁金币
        if (GameControl.coins.Count > 0 && player.position.z - GameControl.coins[0].transform.position.z > destroyDistance)
        {
            Destroy(GameControl.coins[0]);
            GameControl.coins.RemoveAt(0);
        }

        // 当角色距离上一个生成位置超过触发距离时生成金币
        if (player.position.z - lastZ > triggerDistance)
        {
            SpawnCorn();
        }
    }

    void SpawnObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            // 随机选择一个固定的 X 轴位置
            float spawnPosX = spawnPositionsX[Random.Range(0, spawnPositionsX.Length)];
            float spawnPosZ = Random.Range(minZInterval, minZInterval + 4f);

            // 在 Z 轴上按照间隔值生成障碍物的位置
            Vector3 spawnPos = new Vector3(spawnPosX, 0f, lastGeneratedZ + spawnPosZ);

            // 实例化障碍物
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.Euler(0f, 90f, 0f));
            obstacles.Add(obstacle); // 将障碍物添加到列表中

            lastGeneratedZ += spawnPosZ; // 更新上一个生成的障碍物的 Z 坐标
        }
    }

    void SpawnCorn()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            // 随机选择一个固定的 X 轴位置
            float spawnPosX = spawnPositionsX[Random.Range(0, spawnPositionsX.Length)];
            float spawnPosZ = Random.Range(minZ, minZ + 1f);

            // 在 Z 轴上按照间隔值生成金币的位置
            Vector3 spawnPos = new Vector3(spawnPosX, 0.5f, lastZ + spawnPosZ);
            lastZ += spawnPosZ;
            for (int j = 1;j <= 5;j++)
            {
                if(IsOverlapping(spawnPos))
                {
                    spawnPos.y = 1.5f;
                    GameObject newcoin = Instantiate(cornPrefab, spawnPos, Quaternion.identity);
                    GameControl.coins.Add(newcoin); // 将金币添加到列表中
                    lastZ += 1f; // 更新上一个生成的金币的 Z 坐标
                    spawnPos += new Vector3(0f, 0f, 1f);
                }
                else if(!IsOverlapping(spawnPos))
                {
                    if(spawnPos.y == 1.5f)
                    {
                        spawnPos.y = 0.5f;
                    }
                    GameObject newcoin = Instantiate(cornPrefab, spawnPos, Quaternion.identity);
                    GameControl.coins.Add(newcoin); // 将金币添加到列表中
                    lastZ += 1f; // 更新上一个生成的金币的 Z 坐标
                    spawnPos += new Vector3(0f, 0f, 1f);
                }
            }
        }
    }

    // 检查金币生成位置是否与现有障碍物重叠
    bool IsOverlapping(Vector3 position)
    {
        foreach (GameObject obstacle in obstacles)
        {
            if (Mathf.Abs(obstacle.transform.position.x - position.x) == 0f &&
                Mathf.Abs(obstacle.transform.position.z - position.z) < 2f)
            {
                return true;
            }
        }
        return false;
    }
}
