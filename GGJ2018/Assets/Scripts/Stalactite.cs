using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour {

    Coroutine cor;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 10)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        if(transform.GetChild(0).GetComponent<MeshRenderer>()) transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        if (transform)
        {
            if (transform) {
                if (transform.GetChild(1))
                {
                    if (transform.GetChild(1).gameObject)
                    {
                        transform.GetChild(1).gameObject.SetActive(true);
                    }
                }
                      
            }


        }
        yield return new WaitForSeconds(.3F);
        Destroy(this.gameObject);
    }
}
