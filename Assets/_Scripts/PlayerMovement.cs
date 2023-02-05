using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private Rigidbody rb;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ);
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
            rb.velocity = transform.forward *  moveSpeed;
            animator.SetBool("Moving", true);
        }
        else
        {
            //rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
            animator.SetBool("Moving", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Attack");
        }
        Debug.Log(rb.velocity);
    }
}
