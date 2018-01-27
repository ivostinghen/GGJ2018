using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    Transform target=null;
    public float speed;
    Vector3 pos;
    public float posY;
    
	void Awake () {
        pos = transform.position;
        enabled = false;
        target = GameObject.Find("Target").transform;
        if (target != null) enabled = true;
    }

	void LateUpdate () {
        pos.x = target.position.x;
        //pos.y = posY;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed);
    }   
}
