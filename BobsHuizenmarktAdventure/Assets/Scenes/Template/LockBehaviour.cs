using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionWithkey : MonoBehaviour {

    public KeyLockID klid;

    [HideInInspector]
    public bool hasBeenTriggered = false;
    private KeyBehaviour keyBehaviour;


    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Key") {
            return;
        }

        keyBehaviour = other.GetComponent<KeyBehaviour>();

        if (keyBehaviour.klid != klid) {
            return;
        }

        hasBeenTriggered = true;
        keyBehaviour.uses--;
    }
}