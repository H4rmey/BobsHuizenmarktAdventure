using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour {

    public List<LockBehaviour> locks;
    public bool useAutocomplete = false;

    void Start() {
        if (useAutocomplete) {
            locks.Clear();
            GameObject[] go = GameObject.FindGameObjectsWithTag("Lock");
            
            for (int i = 0; i < go.Length; i++) {
                locks.Add(go[i].GetComponent<LockBehaviour>());
            }
        }
    }

    void Update() {
        if (locks.Count > 0) {
            for (int i = 0; i < locks.Count; i++) {
                LockBehaviour lockB = locks[i];

                if (lockB.hasBeenTriggered) {
                    locks.Remove(lockB);
                    Destroy(lockB.gameObject);
                }
            }
        }

        if (locks.Count <= 0) {
            Debug.Log("you completed game :)");
        }
    }
}
