using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public float fireSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * fireSpeed * Time.deltaTime;
	}

    void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);

    }
}
