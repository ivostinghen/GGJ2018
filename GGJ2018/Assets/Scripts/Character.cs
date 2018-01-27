using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    public float jumpForce,horSpeed;
    bool isJumping = false;
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

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0,jumpForce,0);
        }
    }

    void OnCollisionEnter(Collision col)
    {

        
    }
}