using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBehaviour : MonoBehaviour {

    public KeyLockID klid;

    [HideInInspector]
    public bool hasBeenTriggered = false;
    private KeyBehaviour keyBehaviour;

    public float maxTime = 0;
    private float timer = 0;
    private bool timerActive = false;

    void Update()
    {
        Debug.Log(timer);

        if (timer > maxTime) {
            timer = 0;
            timerActive = false;
            keyBehaviour.uses--;
            hasBeenTriggered = true;
        }

        if (timerActive) {
            timer += Time.deltaTime;
        }

        if (keyBehaviour.uses <= 0) {
            Destroy(gameObject);
        }
    }

    public void startTimer() {
        timerActive = true;
        timer = 0;
    }

    public void stopTimer() {
        timerActive = false;
        timer = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Key") {
            return;
        }

        keyBehaviour = other.GetComponent<KeyBehaviour>();

        if (keyBehaviour.klid != klid) {
            return;
        }

        startTimer();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Key") {
            return;
        }

        keyBehaviour = other.GetComponent<KeyBehaviour>();

        if (keyBehaviour.klid != klid) {
            return;
        }

        stopTimer();
    }
}