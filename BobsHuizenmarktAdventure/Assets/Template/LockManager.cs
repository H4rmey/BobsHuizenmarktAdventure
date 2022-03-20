using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockManager : MonoBehaviour {

    GameManager gameManager;

    public List<LockBehaviour> locks;
    public bool useAutocomplete = false;

    private int count = 0;

    public UnityEvent e_endGame;

    void Start() {
        gameManager = FindObjectOfType<GameManager>();

        if (useAutocomplete) {
            locks.Clear();
            GameObject[] go = GameObject.FindGameObjectsWithTag("Lock");
            
            for (int i = 0; i < go.Length; i++) {
                locks.Add(go[i].GetComponent<LockBehaviour>());
            }
        }
    }

    void Update() {
        for (int i = 0; i < locks.Count; i++) {
            LockBehaviour lockB = locks[i];

            if (lockB.hasBeenTriggered) {
                locks.RemoveAt(i);
                Destroy(lockB.gameObject); 
            }
        }

        Debug.Log(locks.Count);
        if (locks.Count <= 0) {
            e_endGame.Invoke();
            gameManager.goToNextGame();
        }
    }
}
