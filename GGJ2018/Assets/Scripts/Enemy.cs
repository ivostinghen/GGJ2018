using System.Collections;
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
    Coroutine cor;
    Animator anim;
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
        yield return new WaitForSeconds(.4F);
        attack.Shoot();
        cor = null;
    }

    void LateUpdate()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, character.position);

        if (dist < 10)
        {
            if (cor == null) cor = StartCoroutine(ShootDelayed());
            side = Mathf.Sign(character.position.x - this.transform.position.x);
            Flip();


            //transform.LookAt(character.transform);
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
        print("change");
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

    void Flip()
    {

        Vector3 tempSide = new Vector3(side, 1, 1);
        transform.localScale = tempSide;

    }
}
