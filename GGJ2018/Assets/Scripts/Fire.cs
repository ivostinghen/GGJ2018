using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * 50 * Time.deltaTime;
	}

    void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);

    }
}
