using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public float moveSpeed;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;
    public Animator animator;
    private float airtime;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //moveDirection
        float yStore = moveDirection.y;
        moveDirection = (Input.GetAxis("Vertical") * Time.deltaTime * transform.forward) + (Input.GetAxis("Horizontal") * Time.deltaTime * transform.right);
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //Animations
        if (moveDirection.z != 0 || moveDirection.x != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        if (controller.isGrounded)
        {
            airtime = 0;
            moveDirection.y = 0;
            animator.SetBool("fall", false);
        }
        else
        {
            airtime += 100*Time.deltaTime;
            if (airtime >= 85)
            {
                animator.SetBool("fall", true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }
}