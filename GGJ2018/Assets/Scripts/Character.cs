using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    public float jumpForce,horSpeed;
    int isJumping = 0;
    public  void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update(){

        Move();
    }

    public void Move()
    {
        float hor = Input.GetAxis("Horizontal") * horSpeed;
        
        
        rb.velocity = new Vector3(hor, rb.velocity.y,0);


        if (Input.GetButtonDown("Jump") && isJumping < 2) 
        {
            isJumping ++;
            Vector3 tempVel = rb.velocity;
            tempVel.y = 0;
            rb.velocity = tempVel;
            rb.AddForce(0,jumpForce,0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            isJumping = 0;
        }

    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            
        }

    }
}