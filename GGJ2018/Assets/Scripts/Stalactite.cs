using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour {

    Coroutine cor;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 10)
        {
            
            if(cor==null)cor= StartCoroutine(Destroy());
        }
    }
    IEnumerator Destroy()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(1F);
        Destroy(this.gameObject);
    }
}
