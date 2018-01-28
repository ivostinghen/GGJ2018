using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Character : MonoBehaviour
{
    Animator anim;
    public Attack attack;
    Rigidbody rb;
    public float jumpForce,horSpeed;
    int isJumping = 0;
    bool isDead = false;
    public  void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }


    public void LateUpdate()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
      
    }
    public void Update(){
        if (isDead) return;
        Move();
        CheckAttack();
    }
    public void CheckAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            attack.Shoot();
        }
        ///TODO: PUNCH
    }
    void Flip(string side)
    {
        if(side == "left")
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Move()
    {
        float hor = Input.GetAxis("Horizontal") * horSpeed;
        if (hor < 0)
        {
            Flip("right");
        }
        else if (hor > 0)
        {
            Flip("left");
        }
        
        rb.velocity = new Vector3(hor, rb.velocity.y,0);


        if (Input.GetButtonDown("Jump") && isJumping < 2) 
        {
            anim.SetTrigger("jump");
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
        else if (col.gameObject.layer == 11 || col.gameObject.layer == 12)
        {
            StartCoroutine(Kill());

        }

    }

    IEnumerator Kill()
    {
        rb.isKinematic = false;
        isDead = true;
        anim.SetTrigger("death");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1);
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            
        }

    }
}