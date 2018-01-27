using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public float fireSpeed;
    // Use this for initialization
    void Start()
    {
        transform.LookAt(GameObject.Find("EnemyTarget").transform) ;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * fireSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);

    }
}
