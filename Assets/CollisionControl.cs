using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    public Renderer[] playerRenderers;    // ģ����Ⱦ������
    public float invincibleTime = 2f;   //��ɫ�޵�ʱ��
    private bool isInvincible = false;  //��ɫ�޵�״̬

    public AudioSource CoinSound; //�����
    public AudioSource ObstacleSound; //��ײ��
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

            // ��GameManager�ű��Ľ���б����Ƴ����
            GameControl.coins.Remove(other.gameObject);

            // ���ٽ�Ҷ���
            Destroy(other.gameObject);

            
            //��������
            GameControl.Score += 1;
        }

        else if(other.CompareTag("Obstacle") && !isInvincible)
        {
            //�������ֵ����
            GameControl.PlayerHP -= 1;
            //�����޵�
            StartCoroutine(InvincibleCoroutine());
            ObstacleSound.Play();
        }
    }

    private System.Collections.IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;

        // ��ɫ��˸Ч��
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

        // ������˸����ɫ�ָ��ɼ�
        foreach (Renderer renderer in playerRenderers)
        {
            renderer.enabled = true;
        }
        isInvincible = false;
    }
}
