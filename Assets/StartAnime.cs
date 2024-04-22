using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StartAnime : MonoBehaviour
{
    public Animator m_Animator;
    private Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("Move", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
