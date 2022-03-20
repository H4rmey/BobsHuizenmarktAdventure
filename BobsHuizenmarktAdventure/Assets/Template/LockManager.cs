using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockManager : MonoBehaviour {

    GameManager gameManager;
    public timer_progress tp;

    public List<LockBehaviour> locks;
    public bool useAutocomplete = false;

    private int count = 0;

    public UnityEvent e_endGame;

    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        tp = FindObjectOfType<timer_progress>();

        if (useAutocomplete) {
            locks.Clear();
            GameObject[] go = GameObject.FindGameObjectsWithTag("Lock");
            
            for (int i = 0; i < go.Length; i++) {
                locks.Add(go[i].GetComponent<LockBehaviour>());
            }
        }

        gameManager.isLoading = false;
    }

    void Update() {
        tp.microgame_start = true;
        for (int i = 0; i < locks.Count; i++) {
            LockBehaviour lockB = locks[i];

            if (lockB.hasBeenTriggered) {
                locks.RemoveAt(i);
                Destroy(lockB.gameObject); 
            }
        }

        if (tp.microgame_fail && !gameManager.isLoading) {
            Debug.Log("fail");
            gameManager.isLoading = true;
            e_endGame.Invoke();
            gameManager.Invoke("goToNextGame", gameManager.sceneSwitchDelay);
        }
        else if (locks.Count <= 0 && !gameManager.isLoading) {
            Debug.Log("succes");
            tp.microgame_succes = true;
            gameManager.isLoading = true;
            e_endGame.Invoke();
            gameManager.Invoke("goToNextGame", gameManager.sceneSwitchDelay);
        }
    }
}
