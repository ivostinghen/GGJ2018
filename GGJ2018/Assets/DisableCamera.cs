using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCamera : MonoBehaviour {

    private void OnTriggerEnter(Collider col)
    {
        Camera.main.transform.parent.GetComponent<CameraBehavior>().enabled = false;
    }

    private void OnTriggerExit(Collider col)
    {
        Camera.main.transform.parent.GetComponent<CameraBehavior>().enabled = true;
    }
}
