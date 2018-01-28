using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCamera : MonoBehaviour {

    public Vector3 camPos;
    private void OnTriggerEnter(Collider col)
    {

        Camera.main.transform.parent.GetComponent<CameraBehavior>().inTransition = true;
        Camera.main.transform.parent.GetComponent<CameraBehavior>().pos = camPos;
    }

    private void OnTriggerExit(Collider col)
    {
        Camera.main.transform.parent.GetComponent<CameraBehavior>().inTransition = false;
        Camera.main.transform.parent.GetComponent<CameraBehavior>().pos = camPos;
    }
}
