﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    bool isChanging = false;
    float side = 1;
    public float horSpeed;
    public float jumpForce;
    Attack attack;
    Transform character;
    Coroutine cor,corDeath;
    Animator anim;
    bool dead = false;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        character = GameObject.Find("Character").transform;
        attack = GetComponent<Attack>();
    }

    IEnumerator ShootDelayed()
    {
        yield return new WaitForSeconds(Random.Range(.6F, 1.2F));
        if (Random.Range(0, 3) != 2)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpForce, 0); ;
        }
        
        yield return new WaitForSeconds(.2F);
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(.2F);
        attack.Shoot();
        cor = null;
    }

    void LateUpdate()
    {
        if (dead == true) return;
        float dist = Vector3.Distance(this.gameObject.transform.position, character.position);

        if (dist < 10)
        {
            if (cor == null) cor = StartCoroutine(ShootDelayed());
            side = Mathf.Sign(character.position.x - this.transform.position.x);
            Flip();
        }
        else if (cor == null)
        {
            Flip();
            transform.Translate(Vector3.right * side * Time.deltaTime * horSpeed);
        }

    }


    public IEnumerator ChangePath()
    {
        isChanging = true;
        side = side * -1;

        Flip();
        yield return new WaitForSeconds(1);
        isChanging = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 9)
        {
            if (isChanging == false) StartCoroutine(ChangePath());
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == 13)
        {

            if(corDeath==null) corDeath = StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        dead = true;
        if(cor!=null)StopCoroutine(cor);

        anim.SetTrigger("death");
        yield return new WaitForSeconds(.8F);
        //GetComponent<Rigidbody>().isKinematic = true;
        gameObject.layer =14;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }


    void Flip()
    {

        Vector3 tempSide = new Vector3(side, 1, 1);
        transform.localScale = tempSide;

    }
}
