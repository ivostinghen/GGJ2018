using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    Transform target=null;
    public float speed;
    public Vector3 pos;
    public float posY;
    public bool inTransition;
	void Awake () {
        pos = transform.position;
        enabled = false;
        target = GameObject.Find("Target").transform;
        if (target != null) enabled = true;
    }

	void LateUpdate () {
        if (inTransition == false)
        {
            pos.x = target.position.x;
        }
        
        //pos.y = posY;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed);
    }   
}
