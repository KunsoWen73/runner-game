using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateControl : MonoBehaviour
{
    //��������
    public Transform player; // ��ҵ� Transform ���
    public float triggerDistance = -50f; // ���ɴ�������
    public float destroyDistance = 5f; //���پ���
    private float[] spawnPositionsX = { -2.5f, 0f, 2.5f }; //�̶�x����

    //�ϰ��ﲿ��
    public GameObject obstaclePrefab; // �ϰ���Ԥ����
    public int obstacleCount = 12; // �ϰ�������
    private float lastGeneratedZ = 0f; // ��һ�����ɵ��ϰ���� Z ����
    private List<GameObject> obstacles = new List<GameObject>();    //�ϰ����б�
    public float minZInterval = 10f; // ��С�� Z ����ֵ

    //��Ҳ���
    public GameObject cornPrefab;   //���Ԥ����
    public int cornCount = 15;      //�������
    private float lastZ = 0f; // ��һ�����ɵĽ�ҵ� Z ����
    public float minZ = 2f; // ��С�� Z ����ֵ
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
        // ��ɫ�������ٴ�������������ϰ���
        if (obstacles.Count > 0 && player.position.z - obstacles[0].transform.position.z > destroyDistance)
        {
            Destroy(obstacles[0]);
            obstacles.RemoveAt(0);
        }

        // ����ɫ������һ������λ�ó�����������ʱ�����ϰ���
        if (player.position.z - lastGeneratedZ > triggerDistance - 20f)
        {
            SpawnObstacles();
        }

        // ��ɫ�������ٴ�����������ٽ��
        if (GameControl.coins.Count > 0 && player.position.z - GameControl.coins[0].transform.position.z > destroyDistance)
        {
            Destroy(GameControl.coins[0]);
            GameControl.coins.RemoveAt(0);
        }

        // ����ɫ������һ������λ�ó�����������ʱ���ɽ��
        if (player.position.z - lastZ > triggerDistance)
        {
            SpawnCorn();
        }
    }

    void SpawnObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            // ���ѡ��һ���̶��� X ��λ��
            float spawnPosX = spawnPositionsX[Random.Range(0, spawnPositionsX.Length)];
            float spawnPosZ = Random.Range(minZInterval, minZInterval + 4f);

            // �� Z ���ϰ��ռ��ֵ�����ϰ����λ��
            Vector3 spawnPos = new Vector3(spawnPosX, 0f, lastGeneratedZ + spawnPosZ);

            // ʵ�����ϰ���
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.Euler(0f, 90f, 0f));
            obstacles.Add(obstacle); // ���ϰ�����ӵ��б���

            lastGeneratedZ += spawnPosZ; // ������һ�����ɵ��ϰ���� Z ����
        }
    }

    void SpawnCorn()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            // ���ѡ��һ���̶��� X ��λ��
            float spawnPosX = spawnPositionsX[Random.Range(0, spawnPositionsX.Length)];
            float spawnPosZ = Random.Range(minZ, minZ + 1f);

            // �� Z ���ϰ��ռ��ֵ���ɽ�ҵ�λ��
            Vector3 spawnPos = new Vector3(spawnPosX, 0.5f, lastZ + spawnPosZ);
            lastZ += spawnPosZ;
            for (int j = 1;j <= 5;j++)
            {
                if(IsOverlapping(spawnPos))
                {
                    spawnPos.y = 1.5f;
                    GameObject newcoin = Instantiate(cornPrefab, spawnPos, Quaternion.identity);
                    GameControl.coins.Add(newcoin); // �������ӵ��б���
                    lastZ += 1f; // ������һ�����ɵĽ�ҵ� Z ����
                    spawnPos += new Vector3(0f, 0f, 1f);
                }
                else if(!IsOverlapping(spawnPos))
                {
                    if(spawnPos.y == 1.5f)
                    {
                        spawnPos.y = 0.5f;
                    }
                    GameObject newcoin = Instantiate(cornPrefab, spawnPos, Quaternion.identity);
                    GameControl.coins.Add(newcoin); // �������ӵ��б���
                    lastZ += 1f; // ������һ�����ɵĽ�ҵ� Z ����
                    spawnPos += new Vector3(0f, 0f, 1f);
                }
            }
        }
    }

    // ���������λ���Ƿ��������ϰ����ص�
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
