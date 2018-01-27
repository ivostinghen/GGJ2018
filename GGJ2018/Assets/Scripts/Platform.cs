using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    Coroutine cor;
    private void OnCollisionEnter(Collision collision)
    {

        if (cor == null) cor = StartCoroutine(Destroy());


    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);

    }


}
