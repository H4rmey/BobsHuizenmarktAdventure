using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public List<string> gameName = new List<string>();
    private List<int> ids = new List<int>();

    private int currentID = 0;

    public float sceneSwitchDelay = 2;

    [HideInInspector]
    public bool isLoading = false;
    
    void Awake() {
        DontDestroyOnLoad(this.gameObject);

        while(ids.Count < gameName.Count) { 
            int r = Random.Range(0, gameName.Count - 1);

            if (!ids.Contains(r)) {
                ids.Add(r);
            }
            r++;
            if (!ids.Contains(r)) {
                ids.Add(r);
            }
        }
    }

    public void goToNextGame() {
        Debug.Log("loading");
        if (currentID >= ids.Count) {
            SceneManager.LoadScene("main_menu");
            ids.Clear();
            currentID = 0;  
            while(ids.Count < gameName.Count) { 
                int r = Random.Range(0, gameName.Count - 1);

                if (!ids.Contains(r)) {
                    ids.Add(r);
                }
                r++;
                if (!ids.Contains(r)) {
                    ids.Add(r);
                }
            }
        }
        else {
            SceneManager.LoadScene(gameName[ids[currentID++]]);
        }
    }
}
