using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject firePrefab;
    public Transform fireSpawner;

    public void Shoot()
    {
        Instantiate(firePrefab, fireSpawner.position, fireSpawner.rotation);
    }

}
