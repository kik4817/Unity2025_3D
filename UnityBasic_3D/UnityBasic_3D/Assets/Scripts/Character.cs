using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    Animator animator;
    float speed;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //if(Keyboard.current.tKey.wasPressedThisFrame)
        //{
           
        //}

        if (Input.GetKey(KeyCode.T))
        {
            speed += Time.deltaTime;
            animator.SetFloat("speed", speed);
        }
        else if (Input.GetKey(KeyCode.T))
        {
            speed =0;
        }
    }
}
