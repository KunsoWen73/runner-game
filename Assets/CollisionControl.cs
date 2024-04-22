using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    public Renderer[] playerRenderers;    // 模型渲染器数组
    public float invincibleTime = 2f;   //角色无敌时间
    private bool isInvincible = false;  //角色无敌状态

    public AudioSource CoinSound; //金币声
    public AudioSource ObstacleSound; //碰撞声
    // Start is called before the first frame update
    void Start()
    {
        playerRenderers = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CoinSound.Play();

            // 从GameManager脚本的金币列表中移除金币
            GameControl.coins.Remove(other.gameObject);

            // 销毁金币对象
            Destroy(other.gameObject);

            
            //分数增加
            GameControl.Score += 1;
        }

        else if(other.CompareTag("Obstacle") && !isInvincible)
        {
            //玩家生命值减少
            GameControl.PlayerHP -= 1;
            //启动无敌
            StartCoroutine(InvincibleCoroutine());
            ObstacleSound.Play();
        }
    }

    private System.Collections.IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;

        // 角色闪烁效果
        float blinkInterval = 0.2f;
        float elapsedTime = 0f;
        while (elapsedTime < invincibleTime)
        {
            foreach (Renderer renderer in playerRenderers)
            {
                renderer.enabled = !renderer.enabled;
            }
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        // 结束闪烁，角色恢复可见
        foreach (Renderer renderer in playerRenderers)
        {
            renderer.enabled = true;
        }
        isInvincible = false;
    }
}
