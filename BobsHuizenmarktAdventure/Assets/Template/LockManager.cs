using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour {
    public List<LockBehaviour> locks;

    void Update() {
        for (int i = 0; i < locks.Count; i++) {
            LockBehaviour lockB = locks[i];

            if (lockB.hasBeenTriggered) {
                locks.Remove(lockB);
                Destroy(lockB.gameObject);
            }
        }

        if (locks.Count <= 0) {
            Debug.Log("you completed game :)");
        }
    }
}
